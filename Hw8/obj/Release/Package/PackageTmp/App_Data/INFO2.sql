
-- ########### Pirates ###########
INSERT INTO [dbo].[Pirates](Name,Conscripted)VALUES('Jason',2002-09-01);
INSERT INTO [dbo].[Pirates](Name,Conscripted)VALUES('Jeson',2002-09-02);
INSERT INTO [dbo].[Pirates](Name,Conscripted)VALUES('Jison',2002-09-03);
INSERT INTO [dbo].[Pirates](Name,Conscripted)VALUES('Joson',2002-09-04);
INSERT INTO [dbo].[Pirates](Name,Conscripted)VALUES('Juson',2002-09-05);

-- ########### Ships ###########
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('K','Frigate',34);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('L','Frigate',54);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('P','Frigate',25);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('T','Frigate',64);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('R','Frigate',34);

-- ########### Crews ###########
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(5,1,1);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(6,1,2);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(4,1,3);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(7,1,4);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(3,1,5);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(6,2,5);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(2,2,4);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(7,2,3);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(1,2,2);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(6,2,1);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(220,3,4);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(130,3,5);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(140,4,1);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(100,4,2);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(200,4,3);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(230,4,4);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(150,4,5);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(100,5,1);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(230,5,3);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(150,5,5);