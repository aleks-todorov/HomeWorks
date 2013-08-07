CREATE TABLE [dbo].[Projects] (
    [ProjectID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Description] NTEXT         NULL,
    [StartDate]   SMALLDATETIME NOT NULL,
    [EndDate]     SMALLDATETIME NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED ([ProjectID] ASC)
);

