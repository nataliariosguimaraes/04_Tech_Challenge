/*
Autor:Jefferson Santos

Data de Cria��o: 10/06/2024

Prop�sito:
Este script � destinado a simplificar o acesso a informa��es sobre contatos.

*/

-- CRIACIATION
CREATE DATABASE DB_FIAP_ARQUITETO

-- USER DATABASE
USE DB_FIAP_ARQUITETO

-- CREATIATION TABLES
CREATE TABLE TB_AREA_CODE(
	id_area_code UNIQUEIDENTIFIER NOT NULL,
	code_region INT NOT NULL,
	PRIMARY KEY(id_area_code)
)


CREATE TABLE TB_CONTACT(
	id_contact UNIQUEIDENTIFIER NOT NULL,
	[name] VARCHAR(100) NOT NULL,
	phone VARCHAR(20) NOT NULL,
	email VARCHAR(40),
	fk_id_area_code UNIQUEIDENTIFIER NOT NULL,
	FeedbackMessage varchar(50)  NULL,
	FOREIGN KEY (fk_id_area_code) REFERENCES TB_AREA_CODE(id_area_code),
	PRIMARY KEY(id_contact)
)

-- Inserindo registros na tabela TB_AREA_CODE
INSERT INTO TB_AREA_CODE (id_area_code, code_region) VALUES
('550e8400-e29b-41d4-a716-446655440000', 1),
('550e8400-e29b-41d4-a716-446655440001', 2),
('550e8400-e29b-41d4-a716-446655440002', 3);



SELECT * FROM TB_AREA_CODE
SELECT * FROM TB_CONTACT 

SELECT c.name, c.phone, c.email, a.code_region FROM TB_CONTACT c
INNER JOIN TB_AREA_CODE a
ON a.id_area_code = c.fk_id_area_code order by [name]