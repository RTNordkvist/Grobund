CREATE TABLE [dbo].[Trades]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [CertificateId] INT NOT NULL, 
    [SellerId] INT NULL, 
    [BuyerId] INT NOT NULL, 
    [Date] DATETIME NOT NULL,
    FOREIGN KEY (CertificateId) REFERENCES Certificates(Id),
    FOREIGN KEY (SellerId) REFERENCES Members(Id),
    FOREIGN KEY (BuyerId) REFERENCES Members(Id),

)
