IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Brand] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Concentration] (
    [ID] int NOT NULL IDENTITY,
    [Type] nvarchar(max) NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_Concentration] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Gender] (
    [ID] int NOT NULL IDENTITY,
    [Type] nvarchar(max) NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_Gender] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Stock] (
    [ID] int NOT NULL IDENTITY,
    [Amount] int NOT NULL,
    [PerfumeID] int NOT NULL,
    [PerfumeryID] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_Stock] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [UserCategories] (
    [ID] int NOT NULL IDENTITY,
    [Category] nvarchar(max) NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_UserCategories] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [UserCategory] (
    [ID] int NOT NULL IDENTITY,
    [Type] nvarchar(max) NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_UserCategory] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Perfumery] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Address] nvarchar(50) NOT NULL,
    [StockID] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_Perfumery] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Perfumery_Stock_StockID] FOREIGN KEY ([StockID]) REFERENCES [Stock] ([ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [User] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [CategoryID] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_User_UserCategories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [UserCategories] ([ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Perfume] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [Cost] int NOT NULL,
    [BrandID] nvarchar(50) NOT NULL,
    [VolumeID] int NOT NULL,
    [GenderID] int NOT NULL,
    [ConcentrationID] int NOT NULL,
    [BrandID1] int NOT NULL,
    [StockID] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_Perfume] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Perfume_Brand_BrandID1] FOREIGN KEY ([BrandID1]) REFERENCES [Brand] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Perfume_Concentration_ConcentrationID] FOREIGN KEY ([ConcentrationID]) REFERENCES [Concentration] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Perfume_Gender_GenderID] FOREIGN KEY ([GenderID]) REFERENCES [Gender] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Perfume_Stock_StockID] FOREIGN KEY ([StockID]) REFERENCES [Stock] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Perfume_UserCategory_VolumeID] FOREIGN KEY ([VolumeID]) REFERENCES [UserCategory] ([ID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Perfume_BrandID1] ON [Perfume] ([BrandID1]);
GO

CREATE INDEX [IX_Perfume_ConcentrationID] ON [Perfume] ([ConcentrationID]);
GO

CREATE INDEX [IX_Perfume_GenderID] ON [Perfume] ([GenderID]);
GO

CREATE INDEX [IX_Perfume_StockID] ON [Perfume] ([StockID]);
GO

CREATE INDEX [IX_Perfume_VolumeID] ON [Perfume] ([VolumeID]);
GO

CREATE INDEX [IX_Perfumery_StockID] ON [Perfumery] ([StockID]);
GO

CREATE UNIQUE INDEX [IX_User_CategoryID] ON [User] ([CategoryID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230501162341_MigrationsInitial', N'6.0.16');
GO

COMMIT;
GO

