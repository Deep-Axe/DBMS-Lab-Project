CREATE TABLE TaskTypes (
    TaskTypeID NUMBER PRIMARY KEY,
    TaskName VARCHAR2(50) NOT NULL UNIQUE,
    Description VARCHAR2(200),
    RequiredPermissionLevel NUMBER,
    IsSystem NUMBER(1) DEFAULT 0
);

CREATE TABLE AutomationScripts (
    ScriptID NUMBER PRIMARY KEY,
    ScriptName VARCHAR2(100) NOT NULL,
    ScriptContent CLOB,
    TaskTypeID NUMBER,
    CreatedBy NUMBER,
    CreatedDate DATE DEFAULT SYSDATE,
    LastModified DATE DEFAULT SYSDATE,
    ModifiedBy NUMBER,
    Version NUMBER DEFAULT 1,
    HashValue VARCHAR2(64), 
    FOREIGN KEY (TaskTypeID) REFERENCES TaskTypes(TaskTypeID),
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
    FOREIGN KEY (ModifiedBy) REFERENCES Users(UserID)
); -- not everything done

CREATE TABLE AutomationLogs (
    TaskID NUMBER PRIMARY KEY,
    ScriptID NUMBER,
    ServerID NUMBER,
    ExecutedBy NUMBER,
    Status VARCHAR2(50) NOT NULL,
    StartTime DATE DEFAULT SYSDATE,
    EndTime DATE,
    LogDetails CLOB,
    ErrorMessage VARCHAR2(500),
    FOREIGN KEY (ScriptID) REFERENCES AutomationScripts(ScriptID),
    FOREIGN KEY (ServerID) REFERENCES Servers(ServerID),
    FOREIGN KEY (ExecutedBy) REFERENCES Users(UserID)
); -- not able to insert

CREATE TABLE UserAccessLogs (
    LogID NUMBER PRIMARY KEY,
    UserID NUMBER,
    ServerID NUMBER,
    Action VARCHAR2(200) NOT NULL,
    IPAddress VARCHAR2(15),
    UserAgent VARCHAR2(200),
    SessionID VARCHAR2(100),
    Timestamp DATE DEFAULT SYSDATE,
    Success NUMBER(1) DEFAULT 1,
    FailureReason VARCHAR2(200),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ServerID) REFERENCES Servers(ServerID)
); -- not able to insert

CREATE TABLE SuspiciousActivity (
    AlertID NUMBER PRIMARY KEY,
    UserID NUMBER,
    ActivityType VARCHAR2(50),
    AttemptCount NUMBER DEFAULT 1,
    FirstDetected DATE DEFAULT SYSDATE,
    LastDetected DATE DEFAULT SYSDATE,
    IPAddress VARCHAR2(15),
    Details VARCHAR2(500),
    Status VARCHAR2(20) DEFAULT 'Open',
    ReviewedBy NUMBER,
    ReviewDate DATE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ReviewedBy) REFERENCES Users(UserID)
); -- single row inserted
