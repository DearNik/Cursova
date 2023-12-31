use ResearchPapers

CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(255),
    Password NVARCHAR(255),
    Email NVARCHAR(255),
    IsAdmin BIT
);

CREATE TABLE ResearchPapers (
    PaperID INT PRIMARY KEY,
    Title NVARCHAR(255),
    AuthorID INT,
    Abstract NVARCHAR(MAX),
    Content NVARCHAR(MAX),
    DateCreated DATETIME,
    DateUpdated DATETIME,
    FOREIGN KEY (AuthorID) REFERENCES Users(UserID)
);

CREATE TABLE Scientists (
	ScientistsID INT PRIMARY KEY,
	FirstName NVARCHAR(255),
	SecondName NVARCHAR(255),
	UserID INT,
	Incumbency NVARCHAR(255),
	Discripion NVARCHAR(MAX),
	Awards NVARCHAR(MAX),
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

