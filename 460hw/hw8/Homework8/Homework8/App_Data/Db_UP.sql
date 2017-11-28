CREATE TABLE [dbo].[Artist]
(
	[Id]		INT				NOT NULL IDENTITY (1,1),
	[Name]		CHAR(50)		NOT NULL PRIMARY KEY,
	[Birthday]	DATE			NULL,
	[BirthCity]	NVARCHAR(Max)	NULL

)

CREATE TABLE [dbo].[Artwork]
(
	[Id]		INT				NOT NULL	IDENTITY (1,1),
	[Title]		CHAR(50)		NOT NULL	PRIMARY KEY,
	[Artist]	CHAR(50)		NOT NULL
)

CREATE TABLE [dbo].[Classification]
(
	[Id]		INT			NOT NULL	IDENTITY(1,1),
	[Title]		CHAR(50)	NOT NULL,
	[Genre]		CHAR(35)	NOT NULL
)

CREATE TABLE [dbo].[Genre]
(
	[Id]		INT			NOT NULL	IDENTITY(1,1),
	[Genre]		CHAR(35)	NOT NULL	PRIMARY KEY
)


INSERT INTO dbo.Artist (Name, Birthday, BirthCity) VALUES
	('M.C. Escher', '1898-07-17', 'Leeuwarden, Netherlands'),
	('Leonardo Da Vinci', '1519-06-02', 'Vincim Italy'),
	('Hatip Mehmed Efendi', '1680-11-18', 'Unknown'),
	('Salvador Dali','1904-02-11', 'Figueres, Spain')

INSERT INTO dbo.Artwork (Title, Artist) VALUES
	('Circle Limit III','M.C. Escher'),
	('Twon Tree','M.C. Escher'),
	('Mona Lisa', ' Leonardo Da Vinci'),
	('The Vitruvian Man', 'Leonardo Da Vinci'),
	('Ebru', 'Hatip Mehmed Efendi'),
	('Honey Is Sweeter Than Blood', 'Salvador Dali')

INSERT INTO dbo.Classification(Title, Genre) VALUES
	('Circle Limit III', 'Tesselation'),
	('Twon Tree', 'Tesselation'),
	('Twon Tree', 'Surrealism'),
	('Mona Lisa', 'Portrait'),
	('Mona Lisa', 'Renaissance'),
	('The Vitruvian Man', 'Renaissance'),
	('Ebru', 'Tesselation'),
	('Honey Is Sweeter Than Blood', 'Surrealism')

INSERT INTO dbo.Genre(Genre) VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance')
