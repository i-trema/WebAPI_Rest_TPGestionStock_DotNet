
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/08/2022 11:34:59
-- Generated from EDMX file: C:\Users\imau\Documents\FormationDoranco\27_CSharp_WebServices\J4\WebAPI_Rest\WebAPIRest_GestionStock\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TPGestionStock];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Articles_dbo_Categories_Categorie_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articles] DROP CONSTRAINT [FK_dbo_Articles_dbo_Categories_Categorie_Id];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Articles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articles];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Articles'
CREATE TABLE [dbo].[Articles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Designation] nvarchar(max)  NULL,
    [QteMini] int  NULL,
    [Prix] float  NULL,
    [Categorie_Id] int  NULL,
    [info] varchar(10)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NULL,
    [Info] nvarchar(max)  NULL,
    [DateDeCreation] datetime  NOT NULL,
    [EntrepotId] int  NOT NULL
);
GO

-- Creating table 'Entrepots'
CREATE TABLE [dbo].[Entrepots] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Adresse] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [PK_Articles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Entrepots'
ALTER TABLE [dbo].[Entrepots]
ADD CONSTRAINT [PK_Entrepots]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Categorie_Id] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [FK_dbo_Articles_dbo_Categories_Categorie_Id]
    FOREIGN KEY ([Categorie_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Articles_dbo_Categories_Categorie_Id'
CREATE INDEX [IX_FK_dbo_Articles_dbo_Categories_Categorie_Id]
ON [dbo].[Articles]
    ([Categorie_Id]);
GO

-- Creating foreign key on [EntrepotId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_EntrepotCategory]
    FOREIGN KEY ([EntrepotId])
    REFERENCES [dbo].[Entrepots]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntrepotCategory'
CREATE INDEX [IX_FK_EntrepotCategory]
ON [dbo].[Categories]
    ([EntrepotId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------