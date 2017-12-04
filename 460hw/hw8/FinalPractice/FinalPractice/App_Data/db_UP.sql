CREATE TABLE [dbo].[Artist]
(
	[ArtistID]			INT			NOT NULL,
	[ArtistName]		CHAR(50)	NOT NULL,
	[DateOfBirth]		DATE		NULL,
	[CityOfBirth]		CHAR(50)	NULL

	CONSTRAINT [PK_dbo.Artist] PRIMARY KEY CLUSTERED (ArtistID ASC) /*Primary key as ascending numeral*/
)

INSERT INTO [dbo].[Artist](ArtistID, ArtistName, DateOfBirth, CityOfBirth) VALUES
	(1 ,'M.C. Escher', '1898-07-17', 'Leeuwarden, Netherlands'),
	(2 ,'Leonardo Da Vinci', '1519-06-02', 'Vincim Italy'),
	(3 ,'Hatip Mehmed Efendi', '1680-11-18', 'Unknown'),
	(4 ,'Salvador Dali','1904-02-11', 'Figueres, Spain')

CREATE TABLE [dbo].[Genre]
(
	[GenreID]			INT			NOT NULL,
	[Genre]				CHAR(35)	NOT NULL

	CONSTRAINT [PK_dbo.Genre] PRIMARY KEY CLUSTERED (GenreID ASC)
)

INSERT INTO dbo.Genre(GenreID, Genre) VALUES
(1, 'Tesselation'),
(2, 'Surrealism'),
(3, 'Portrait'),
(4, 'Renaissance')

CREATE TABLE [dbo].[Artwork]
(
	[ArtworkID]			INT			NOT NULL,
	[ArtworkTitle]		CHAR(50)	NOT NULL,
	[ArtistID]			INT			NOT NULL

	CONSTRAINT [PK_dbo.Artwork] PRIMARY KEY CLUSTERED (ArtworkID ASC)
	CONSTRAINT [FK_dbo.Artwork] FOREIGN KEY (ArtistID) REFERENCES [dbo].[Artist] (ArtistID)
)

INSERT INTO dbo.Artwork (ArtworkID, ArtworkTitle, ArtistID) VALUES
	(1 ,'Circle Limit III', 1),
	(2 ,'Twon Tree', 1),
	(3 ,'Mona Lisa', 2),
	(4 ,'The Vitruvian Man', 2),
	(5 ,'Ebru', 3),
	(6 ,'Honey Is Sweeter Than Blood', 4)


CREATE TABLE [dbo].[Classification]
(
	[ClassificationID]	INT			NOT NULL,
	[ArtworkID]			INT			NOT NULL,
	[GenreID]			INT			NOT NULL

	CONSTRAINT [PK_dbo.Classification] PRIMARY KEY CLUSTERED (ClassificationID ASC),
	CONSTRAINT [FK_dbo.Classification] FOREIGN KEY (ArtworkID) REFERENCES [dbo].[Artwork] (ArtworkID),
	CONSTRAINT [FK2_dbo.Classification] FOREIGN KEY (GenreID) REFERENCES [dbo].[Genre] (GenreID)
)

INSERT INTO dbo.Classification(ClassificationID, ArtworkID, GenreID) VALUES
	(1, 1, 1),
	(2, 2, 1),
	(3, 2, 2),
	(4, 3, 3),
	(5, 3, 4),
	(6, 4, 4),
	(7, 5, 1),
	(8, 6, 2)