USE SteamKeyStoreDB;

-- Insert into User table (Customers, Developers, Publishers, Admins)
INSERT INTO [User] (UserName, Email, PasswordHash, Role)
VALUES
-- Customers
('John Doe', 'john.doe@example.com', 'hash1', 'CUSTOMER'),
('Jane Smith', 'jane.smith@example.com', 'hash2', 'CUSTOMER'),
('Alice Johnson', 'alice.johnson@example.com', 'hash3', 'CUSTOMER'),
('Bob Brown', 'bob.brown@example.com', 'hash4', 'CUSTOMER'),
('Charlie Davis', 'charlie.davis@example.com', 'hash5', 'CUSTOMER'),
-- Developers
('CD Projekt Red', 'dev1@cdprojektred.com', 'hash6', 'CREATOR'),
('Rockstar Games', 'dev2@rockstargames.com', 'hash7', 'CREATOR'),
('Ubisoft Montreal', 'dev3@ubisoft.com', 'hash8', 'CREATOR'),
('FromSoftware', 'dev4@fromsoftware.com', 'hash9', 'CREATOR'),
('Larian Studios', 'dev5@larian.com', 'hash10', 'CREATOR'),
-- Publishers
('CD Projekt Red', 'publisher1@cdprojektred.com', 'hash11', 'CREATOR'),
('Rockstar Games', 'publisher2@rockstargames.com', 'hash12', 'CREATOR'),
('Ubisoft', 'publisher3@ubisoft.com', 'hash13', 'CREATOR'),
('Bandai Namco', 'publisher4@bandainamco.com', 'hash14', 'CREATOR'),
('Larian Studios', 'publisher5@larian.com', 'hash15', 'CREATOR'),
-- Admins
('Admin User', 'admin@example.com', 'hash16', 'ADMIN');

-- Insert into Product table (Real-world games and DLCs)
INSERT INTO Product (Type, Title, Description, SystemRequirements, DeveloperID, PublisherID, Price, ReleaseDate, MainImageURL, GameId)
VALUES
-- Base Games (GameId is NULL)
('BASE_GAME', 'The Witcher 3: Wild Hunt', 'An open-world RPG set in a fantasy universe.', 'Windows 7/8/10, 8GB RAM, GTX 770', 6, 11, 39.99, '2015-05-19', 'https://example.com/witcher3.jpg', NULL),
('BASE_GAME', 'Red Dead Redemption 2', 'A story-driven action-adventure game set in the Wild West.', 'Windows 10, 12GB RAM, GTX 1060', 7, 12, 59.99, '2018-10-26', 'https://example.com/rdr2.jpg', NULL),
('BASE_GAME', 'Assassin''s Creed Valhalla', 'A Viking-themed action RPG.', 'Windows 10, 8GB RAM, GTX 960', 8, 13, 49.99, '2020-11-10', 'https://example.com/acvalhalla.jpg', NULL),
('BASE_GAME', 'The Witcher 2: Assassins of Kings', 'A dark fantasy RPG and the second installment in The Witcher series.', 'Windows XP/Vista/7, 2GB RAM, GeForce 8800', 6, 11, 19.99, '2011-05-17', 'https://example.com/witcher2.jpg', NULL),
('BASE_GAME', 'Elden Ring', 'An open-world action RPG by FromSoftware.', 'Windows 10, 12GB RAM, GTX 1070', 9, 14, 59.99, '2022-02-25', 'https://example.com/eldenring.jpg', NULL),
('BASE_GAME', 'Cyberpunk 2077', 'A futuristic open-world RPG.', 'Windows 10, 16GB RAM, GTX 1060', 6, 11, 49.99, '2020-12-10', 'https://example.com/cyberpunk2077.jpg', NULL),
('BASE_GAME', 'Grand Theft Auto V', 'An open-world action-adventure game.', 'Windows 10, 8GB RAM, GTX 660', 7, 12, 29.99, '2013-09-17', 'https://example.com/gtav.jpg', NULL),
('BASE_GAME', 'Far Cry 6', 'An open-world first-person shooter.', 'Windows 10, 8GB RAM, GTX 960', 8, 13, 59.99, '2021-10-07', 'https://example.com/farcry6.jpg', NULL),
('BASE_GAME', 'Divinity: Original Sin 2', 'A critically acclaimed RPG with deep storytelling and tactical combat.', 'Windows 7/8/10, 4GB RAM, GTX 550', 10, 15, 44.99, '2017-09-14', 'https://example.com/divinity2.jpg', NULL),
('BASE_GAME', 'Dark Souls III', 'A challenging action RPG.', 'Windows 10, 8GB RAM, GTX 750 Ti', 9, 14, 49.99, '2016-04-12', 'https://example.com/darksouls3.jpg', NULL),
-- DLCs (GameId references the base game)
('DLC', 'The Witcher 3: Hearts of Stone', 'An expansion for The Witcher 3.', 'Windows 7/8/10, 8GB RAM, GTX 770', 6, 11, 9.99, '2015-10-13', 'https://example.com/heartsofstone.jpg', 1),
('DLC', 'The Witcher 3: Blood and Wine', 'A massive expansion for The Witcher 3.', 'Windows 7/8/10, 8GB RAM, GTX 770', 6, 11, 19.99, '2016-05-31', 'https://example.com/bloodandwine.jpg', 1),
('DLC', 'Assassin''s Creed Valhalla: Wrath of the Druids', 'An expansion for AC Valhalla.', 'Windows 10, 8GB RAM, GTX 960', 8, 13, 19.99, '2021-05-13', 'https://example.com/wrathofthedruids.jpg', 3),
('DLC', 'Assassin''s Creed Valhalla: The Siege of Paris', 'Another expansion for AC Valhalla.', 'Windows 10, 8GB RAM, GTX 960', 8, 13, 19.99, '2021-08-12', 'https://example.com/siegeofparis.jpg', 3),
('DLC', 'Elden Ring: Shadow of the Erdtree', 'An expansion for Elden Ring.', 'Windows 10, 12GB RAM, GTX 1070', 9, 14, 29.99, '2023-12-31', 'https://example.com/shadowoftheerdtree.jpg', 5);

-- Insert into Tag table (Real-world game tags)
INSERT INTO Tag (Name)
VALUES
('Action'),
('Adventure'),
('RPG'),
('Open World'),
('Shooter'),
('Fantasy'),
('Horror'),
('Multiplayer'),
('Single Player'),
('Sci-Fi'),
('Stealth'),
('Survival'),
('Puzzle'),
('Indie'),
('Simulation'),
('Strategy'),
('Sports'),
('Racing'),
('Fighting'),
('Casual');

-- Insert into ProductTag table (Associate tags with products)
INSERT INTO ProductTag (ProductID, TagID)
VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 6), -- The Witcher 3
(2, 1), (2, 2), (2, 4), (2, 5),         -- Red Dead Redemption 2
(3, 1), (3, 2), (3, 4), (3, 6),         -- Assassin's Creed Valhalla
(4, 1), (4, 2), (4, 3), (4, 6),         -- The Witcher 2
(5, 1), (5, 3), (5, 4), (5, 6),         -- Elden Ring
(6, 1), (6, 3), (6, 4), (6, 10),        -- Cyberpunk 2077
(7, 1), (7, 4), (7, 5),                 -- Grand Theft Auto V
(8, 1), (8, 4), (8, 5),                 -- Far Cry 6
(9, 1), (9, 2), (9, 3), (9, 4),         -- Divinity: Original Sin 2
(10, 1), (10, 3), (10, 6);              -- Dark Souls III

-- Insert into Edition table (Base editions for all games)
INSERT INTO Edition (GameId, Title, Price)
VALUES
-- Base editions for all games
(1, 'Standard Edition', 39.99), -- The Witcher 3: Wild Hunt
(2, 'Standard Edition', 59.99), -- Red Dead Redemption 2
(3, 'Standard Edition', 49.99), -- Assassin's Creed Valhalla
(4, 'Standard Edition', 19.99), -- The Witcher 2: Assassins of Kings
(5, 'Standard Edition', 59.99), -- Elden Ring
(6, 'Standard Edition', 49.99), -- Cyberpunk 2077
(7, 'Standard Edition', 29.99), -- Grand Theft Auto V
(8, 'Standard Edition', 59.99), -- Far Cry 6
(9, 'Standard Edition', 44.99), -- Divinity: Original Sin 2
(10, 'Standard Edition', 49.99); -- Dark Souls III

-- Insert into Edition table (Special editions with DLCs)
INSERT INTO Edition (GameId, Title, Price)
VALUES
-- Special editions for The Witcher 3: Wild Hunt
(1, 'Game of the Year Edition', 49.99); -- Includes Hearts of Stone and Blood and Wine

-- Insert into EditionContent table (DLCs included in special editions)
INSERT INTO EditionContent (EditionID, ProductId)
VALUES
-- Game of the Year Edition for The Witcher 3 includes Hearts of Stone and Blood and Wine
(11, 11), -- Hearts of Stone
(11, 12); -- Blood and Wine