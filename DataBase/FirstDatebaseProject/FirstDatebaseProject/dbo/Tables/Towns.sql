CREATE TABLE [dbo].[Towns] (
    [TownID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED ([TownID] ASC)
);

