-- Criar banco DB_FIAP_ARQUITETO se não existir
DO $$ 
BEGIN 
    IF NOT EXISTS (SELECT 1 FROM pg_database WHERE datname = 'DB_FIAP_ARQUITETO') THEN 
        CREATE DATABASE DB_FIAP_ARQUITETO; 
    END IF;
END $$;

-- Conectar ao banco de dados recém-criado
\connect DB_FIAP_ARQUITETO;

-- Log inicial
DO $$ BEGIN
    RAISE NOTICE 'Iniciando script de criação do banco e tabela...';
END $$;

-- Criar a tabela TB_CONTACT
CREATE TABLE IF NOT EXISTS public."TB_CONTACT" (
    id_contact UUID NOT NULL,
    "name" VARCHAR NOT NULL,
    phone VARCHAR NOT NULL,
    "DDD" VARCHAR NOT NULL,
    email VARCHAR NOT NULL,
    "FeedbackMessage" VARCHAR NULL,
    CONSTRAINT "PK_TB_CONTACT" PRIMARY KEY (id_contact)
);

-- Log após a criação da tabela
DO $$ BEGIN
    RAISE NOTICE 'Tabela TB_CONTACT criada com sucesso!';
END $$;

-- Criar banco DB_ANALISE_SENTIMENTO se não existir
BEGIN 
    IF NOT EXISTS (SELECT 1 FROM pg_database WHERE datname = 'DB_ANALISE_SENTIMENTO') THEN 
        CREATE DATABASE DB_ANALISE_SENTIMENTO; 
    END IF;
END 

-- Conectar ao banco de dados recém-criado
\connect DB_ANALISE_SENTIMENTO;

-- Log inicial
DO $$ BEGIN
    RAISE NOTICE 'Iniciando script de criação do banco e tabela...';
END $$;

-- Criar a tabela Feedback
CREATE TABLE IF NOT EXISTS feedback (
    Id SERIAL PRIMARY KEY,
    Name UUID NOT NULL,
    FeedbackMessage TEXT NOT NULL,
    Sentiment TEXT NOT NULL,
    Score NUMERIC(5,2) NOT NULL
);

-- Log após a criação da tabela
DO $$ BEGIN
    RAISE NOTICE 'Tabela Feedback criada com sucesso!';
END $$;