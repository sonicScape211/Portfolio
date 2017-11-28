IF EXISTS
(
	SELECT *
	FROM sys.tables
	WHERE tables.name IN ('Artist', 'Artwork', 'Classification', 'Genre')
)

BEGIN

	DROP TABLE dbo.Classification
	DROP TABLE dbo.Genre
	DROP TABLE dbo.Artwork
	DROP TABLE dbo.Artist
END