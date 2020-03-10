--DML

INSERT INTO Empresa (NomeEmpresa)
VALUES	('Senatur');
GO

INSERT INTO EstadoPacote (Estado)
VALUES	('Dispon�vel'),
		('Indispon�vel');
GO

INSERT INTO Pacote (NomePacote, Descricao, DataIda, DataVolta, Valor, Cidade, IdEmpresa, IdEstadoPacote)
VALUES	('Salvador - 5 Dias/ 4 Di�rias','O que n�o falta em Salvador s�o atra��es. Prova disso s�o as praias, os museus e as constru��es seculares que d�o um charme mais que especial � regi�o.','06/08/2020','10/08/2020',854.00,'Salvador',1,1),
		('Resorts na Bahia - Litoral Norte - 5 Dias/4 Di�rias',' O Litoral Norte da Bahia conta com in�meras praias emolduradas por coqueiros, al�m de piscinas naturais de �guas mornas que s�o protegidas por recifes e habitadas por peixes coloridos.','14/05/2020','18/05/2020',1826.00,'Salvador',1,1),
		('Bonito Via Campo Grande - 1 Passeio - 5 Dias/4 Di�rias','Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de �guas cristalinas, al�m de cavernas inundadas, pared�es rochosos e uma infinidade de peixes.','28/03/2020','01/04/2020',1004.00,'Bonito',1,1);
GO

INSERT INTO TipoUsuario (Titulo)
VALUES	('Administrador'),
		('Comum');
GO

INSERT INTO Usuario (Email, Senha, IdTipoUsuario)
VALUES	('admin@admin.com','admin',1),
		('cliente@cliente.com','cliente',2);
GO