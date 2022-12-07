CREATE TABLE [dbo].[Members] (
    [Id]          INT        IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (450) NULL,
    [Email]       NVARCHAR (50) NULL,
    [PhoneNumber] NVARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
