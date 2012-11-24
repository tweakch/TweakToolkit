
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/24/2012 14:32:33
-- Generated from EDMX file: C:\Users\aklee\Documents\Visual Studio 2010\Projects\Tweak\TweakToolkit\TweakToolkitSolution\TweakToolkit.WCF.Test\Data\WebsiteDataEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [struktoData];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[StruktoDataModelStoreContainer].[cat_ProductPriceDataView]', 'U') IS NOT NULL
    DROP TABLE [StruktoDataModelStoreContainer].[cat_ProductPriceDataView];
GO
IF OBJECT_ID(N'[StruktoDataModelStoreContainer].[cat_ProductsForWebsite]', 'U') IS NOT NULL
    DROP TABLE [StruktoDataModelStoreContainer].[cat_ProductsForWebsite];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'cat_ProductsForWebsite'
CREATE TABLE [dbo].[cat_ProductsForWebsite] (
    [Valor] int  NOT NULL,
    [Name] nvarchar(120)  NOT NULL,
    [NameEN] nvarchar(120)  NOT NULL,
    [IsOnline] bit  NOT NULL,
    [IsPriceDirty] bit  NOT NULL,
    [EmissionPrice] float  NOT NULL,
    [Notional] int  NOT NULL,
    [SmallestTradeableUnit] int  NOT NULL,
    [Guarantor] nvarchar(max)  NULL,
    [GuarantorShort] nvarchar(max)  NULL,
    [Issuer] nvarchar(max)  NULL,
    [IssuerShort] nvarchar(max)  NULL,
    [LeadManager] nvarchar(max)  NULL,
    [LeadManagerShort] nvarchar(max)  NULL,
    [AssetClass] nvarchar(50)  NOT NULL,
    [AssetClassEn] nvarchar(50)  NOT NULL,
    [ProductCategory] nvarchar(50)  NOT NULL,
    [ProductCategoryEn] nvarchar(50)  NOT NULL,
    [ProductState] nvarchar(50)  NOT NULL,
    [ProductStateEn] nvarchar(50)  NOT NULL,
    [ProductType] nvarchar(50)  NOT NULL,
    [ProductTypeEn] nvarchar(50)  NOT NULL,
    [Currency] nvarchar(50)  NOT NULL,
    [CurrencyRisk] nvarchar(50)  NOT NULL,
    [CurrencyRiskEn] nvarchar(50)  NOT NULL,
    [Pricing] nvarchar(50)  NOT NULL,
    [PricingEn] nvarchar(50)  NOT NULL,
    [ValutaDate] datetime  NULL,
    [RedemptionDate] datetime  NULL,
    [StartFixationDate] datetime  NULL,
    [EndFixationDate] datetime  NULL,
    [HasEndFixation] bit  NOT NULL,
    [CouponObservation] nvarchar(50)  NOT NULL,
    [ConditionalObservation] nvarchar(50)  NOT NULL,
    [FloaterObservation] nvarchar(50)  NOT NULL,
    [ProtectionType] nvarchar(50)  NOT NULL,
    [CallData] nvarchar(50)  NOT NULL,
    [CallDataEn] nvarchar(50)  NOT NULL,
    [EarlyRedemption] nvarchar(50)  NOT NULL,
    [EarlyRedemptionEn] nvarchar(50)  NOT NULL,
    [ISIN] nvarchar(max)  NOT NULL,
    [StockExchange] nvarchar(max)  NOT NULL,
    [CouponGuaranteed] nvarchar(max)  NULL,
    [CouponConditional] nvarchar(max)  NULL,
    [TextCouponConditional] nvarchar(max)  NULL,
    [Floater] nvarchar(max)  NULL,
    [TextFloater] nvarchar(max)  NULL,
    [CouponMinimal] nvarchar(max)  NULL,
    [CouponMaximal] nvarchar(max)  NULL,
    [TextCoupon] nvarchar(max)  NULL,
    [TextEarlyRedemption] nvarchar(max)  NULL,
    [Cap] nvarchar(max)  NULL,
    [PaybackMaximal] nvarchar(max)  NULL,
    [TextPaybackMaximal] nvarchar(max)  NULL,
    [Protection] nvarchar(max)  NULL,
    [PaybackMinimal] nvarchar(max)  NULL,
    [Participation] nvarchar(max)  NULL,
    [TextParticipation] nvarchar(max)  NULL,
    [Discount] nvarchar(max)  NULL,
    [MaxYield] nvarchar(max)  NULL,
    [BonusLevel] nvarchar(max)  NULL,
    [ProductCategoryValue] int  NULL,
    [ProductTypeValue] int  NOT NULL,
    [EmissionTypeDescription] nvarchar(max)  NOT NULL,
    [Symbol] nvarchar(max)  NOT NULL,
    [Additional1Text] nvarchar(max)  NULL,
    [Additional1Value] nvarchar(max)  NULL,
    [Additional2Text] nvarchar(max)  NULL,
    [Additional2Value] nvarchar(max)  NULL,
    [Additional3Text] nvarchar(max)  NULL,
    [Additional3Value] nvarchar(max)  NULL,
    [CouponGuaranteedEN] nvarchar(max)  NULL,
    [CouponConditionalEN] nvarchar(max)  NULL,
    [FloaterEN] nvarchar(max)  NULL,
    [TextFloaterEN] nvarchar(max)  NULL,
    [CouponMinimalEN] nvarchar(max)  NULL,
    [CouponMaximalEN] nvarchar(max)  NULL,
    [TextCouponEN] nvarchar(max)  NULL,
    [TextEarlyRedemptionEN] nvarchar(max)  NULL,
    [CapEN] nvarchar(max)  NULL,
    [MaxYieldEN] nvarchar(max)  NULL,
    [TextPaybackMaximalEN] nvarchar(max)  NULL,
    [ProtectionEN] nvarchar(max)  NULL,
    [ParticipationEN] nvarchar(max)  NULL,
    [TextParticipationEN] nvarchar(max)  NULL,
    [DiscountEN] nvarchar(max)  NULL,
    [BonusLevelEN] nvarchar(max)  NULL,
    [PaybackMaximaEN] nvarchar(max)  NULL,
    [TextCouponConditionalEN] nvarchar(max)  NULL,
    [PaybackMinimalEN] nvarchar(max)  NULL,
    [Additional1TextEN] nvarchar(max)  NULL,
    [Additional1ValueEN] nvarchar(max)  NULL,
    [Additional2TextEN] nvarchar(max)  NULL,
    [Additional2ValueEN] nvarchar(max)  NULL,
    [Additional3TextEN] nvarchar(max)  NULL,
    [Additional3ValueEN] nvarchar(max)  NULL,
    [CouponObservationEn] nvarchar(50)  NOT NULL,
    [ConditionalObservationEn] nvarchar(50)  NOT NULL,
    [FloaterObservationEn] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Valor], [Name], [NameEN], [IsOnline], [IsPriceDirty], [EmissionPrice], [Notional], [SmallestTradeableUnit], [AssetClass], [AssetClassEn], [ProductCategory], [ProductCategoryEn], [ProductState], [ProductStateEn], [ProductType], [ProductTypeEn], [Currency], [CurrencyRisk], [CurrencyRiskEn], [Pricing], [PricingEn], [HasEndFixation], [CouponObservation], [ConditionalObservation], [FloaterObservation], [ProtectionType], [CallData], [CallDataEn], [EarlyRedemption], [EarlyRedemptionEn], [ISIN], [StockExchange], [ProductTypeValue], [EmissionTypeDescription], [Symbol], [CouponObservationEn], [ConditionalObservationEn], [FloaterObservationEn] in table 'cat_ProductsForWebsite'
ALTER TABLE [dbo].[cat_ProductsForWebsite]
ADD CONSTRAINT [PK_cat_ProductsForWebsite]
    PRIMARY KEY CLUSTERED ([Valor], [Name], [NameEN], [IsOnline], [IsPriceDirty], [EmissionPrice], [Notional], [SmallestTradeableUnit], [AssetClass], [AssetClassEn], [ProductCategory], [ProductCategoryEn], [ProductState], [ProductStateEn], [ProductType], [ProductTypeEn], [Currency], [CurrencyRisk], [CurrencyRiskEn], [Pricing], [PricingEn], [HasEndFixation], [CouponObservation], [ConditionalObservation], [FloaterObservation], [ProtectionType], [CallData], [CallDataEn], [EarlyRedemption], [EarlyRedemptionEn], [ISIN], [StockExchange], [ProductTypeValue], [EmissionTypeDescription], [Symbol], [CouponObservationEn], [ConditionalObservationEn], [FloaterObservationEn] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------