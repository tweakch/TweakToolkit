
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/23/2012 02:33:56
-- Generated from EDMX file: D:\Documents\GitHub\TweakToolkit\TweakToolkit\TweakToolkit.EntityFramework\TweakTestEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [tweakTestData];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CarTire]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TireSet] DROP CONSTRAINT [FK_CarTire];
GO
IF OBJECT_ID(N'[dbo].[FK_HouseDoor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DoorSet] DROP CONSTRAINT [FK_HouseDoor];
GO
IF OBJECT_ID(N'[dbo].[FK_CycleLock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LockSet] DROP CONSTRAINT [FK_CycleLock];
GO
IF OBJECT_ID(N'[dbo].[FK_HouseRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomSet] DROP CONSTRAINT [FK_HouseRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomDoor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DoorSet] DROP CONSTRAINT [FK_RoomDoor];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonHouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HouseSet] DROP CONSTRAINT [FK_PersonHouse];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarSet] DROP CONSTRAINT [FK_PersonCar];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCycle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CycleSet] DROP CONSTRAINT [FK_PersonCycle];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPortfolio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PortfolioSet] DROP CONSTRAINT [FK_PersonPortfolio];
GO
IF OBJECT_ID(N'[dbo].[FK_PortfolioStock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockSet] DROP CONSTRAINT [FK_PortfolioStock];
GO
IF OBJECT_ID(N'[dbo].[FK_StockPrice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PriceSet] DROP CONSTRAINT [FK_StockPrice];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarSet];
GO
IF OBJECT_ID(N'[dbo].[TireSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TireSet];
GO
IF OBJECT_ID(N'[dbo].[HouseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HouseSet];
GO
IF OBJECT_ID(N'[dbo].[DoorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DoorSet];
GO
IF OBJECT_ID(N'[dbo].[CycleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CycleSet];
GO
IF OBJECT_ID(N'[dbo].[LockSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LockSet];
GO
IF OBJECT_ID(N'[dbo].[RoomSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[StockSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StockSet];
GO
IF OBJECT_ID(N'[dbo].[PortfolioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PortfolioSet];
GO
IF OBJECT_ID(N'[dbo].[PriceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PriceSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CarSet'
CREATE TABLE [dbo].[CarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Brand] nvarchar(max)  NULL,
    [Bhp] int  NOT NULL,
    [Owner_Id] int  NULL
);
GO

-- Creating table 'TireSet'
CREATE TABLE [dbo].[TireSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Dimension] smallint  NOT NULL,
    [Car_Id] int  NOT NULL
);
GO

-- Creating table 'HouseSet'
CREATE TABLE [dbo].[HouseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address_PostalCode] smallint  NOT NULL,
    [Address_Street] nvarchar(max)  NOT NULL,
    [Address_StreetNumber] nvarchar(max)  NOT NULL,
    [Address_City] nvarchar(max)  NOT NULL,
    [Owner_Id] int  NOT NULL
);
GO

-- Creating table 'DoorSet'
CREATE TABLE [dbo].[DoorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Width] smallint  NOT NULL,
    [Height] smallint  NOT NULL,
    [House_Id] int  NOT NULL,
    [Room_Id] int  NOT NULL
);
GO

-- Creating table 'CycleSet'
CREATE TABLE [dbo].[CycleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Gears] smallint  NOT NULL,
    [Owner_Id] int  NULL
);
GO

-- Creating table 'LockSet'
CREATE TABLE [dbo].[LockSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Brand] nvarchar(max)  NOT NULL,
    [Cycle_Id] int  NOT NULL
);
GO

-- Creating table 'RoomSet'
CREATE TABLE [dbo].[RoomSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Size] nvarchar(max)  NOT NULL,
    [House_Id] int  NOT NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StockSet'
CREATE TABLE [dbo].[StockSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ticker] nvarchar(max)  NULL,
    [Valor] int  NOT NULL,
    [Portfolio_Id] int  NOT NULL
);
GO

-- Creating table 'PortfolioSet'
CREATE TABLE [dbo].[PortfolioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Person_Id] int  NOT NULL
);
GO

-- Creating table 'PriceSet'
CREATE TABLE [dbo].[PriceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bid] decimal(18,0)  NULL,
    [Ask] decimal(18,0)  NULL,
    [LastUpdate] datetime  NULL,
    [Stock_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [PK_CarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TireSet'
ALTER TABLE [dbo].[TireSet]
ADD CONSTRAINT [PK_TireSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HouseSet'
ALTER TABLE [dbo].[HouseSet]
ADD CONSTRAINT [PK_HouseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DoorSet'
ALTER TABLE [dbo].[DoorSet]
ADD CONSTRAINT [PK_DoorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CycleSet'
ALTER TABLE [dbo].[CycleSet]
ADD CONSTRAINT [PK_CycleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LockSet'
ALTER TABLE [dbo].[LockSet]
ADD CONSTRAINT [PK_LockSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoomSet'
ALTER TABLE [dbo].[RoomSet]
ADD CONSTRAINT [PK_RoomSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [PK_StockSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PortfolioSet'
ALTER TABLE [dbo].[PortfolioSet]
ADD CONSTRAINT [PK_PortfolioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PriceSet'
ALTER TABLE [dbo].[PriceSet]
ADD CONSTRAINT [PK_PriceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Car_Id] in table 'TireSet'
ALTER TABLE [dbo].[TireSet]
ADD CONSTRAINT [FK_CarTire]
    FOREIGN KEY ([Car_Id])
    REFERENCES [dbo].[CarSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarTire'
CREATE INDEX [IX_FK_CarTire]
ON [dbo].[TireSet]
    ([Car_Id]);
GO

-- Creating foreign key on [House_Id] in table 'DoorSet'
ALTER TABLE [dbo].[DoorSet]
ADD CONSTRAINT [FK_HouseDoor]
    FOREIGN KEY ([House_Id])
    REFERENCES [dbo].[HouseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HouseDoor'
CREATE INDEX [IX_FK_HouseDoor]
ON [dbo].[DoorSet]
    ([House_Id]);
GO

-- Creating foreign key on [Cycle_Id] in table 'LockSet'
ALTER TABLE [dbo].[LockSet]
ADD CONSTRAINT [FK_CycleLock]
    FOREIGN KEY ([Cycle_Id])
    REFERENCES [dbo].[CycleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CycleLock'
CREATE INDEX [IX_FK_CycleLock]
ON [dbo].[LockSet]
    ([Cycle_Id]);
GO

-- Creating foreign key on [House_Id] in table 'RoomSet'
ALTER TABLE [dbo].[RoomSet]
ADD CONSTRAINT [FK_HouseRoom]
    FOREIGN KEY ([House_Id])
    REFERENCES [dbo].[HouseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HouseRoom'
CREATE INDEX [IX_FK_HouseRoom]
ON [dbo].[RoomSet]
    ([House_Id]);
GO

-- Creating foreign key on [Room_Id] in table 'DoorSet'
ALTER TABLE [dbo].[DoorSet]
ADD CONSTRAINT [FK_RoomDoor]
    FOREIGN KEY ([Room_Id])
    REFERENCES [dbo].[RoomSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomDoor'
CREATE INDEX [IX_FK_RoomDoor]
ON [dbo].[DoorSet]
    ([Room_Id]);
GO

-- Creating foreign key on [Owner_Id] in table 'HouseSet'
ALTER TABLE [dbo].[HouseSet]
ADD CONSTRAINT [FK_PersonHouse]
    FOREIGN KEY ([Owner_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonHouse'
CREATE INDEX [IX_FK_PersonHouse]
ON [dbo].[HouseSet]
    ([Owner_Id]);
GO

-- Creating foreign key on [Owner_Id] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [FK_PersonCar]
    FOREIGN KEY ([Owner_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCar'
CREATE INDEX [IX_FK_PersonCar]
ON [dbo].[CarSet]
    ([Owner_Id]);
GO

-- Creating foreign key on [Owner_Id] in table 'CycleSet'
ALTER TABLE [dbo].[CycleSet]
ADD CONSTRAINT [FK_PersonCycle]
    FOREIGN KEY ([Owner_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCycle'
CREATE INDEX [IX_FK_PersonCycle]
ON [dbo].[CycleSet]
    ([Owner_Id]);
GO

-- Creating foreign key on [Person_Id] in table 'PortfolioSet'
ALTER TABLE [dbo].[PortfolioSet]
ADD CONSTRAINT [FK_PersonPortfolio]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPortfolio'
CREATE INDEX [IX_FK_PersonPortfolio]
ON [dbo].[PortfolioSet]
    ([Person_Id]);
GO

-- Creating foreign key on [Portfolio_Id] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [FK_PortfolioStock]
    FOREIGN KEY ([Portfolio_Id])
    REFERENCES [dbo].[PortfolioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PortfolioStock'
CREATE INDEX [IX_FK_PortfolioStock]
ON [dbo].[StockSet]
    ([Portfolio_Id]);
GO

-- Creating foreign key on [Stock_Id] in table 'PriceSet'
ALTER TABLE [dbo].[PriceSet]
ADD CONSTRAINT [FK_StockPrice]
    FOREIGN KEY ([Stock_Id])
    REFERENCES [dbo].[StockSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StockPrice'
CREATE INDEX [IX_FK_StockPrice]
ON [dbo].[PriceSet]
    ([Stock_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------