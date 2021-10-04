USE SENAI_SPMEDICALDROUP;
GO

insert into TipoUsuario ( TituloTipoUsuario)
values('Paciente'), ('Medico')

INSERT INTO Usuario(IdTipoUsuario, NomeUsuario, Email, Senha)
VALUES (1, 'Lucas', 'lucas@gmail.com', 'lucas756'),
	   (1, 'Alexandre', 'alexandre@gmail.com', 'alezinhogameplays'),
	   (1, 'Fabricio', 'fafa123@gmail.com', 'fazinho789'),
	   (1, 'Henrique', 'Cardosado123@gmail.com', 'henri2546'),
	   (1, 'Jonas', 'Jincara@hotmail.com', '40028922'),
	   (1, 'Brener', 'Brener@gmail.com', 'NoLook153'),
	   (1, 'Matheus', 'matheus@outlook.com', 'Lili123321'),
	   (2, 'Victor', 'VictorLopes@spmedicalgroup.com.br', 'Victor123'),
	   (2, 'Richard', 'Richard@spmedicalgroup.com.br', 'richard123'),
	   (2, 'Helen', 'helen@spmedicalgroup.com.br', 'helenzinha');
GO

INSERT INTO Clinica(NomeFantasia, RazaoSocial, Endereco, Cnpj, HorariodeAbertura, HorariodeFechamento)
VALUES ('Clinica Chapeiras', 'SP Medical Group', 'Av. Barão Limeira, 532, São Paulo, SP', '77.777.777/7777-77', '07:00', '20:00');
GO

insert into Especialidade (Descricao)
values ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),('Cirurgia da Mão'),('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral')
,('Cirurgia Pediátrica'),('Cirurgia Plástica'),('Cirurgia Torácica'),('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria');
GO

select * from Medico

INSERT INTO Medico(IdUsuario, IdEspecialidade, IdClinica, Crm)
VALUES (8, 4, 1, '12345-SP'),
	   (9, 13, 1, '98765-SP'),
	   (10, 1, 1, '75632-SP');
GO

INSERT INTO UsuarioPaciente(IdUsuario, Telefone, DataNascimento, Endereco, Rg, Cpf)
VALUES (3, '11 3456-7654', '13/10/1983', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000', '43522543-5', '94839859000'),
	   (4, '11 98765-6543', '23/07/2001', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200', '32654345-7', '73556944057'),
	   (5, '11 97208-4453', '10/10/1978', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200', '54636525-3', '16839338002'),
	   (6, '11 3456-6543', '13/10/1985', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030', '54366362-5', '14332654765'),
	   (7, '11 7656-6377', '27/08/1975', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380', '53254444-1', '91305348010'),
	   (8, '11 95436-8769', '21/03/1972', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001', '54566266-7', '79799299004'),
	   (9, '', '05/03/2018', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140', '54566266-8', '13771913039')
GO

insert into Situacao(Descricao)
values ('Aprovada'),('Agendada'),('Cancelada')

INSERT INTO Consulta(IdMedico, IdPaciente, DataeHora, IdSituacao, Descricao)
VALUES (2, 7, '20/01/2020 15:00', 1, ''),
	   (2, 2, '06/01/2020 10:00', 2, ''),
	   (3, 3, '07/02/2020 11:00', 1, ''),
	   (2, 2, '06/02/2018 10:00', 1, ''),
	   (2, 4, '07/02/2019 11:00', 2, ''),
	   (3, 7, '08/03/2020 15:00', 3, ''),
	   (4, 4, '09/03/2020 11:00', 2, '')
GO