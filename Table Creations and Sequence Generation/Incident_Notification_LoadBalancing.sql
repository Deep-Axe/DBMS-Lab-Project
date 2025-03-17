CREATE TABLE IncidentTypes (
    TypeID NUMBER PRIMARY KEY,
    TypeName VARCHAR2(100) NOT NULL UNIQUE,
    Description VARCHAR2(200),
    DefaultSeverity VARCHAR2(20),
    SLAHours NUMBER DEFAULT 24
);

CREATE TABLE IncidentLogs (
    IncidentID NUMBER PRIMARY KEY,
    TypeID NUMBER,
    ServerID NUMBER,
    Title VARCHAR2(200) NOT NULL,
    Description CLOB,
    Severity VARCHAR2(50) NOT NULL,
    Priority VARCHAR2(20) DEFAULT 'Medium',
    ReportedBy NUMBER,
    AssignedTo NUMBER,
    Status VARCHAR2(50) NOT NULL,
    CreatedDate DATE DEFAULT SYSDATE,
    SLADeadline DATE,
    ResolutionDate DATE,
    ResolutionSummary CLOB,
    ImpactLevel VARCHAR2(20),
    FOREIGN KEY (TypeID) REFERENCES IncidentTypes(TypeID),
    FOREIGN KEY (ServerID) REFERENCES Servers(ServerID),
    FOREIGN KEY (ReportedBy) REFERENCES Users(UserID),
    FOREIGN KEY (AssignedTo) REFERENCES Users(UserID)
);

CREATE TABLE IncidentComments (
    CommentID NUMBER PRIMARY KEY,
    IncidentID NUMBER NOT NULL,
    CommentText CLOB NOT NULL,
    CommentedBy NUMBER NOT NULL,
    Timestamp DATE DEFAULT SYSDATE,
    IsInternal NUMBER(1) DEFAULT 0,  -- Internal notes vs. public comments
    FOREIGN KEY (IncidentID) REFERENCES IncidentLogs(IncidentID),
    FOREIGN KEY (CommentedBy) REFERENCES Users(UserID)
);

CREATE TABLE IncidentStatusHistory (
    HistoryID NUMBER PRIMARY KEY,
    IncidentID NUMBER NOT NULL,
    OldStatus VARCHAR2(50),
    NewStatus VARCHAR2(50) NOT NULL,
    ChangedBy NUMBER NOT NULL,
    ChangeTime DATE DEFAULT SYSDATE,
    Comment VARCHAR2(500),
    FOREIGN KEY (IncidentID) REFERENCES IncidentLogs(IncidentID),
    FOREIGN KEY (ChangedBy) REFERENCES Users(UserID)
);

CREATE TABLE NotificationChannels (
    ChannelID NUMBER PRIMARY KEY,
    ChannelName VARCHAR2(100) NOT NULL UNIQUE,
    ChannelType VARCHAR2(50) NOT NULL,
    Configuration CLOB,
    Active NUMBER(1) DEFAULT 1,
    CreatedBy NUMBER,
    CreatedDate DATE DEFAULT SYSDATE,
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);

CREATE TABLE NotificationTemplates (
    TemplateID NUMBER PRIMARY KEY,
    TemplateName VARCHAR2(100) NOT NULL UNIQUE,
    Subject VARCHAR2(200),
    BodyTemplate CLOB NOT NULL,
    EventType VARCHAR2(50) NOT NULL,
    CreatedBy NUMBER,
    CreatedDate DATE DEFAULT SYSDATE,
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);

CREATE TABLE Notifications (
    NotificationID NUMBER PRIMARY KEY,
    IncidentID NUMBER,
    UserID NUMBER,
    ChannelID NUMBER,
    TemplateID NUMBER,
    SentTime DATE DEFAULT SYSDATE,
    Status VARCHAR2(20) DEFAULT 'Sent',
    Retries NUMBER DEFAULT 0,
    Content CLOB,
    FOREIGN KEY (IncidentID) REFERENCES IncidentLogs(IncidentID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ChannelID) REFERENCES NotificationChannels(ChannelID),
    FOREIGN KEY (TemplateID) REFERENCES NotificationTemplates(TemplateID)
);

CREATE TABLE LoadBalancingEvents (
    EventID NUMBER PRIMARY KEY,
    InitiatedBy NUMBER,
    TriggerReason VARCHAR2(100),
    Status VARCHAR2(20) DEFAULT 'Processing',
    StartTime DATE DEFAULT SYSDATE,
    EndTime DATE,
    SuccessRate NUMBER,
    FOREIGN KEY (InitiatedBy) REFERENCES Users(UserID)
);

CREATE TABLE LoadBalancingDetails (
    DetailID NUMBER PRIMARY KEY,
    EventID NUMBER,
    ServerID NUMBER,
    LoadBefore NUMBER,
    LoadAfter NUMBER,
    StatusBefore VARCHAR2(20),
    StatusAfter VARCHAR2(20),
    FOREIGN KEY (EventID) REFERENCES LoadBalancingEvents(EventID),
    FOREIGN KEY (ServerID) REFERENCES Servers(ServerID)
);