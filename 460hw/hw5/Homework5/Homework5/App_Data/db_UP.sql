CREATE TABLE [dbo].[DMVEntries] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [DateOfBirth]   DATETIME       NOT NULL,
    [FullName]      NVARCHAR (MAX) NULL,
    [StreetAddress] NVARCHAR (MAX) NULL,
    [City]          NVARCHAR (MAX) NULL,
    [State]         NVARCHAR (MAX) NULL,
    [Zipcode]       INT            NOT NULL,
    [SignedDate]    DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.DMVEntries] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO dbo.DMVEntries (ID, DateOfBirth, FullName, StreetAddress, City, State, Zipcode, SignedDate) VALUES
	(453, '05-06-1980 00:00:00', 'Name', '1645 NW Division', 'Corvallis', 'Oregon', 97330, '06-34-2015');

GO	
