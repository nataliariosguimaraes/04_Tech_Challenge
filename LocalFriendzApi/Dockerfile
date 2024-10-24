# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5005
EXPOSE 5006

# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiando arquivos .csproj
COPY ["src/LocalFriendzApi/LocalFriendzApi.csproj", "src/LocalFriendzApi/"]
COPY ["src/LocalFriendzApi.Core/LocalFriendzApi.Core.csproj", "src/LocalFriendzApi.Core/"]
COPY ["src/LocalFriendzApi.Application/LocalFriendzApi.Application.csproj", "src/LocalFriendzApi.Application/"]
COPY ["src/LocalFriendzApi.Infrastructure/LocalFriendzApi.Infrastructure.csproj", "src/LocalFriendzApi.Infrastructure/"]
COPY ["src/LocalFriendzApi.Test/LocalFriendzApi.IntegrationTests.csproj", "src/LocalFriendzApi.Test/"]

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Restauração de dependências
RUN dotnet restore src/LocalFriendzApi/LocalFriendzApi.csproj

# Copiando todos os arquivos de c?digo-fonte e outras pastas necess?rias
COPY imgs /src/imgs
COPY scripts /src/scripts


# Copiando todos os arquivos de código-fonte
COPY . .

# Construindo a aplicação
WORKDIR "/src/src/LocalFriendzApi"
RUN dotnet build "LocalFriendzApi.csproj" -c Release -o /app/build

# Etapa de build dos testes
WORKDIR "/src/src/LocalFriendzApi.Test"
RUN dotnet build "LocalFriendzApi.IntegrationTests.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
WORKDIR "/src/src/LocalFriendzApi"
RUN dotnet publish "LocalFriendzApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final para a aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Definindo as variáveis de ambiente para o PostgreSQL
ENTRYPOINT ["dotnet", "LocalFriendzApi.dll"]
