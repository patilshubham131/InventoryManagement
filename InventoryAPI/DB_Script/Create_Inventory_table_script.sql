
CREATE TABLE [dbo].[Inventory] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    [Description]  NVARCHAR (200) NULL,
	Price FLOAT
    CONSTRAINT [PK_dbo.Blogs] PRIMARY KEY CLUSTERED ([Id] ASC)
);