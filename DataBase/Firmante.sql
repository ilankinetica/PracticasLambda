CREATE TABLE [dbo].[Firmante]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdDocumento] INT NOT NULL, 
    [Nombre] NCHAR(10) NOT NULL, 
    [Firma] NCHAR(10) NOT NULL, 
    [Edad] INT NOT NULL
)
