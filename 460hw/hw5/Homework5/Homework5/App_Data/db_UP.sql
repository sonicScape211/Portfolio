

CREATE TABLE [dbo].[DMVEntries] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
	[LicenseNumber]	INT			   NOT NULL,
    [DateOfBirth]   DATETIME       NOT NULL,
    [FullName]      NVARCHAR (MAX) NULL,
    [StreetAddress] NVARCHAR (MAX) NULL,
    [City]          NVARCHAR (MAX) NULL,
    [State]         NVARCHAR (MAX) NULL,
    [Zipcode]       INT            NOT NULL,
    [SignedDate]    DATETIME       NOT NULL,
    /*CONSTRAINT [PK_dbo.DMVEntries] PRIMARY KEY CLUSTERED ([ID] ASC)*/
);

INSERT INTO dbo.DMVEntries(LicenseNumber, DateOfBirth, FullName, StreetAddress, City, State, Zipcode, SignedDate) VALUES
	(453, '1994-08-10 00:00:00', 'Name', '1645 NW Division', 'Corvallis', 'Oregon', 97330, '2015-10-08 00:00:00');

GO	
