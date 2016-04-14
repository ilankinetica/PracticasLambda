CREATE TABLE [dbo].[Firmante]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(50) NOT NULL, 
    [Firma] NVARCHAR(50) NOT NULL, 
    [Edad] INT NOT NULL, 
    [IdDocumento] INT NOT NULL
)
