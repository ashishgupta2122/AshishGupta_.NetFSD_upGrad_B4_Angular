CREATE DATABASE ContDb;

USE ContDb;

CREATE TABLE Contacts (
    ContactId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL
);

INSERT INTO Contacts (Name, Email, Phone) VALUES
('Ashish Gupta', 'ashish@gmail.com', '9876543210'),
('Rahul Sharma', 'rahul@gmail.com', '9123456780'),
('Priya Singh', 'priya@gmail.com', '9988776655');