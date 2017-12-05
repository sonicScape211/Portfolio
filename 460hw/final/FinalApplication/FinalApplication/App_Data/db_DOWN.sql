IF EXISTS
(
	SELECT *
	FROM sys.tables
	WHERE tables.name IN ('Buyer', 'Seller', 'Item', 'Bid')
)

BEGIN
	DROP TABLE dbo.Bid
	DROP TABLE dbo.Item
	DROP TABLE dbo.Buyer
	DROP TABLE dbo.Seller
END