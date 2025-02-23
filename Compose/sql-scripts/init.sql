USE SteamKeyStoreDB;
-- Create the User table
CREATE TABLE [User] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(100) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    PasswordSalt VARCHAR(255) NOT NULL,
    Role VARCHAR(10) NOT NULL CHECK (Role IN ('CUSTOMER', 'CREATOR', 'ADMIN')),
    CreatedAt DATETIME2 DEFAULT GETDATE()
);

-- Create the Product table
CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Type VARCHAR(20) NOT NULL CHECK (Type IN ('BASE_GAME', 'DLC')),
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    SystemRequirements NVARCHAR(MAX),
    DeveloperID INT NOT NULL FOREIGN KEY REFERENCES [User](Id),
    PublisherID INT NOT NULL FOREIGN KEY REFERENCES [User](Id),
    GameId INT NULL FOREIGN KEY REFERENCES Product(Id), --If product is DLC
    Price DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    ReleaseDate DATE,
    MainImageURL VARCHAR(255)
);

-- Create the Edition table
CREATE TABLE Edition (
    Id INT PRIMARY KEY IDENTITY(1,1),
    GameId INT NOT NULL FOREIGN KEY REFERENCES Product(Id),
    Title NVARCHAR(200) NOT NULL,
    Price DECIMAL(10,2) NOT NULL DEFAULT 0.00
);

-- Create the EditionContent table
CREATE TABLE EditionContent (
    EditionID INT NOT NULL FOREIGN KEY REFERENCES Edition(Id),
    ProductId INT NOT NULL FOREIGN KEY REFERENCES Product(Id),
    PRIMARY KEY (EditionID, ProductId)
);

-- Create the Tag table
CREATE TABLE Tag (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL UNIQUE
);

-- Create the ProductTag bridge table
CREATE TABLE ProductTag (
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Product(Id),
    TagID INT NOT NULL FOREIGN KEY REFERENCES Tag(Id),
    PRIMARY KEY (ProductID, TagID)
);

-- Create the Sale table
CREATE TABLE Sale (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT FOREIGN KEY REFERENCES Product(Id),
    EditionId INT FOREIGN KEY REFERENCES Edition(Id),
    DiscountPercentage DECIMAL(5,2) NOT NULL,
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL
);

-- Create the Coupon table
CREATE TABLE Coupon (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Code VARCHAR(50) NOT NULL UNIQUE,
    DiscountPercentage DECIMAL(5,2) NOT NULL,
    StartDate DATETIME2,
    EndDate DATETIME2,
    MaxUsage INT,
    CurrentUsage INT DEFAULT 0
);

-- Create the Review table
CREATE TABLE Review (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Product(Id),
    CustomerID INT NOT NULL FOREIGN KEY REFERENCES [User](Id),
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 10),
    HoursPlayed INT NOT NULL,
    ReviewText NVARCHAR(MAX),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2
);

-- Create the News table
CREATE TABLE News (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Product(Id),
    Title NVARCHAR(200) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE()
);

-- Create the Wishlist table
CREATE TABLE Wishlist (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL FOREIGN KEY REFERENCES [User](Id),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Product(Id),
    CreatedAt DATETIME2 DEFAULT GETDATE()
);

-- Create the Order table
CREATE TABLE [Order] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL FOREIGN KEY REFERENCES [User](Id),
    OrderDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    CouponID INT FOREIGN KEY REFERENCES Coupon(Id),
    TotalPrice DECIMAL(10,2) NOT NULL
);

-- Create the OrderItem table
CREATE TABLE OrderItem (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL FOREIGN KEY REFERENCES [Order](Id),
    EditionID INT NULL FOREIGN KEY REFERENCES Edition(Id),
    ProductID INT NULL FOREIGN KEY REFERENCES Product(Id),
    UnitPrice DECIMAL(10,2) NOT NULL,
    DiscountApplied DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    FinalPrice DECIMAL(10,2) NOT NULL
);

-- Create the ProductKey table
CREATE TABLE ProductKey (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Product(Id),
    KeyCode VARCHAR(50) NOT NULL UNIQUE,
    IsSold BIT NOT NULL DEFAULT 0,
    DateSold DATETIME2
);

-- Create the OrderItemKey table
CREATE TABLE OrderItemKey (
    OrderItemKeyID INT PRIMARY KEY IDENTITY(1,1),
    OrderItemID INT NOT NULL FOREIGN KEY REFERENCES OrderItem(Id),
    ProductKeyID INT NOT NULL FOREIGN KEY REFERENCES ProductKey(Id)
);