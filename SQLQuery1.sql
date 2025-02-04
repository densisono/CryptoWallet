-- Crear Base de Datos
CREATE DATABASE CryptoWalletDB
GO

USE CryptoWalletDB
GO

-- Crear Esquema
CREATE SCHEMA crypto
GO

-- Tablas Base
CREATE TABLE crypto.Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    TwoFactorEnabled BIT DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    LastLogin DATETIME2,
    IsActive BIT DEFAULT 1,
    CONSTRAINT UQ_Users_Email UNIQUE (Email)
)
GO

CREATE TABLE crypto.UserProfiles (
    ProfileId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    PreferredCurrency NVARCHAR(10) DEFAULT 'USD',
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2,
    CONSTRAINT FK_UserProfiles_Users FOREIGN KEY (UserId) REFERENCES crypto.Users(UserId)
)
GO

CREATE TABLE crypto.WalletTypes (
    WalletTypeId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
)
GO

CREATE TABLE crypto.Wallets (
    WalletId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    WalletTypeId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2,
    IsActive BIT DEFAULT 1,
    CONSTRAINT FK_Wallets_Users FOREIGN KEY (UserId) REFERENCES crypto.Users(UserId),
    CONSTRAINT FK_Wallets_WalletTypes FOREIGN KEY (WalletTypeId) REFERENCES crypto.WalletTypes(WalletTypeId)
)
GO

CREATE TABLE crypto.WalletAddresses (
    AddressId INT PRIMARY KEY IDENTITY(1,1),
    WalletId INT NOT NULL,
    Address NVARCHAR(MAX) NOT NULL,
    EncryptedRecoveryPhrase VARBINARY(MAX),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2,
    IsActive BIT DEFAULT 1,
    CONSTRAINT FK_WalletAddresses_Wallets FOREIGN KEY (WalletId) REFERENCES crypto.Wallets(WalletId)
)
GO

CREATE TABLE crypto.Cryptocurrencies (
    CryptoId INT PRIMARY KEY IDENTITY(1,1),
    Symbol NVARCHAR(20) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2,
    CONSTRAINT UQ_Cryptocurrencies_Symbol UNIQUE (Symbol)
)
GO

CREATE TABLE crypto.FiatCurrencies (
    FiatId INT PRIMARY KEY IDENTITY(1,1),
    Code NVARCHAR(10) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    Symbol NVARCHAR(5),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2,
    CONSTRAINT UQ_FiatCurrencies_Code UNIQUE (Code)
)
GO

CREATE TABLE crypto.PriceHistory (
    PriceId INT PRIMARY KEY IDENTITY(1,1),
    CryptoId INT NOT NULL,
    FiatCurrencyId INT NOT NULL,
    Price DECIMAL(18,8) NOT NULL,
    Timestamp DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_PriceHistory_Cryptocurrencies FOREIGN KEY (CryptoId) REFERENCES crypto.Cryptocurrencies(CryptoId),
    CONSTRAINT FK_PriceHistory_FiatCurrencies FOREIGN KEY (FiatCurrencyId) REFERENCES crypto.FiatCurrencies(FiatId)
)
GO

-- Índices
CREATE INDEX IX_Users_Email ON crypto.Users(Email)
CREATE INDEX IX_Wallets_UserId ON crypto.Wallets(UserId)
CREATE INDEX IX_WalletAddresses_WalletId ON crypto.WalletAddresses(WalletId)
CREATE INDEX IX_PriceHistory_CryptoId ON crypto.PriceHistory(CryptoId)
GO

-- Datos Iniciales
INSERT INTO crypto.FiatCurrencies (Code, Name, Symbol) VALUES 
('USD', 'US Dollar', '$'),
('EUR', 'Euro', '€'),
('DOP', 'Dominican Peso', 'RD$')
GO

INSERT INTO crypto.WalletTypes (Name, Description) VALUES 
('Hardware Wallet', 'Physical cryptocurrency wallet device'),
('Software Wallet', 'Desktop or mobile application wallet'),
('Paper Wallet', 'Physical document containing crypto keys'),
('Exchange Wallet', 'Wallet hosted on cryptocurrency exchange')
GO

-- Agregar campos de seguridad a las tablas existentes
ALTER TABLE crypto.Users
ADD TwoFactorSecret NVARCHAR(MAX) NULL,
    LastTokenResetTime DATETIME2 NULL,
    FailedLoginAttempts INT DEFAULT 0,
    LockoutEnd DATETIME2 NULL;

-- Tabla para tokens de recuperación
CREATE TABLE crypto.RecoveryTokens (
    TokenId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    Token NVARCHAR(100) NOT NULL,
    ExpirationDate DATETIME2 NOT NULL,
    IsUsed BIT DEFAULT 0,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT FK_RecoveryTokens_Users FOREIGN KEY (UserId) 
        REFERENCES crypto.Users(UserId)
);

-- Tabla para registro de actividad de seguridad
CREATE TABLE crypto.SecurityAuditLog (
    LogId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    EventType NVARCHAR(50) NOT NULL,
    EventDescription NVARCHAR(MAX),
    IpAddress NVARCHAR(50),
    UserAgent NVARCHAR(500),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT FK_SecurityAuditLog_Users FOREIGN KEY (UserId) 
        REFERENCES crypto.Users(UserId)
);

-- Índices para seguridad
CREATE INDEX IX_Users_Email_PasswordHash ON crypto.Users(Email, PasswordHash);
CREATE INDEX IX_RecoveryTokens_Token ON crypto.RecoveryTokens(Token);
CREATE INDEX IX_SecurityAuditLog_UserId_EventType ON 
    crypto.SecurityAuditLog(UserId, EventType);

-- Tablas para métricas y monitoreo
CREATE TABLE crypto.PerformanceMetrics (
    MetricId INT PRIMARY KEY IDENTITY(1,1),
    MetricName NVARCHAR(100) NOT NULL,
    MetricValue FLOAT NOT NULL,
    Timestamp DATETIME2 NOT NULL DEFAULT GETDATE(),
    Tags NVARCHAR(MAX)
);

CREATE TABLE crypto.AlertRules (
    RuleId INT PRIMARY KEY IDENTITY(1,1),
    MetricName NVARCHAR(100) NOT NULL,
    Condition NVARCHAR(50) NOT NULL,
    Threshold FLOAT NOT NULL,
    NotificationChannel NVARCHAR(50) NOT NULL,
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2
);

CREATE TABLE crypto.AlertHistory (
    AlertId INT PRIMARY KEY IDENTITY(1,1),
    RuleId INT NOT NULL,
    MetricValue FLOAT NOT NULL,
    Triggered DATETIME2 DEFAULT GETDATE(),
    NotificationSent BIT DEFAULT 0,
    CONSTRAINT FK_AlertHistory_Rules FOREIGN KEY (RuleId) 
        REFERENCES crypto.AlertRules(RuleId)
);

-- Tablas para reportes
CREATE TABLE crypto.Reports (
    ReportId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    ReportType NVARCHAR(50) NOT NULL,
    GeneratedDate DATETIME2 DEFAULT GETDATE(),
    ReportData VARBINARY(MAX),
    CONSTRAINT FK_Reports_Users FOREIGN KEY (UserId) 
        REFERENCES crypto.Users(UserId)
);

-- Índices
CREATE INDEX IX_PerformanceMetrics_MetricName_Timestamp 
    ON crypto.PerformanceMetrics(MetricName, Timestamp);
CREATE INDEX IX_AlertRules_MetricName 
    ON crypto.AlertRules(MetricName);
CREATE INDEX IX_Reports_UserId_ReportType 
    ON crypto.Reports(UserId, ReportType);