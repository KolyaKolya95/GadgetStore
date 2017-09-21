CREATE TABLE [dbo].[Gadgets] (
    [GadgetId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Type]     NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([GadgetId] ASC)
);

