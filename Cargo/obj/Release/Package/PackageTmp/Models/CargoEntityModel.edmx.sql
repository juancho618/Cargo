
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/15/2016 18:25:24
-- Generated from EDMX file: C:\Users\Juancho\documents\visual studio 2015\Projects\Cargo\Cargo\Models\CargoEntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CargoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_Courier_DeliveryCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Couriers] DROP CONSTRAINT [FK_Courier_DeliveryCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Courier_Warehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Couriers] DROP CONSTRAINT [FK_Courier_Warehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_Warehouse_Branch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Warehouses] DROP CONSTRAINT [FK_Warehouse_Branch];
GO
IF OBJECT_ID(N'[dbo].[FK_Warehouse_CompanyAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Warehouses] DROP CONSTRAINT [FK_Warehouse_CompanyAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_Warehouse_CompanyAccount1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Warehouses] DROP CONSTRAINT [FK_Warehouse_CompanyAccount1];
GO
IF OBJECT_ID(N'[dbo].[FK_Warehouse_CompanyAccount2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Warehouses] DROP CONSTRAINT [FK_Warehouse_CompanyAccount2];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyAccount_Country]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompanyAccounts] DROP CONSTRAINT [FK_CompanyAccount_Country];
GO
IF OBJECT_ID(N'[dbo].[FK_NotificationAccountRelation_CompanyAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NotificationAccountRelations] DROP CONSTRAINT [FK_NotificationAccountRelation_CompanyAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_NotificationAccountRelation_Notification]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NotificationAccountRelations] DROP CONSTRAINT [FK_NotificationAccountRelation_Notification];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountClasificationRelation_AccountClasification]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountClasificationRelations] DROP CONSTRAINT [FK_AccountClasificationRelation_AccountClasification];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountClasificationRelation_CompanyAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountClasificationRelations] DROP CONSTRAINT [FK_AccountClasificationRelation_CompanyAccount];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[C__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[C__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Couriers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Couriers];
GO
IF OBJECT_ID(N'[dbo].[DeliveryCompanies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliveryCompanies];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Warehouses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Warehouses];
GO
IF OBJECT_ID(N'[dbo].[CurrentWarehouseCodeNumbers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrentWarehouseCodeNumbers];
GO
IF OBJECT_ID(N'[dbo].[Branches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Branches];
GO
IF OBJECT_ID(N'[dbo].[CompanyAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanyAccounts];
GO
IF OBJECT_ID(N'[dbo].[Conditions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Conditions];
GO
IF OBJECT_ID(N'[dbo].[UnitTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UnitTypes];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[Notifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notifications];
GO
IF OBJECT_ID(N'[dbo].[NotificationAccountRelations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NotificationAccountRelations];
GO
IF OBJECT_ID(N'[dbo].[AccountClasifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountClasifications];
GO
IF OBJECT_ID(N'[dbo].[AccountClasificationRelations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountClasificationRelations];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [Nombre] nchar(30)  NULL,
    [Apellido] nchar(50)  NULL,
    [Foto] nvarchar(max)  NULL
);
GO

-- Creating table 'Couriers'
CREATE TABLE [dbo].[Couriers] (
    [CourierID] nvarchar(100)  NOT NULL,
    [Fk_WarehouseID] nvarchar(100)  NOT NULL,
    [Length] float  NOT NULL,
    [Width] float  NOT NULL,
    [Height] float  NOT NULL,
    [Weight] float  NOT NULL,
    [TrakingNumber] nvarchar(100)  NOT NULL,
    [Fk_DeliveryCompany] nvarchar(100)  NULL,
    [Deleted] bit  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [LastModificationDate] datetime  NULL,
    [DeletedDate] datetime  NULL,
    [Units] int  NOT NULL,
    [Fk_UnitType] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'DeliveryCompanies'
CREATE TABLE [dbo].[DeliveryCompanies] (
    [CompanyID] nvarchar(100)  NOT NULL,
    [CompanyName] nvarchar(100)  NOT NULL,
    [Deleted] bit  NOT NULL
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

-- Creating table 'Warehouses'
CREATE TABLE [dbo].[Warehouses] (
    [WarehouseID] nvarchar(100)  NOT NULL,
    [NumberCode] int  NOT NULL,
    [Fk_BranchID] nvarchar(100)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [Fk_ShipperID] nvarchar(100)  NULL,
    [Fk_Consignee] nvarchar(100)  NULL,
    [Fk_Agent] nvarchar(100)  NULL,
    [Fk_DeliveryCompany] nvarchar(100)  NULL,
    [Fk_Condition] nvarchar(100)  NULL,
    [Description] nvarchar(max)  NULL,
    [Fk_Origin] nvarchar(100)  NULL,
    [Fk_Destination] nvarchar(100)  NULL
);
GO

-- Creating table 'CurrentWarehouseCodeNumbers'
CREATE TABLE [dbo].[CurrentWarehouseCodeNumbers] (
    [WarehHouseID] int IDENTITY(1,1) NOT NULL,
    [WarehouseCodeNumber] int  NOT NULL
);
GO

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [BranchID] nvarchar(100)  NOT NULL,
    [BranchName] nvarchar(100)  NULL
);
GO

-- Creating table 'CompanyAccounts'
CREATE TABLE [dbo].[CompanyAccounts] (
    [CompanyAccountID] nvarchar(100)  NOT NULL,
    [CompanyName] nvarchar(200)  NOT NULL,
    [Adress] nvarchar(300)  NULL,
    [City] nvarchar(100)  NULL,
    [State] nvarchar(100)  NOT NULL,
    [ZipCode] nvarchar(50)  NULL,
    [Fk_CountryID] nvarchar(100)  NULL,
    [Email] nvarchar(100)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Fax] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NULL,
    [ContactName] nvarchar(150)  NULL,
    [Fk_Agent] nvarchar(100)  NULL,
    [AccountClasificationAccountClasificationID] nvarchar(100)  NULL
);
GO

-- Creating table 'Conditions'
CREATE TABLE [dbo].[Conditions] (
    [ConditionID] nvarchar(100)  NOT NULL,
    [ConditionName] nvarchar(100)  NULL
);
GO

-- Creating table 'UnitTypes'
CREATE TABLE [dbo].[UnitTypes] (
    [UnitTypeId] nvarchar(100)  NOT NULL,
    [UnitName] nvarchar(80)  NOT NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [CountryID] nvarchar(100)  NOT NULL,
    [CountryName] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Notifications'
CREATE TABLE [dbo].[Notifications] (
    [NotificationID] nvarchar(100)  NOT NULL,
    [NotificationName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'NotificationAccountRelations'
CREATE TABLE [dbo].[NotificationAccountRelations] (
    [NotificationAccountRelation1] nvarchar(100)  NOT NULL,
    [Fk_Account] nvarchar(100)  NULL,
    [Fk_Notification] nvarchar(100)  NULL
);
GO

-- Creating table 'AccountClasifications'
CREATE TABLE [dbo].[AccountClasifications] (
    [AccountClasificationID] nvarchar(100)  NOT NULL,
    [ClasificationName] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'AccountClasificationRelations'
CREATE TABLE [dbo].[AccountClasificationRelations] (
    [AccountClasificationID] nvarchar(100)  NOT NULL,
    [Fk_AccountID] nvarchar(100)  NOT NULL,
    [Fk_ClasificationID] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CourierID] in table 'Couriers'
ALTER TABLE [dbo].[Couriers]
ADD CONSTRAINT [PK_Couriers]
    PRIMARY KEY CLUSTERED ([CourierID] ASC);
GO

-- Creating primary key on [CompanyID] in table 'DeliveryCompanies'
ALTER TABLE [dbo].[DeliveryCompanies]
ADD CONSTRAINT [PK_DeliveryCompanies]
    PRIMARY KEY CLUSTERED ([CompanyID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [WarehouseID] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [PK_Warehouses]
    PRIMARY KEY CLUSTERED ([WarehouseID] ASC);
GO

-- Creating primary key on [WarehHouseID] in table 'CurrentWarehouseCodeNumbers'
ALTER TABLE [dbo].[CurrentWarehouseCodeNumbers]
ADD CONSTRAINT [PK_CurrentWarehouseCodeNumbers]
    PRIMARY KEY CLUSTERED ([WarehHouseID] ASC);
GO

-- Creating primary key on [BranchID] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([BranchID] ASC);
GO

-- Creating primary key on [CompanyAccountID] in table 'CompanyAccounts'
ALTER TABLE [dbo].[CompanyAccounts]
ADD CONSTRAINT [PK_CompanyAccounts]
    PRIMARY KEY CLUSTERED ([CompanyAccountID] ASC);
GO

-- Creating primary key on [ConditionID] in table 'Conditions'
ALTER TABLE [dbo].[Conditions]
ADD CONSTRAINT [PK_Conditions]
    PRIMARY KEY CLUSTERED ([ConditionID] ASC);
GO

-- Creating primary key on [UnitTypeId] in table 'UnitTypes'
ALTER TABLE [dbo].[UnitTypes]
ADD CONSTRAINT [PK_UnitTypes]
    PRIMARY KEY CLUSTERED ([UnitTypeId] ASC);
GO

-- Creating primary key on [CountryID] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([CountryID] ASC);
GO

-- Creating primary key on [NotificationID] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [PK_Notifications]
    PRIMARY KEY CLUSTERED ([NotificationID] ASC);
GO

-- Creating primary key on [NotificationAccountRelation1] in table 'NotificationAccountRelations'
ALTER TABLE [dbo].[NotificationAccountRelations]
ADD CONSTRAINT [PK_NotificationAccountRelations]
    PRIMARY KEY CLUSTERED ([NotificationAccountRelation1] ASC);
GO

-- Creating primary key on [AccountClasificationID] in table 'AccountClasifications'
ALTER TABLE [dbo].[AccountClasifications]
ADD CONSTRAINT [PK_AccountClasifications]
    PRIMARY KEY CLUSTERED ([AccountClasificationID] ASC);
GO

-- Creating primary key on [AccountClasificationID] in table 'AccountClasificationRelations'
ALTER TABLE [dbo].[AccountClasificationRelations]
ADD CONSTRAINT [PK_AccountClasificationRelations]
    PRIMARY KEY CLUSTERED ([AccountClasificationID] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [Fk_DeliveryCompany] in table 'Couriers'
ALTER TABLE [dbo].[Couriers]
ADD CONSTRAINT [FK_Courier_DeliveryCompany]
    FOREIGN KEY ([Fk_DeliveryCompany])
    REFERENCES [dbo].[DeliveryCompanies]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Courier_DeliveryCompany'
CREATE INDEX [IX_FK_Courier_DeliveryCompany]
ON [dbo].[Couriers]
    ([Fk_DeliveryCompany]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [Fk_WarehouseID] in table 'Couriers'
ALTER TABLE [dbo].[Couriers]
ADD CONSTRAINT [FK_Courier_Warehouse]
    FOREIGN KEY ([Fk_WarehouseID])
    REFERENCES [dbo].[Warehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Courier_Warehouse'
CREATE INDEX [IX_FK_Courier_Warehouse]
ON [dbo].[Couriers]
    ([Fk_WarehouseID]);
GO

-- Creating foreign key on [Fk_BranchID] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [FK_Warehouse_Branch]
    FOREIGN KEY ([Fk_BranchID])
    REFERENCES [dbo].[Branches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Warehouse_Branch'
CREATE INDEX [IX_FK_Warehouse_Branch]
ON [dbo].[Warehouses]
    ([Fk_BranchID]);
GO

-- Creating foreign key on [Fk_ShipperID] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [FK_Warehouse_CompanyAccount]
    FOREIGN KEY ([Fk_ShipperID])
    REFERENCES [dbo].[CompanyAccounts]
        ([CompanyAccountID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Warehouse_CompanyAccount'
CREATE INDEX [IX_FK_Warehouse_CompanyAccount]
ON [dbo].[Warehouses]
    ([Fk_ShipperID]);
GO

-- Creating foreign key on [Fk_Consignee] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [FK_Warehouse_CompanyAccount1]
    FOREIGN KEY ([Fk_Consignee])
    REFERENCES [dbo].[CompanyAccounts]
        ([CompanyAccountID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Warehouse_CompanyAccount1'
CREATE INDEX [IX_FK_Warehouse_CompanyAccount1]
ON [dbo].[Warehouses]
    ([Fk_Consignee]);
GO

-- Creating foreign key on [Fk_Agent] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [FK_Warehouse_CompanyAccount2]
    FOREIGN KEY ([Fk_Agent])
    REFERENCES [dbo].[CompanyAccounts]
        ([CompanyAccountID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Warehouse_CompanyAccount2'
CREATE INDEX [IX_FK_Warehouse_CompanyAccount2]
ON [dbo].[Warehouses]
    ([Fk_Agent]);
GO

-- Creating foreign key on [Fk_CountryID] in table 'CompanyAccounts'
ALTER TABLE [dbo].[CompanyAccounts]
ADD CONSTRAINT [FK_CompanyAccount_Country]
    FOREIGN KEY ([Fk_CountryID])
    REFERENCES [dbo].[Countries]
        ([CountryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyAccount_Country'
CREATE INDEX [IX_FK_CompanyAccount_Country]
ON [dbo].[CompanyAccounts]
    ([Fk_CountryID]);
GO

-- Creating foreign key on [Fk_Account] in table 'NotificationAccountRelations'
ALTER TABLE [dbo].[NotificationAccountRelations]
ADD CONSTRAINT [FK_NotificationAccountRelation_CompanyAccount]
    FOREIGN KEY ([Fk_Account])
    REFERENCES [dbo].[CompanyAccounts]
        ([CompanyAccountID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NotificationAccountRelation_CompanyAccount'
CREATE INDEX [IX_FK_NotificationAccountRelation_CompanyAccount]
ON [dbo].[NotificationAccountRelations]
    ([Fk_Account]);
GO

-- Creating foreign key on [Fk_Notification] in table 'NotificationAccountRelations'
ALTER TABLE [dbo].[NotificationAccountRelations]
ADD CONSTRAINT [FK_NotificationAccountRelation_Notification]
    FOREIGN KEY ([Fk_Notification])
    REFERENCES [dbo].[Notifications]
        ([NotificationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NotificationAccountRelation_Notification'
CREATE INDEX [IX_FK_NotificationAccountRelation_Notification]
ON [dbo].[NotificationAccountRelations]
    ([Fk_Notification]);
GO

-- Creating foreign key on [Fk_AccountID] in table 'AccountClasificationRelations'
ALTER TABLE [dbo].[AccountClasificationRelations]
ADD CONSTRAINT [FK_AccountClasificationRelation_AccountClasification]
    FOREIGN KEY ([Fk_AccountID])
    REFERENCES [dbo].[AccountClasifications]
        ([AccountClasificationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountClasificationRelation_AccountClasification'
CREATE INDEX [IX_FK_AccountClasificationRelation_AccountClasification]
ON [dbo].[AccountClasificationRelations]
    ([Fk_AccountID]);
GO

-- Creating foreign key on [Fk_ClasificationID] in table 'AccountClasificationRelations'
ALTER TABLE [dbo].[AccountClasificationRelations]
ADD CONSTRAINT [FK_AccountClasificationRelation_CompanyAccount]
    FOREIGN KEY ([Fk_ClasificationID])
    REFERENCES [dbo].[CompanyAccounts]
        ([CompanyAccountID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountClasificationRelation_CompanyAccount'
CREATE INDEX [IX_FK_AccountClasificationRelation_CompanyAccount]
ON [dbo].[AccountClasificationRelations]
    ([Fk_ClasificationID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------