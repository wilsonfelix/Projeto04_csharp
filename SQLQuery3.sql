﻿create table CLIENTE(
	IDCLIENTE		UNIQUEIDENTIFIER	NOT NULL,
	NOME			NVARCHAR(150)		NOT NULL,
	CPF				NVARCHAR(15)		NOT NULL,
	DATANASCIMENTO	DATE				NOT NULL,
	PRIMARY KEY (IDCLIENTE))
GO

CREATE PROCEDURE SP_INSERIRCLIENTE
	@NOME				NVARCHAR(150),
	@CPF				NVARCHAR(15),
	@DATANASCIMENTO		DATE
AS
BEGIN
	BEGIN TRANSACTION --ABRINDO UMA TRANSAÇÃO
	INSERT INTO CLIENTE(IDCLIENTE, NOME, CPF, DATANASCIMENTO)
				VALUES(NEWID(), @NOME, @CPF,@DATANASCIMENTO)
	COMMIT --FINALIZANDO E EXECUTANDO A TRANSAÇÃO
END
GO

CREATE PROCEDURE SP_ATUALIZARCLIENTE
	@IDCLIENTE			UNIQUEIDENTIFIER,
	@NOME				NVARCHAR(150),
	@CPF				NVARCHAR(15),
	@DATANASCIMENTO		DATE
AS
BEGIN
	BEGIN TRANSACTION --ABRINDO UMA TRANSAÇÃO
	UPDATE CLIENTE
	SET
		NOME = @NOME,
		CPF = @CPF,
		DATANASCIMENTO = @DATANASCIMENTO
	WHERE
		IDCLIENTE = @IDCLIENTE

	COMMIT --FINALIZANDO E EXECUTANDO A TRANSAÇÃO
END
GO

CREATE PROCEDURE SP_EXCLUIRCLIENTE
	@IDCLIENTE		UNIQUEIDENTIFIER
AS
BEGIN
	BEGIN TRANSACTION --ABRINDO UMA TRANSAÇÃO
	DELETE CLIENTE WHERE IDCLIENTE = @IDCLIENTE
	COMMIT --FINALIZANDO E EXECUTANDO A TRANSAÇÃO
END
GO
