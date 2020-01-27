--drop table [dbo].[tblPromotion]
--drop table [dbo].[tblProductDetails]
--drop table [dbo].[tblDiscount]
--drop table [dbo].[tblCustomerTransaction]
--drop table [dbo].[tblTotalDetails]

Print 'Creating table tblPromotion'
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPromotion]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[tblPromotion](
	[PromotionId] nvarchar(50) NOT NULL,
	[PromotionName] nvarchar(200) NOT NULL,
	[Category] nvarchar(100) NOT NULL,
	[PointsPerDollar]INT NOT NULL,
	[dtmInserted] datetime,
	[StartDate] datetime,
	[EndDate] datetime,
	
 CONSTRAINT [PK_tblPromotion	] PRIMARY KEY CLUSTERED 
(
	[PromotionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]	

SET ANSI_PADDING OFF

Print 'Success.'
END
GO


Print 'Creating table tblProductDetails'
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblProductDetails]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[tblProductDetails](
	[ProductId] nvarchar(50) NOT NULL,
	[ProductName] nvarchar(200) NOT NULL,
	[Category] nvarchar(100) NOT NULL,
	[UnitPrice]FLOAT NOT NULL,
	[dtmInserted] datetime,
	
 CONSTRAINT [PK_tblProductDetails	] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]	

SET ANSI_PADDING OFF

ALTER TABLE [dbo].[tblProductDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblProductDetails_tblPromotion] FOREIGN KEY([Category])
REFERENCES [dbo].[tblPromotion] ([Category])

Print 'Success.'
END
GO

Print 'Creating table tblDiscount'
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblDiscount]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[tblDiscount](
	[DiscountId] nvarchar(50) NOT NULL,
	[DiscountPromotionName] nvarchar(200) NOT NULL,
	[dtmInserted] datetime,
	[Percent] float Not NULL,
	[StartDate] datetime,
	[EndDate] datetime,
	[ProductId] nvarchar(50) NOT NULL
	
 CONSTRAINT [PK_tblDiscount] PRIMARY KEY CLUSTERED 
(
	[DiscountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]	

SET ANSI_PADDING OFF

ALTER TABLE [dbo].[tblDiscount]  WITH CHECK ADD  CONSTRAINT [FK_tblProductDetails_tblDiscount] FOREIGN KEY([ProductId])
REFERENCES [dbo].[tblProductDetails] ([ProductId])

Print 'Success.'
END
GO

Print 'Creating table tblCustomerTransaction'
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCustomerTransaction]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[tblCustomerTransaction](

	[CustomerId][uniqueidentifier] NOT NULL,
	[LoyaltyCard] nvarchar(50) NOT NULL,
	[dtmTransaction] datetime,
	[dtmInserted] datetime

 CONSTRAINT [PK_tblCustomerTransactionn] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]	

SET ANSI_PADDING OFF

Print 'Success.'
END
GO

Print 'Creating table tblBasket'
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblBasket]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[tblBasket](

	[BasketID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId][uniqueidentifier] NOT NULL,
	[ProductId] nvarchar(50) NOT NULL,
	[Quantity] int  NOT NULL,
	[UnitPrice]FLOAT NOT NULL,


 CONSTRAINT [PK_tblBasket] PRIMARY KEY CLUSTERED 
(
	[BasketID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]	

SET ANSI_PADDING OFF

ALTER TABLE [dbo].[tblBasket]  WITH CHECK ADD  CONSTRAINT [FK_tblBasket_tblCustomerTransaction] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tblCustomerTransaction] ([CustomerId])

Print 'Success.'
END
GO

Print 'Creating table tblTotalDetail'
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTotalDetail]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[tblTotalDetail](
	[TotalD] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[DiscountApplied] [int] NULL,
	[GrandTotal] [float] NOT NULL,
	[TotalAmount] [float] NOT NULL,
	[PointsTotal] [int] NULL,
	[dtmInserted] [datetime] NULL,
 CONSTRAINT [PK_tblTotalDetail] PRIMARY KEY CLUSTERED 
(
	[TotalD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_PADDING OFF

ALTER TABLE [dbo].[tblTotalDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblTotalDetails_tblCustomerTransaction] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tblCustomerTransaction] ([CustomerId])

Print 'Success.'
END
GO

Print 'Creating table tblTotalDetail'
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTotalDetail]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[tblTotalDetail](

	[TotalD] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId][uniqueidentifier] NOT NULL,
	[DiscountApplied] int NULL,
	[GrandTotal] float NOT NULL,
	[TotalAmount] float NOT NULL,
	[PointsTotal] int NULL,
	[dtmInserted] datetime

 CONSTRAINT [PK_tblTotalDetail] PRIMARY KEY CLUSTERED 
(
	[TotalD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]	

SET ANSI_PADDING OFF

ALTER TABLE [dbo].[tblTotalDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblTotalDetail_tblCustomerTransaction] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tblCustomerTransaction] ([CustomerId])

Print 'Success.'
END
GO

------------------


Print 'Inserting Sample Data'
GO

	INSERT INTO [dbo].[tblPromotion] ([PromotionId],[PromotionName], [Category], [PointsPerDollar], [dtmInserted],[StartDate],[EndDate]) 
	VALUES('PP001','New Year Promo', 'Any',2,GetDate(),'2020-01-01 00:00:00.000','2020-01-30 00:00:00.000')

	INSERT INTO [dbo].[tblPromotion] ([PromotionId],[PromotionName], [Category], [PointsPerDollar], [dtmInserted],[StartDate],[EndDate]) 
	VALUES('PP002','Fuel Promo', 'Fuel',3,GetDate(),'2020-02-05 00:00:00.000','2020-02-15 00:00:00.000')

	INSERT INTO [dbo].[tblPromotion] ([PromotionId],[PromotionName], [Category], [PointsPerDollar], [dtmInserted],[StartDate],[EndDate]) 
	VALUES('PP003','Shop Promo', 'Shop',4,GetDate(),'2020-03-01 00:00:00.000','2020-03-20 00:00:00.000')


	INSERT INTO [dbo].[tblProductDetails] ([ProductId],[ProductName], [Category], [UnitPrice], [dtmInserted]) 
	VALUES('PRD01','Vortex 95', 'Fuel',1.2,GetDate())
	
	INSERT INTO [dbo].[tblProductDetails] ([ProductId],[ProductName], [Category], [UnitPrice], [dtmInserted]) 
	VALUES('PRD02','Vortex 98', 'Fuel',1.3,GetDate())
	
	INSERT INTO [dbo].[tblProductDetails] ([ProductId],[ProductName], [Category], [UnitPrice], [dtmInserted]) 
	VALUES('PRD03','Diesel', 'Fuel',1.1,GetDate())
	
	INSERT INTO [dbo].[tblProductDetails] ([ProductId],[ProductName], [Category], [UnitPrice], [dtmInserted]) 
	VALUES('PRD04','Twix 55g', 'Shop',2.3,GetDate())
	
	INSERT INTO [dbo].[tblProductDetails] ([ProductId],[ProductName], [Category], [UnitPrice], [dtmInserted]) 
	VALUES('PRD05','Mars 72g', 'Shop',5.1,GetDate())

	INSERT INTO [dbo].[tblProductDetails] ([ProductId],[ProductName], [Category], [UnitPrice], [dtmInserted]) 
	VALUES('PRD06','SNICKERS 72G', 'Shop',3.4,GetDate())


	INSERT INTO [dbo].[tblDiscount] ([DiscountId],[DiscountPromotionName], [dtmInserted], [Percent], [StartDate],[EndDate],[ProductId]) 
	VALUES('DP001','Fuel Discount Promo',GetDate(),0.15,'2020-01-01 00:00:00.000','2020-02-15 00:00:00.000','PRD02')

	INSERT INTO [dbo].[tblDiscount] ([DiscountId],[DiscountPromotionName], [dtmInserted], [Percent], [StartDate],[EndDate],[ProductId]) 
	VALUES('DP002','Happy Promo',GetDate(),0.15,'2020-03-02 00:00:00.000','2020-03-20 00:00:00.000','PRD02')

Print 'Sample Data Inserted'
GO

--select * from [dbo].[tblPromotion]
--select * from [dbo].[tblProductDetails]
--select * from [dbo].[tblDiscount]