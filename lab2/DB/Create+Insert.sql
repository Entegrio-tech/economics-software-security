CREATE DATABASE Products

GO
USE Products
  
CREATE TABLE Genres
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Games
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL, 
    GenreId INT REFERENCES Genres (Id),
    Type NVARCHAR(50) NOT NULL,
    Quantity INT NOT NULL,
    Price MONEY NOT NULL,
	Allowance INT NOT NULL
)

INSERT INTO Genres 
VALUES
('Action'),
('Simulation'),
('Strategy'),
('Role-playing Games'),
('Adventure'),
('Puzzle')

INSERT INTO Games
VALUES
('Hyperdimension Neptunia Re;Birth1', 4, 'DVD', 10, 229, 18),
('Serious Sam Fusion 2017 (beta)', 1, 'DVD', 6, 229, 18),
('Disassembly 3D', 2, 'DVD', 6, 379, 86),
('Tropico 5', 3, 'DVD', 2, 279, 95),
('Invasion Machine', 3, 'DVD', 6, 269, 38),
('Quake Champions', 1, 'DVD', 10, 0, 39),
('Ys VIII: Lacrimosa of DANA', 4, 'DVD', 3, 499, 76),
('Game Dev Tycoon', 2, 'DVD', 4, 168, 79),
('MXGP 2020 - The Official Motocross Videogame', 2, 'DVD', 2, 405, 47),
('Nuclear Throne', 1, 'DVD', 2, 199, 72),
('Just Dance 2017', 1, 'DVD', 8, 759, 60),
('Saurian', 2, 'DVD', 9, 279, 64),
('Into The Flames', 2, 'DVD', 7, 279, 88),
('Fallout Tactics: Brotherhood of Steel', 4, 'DVD', 7, 260, 80),
('Forts', 3, 'DVD', 6, 229, 51),
('Armello', 3, 'DVD', 7, 279, 24),
('Tales of Maj`Eyal', 5, 'DVD', 5, 129, 29),
('Pro Cycling Manager 2020', 2, 'DVD', 7, 929, 33),
('Knights College', 5, 'DVD', 1, 329, 19),
('HeXen: Beyond Heretic', 1, 'DVD', 6, 130, 59)