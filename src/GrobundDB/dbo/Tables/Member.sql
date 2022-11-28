CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NCHAR(30) NOT NULL, 
    [LastName] NCHAR(50) NULL, 
    [Email] NCHAR(50) NULL, 
    [PhoneNumber] NCHAR(20) NULL


)
