USE SENAI_SPMEDICALDROUP;
GO

--Criou uma fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
SELECT COUNT(IdMedico)
FROM Medico
WHERE IdEspecialidade = 4
GO

--Criou uma fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
CREATE PROCEDURE P_Idade
AS  
SELECT  NomeUsuario, DATEDIFF(YEAR, (DataNascimento), GETDATE()) AS 'Idade'
FROM UsuarioPaciente
INNER JOIN Usuario 
ON UsuarioPaciente.IdUsuario = Usuario.IdUsuario
GO

EXEC P_Idade;
GO

--Converteu a data de nascimento do usu�rio para o formato (mm-dd-yyyy) na exibi��o
SELECT  NomeUsuario 'Nome', FORMAT (DataNascimento, 'dd-MM-yyyy') 'Data Nascimento' FROM UsuarioPaciente 
INNER JOIN Usuario
ON Usuario.IdUsuario = UsuarioPaciente.IdUsuario

--Mostrou a quantidade de usu�rios ap�s realizar a importa��o do banco de dados
SELECT COUNT(IdUsuario) 'Quantidade de usu�rios' FROM Usuario;
GO