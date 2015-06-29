
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/25/2015 21:47:20
-- Generated from EDMX file: C:\Users\priyvasanthan\Documents\Visual Studio 2013\Projects\BootstrapMVC_IISExpress\BootstrapMVC\Models\Stores.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Stores];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Post_Post]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_Post_Post];
GO
IF OBJECT_ID(N'[dbo].[FK_Post_Title]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_Post_Title];
GO
IF OBJECT_ID(N'[dbo].[FK_Title_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Title] DROP CONSTRAINT [FK_Title_Category];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CATEGORY]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CATEGORY];
GO
IF OBJECT_ID(N'[dbo].[Post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Post];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Title]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Title];
GO
IF OBJECT_ID(N'[StoresModelStoreContainer].[View_ListItem]', 'U') IS NOT NULL
    DROP TABLE [StoresModelStoreContainer].[View_ListItem];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Price] decimal(10,2)  NOT NULL,
    [Image] varbinary(max)  NULL,
    [DateCreated] datetime  NULL,
    [LastUpdated] datetime  NULL,
    [Details] nvarchar(max)  NULL
);
GO

-- Creating table 'View_ListItem'
CREATE TABLE [dbo].[View_ListItem] (
    [Name] varchar(100)  NOT NULL,
    [Price] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'CATEGORies'
CREATE TABLE [dbo].[CATEGORies] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PostDetail] varchar(max)  NULL,
    [MasterPostID] int  NULL,
    [TitleID] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'Titles'
CREATE TABLE [dbo].[Titles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [CategoryID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Name], [Price] in table 'View_ListItem'
ALTER TABLE [dbo].[View_ListItem]
ADD CONSTRAINT [PK_View_ListItem]
    PRIMARY KEY CLUSTERED ([Name], [Price] ASC);
GO

-- Creating primary key on [ID] in table 'CATEGORies'
ALTER TABLE [dbo].[CATEGORies]
ADD CONSTRAINT [PK_CATEGORies]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Titles'
ALTER TABLE [dbo].[Titles]
ADD CONSTRAINT [PK_Titles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryID] in table 'Titles'
ALTER TABLE [dbo].[Titles]
ADD CONSTRAINT [FK_Title_Category]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[CATEGORies]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Title_Category'
CREATE INDEX [IX_FK_Title_Category]
ON [dbo].[Titles]
    ([CategoryID]);
GO

-- Creating foreign key on [MasterPostID] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Post_Post]
    FOREIGN KEY ([MasterPostID])
    REFERENCES [dbo].[Posts]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Post_Post'
CREATE INDEX [IX_FK_Post_Post]
ON [dbo].[Posts]
    ([MasterPostID]);
GO

-- Creating foreign key on [TitleID] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Post_Title]
    FOREIGN KEY ([TitleID])
    REFERENCES [dbo].[Titles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Post_Title'
CREATE INDEX [IX_FK_Post_Title]
ON [dbo].[Posts]
    ([TitleID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------