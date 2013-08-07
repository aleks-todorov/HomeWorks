CREATE TABLE [dbo].[Addresses] (
    [AddressID]   INT            IDENTITY (1, 1) NOT NULL,
    [AddressText] NVARCHAR (100) NOT NULL,
    [TownID]      INT            NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([AddressID] ASC),
    CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY ([TownID]) REFERENCES [dbo].[Towns] ([TownID])
);

