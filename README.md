# ECommerceDemo
ECommerce Demo with .NET Core, EF, DDD

Description:

- The Code simulates an e-commerce campaign period. 
- The campaign decreases the price of the products that are added to system.
- Every hour, 1 order is placed for 1 product with 10 volume demand to system if possible (stock).
- Orders are placed with instant price (affected from campaign).
- After campaign duration, price turns to its initial value. 

*Test Cases will be added.

Commands from Postman:

//create_product
(POST) api/product body->json
{
    "productCode": 1,
    "price": 200,
    "stock": 260
}

//get_product_info
(GET) api/product/{productCode}

//create_order
(POST) api/order body->json
{
    "productCode": 1,
    "quantity": 100
}

//create_campaign
(POST) api/campaign body->json
{
	"campaignName": "firstCampaign",
	"productCode": 1,
	"duration": 3,
	"priceManipulationLimit": 10,
	"targetSalesCount": 50,
	"status": true
}

//get_campaign_info
(GET) api/campaign/{campaignName}

//increase_time
(POST) api/time body->int

DB Script:

USE [test]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ProductCode] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Stock] [int] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CampaignId] [int] NULL,
	[Status] [bit] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Campaign](
	[CampaignId] [int] IDENTITY(1,1) NOT NULL,
	[CampaignName] [varchar](max) NOT NULL,
	[ProductCode] [int] NOT NULL,
	[Duration] [int] NOT NULL,
	[PriceManipulationLimit] [int] NOT NULL,
	[TargetSalesCount] [int] NOT NULL,
	[Status] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
