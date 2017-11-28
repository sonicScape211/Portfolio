IF EXISTS
(
	SELECT *
	FROM sys.tables
	WHERE tables.name = 'Artist'
)

BEGIN
	DROP TABLE dbo.Artist
END