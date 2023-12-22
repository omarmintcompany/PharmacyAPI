USE master;
GO

CREATE DATABASE PharmacyDB;
GO

CREATE TABLE PharmacyDB.dbo.Pharmacys(
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	
	PharmacyName [nvarchar](100) NOT NULL,
	Address [nvarchar](200) NOT NULL,	
	Latitude float not NULL,
	Longitude float Not NULL
 CONSTRAINT [PK_Log_3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 

GO

INSERT INTO PharmacyDB.dbo.Pharmacys ([PharmacyName],[Address],[Latitude],[Longitude])
VALUES
('Farmacia Joaquin Sanz Blanco','Calle del General Vives, 80 Parque Santa Catalina, 6, C. Ripoche, 2, 35007 Las Palmas de Gran Canaria, Las Palmas',28.14156013,-15.43104),
('Farmacia Cristina Cardenes',	'C. Juan Manuel Duran Gonzalez, 18, 35007 Las Palmas de Gran Canaria, Las Palmas',	28.1367110879118,-15.43195757),
('Farmacia Alicia y Carlos Rios Artiles 1',	'C. Pdte. Alvear, 8, 35006 Las Palmas de Gran Canaria, Las Palmas',	28.137670876923,-15.42966616)
