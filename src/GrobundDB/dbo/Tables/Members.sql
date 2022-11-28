CREATE TABLE [dbo].[Members] (
    [Id]          INT        IDENTITY (1, 1) NOT NULL,
    [FirstName]   NCHAR (30) NOT NULL,
    [LastName]    NCHAR (50) NULL,
    [Email]       NCHAR (50) NULL,
    [PhoneNumber] NCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
