CREATE TABLE ConfigurationProfiles (
    ConfigID NUMBER PRIMARY KEY,
    ProfileName VARCHAR2(100) NOT NULL,
    Description VARCHAR2(200),
    CreatedBy NUMBER,
    CreatedDate DATE DEFAULT SYSDATE,
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);

CREATE TABLE ServerConfigurations (
    ServerConfigID NUMBER PRIMARY KEY,
    ServerID NUMBER,
    ConfigID NUMBER,
    ConfigData CLOB,
    IsBaseline NUMBER(1) DEFAULT 0,
    Version NUMBER DEFAULT 1,
    LastUpdated DATE DEFAULT SYSDATE,
    UpdatedBy NUMBER,
    FOREIGN KEY (ServerID) REFERENCES Servers(ServerID),
    FOREIGN KEY (ConfigID) REFERENCES ConfigurationProfiles(ConfigID),
    FOREIGN KEY (UpdatedBy) REFERENCES Users(UserID)
);

CREATE TABLE ConfigurationHistory (
    HistoryID NUMBER PRIMARY KEY,
    ServerConfigID NUMBER,
    ChangeType VARCHAR2(20),
    ChangedDate DATE DEFAULT SYSDATE,
    ChangedBy NUMBER,
    PreviousVersion NUMBER,
    ChangeDetails VARCHAR2(500),
    FOREIGN KEY (ServerConfigID) REFERENCES ServerConfigurations(ServerConfigID),
    FOREIGN KEY (ChangedBy) REFERENCES Users(UserID)
);

CREATE TABLE AlertDefinitions (
    AlertDefID NUMBER PRIMARY KEY,
    MetricType VARCHAR2(50) NOT NULL,
    Condition VARCHAR2(10) NOT NULL,
    Threshold NUMBER NOT NULL,
    Severity VARCHAR2(20) NOT NULL,
    Description VARCHAR2(200),
    CreatedBy NUMBER,
    CreatedDate DATE DEFAULT SYSDATE,
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);

CREATE TABLE AlertsConfig (
    AlertID NUMBER PRIMARY KEY,
    ServerID NUMBER,
    AlertDefID NUMBER,
    Active NUMBER(1) DEFAULT 1,
    CreatedBy NUMBER,
    CreatedDate DATE DEFAULT SYSDATE,
    FOREIGN KEY (ServerID) REFERENCES Servers(ServerID),
    FOREIGN KEY (AlertDefID) REFERENCES AlertDefinitions(AlertDefID),
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);

CREATE TABLE Alerts (
    AlertLogID NUMBER PRIMARY KEY,
    AlertID NUMBER,
    TriggerValue NUMBER,
    TriggerTime DATE DEFAULT SYSDATE,
    Acknowledged NUMBER(1) DEFAULT 0,
    AcknowledgedBy NUMBER,
    AcknowledgedTime DATE,
    FOREIGN KEY (AlertID) REFERENCES AlertsConfig(AlertID),
    FOREIGN KEY (AcknowledgedBy) REFERENCES Users(UserID)
);