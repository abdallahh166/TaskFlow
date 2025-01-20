CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL, -- Consider hashing passwords
    Email NVARCHAR(255) NOT NULL UNIQUE
);

INSERT INTO Users (Username, Password, Email)
VALUES ('abdallah', '123', 'abdallah@gmail.com');