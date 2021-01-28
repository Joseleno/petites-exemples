IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [Nom] VARCHAR(80) NOT NULL,
    [Tel] CHAR(11) NULL,
    [CEP] CHAR(8) NOT NULL,
    [Province] CHAR(2) NOT NULL,
    [Ville] nvarchar(60) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Produits] (
    [Id] int NOT NULL IDENTITY,
    [Codebarre] VARCHAR(80) NOT NULL,
    [Description] VARCHAR(60) NULL,
    [Valeur] decimal(18,2) NOT NULL,
    [TypeProduit] nvarchar(max) NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Produits] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Commandes] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [Debut] datetime2 NOT NULL DEFAULT (GETDATE()),
    [Fin] datetime2 NOT NULL,
    [TypeLivraison] nvarchar(max) NOT NULL,
    [StatutCommande] nvarchar(max) NOT NULL,
    [Remarque] VARCHAR(512) NULL,
    CONSTRAINT [PK_Commandes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Commandes_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ItensCommandes] (
    [Id] int NOT NULL IDENTITY,
    [CommandeId] int NOT NULL,
    [ProduitId] int NOT NULL,
    [Quantite] int NOT NULL DEFAULT 1,
    [Valeur] decimal(18,2) NOT NULL,
    [Remise] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ItensCommandes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ItensCommandes_Commandes_CommandeId] FOREIGN KEY ([CommandeId]) REFERENCES [Commandes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItensCommandes_Produits_ProduitId] FOREIGN KEY ([ProduitId]) REFERENCES [Produits] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [idx_client_tel] ON [Clients] ([Tel]);

GO

CREATE INDEX [IX_Commandes_ClientId] ON [Commandes] ([ClientId]);

GO

CREATE INDEX [IX_ItensCommandes_CommandeId] ON [ItensCommandes] ([CommandeId]);

GO

CREATE INDEX [IX_ItensCommandes_ProduitId] ON [ItensCommandes] ([ProduitId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210126034121_FirstMigration', N'3.1.5');

GO

