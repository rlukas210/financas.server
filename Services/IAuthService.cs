namespace financas.server.Services
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(string email, string senha);
        Task<bool> RegisterAsync(string nome, string email, string senha);
    }
}