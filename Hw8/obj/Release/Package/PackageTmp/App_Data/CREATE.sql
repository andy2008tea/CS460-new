-- ########### Pirates ###########
CREATE TABLE [dbo].[Pirates]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[Conscripted] [datetime] NOT NULL,
	CONSTRAINT [PK_dbo.Pirates] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### Ships ###########
CREATE TABLE [dbo].[Ships]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Tonnage] [float] NOT NULL,
	CONSTRAINT [PK_dbo.Ships] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### Crews ###########
CREATE TABLE [dbo].[Crews]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Booty] [decimal](18, 0) NOT NULL,
	[PirateID] INT NOT NULL,
	[ShipID] INT NOT NULL,
	CONSTRAINT [PK_dbo.Crews] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Crews_dbo.Pirates_ID] FOREIGN KEY ([PirateID]) REFERENCES [dbo].[Pirates] ([ID]),
	CONSTRAINT [FK_dbo.Crews_dbo.Ships_ID] FOREIGN KEY ([ShipID]) REFERENCES [dbo].[Ships] ([ID])
);