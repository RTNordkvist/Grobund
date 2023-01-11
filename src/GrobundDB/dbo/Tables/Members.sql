CREATE TABLE [dbo].[Members] (
    [Id]          INT        IDENTITY (1, 1) NOT NULL,
    [MemberNo]    NVARCHAR (450) NULL,
    [Name]        NVARCHAR (450) NULL,
    [Email]       NVARCHAR (50) NULL,
    [PhoneNumber] NVARCHAR (20) NULL,
    [MobileNumber] NVARCHAR (20) NULL,
    [Address1]  NVARCHAR (450) NULL,
    [Address2]  NVARCHAR (450) NULL,
    [PostalCode]  NVARCHAR (20) NULL,
    [City]  NVARCHAR (100) NULL,
    [Country]  NVARCHAR (50) NULL,
    [Registered]  DateTime NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC)
)
