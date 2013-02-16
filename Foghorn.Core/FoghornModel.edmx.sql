
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/15/2013 18:45:53
-- Generated from EDMX file: C:\Development\Foghorn\Foghorn.Core\FoghornModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Foghorn];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SubscriberNotification_Subscriber]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubscriberNotification] DROP CONSTRAINT [FK_SubscriberNotification_Subscriber];
GO
IF OBJECT_ID(N'[dbo].[FK_SubscriberNotification_Notification]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubscriberNotification] DROP CONSTRAINT [FK_SubscriberNotification_Notification];
GO
IF OBJECT_ID(N'[dbo].[FK_SendingApplicationSubscriber]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subscribers] DROP CONSTRAINT [FK_SendingApplicationSubscriber];
GO
IF OBJECT_ID(N'[dbo].[FK_NotificationNotificationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notifications] DROP CONSTRAINT [FK_NotificationNotificationType];
GO
IF OBJECT_ID(N'[dbo].[FK_SendingApplicationNotificationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NotificationTypes] DROP CONSTRAINT [FK_SendingApplicationNotificationType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Subscribers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subscribers];
GO
IF OBJECT_ID(N'[dbo].[Notifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notifications];
GO
IF OBJECT_ID(N'[dbo].[SendingApplications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SendingApplications];
GO
IF OBJECT_ID(N'[dbo].[NotificationTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NotificationTypes];
GO
IF OBJECT_ID(N'[dbo].[SubscriberNotification]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubscriberNotification];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Subscribers'
CREATE TABLE [dbo].[Subscribers] (
    [SubscriberId] uniqueidentifier  NOT NULL,
    [SubscriberName] nvarchar(255)  NOT NULL,
    [Port] int  NULL,
    [HostName] nvarchar(255)  NOT NULL,
    [Password] nvarchar(20)  NOT NULL,
    [SendingApplication_SendingApplicationId] int  NOT NULL
);
GO

-- Creating table 'Notifications'
CREATE TABLE [dbo].[Notifications] (
    [NotificationId] int IDENTITY(1,1) NOT NULL,
    [NotificationTitle] nvarchar(max)  NOT NULL,
    [NotificationMessage] nvarchar(max)  NOT NULL,
    [SentDateTime] datetime  NOT NULL,
    [Priority] int  NOT NULL,
    [Sticky] bit  NOT NULL,
    [NotificationType_NotificationTypeId] int  NOT NULL
);
GO

-- Creating table 'SendingApplications'
CREATE TABLE [dbo].[SendingApplications] (
    [SendingApplicationId] int IDENTITY(1,1) NOT NULL,
    [SendingApplicationName] nvarchar(255)  NOT NULL,
    [SendingApplicationIcon] varbinary(max)  NULL
);
GO

-- Creating table 'NotificationTypes'
CREATE TABLE [dbo].[NotificationTypes] (
    [NotificationTypeId] int IDENTITY(1,1) NOT NULL,
    [NotificationTypeName] nvarchar(32)  NOT NULL,
    [NotificationTypeDisplayName] nvarchar(255)  NOT NULL,
    [NotificationTypeIcon] varbinary(max)  NULL,
    [SendingApplication_SendingApplicationId] int  NOT NULL
);
GO

-- Creating table 'SubscriberNotification'
CREATE TABLE [dbo].[SubscriberNotification] (
    [SentToSubscribers_SubscriberId] uniqueidentifier  NOT NULL,
    [NotificationsSent_NotificationId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [SubscriberId] in table 'Subscribers'
ALTER TABLE [dbo].[Subscribers]
ADD CONSTRAINT [PK_Subscribers]
    PRIMARY KEY CLUSTERED ([SubscriberId] ASC);
GO

-- Creating primary key on [NotificationId] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [PK_Notifications]
    PRIMARY KEY CLUSTERED ([NotificationId] ASC);
GO

-- Creating primary key on [SendingApplicationId] in table 'SendingApplications'
ALTER TABLE [dbo].[SendingApplications]
ADD CONSTRAINT [PK_SendingApplications]
    PRIMARY KEY CLUSTERED ([SendingApplicationId] ASC);
GO

-- Creating primary key on [NotificationTypeId] in table 'NotificationTypes'
ALTER TABLE [dbo].[NotificationTypes]
ADD CONSTRAINT [PK_NotificationTypes]
    PRIMARY KEY CLUSTERED ([NotificationTypeId] ASC);
GO

-- Creating primary key on [SentToSubscribers_SubscriberId], [NotificationsSent_NotificationId] in table 'SubscriberNotification'
ALTER TABLE [dbo].[SubscriberNotification]
ADD CONSTRAINT [PK_SubscriberNotification]
    PRIMARY KEY NONCLUSTERED ([SentToSubscribers_SubscriberId], [NotificationsSent_NotificationId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SentToSubscribers_SubscriberId] in table 'SubscriberNotification'
ALTER TABLE [dbo].[SubscriberNotification]
ADD CONSTRAINT [FK_SubscriberNotification_Subscriber]
    FOREIGN KEY ([SentToSubscribers_SubscriberId])
    REFERENCES [dbo].[Subscribers]
        ([SubscriberId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [NotificationsSent_NotificationId] in table 'SubscriberNotification'
ALTER TABLE [dbo].[SubscriberNotification]
ADD CONSTRAINT [FK_SubscriberNotification_Notification]
    FOREIGN KEY ([NotificationsSent_NotificationId])
    REFERENCES [dbo].[Notifications]
        ([NotificationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SubscriberNotification_Notification'
CREATE INDEX [IX_FK_SubscriberNotification_Notification]
ON [dbo].[SubscriberNotification]
    ([NotificationsSent_NotificationId]);
GO

-- Creating foreign key on [SendingApplication_SendingApplicationId] in table 'Subscribers'
ALTER TABLE [dbo].[Subscribers]
ADD CONSTRAINT [FK_SendingApplicationSubscriber]
    FOREIGN KEY ([SendingApplication_SendingApplicationId])
    REFERENCES [dbo].[SendingApplications]
        ([SendingApplicationId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SendingApplicationSubscriber'
CREATE INDEX [IX_FK_SendingApplicationSubscriber]
ON [dbo].[Subscribers]
    ([SendingApplication_SendingApplicationId]);
GO

-- Creating foreign key on [NotificationType_NotificationTypeId] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [FK_NotificationNotificationType]
    FOREIGN KEY ([NotificationType_NotificationTypeId])
    REFERENCES [dbo].[NotificationTypes]
        ([NotificationTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NotificationNotificationType'
CREATE INDEX [IX_FK_NotificationNotificationType]
ON [dbo].[Notifications]
    ([NotificationType_NotificationTypeId]);
GO

-- Creating foreign key on [SendingApplication_SendingApplicationId] in table 'NotificationTypes'
ALTER TABLE [dbo].[NotificationTypes]
ADD CONSTRAINT [FK_SendingApplicationNotificationType]
    FOREIGN KEY ([SendingApplication_SendingApplicationId])
    REFERENCES [dbo].[SendingApplications]
        ([SendingApplicationId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SendingApplicationNotificationType'
CREATE INDEX [IX_FK_SendingApplicationNotificationType]
ON [dbo].[NotificationTypes]
    ([SendingApplication_SendingApplicationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------