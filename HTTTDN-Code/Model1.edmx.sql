
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/30/2017 13:30:27
-- Generated from EDMX file: D:\CNTT\HTTT doanh nghiep\HTTTDN-Code\HTTTDN-Code\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QLMa];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_NguoiDungLogDangNhap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogDangNhaps] DROP CONSTRAINT [FK_NguoiDungLogDangNhap];
GO
IF OBJECT_ID(N'[dbo].[FK_NguoiDungLogDangXuat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogDangXuats] DROP CONSTRAINT [FK_NguoiDungLogDangXuat];
GO
IF OBJECT_ID(N'[dbo].[FK_NguoiDungMa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mas] DROP CONSTRAINT [FK_NguoiDungMa];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LogDangNhaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogDangNhaps];
GO
IF OBJECT_ID(N'[dbo].[LogDangXuats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogDangXuats];
GO
IF OBJECT_ID(N'[dbo].[LSKhoas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LSKhoas];
GO
IF OBJECT_ID(N'[dbo].[Mas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mas];
GO
IF OBJECT_ID(N'[dbo].[NguoiDungs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NguoiDungs];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LogDangNhaps'
CREATE TABLE [dbo].[LogDangNhaps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ThoiGianDN] datetime  NOT NULL,
    [IdND] int  NOT NULL
);
GO

-- Creating table 'LogDangXuats'
CREATE TABLE [dbo].[LogDangXuats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ThoiGianDX] datetime  NOT NULL,
    [IdND] int  NOT NULL
);
GO

-- Creating table 'LSKhoas'
CREATE TABLE [dbo].[LSKhoas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdDTKhoa] int  NOT NULL,
    [ThoiGianKhoa] datetime  NOT NULL,
    [LiDoKhoa] nvarchar(max)  NOT NULL,
    [SoNgayKhoa] int  NOT NULL,
    [DoiTuong] bit  NOT NULL
);
GO

-- Creating table 'Mas'
CREATE TABLE [dbo].[Mas] (
    [IdMa] int IDENTITY(1,1) NOT NULL,
    [NoiDung] nvarchar(max)  NOT NULL,
    [TrangThai] int  NOT NULL,
    [ThoiGianKhoiTao] datetime  NOT NULL,
    [ThoiGianHetHan] datetime  NOT NULL,
    [ThoiGianLay] datetime  NULL,
    [IDNguoiLay] int  NULL,
    [IDNguoiTao] int  NOT NULL,
    [SoKiTu] int  NOT NULL
);
GO

-- Creating table 'NguoiDungs'
CREATE TABLE [dbo].[NguoiDungs] (
    [IdND] int IDENTITY(1,1) NOT NULL,
    [TaiKhoan] nvarchar(max)  NOT NULL,
    [MatKhau] nvarchar(max)  NOT NULL,
    [TenNhanVien] nvarchar(max)  NOT NULL,
    [ChucVu] bit  NOT NULL,
    [TrangThai] bit  NOT NULL,
    [ChuThich] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'LogDangNhaps'
ALTER TABLE [dbo].[LogDangNhaps]
ADD CONSTRAINT [PK_LogDangNhaps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogDangXuats'
ALTER TABLE [dbo].[LogDangXuats]
ADD CONSTRAINT [PK_LogDangXuats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LSKhoas'
ALTER TABLE [dbo].[LSKhoas]
ADD CONSTRAINT [PK_LSKhoas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdMa] in table 'Mas'
ALTER TABLE [dbo].[Mas]
ADD CONSTRAINT [PK_Mas]
    PRIMARY KEY CLUSTERED ([IdMa] ASC);
GO

-- Creating primary key on [IdND] in table 'NguoiDungs'
ALTER TABLE [dbo].[NguoiDungs]
ADD CONSTRAINT [PK_NguoiDungs]
    PRIMARY KEY CLUSTERED ([IdND] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdND] in table 'LogDangNhaps'
ALTER TABLE [dbo].[LogDangNhaps]
ADD CONSTRAINT [FK_NguoiDungLogDangNhap]
    FOREIGN KEY ([IdND])
    REFERENCES [dbo].[NguoiDungs]
        ([IdND])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NguoiDungLogDangNhap'
CREATE INDEX [IX_FK_NguoiDungLogDangNhap]
ON [dbo].[LogDangNhaps]
    ([IdND]);
GO

-- Creating foreign key on [IdND] in table 'LogDangXuats'
ALTER TABLE [dbo].[LogDangXuats]
ADD CONSTRAINT [FK_NguoiDungLogDangXuat]
    FOREIGN KEY ([IdND])
    REFERENCES [dbo].[NguoiDungs]
        ([IdND])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NguoiDungLogDangXuat'
CREATE INDEX [IX_FK_NguoiDungLogDangXuat]
ON [dbo].[LogDangXuats]
    ([IdND]);
GO

-- Creating foreign key on [IDNguoiTao] in table 'Mas'
ALTER TABLE [dbo].[Mas]
ADD CONSTRAINT [FK_NguoiDungMa]
    FOREIGN KEY ([IDNguoiTao])
    REFERENCES [dbo].[NguoiDungs]
        ([IdND])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NguoiDungMa'
CREATE INDEX [IX_FK_NguoiDungMa]
ON [dbo].[Mas]
    ([IDNguoiTao]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------