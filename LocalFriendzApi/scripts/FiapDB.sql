-- Conectar ao banco de dados recém-criado
\c DB_FIAP_ARQUITETO;

-- Log inicial
DO $$ BEGIN
    RAISE NOTICE 'Iniciando script de criação do banco e tabela...';
END $$;

-- Criação da tabela TB_CONTACT no schema public
CREATE TABLE public."TB_CONTACT" (
    id_contact uuid NOT NULL,
    "name" varchar NOT NULL,
    phone varchar NOT NULL,
    "DDD" varchar NOT NULL,
    email varchar NOT NULL,
    CONSTRAINT "PK_TB_CONTACT" PRIMARY KEY (id_contact)
);

-- Log após a criação da tabela
DO $$ BEGIN
    RAISE NOTICE 'Tabela TB_CONTACT criada com sucesso!';
END $$;

