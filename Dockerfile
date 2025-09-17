FROM ubuntu:24.04

# Instala dependências básicas
RUN apt-get update && \
    apt-get install -y wget apt-transport-https software-properties-common gnupg ca-certificates

# Instala o .NET 9 SDK
RUN wget https://packages.microsoft.com/config/ubuntu/24.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    rm packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y dotnet-sdk-9.0

# Instala o MariaDB Server
RUN apt-get update && \
    apt-get install -y mariadb-server

# Define variáveis de ambiente padrão do MariaDB
ENV MYSQL_ROOT_PASSWORD=root

# Expõe as portas padrão
EXPOSE 5000 5001 3306

# Comando padrão: inicia o MariaDB em background e mantém o container rodando
CMD service mariadb start && tail -f /dev/null
