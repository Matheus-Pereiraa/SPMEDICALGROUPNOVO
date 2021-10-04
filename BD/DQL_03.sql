USE SENAI_SPMEDICALDROUP;
GO

--Criou uma função para retornar a quantidade de médicos de uma determinada especialidade
SELECT COUNT(IdMedico)
FROM Medico
WHERE IdEspecialidade = 4
GO

--Criou uma função para retornar a quantidade de médicos de uma determinada especialidade
CREATE PROCEDURE P_Idade
AS  
SELECT  NomeUsuario, DATEDIFF(YEAR, (DataNascimento), GETDATE()) AS 'Idade'
FROM UsuarioPaciente
INNER JOIN Usuario 
ON UsuarioPaciente.IdUsuario = Usuario.IdUsuario
GO

EXEC P_Idade;
GO

--Converteu a data de nascimento do usuário para o formato (mm-dd-yyyy) na exibição
SELECT  NomeUsuario 'Nome', FORMAT (DataNascimento, 'dd-MM-yyyy') 'Data Nascimento' FROM UsuarioPaciente 
INNER JOIN Usuario
ON Usuario.IdUsuario = UsuarioPaciente.IdUsuario

--Mostrou a quantidade de usuários após realizar a importação do banco de dados
SELECT COUNT(IdUsuario) 'Quantidade de usuários' FROM Usuario;
GO