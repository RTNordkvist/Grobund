CREATE TABLE [dbo].[Associations]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [Name] NVARCHAR(450) NULL, 
    [MaxNoOfCertificates] INT NULL, 
    [CertificatePrice] MONEY NULL,
)
