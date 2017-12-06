CREATE TABLE [dbo].[Buyer]
(
	[BuyerID]		INT				NOT NULL Identity (1,1),
	[BuyerName]		CHAR(50)		NOT NULL

	CONSTRAINT [PK_dbo.Buyer] PRIMARY KEY CLUSTERED (BuyerID ASC) /*Primary key as ascending numeral*/
)

INSERT INTO [dbo].[Buyer](BuyerName) VALUES
	('Jane Stone'),
    ('Tom McMasters'),
	('Otto Vanderwall')

CREATE TABLE [dbo].[Seller]
(
	[SellerID]		INT				NOT NULL IDENTITY (1, 1),			
	[SellerName]	CHAR(50)		NOT NULL

	CONSTRAINT [PK_dbo.Seller] PRIMARY KEY CLUSTERED (SellerID ASC)
)

INSERT INTO dbo.Seller (SellerName) VALUES
	('Gayle Hardy'),
	('Lyle Banks'),
	('Pearl Greene')

CREATE TABLE [dbo].[Item]
(
	[ItemID]			INT				NOT NULL,	
	[ItemName]			CHAR(35)		NOT NULL,
	[ItemDescription]	CHAR(250)		NOT NULL,
	[SellerID]			INT				NOT NULL

	CONSTRAINT [PK_dbo.Item] PRIMARY KEY CLUSTERED (ItemID ASC),
	CONSTRAINT [FK_dbo.Item] FOREIGN KEY (SellerID) REFERENCES [dbo].[Seller] (SellerID)
)

INSERT INTO dbo.Item (ItemID, ItemName, ItemDescription, SellerID) VALUES
	(1001,'Abraham Lincoln Hammer', 'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 3), 
    (1002,'Albert Einsteins Telescope', 'A brass telescope owned by Albert Einstein in Germany, circa 1927', 1),
	(1003,'Bob Dylan Love Poems', 'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 2)

CREATE TABLE [dbo].[Bid]
(
	[BidID]			INT			NOT NULL	IDENTITY(1,1),
	[ItemID]		INT			NOT NULL,
	[BuyerID]		INT			NOT NULL,
	[Price]			INT			NOT NULL,
	[BidTime]		DATETIME	NOT NULL

	CONSTRAINT [PK_dbo.Bid] PRIMARY KEY CLUSTERED (BidID ASC),
	CONSTRAINT [FK_dbo.Bid] FOREIGN KEY (ItemID) REFERENCES [dbo].[Item] (ItemID),
	CONSTRAINT [FK2_dbo.Bid] FOREIGN KEY (BuyerID) REFERENCES [dbo].[Buyer] (BuyerID)
)

INSERT INTO dbo.Bid (ItemID, BuyerID, Price, Bidtime) VALUES
	(1001, 3, 250000, '12/04/2017 09:04:22'),
    (1003, 1, 95000, '12/04/2017 08:44:03')