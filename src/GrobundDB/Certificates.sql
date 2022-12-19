CREATE TABLE [dbo].[Certificates]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [CertificateNumber] INT NOT NULL, 
    [AssociationId] INT NOT NULL, 
    [OwnerId] INT NULL,
    [PaidAmount] MONEY NULL, 
    FOREIGN KEY (AssociationId) REFERENCES Associations(Id),
    FOREIGN KEY (OwnerId) REFERENCES Members(Id),
)
