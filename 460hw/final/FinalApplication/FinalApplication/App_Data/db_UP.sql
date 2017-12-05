CREATE TABLE [dbo].[]
(
	

	CONSTRAINT [PK_dbo.] PRIMARY KEY CLUSTERED ( ASC) /*Primary key as ascending numeral*/
)

INSERT INTO [dbo].[](,,,) VALUES
	(),
    ()

CREATE TABLE [dbo].[]
(
	[]			
	[]

	CONSTRAINT [PK_dbo.] PRIMARY KEY CLUSTERED ( ASC)
)

INSERT INTO dbo. () VALUES
(),
()

CREATE TABLE [dbo].[]
(
	[]		
	[]		
	[]		

	CONSTRAINT [PK_dbo.Artwork] PRIMARY KEY CLUSTERED (ArtworkID ASC),
	CONSTRAINT [FK_dbo.Artwork] FOREIGN KEY (ArtistID) REFERENCES [dbo].[Artist] (ArtistID)
)

INSERT INTO dbo. () VALUES
	(),
    ()


CREATE TABLE [dbo].[]
(

	CONSTRAINT [PK_dbo.] PRIMARY KEY CLUSTERED ( ASC),
	CONSTRAINT [FK_dbo.] FOREIGN KEY () REFERENCES [dbo].[] (),
	CONSTRAINT [FK2_dbo.] FOREIGN KEY () REFERENCES [dbo].[] ()
)

INSERT INTO dbo. () VALUES
	(),
    ()