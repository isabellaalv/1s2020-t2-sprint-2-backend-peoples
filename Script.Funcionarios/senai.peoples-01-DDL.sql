-- DDL

CREATE DATABASE T_Peoples;
USE T_Peoples;

CREATE TABLE Funcionarios (
	IdFuncionario	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (255),
	Sobrenome		VARCHAR (255),
);

CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR (255) 
);

CREATE TABLE Usuario (

	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (255),
	Senha VARCHAR (255),
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);

SELECT * FROM Usuario;
SELECT * FROM TipoUsuario;
SELECT * FROM Funcionarios;

INSERT INTO TipoUsuario (Titulo)
VALUES ('Adm'), ('Comum');

INSERT INTO Usuario (Email, Senha, IdTipoUsuario)
VALUES ('saulo@saulo', '113', 2), ('carol@carol', '223', 1);
