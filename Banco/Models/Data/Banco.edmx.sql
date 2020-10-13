
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/12/2020 22:28:33
-- Generated from EDMX file: C:\Users\glanza007\source\repos\Banco\Banco\Models\Data\Banco.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Banco];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Cliente_Genero]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cliente] DROP CONSTRAINT [FK_Cliente_Genero];
GO
IF OBJECT_ID(N'[dbo].[FK_Cuenta_Cliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuenta] DROP CONSTRAINT [FK_Cuenta_Cliente];
GO
IF OBJECT_ID(N'[dbo].[FK_Cuenta_Estado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuenta] DROP CONSTRAINT [FK_Cuenta_Estado];
GO
IF OBJECT_ID(N'[dbo].[FK_Cuenta_TipoCuenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuenta] DROP CONSTRAINT [FK_Cuenta_TipoCuenta];
GO
IF OBJECT_ID(N'[dbo].[FK_Cuenta_TipoMoneda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuenta] DROP CONSTRAINT [FK_Cuenta_TipoMoneda];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[Cuenta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuenta];
GO
IF OBJECT_ID(N'[dbo].[Estado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estado];
GO
IF OBJECT_ID(N'[dbo].[Genero]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genero];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TipoCuenta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoCuenta];
GO
IF OBJECT_ID(N'[dbo].[TipoMoneda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoMoneda];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [IdCliente] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Apellidos] nvarchar(50)  NOT NULL,
    [Direccion] nvarchar(300)  NULL,
    [FechaNacimiento] datetime  NULL,
    [Identidad] nvarchar(20)  NOT NULL,
    [GeneroId] int  NOT NULL,
    [LugarNacimiento] nvarchar(50)  NULL
);
GO

-- Creating table 'Cuenta'
CREATE TABLE [dbo].[Cuenta] (
    [CuentaId] int IDENTITY(1,1) NOT NULL,
    [TipoMonedaId] int  NOT NULL,
    [Saldo] decimal(18,2)  NOT NULL,
    [EstadoId] int  NOT NULL,
    [TipoCuentaId] int  NOT NULL,
    [ClienteId] int  NULL,
    [NumCuenta] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Estado'
CREATE TABLE [dbo].[Estado] (
    [EstadoId] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'Genero'
CREATE TABLE [dbo].[Genero] (
    [GeneroId] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TipoCuenta'
CREATE TABLE [dbo].[TipoCuenta] (
    [TipoCuentaId] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'TipoMoneda'
CREATE TABLE [dbo].[TipoMoneda] (
    [TipoMonedaId] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(25)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCliente] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([IdCliente] ASC);
GO

-- Creating primary key on [CuentaId] in table 'Cuenta'
ALTER TABLE [dbo].[Cuenta]
ADD CONSTRAINT [PK_Cuenta]
    PRIMARY KEY CLUSTERED ([CuentaId] ASC);
GO

-- Creating primary key on [EstadoId] in table 'Estado'
ALTER TABLE [dbo].[Estado]
ADD CONSTRAINT [PK_Estado]
    PRIMARY KEY CLUSTERED ([EstadoId] ASC);
GO

-- Creating primary key on [GeneroId] in table 'Genero'
ALTER TABLE [dbo].[Genero]
ADD CONSTRAINT [PK_Genero]
    PRIMARY KEY CLUSTERED ([GeneroId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TipoCuentaId] in table 'TipoCuenta'
ALTER TABLE [dbo].[TipoCuenta]
ADD CONSTRAINT [PK_TipoCuenta]
    PRIMARY KEY CLUSTERED ([TipoCuentaId] ASC);
GO

-- Creating primary key on [TipoMonedaId] in table 'TipoMoneda'
ALTER TABLE [dbo].[TipoMoneda]
ADD CONSTRAINT [PK_TipoMoneda]
    PRIMARY KEY CLUSTERED ([TipoMonedaId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GeneroId] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [FK_Cliente_Genero]
    FOREIGN KEY ([GeneroId])
    REFERENCES [dbo].[Genero]
        ([GeneroId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Genero'
CREATE INDEX [IX_FK_Cliente_Genero]
ON [dbo].[Cliente]
    ([GeneroId]);
GO

-- Creating foreign key on [ClienteId] in table 'Cuenta'
ALTER TABLE [dbo].[Cuenta]
ADD CONSTRAINT [FK_Cuenta_Cliente]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Cliente]
        ([IdCliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cuenta_Cliente'
CREATE INDEX [IX_FK_Cuenta_Cliente]
ON [dbo].[Cuenta]
    ([ClienteId]);
GO

-- Creating foreign key on [EstadoId] in table 'Cuenta'
ALTER TABLE [dbo].[Cuenta]
ADD CONSTRAINT [FK_Cuenta_Estado]
    FOREIGN KEY ([EstadoId])
    REFERENCES [dbo].[Estado]
        ([EstadoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cuenta_Estado'
CREATE INDEX [IX_FK_Cuenta_Estado]
ON [dbo].[Cuenta]
    ([EstadoId]);
GO

-- Creating foreign key on [TipoCuentaId] in table 'Cuenta'
ALTER TABLE [dbo].[Cuenta]
ADD CONSTRAINT [FK_Cuenta_TipoCuenta]
    FOREIGN KEY ([TipoCuentaId])
    REFERENCES [dbo].[TipoCuenta]
        ([TipoCuentaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cuenta_TipoCuenta'
CREATE INDEX [IX_FK_Cuenta_TipoCuenta]
ON [dbo].[Cuenta]
    ([TipoCuentaId]);
GO

-- Creating foreign key on [TipoMonedaId] in table 'Cuenta'
ALTER TABLE [dbo].[Cuenta]
ADD CONSTRAINT [FK_Cuenta_TipoMoneda]
    FOREIGN KEY ([TipoMonedaId])
    REFERENCES [dbo].[TipoMoneda]
        ([TipoMonedaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cuenta_TipoMoneda'
CREATE INDEX [IX_FK_Cuenta_TipoMoneda]
ON [dbo].[Cuenta]
    ([TipoMonedaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------