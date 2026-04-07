CREATE DATABASE EMSDB;

USE EMSDB;

CREATE TABLE Users(
	EmailId NVARCHAR(100) PRIMARY KEY,
	UserName NVARCHAR(50) NOT NULL,
	Role NVARCHAR(20) NOT NULL,
	Password NVARCHAR(20) NOT NULL
	);

CREATE TABLE Events (
    EventId UNIQUEIDENTIFIER PRIMARY KEY,
    EventName NVARCHAR(50) NOT NULL,
    EventCategory NVARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description NVARCHAR(MAX),
    Status NVARCHAR(20)
);

CREATE TABLE Speakers (
    SpeakerId UNIQUEIDENTIFIER PRIMARY KEY,
    SpeakerName NVARCHAR(50) NOT NULL
);

CREATE TABLE Sessions (
    SessionId UNIQUEIDENTIFIER PRIMARY KEY,
    EventId UNIQUEIDENTIFIER NOT NULL,
    SessionTitle NVARCHAR(50) NOT NULL,
    SpeakerId UNIQUEIDENTIFIER,
    Description NVARCHAR(MAX),
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl NVARCHAR(200),

    FOREIGN KEY (EventId) REFERENCES Events(EventId),
    FOREIGN KEY (SpeakerId) REFERENCES Speakers(SpeakerId)
);

CREATE TABLE ParticipantEvents (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    ParticipantEmailId NVARCHAR(100),
    EventId UNIQUEIDENTIFIER,
    IsAttended BIT,

    FOREIGN KEY (ParticipantEmailId) REFERENCES Users(EmailId),
    FOREIGN KEY (EventId) REFERENCES Events(EventId)
);

INSERT INTO Users VALUES 
('admin@gmail.com', 'Admin', 'Admin', '123456'),
('user@gmail.com', 'User', 'Participant', '123456');


INSERT INTO Events VALUES 
(NEWID(), 'Tech Conference', 'Tech', GETDATE(), 'Tech Event', 'Active'),
(NEWID(), 'AI Summit', 'Technology', GETDATE(), 'AI Event', 'Active');


INSERT INTO Speakers VALUES 
(NEWID(), 'John Doe'),
(NEWID(), 'Rahul Sharma');

SELECT * FROM Users;
SELECT * FROM Events;
SELECT * FROM Speakers;
SELECT * FROM Sessions;
SELECT * FROM ParticipantEvents;
