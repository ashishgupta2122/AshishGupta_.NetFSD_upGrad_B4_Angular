CREATE DATABASE EventDb;

USE EventDb;

CREATE TABLE UserInfo
(
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin','Participant')),
    Password VARCHAR(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20)
);

CREATE TABLE EventDetails
(
    EventId INT IDENTITY(1,1) PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(255) NULL,
    Status VARCHAR(20) CHECK (Status IN ('Active','In-Active'))
);

CREATE TABLE SpeakersDetails
(
    SpeakerId INT IDENTITY(1,1) PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL
);

CREATE TABLE SessionInfo
(
    SessionId INT IDENTITY(1,1) PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(255),
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(200),

    CONSTRAINT FK_Event FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    CONSTRAINT FK_Speaker FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);

CREATE TABLE ParticipantEventDetails
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT CHECK (IsAttended IN (0,1)),

    CONSTRAINT FK_User FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    CONSTRAINT FK_Event2 FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    CONSTRAINT FK_Session FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);

INSERT INTO UserInfo VALUES
('ashish@gmail.com','Ashish','Admin','123456'),
('basu@gmail.com','basu','Participant','123456');

INSERT INTO EventDetails (EventName,EventCategory,EventDate,Status)
VALUES
('Tech Summit','IT','2026-03-10','Active');

INSERT INTO SpeakersDetails (SpeakerName)
VALUES ('Jaya Gupta');

INSERT INTO SessionInfo 
(EventId,SessionTitle,SpeakerId,SessionStart,SessionEnd)
VALUES
(1,'AI Basics',1,'2026-03-10 10:00','2026-03-10 11:00');

INSERT INTO ParticipantEventDetails
(ParticipantEmailId,EventId,SessionId,IsAttended)
VALUES
('basu@gmail.com',1,1,1);

SELECT 
    u.UserName,
    e.EventName,
    s.SessionTitle,
    p.IsAttended
FROM ParticipantEventDetails p
JOIN UserInfo u ON p.ParticipantEmailId = u.EmailId
JOIN EventDetails e ON p.EventId = e.EventId
JOIN SessionInfo s ON p.SessionId = s.SessionId;