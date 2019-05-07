IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Orders] (
    [OrderID] int NOT NULL IDENTITY,
    [Shipped] bit NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Address1] nvarchar(max) NOT NULL,
    [Address2] nvarchar(max) NULL,
    [City] nvarchar(max) NOT NULL,
    [Zip] nvarchar(max) NULL,
    [Country] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID])
);

GO

CREATE TABLE [Products] (
    [ProductID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Price] decimal(18, 2) NOT NULL,
    [Category] nvarchar(max) NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID])
);

GO

CREATE TABLE [CartLine] (
    [CartLineID] int NOT NULL IDENTITY,
    [ProductID] int NULL,
    [Quantity] int NOT NULL,
    [OrderID] int NULL,
    CONSTRAINT [PK_CartLine] PRIMARY KEY ([CartLineID]),
    CONSTRAINT [FK_CartLine_Orders_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [Orders] ([OrderID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CartLine_Products_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [Products] ([ProductID]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_CartLine_OrderID] ON [CartLine] ([OrderID]);

GO

CREATE INDEX [IX_CartLine_ProductID] ON [CartLine] ([ProductID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190506143858_Initial', N'2.1.4-rtm-31024');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190506143916_Orders', N'2.1.4-rtm-31024');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190506143939_ShippedOrders', N'2.1.4-rtm-31024');

GO

