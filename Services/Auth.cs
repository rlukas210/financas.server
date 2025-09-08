using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using financas.server.Data;
using financas.server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace financas.server.Services
{
    public class Auth : IAuthService
    {
        private readonly AppDbContext _appdbcontext;
        private readonly IConfiguration _configuration;

        public Auth(AppDbContext appdbcontext, IConfiguration configuration)
        {
            _appdbcontext = appdbcontext;
            _configuration = configuration;
        }

        public async Task<string?> AuthenticateAsync(string email, string senha)
        {
            var usuario = await _appdbcontext.Usuarios
            .SingleOrDefaultAsync(u => u.EmailUsuario == email && u.SenhaUsuario == senha && u.Status == Models.StatusUsuario.Ativo);
            if (usuario == null) return null;

            return GenerateJwtToken(usuario);
        }

        public async Task<bool> RegisterAsync(string nome, string email, string senha)
        {
            if (await _appdbcontext.Usuarios.AnyAsync(u => u.EmailUsuario == email))
                return false;

            var novoUsuario = new Usuarios
            {
                IdUsuario = Guid.NewGuid(),
                NomeUsuario = nome,
                EmailUsuario = email,
                SenhaUsuario = senha,
                Status = StatusUsuario.Ativo
            };

            _appdbcontext.Usuarios.Add(novoUsuario);
            await _appdbcontext.SaveChangesAsync();
            return true;
        }

        private string GenerateJwtToken(Usuarios usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, usuario.NomeUsuario)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}