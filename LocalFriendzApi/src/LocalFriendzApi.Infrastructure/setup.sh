#!/bin/bash

# Definir as variáveis necessárias
PROJECT_DIR=$(dirname "$0")
PROJECT_FILE="$PROJECT_DIR/../LocalFriendzApi/LocalFriendzApi.csproj"
STARTUP_PROJECT="$PROJECT_FILE"
MIGRATION_PROJECT="$PROJECT_DIR/../LocalFriendzApi.Infrastructure/LocalFriendzApi.Infrastructure.csproj"
DB_NAME="DB_FIAP_ARQUITETO"
MIGRATION_NAME="InitialCreate"

# Função para exibir mensagens
function info {
    echo -e "\033[1;34m[INFO]\033[0m $1"
}

# Função para exibir erros
function error {
    echo -e "\033[1;31m[ERROR]\033[0m $1"
}

# Verificar se o .NET SDK está instalado
if ! command -v dotnet &> /dev/null
then
    error "O .NET SDK não está instalado. Por favor, instale o .NET SDK primeiro."
    exit 1
fi

# Verificar se o arquivo .csproj existe
if [ ! -f "$PROJECT_FILE" ]; then
    error "Arquivo .csproj não encontrado. Execute este script no diretório raiz do projeto."
    exit 1
fi

# Função para verificar e apagar o banco de dados existente
function drop_database {
    info "Verificando se o banco de dados $DB_NAME existe..."
    if dotnet ef database list -p "$MIGRATION_PROJECT" -s "$STARTUP_PROJECT" | grep "$DB_NAME" > /dev/null; then
        info "Banco de dados $DB_NAME encontrado. Apagando o banco de dados..."
        dotnet ef database drop -p "$MIGRATION_PROJECT" -s "$STARTUP_PROJECT" --force
        if [ $? -ne 0 ]; then
            error "Falha ao apagar o banco de dados $DB_NAME."
            exit 1
        fi
        info "Banco de dados $DB_NAME apagado com sucesso."
    else
        info "Banco de dados $DB_NAME não encontrado. Continuando..."
    fi
}

# Chamar a função para apagar o banco de dados existente, se houver
drop_database

# Atualizar a versão da ferramenta Entity Framework
info "Atualizando a versão da ferramenta Entity Framework..."
dotnet tool update --global dotnet-ef --version 8.0.6

if [ $? -ne 0 ]; then
    error "Falha ao atualizar a ferramenta Entity Framework."
    exit 1
fi

# Restaurar dependências do projeto
info "Restaurando dependências do projeto..."
dotnet restore "$PROJECT_FILE"

if [ $? -ne 0 ]; then
    error "Falha ao restaurar dependências do projeto."
    exit 1
fi

# Remover quaisquer migrações anteriores chamadas InitialCreate
INITIAL_CREATE_EXISTS=$(dotnet ef migrations list -p "$MIGRATION_PROJECT" -s "$STARTUP_PROJECT" | grep "$MIGRATION_NAME")

if [ ! -z "$INITIAL_CREATE_EXISTS" ]; then
    info "Removendo migração anterior chamada $MIGRATION_NAME..."
    dotnet ef migrations remove -p "$MIGRATION_PROJECT" -s "$STARTUP_PROJECT" -f
fi

# Adicionar nova migração, garantindo um nome único se InitialCreate já foi usado
COUNTER=1
NEW_MIGRATION_NAME=$MIGRATION_NAME

while dotnet ef migrations list -p "$MIGRATION_PROJECT" -s "$STARTUP_PROJECT" | grep "$NEW_MIGRATION_NAME" > /dev/null
do
    NEW_MIGRATION_NAME="${MIGRATION_NAME}${COUNTER}"
    COUNTER=$((COUNTER + 1))
done

info "Adicionando nova migração: $NEW_MIGRATION_NAME..."
dotnet ef migrations add "$NEW_MIGRATION_NAME" -p "$MIGRATION_PROJECT" -s "$STARTUP_PROJECT"

if [ $? -ne 0 ]; then
    error "Falha ao criar nova migração."
    exit 1
fi

# Aplicar a migração ao banco de dados
info "Aplicando migração ao banco de dados..."
dotnet ef database update -p "$MIGRATION_PROJECT" -s "$STARTUP_PROJECT"

if [ $? -ne 0 ]; then
    error "Falha ao aplicar migrações ao banco de dados."
    exit 1
fi

info "Migrações aplicadas com sucesso ao banco de dados!"
