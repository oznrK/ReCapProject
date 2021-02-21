CREATE TABLE Cars 
(
	Id INT NOT NULL PRIMARY KEY, 
    BrandId INT NOT NULL, 
    ColorId INT NOT NULL, 
    ModelYear NVARCHAR(25) NOT NULL, 
    DailyPrice DECIMAL NOT NULL, 
    Descriptions NVARCHAR(25) NULL, 
	FOREIGN KEY (BrandID) REFERENCES Brands(BrandID),
	FOREIGN KEY (ColorID) REFERENCES Colors(ColorID)
)
CREATE TABLE Colors
(
	ColorId INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    ColorName NVARCHAR(10) NULL,
)
CREATE TABLE Brands
(
	BrandId INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    BrandName NVARCHAR(25) NULL,
)

INSERT INTO Colors(ColorName)
VALUES
    ('Beyaz'),
    ('Siyah'),
    ('Mavi');

INSERT INTO Brands(BrandName)
VALUES 
    ('Opel'),
    ('Mercedes'),
    ('BMW');

INSERT INTO Cars(Id, BrandId, ColorId, ModelYear, DailyPrice, Descriptions)
VALUES 
    ('1','1','3', '2020', '200', 'Otomatik v.'),
    ('2','2','1', '2015', '100', 'Manuel v.'),
    ('3','3','1', '2017', '100', 'Manuel v.'),
    ('4','2','2', '2019', '150', 'Otomatik v.');

SELECT * FROM Cars
SELECT * FROM Brands
SELECT * FROM Colors
