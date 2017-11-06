

CREATE TABLE [dbo].[DMVEntries] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
	[LicenseNumber]	INT			   NULL,
    [DateOfBirth]   DATE		   NOT NULL,
    [FullName]      NVARCHAR (MAX) NOT NULL,
    [StreetAddress] NVARCHAR (MAX) NOT NULL,
    [City]          NVARCHAR (MAX) NOT NULL,
    [State]         NVARCHAR (MAX) NOT NULL,
    [Zipcode]       INT            NOT NULL,
    [SignedDate]    DATETIME       NULL,
    /*CONSTRAINT [PK_dbo.DMVEntries] PRIMARY KEY CLUSTERED ([ID] ASC)*/
);

INSERT INTO dbo.DMVEntries(LicenseNumber, DateOfBirth, FullName, StreetAddress, City, State, Zipcode, SignedDate) VALUES
	(453, '1994-08-10', 'Name', '1645 NW Division', 'Corvallis', 'Oregon', 97330, '2015-10-08 00:00:00'),
	(7852, '1975-04-25', 'Robare De Four', '3235 W Conifer', 'Salem', 'Oregon', 78466, '2017-10-31 05:32:57'),
	(96453, '1983-01-17', 'Sannon F. Calhoon', '174 E 1st Street', 'Portland', 'Oregon', 98466 , '2016-08-25 07:24:45'),
	(74315, '1996-02-29', 'Nate C. Aliander', '47804 SW 35th Ave', 'Salem', 'Oregon', 78466 , '2005-05-01 08:16:58'),
	(96453, '1946-11-25', 'James T. Douglous', '7841 Harrison St.', 'Eugene', 'Oregon', 74404 , '2000-11-26 05:15:43');
	


GO	
