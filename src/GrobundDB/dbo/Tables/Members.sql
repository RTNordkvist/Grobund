CREATE TABLE [dbo].[Members] (
    [Id]          INT        IDENTITY (1, 1) NOT NULL,
    [Name]   NCHAR (70) NOT NULL,
    [Email]       NCHAR (50) NULL,
	[Registered]  NCHAR (50) NULL,
    [PhoneNumber] NCHAR (20) NULL,
	[MobileNumber] NCHAR (20) NULL,
	[Address1] NCHAR (100) NULL,
	[Address2] NCHAR (100) NULL,
	[City] NCHAR (50) NULL,
	[PostalCode] NCHAR (100) NULL,
	[Country] NCHAR (50) NULL,
	[UserCertificate] NCHAR (50) NULL,
	[LandCertificate] NCHAR (50) NULL,
	
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
