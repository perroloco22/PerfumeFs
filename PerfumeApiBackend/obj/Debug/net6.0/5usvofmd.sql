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

CREATE TABLE [Perfumery] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Address] nvarchar(50) NOT NULL,
    [PerfumeID] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_Perfumery] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Perfume] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [Notes] nvarchar(50) NOT NULL,
    [Brand] nvarchar(50) NOT NULL,
    [Volume] int NOT NULL,
    [Gender] int NOT NULL,
    [Price] int NOT NULL,
    [PerfumeryID] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NULL,
    [DeleteAt] datetime2 NULL,
    CONSTRAINT [PK_Perfume] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Perfume_Perfumery_PerfumeryID] FOREIGN KEY ([PerfumeryID]) REFERENCES [Perfumery] ([ID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Perfume_PerfumeryID] ON [Perfume] ([PerfumeryID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230421234754_Created Db', N'6.0.16');
GO

COMMIT;
GO

