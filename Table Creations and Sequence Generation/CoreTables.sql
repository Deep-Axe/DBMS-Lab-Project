CREATE TABLE Locations (
    LocationID NUMBER PRIMARY KEY,
    LocationName VARCHAR2(100) NOT NULL,
    Address VARCHAR2(200),
    ContactPerson VARCHAR2(100),
    ContactEmail VARCHAR2(100)
);

CREATE TABLE Users (
    UserID NUMBER PRIMARY KEY,
    UserName VARCHAR2(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR2(128) NOT NULL,
    Salt VARCHAR2(64) NOT NULL,  
    Email VARCHAR2(100) NOT NULL,
    FullName VARCHAR2(100),
    LastLoginTime DATE,
    Active NUMBER(1) DEFAULT 1,
    FailedLoginAttempts NUMBER DEFAULT 0,
    AccountLocked NUMBER(1) DEFAULT 0,
    LockoutEnd DATE,
    LastPasswordChange DATE DEFAULT SYSDATE,
    RequirePasswordChange NUMBER(1) DEFAULT 0,
    TwoFactorEnabled NUMBER(1) DEFAULT 0,
    TwoFactorKey VARCHAR2(100),
    ApiKey VARCHAR2(128),
    ApiKeyExpiration DATE,
    CreatedDate DATE DEFAULT SYSDATE,
    CreatedBy NUMBER
);

CREATE TABLE Roles (
    RoleID NUMBER PRIMARY KEY,
    RoleName VARCHAR2(50) NOT NULL UNIQUE,
    Description VARCHAR2(200),
    PermissionLevel NUMBER NOT NULL,
    IsSystem NUMBER(1) DEFAULT 0,  
    CreatedDate DATE DEFAULT SYSDATE,
    LastModified DATE DEFAULT SYSDATE
);

CREATE TABLE UserRoles (
    UserRoleID NUMBER PRIMARY KEY,
    UserID NUMBER,
    RoleID NUMBER,
    AssignedDate DATE DEFAULT SYSDATE,
    AssignedBy NUMBER,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    FOREIGN KEY (AssignedBy) REFERENCES Users(UserID),
    UNIQUE (UserID, RoleID)
);

CREATE TABLE Permissions (
    PermissionID NUMBER PRIMARY KEY,
    PermissionName VARCHAR2(100) NOT NULL UNIQUE,
    Description VARCHAR2(200),
    PermissionCategory VARCHAR2(50) NOT NULL
);

CREATE TABLE RolePermissions (
    RolePermissionID NUMBER PRIMARY KEY,
    RoleID NUMBER NOT NULL,
    PermissionID NUMBER NOT NULL,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    FOREIGN KEY (PermissionID) REFERENCES Permissions(PermissionID),
    UNIQUE (RoleID, PermissionID)
);

CREATE TABLE Servers (
    ServerID NUMBER PRIMARY KEY,
    ServerName VARCHAR2(100) UNIQUE NOT NULL,
    IPAddress VARCHAR2(15),
    OperatingSystem VARCHAR2(50),
    Status VARCHAR2(20) DEFAULT 'Running',
    LastRestartTime DATE,
    LastCheckedTime DATE,
    MaxLoadCapacity NUMBER DEFAULT 100,
    LocationID NUMBER,
    CreatedDate DATE DEFAULT SYSDATE,
    CreatedBy NUMBER,
    LastModifiedDate DATE DEFAULT SYSDATE,
    LastModifiedBy NUMBER,
    FOREIGN KEY (LocationID) REFERENCES Locations(LocationID),
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
    FOREIGN KEY (LastModifiedBy) REFERENCES Users(UserID)
);

CREATE TABLE AuthTokens (
    TokenID NUMBER PRIMARY KEY,
    UserID NUMBER NOT NULL,
    TokenValue VARCHAR2(256) NOT NULL,
    IssuedAt DATE DEFAULT SYSDATE,
    ExpiresAt DATE NOT NULL,
    TokenType VARCHAR2(20) DEFAULT 'Bearer',
    DeviceInfo VARCHAR2(200),
    IPAddress VARCHAR2(50),
    Revoked NUMBER(1) DEFAULT 0,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE UserSessions (
    SessionID NUMBER PRIMARY KEY,
    UserID NUMBER NOT NULL,
    SessionToken VARCHAR2(128) NOT NULL UNIQUE,
    LoginTime DATE DEFAULT SYSDATE,
    LastActivityTime DATE DEFAULT SYSDATE,
    ExpiryTime DATE NOT NULL,
    IPAddress VARCHAR2(50),
    UserAgent VARCHAR2(200),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE PasswordResetTokens (
    TokenID NUMBER PRIMARY KEY,
    UserID NUMBER NOT NULL,
    ResetToken VARCHAR2(128) NOT NULL UNIQUE,
    CreatedAt DATE DEFAULT SYSDATE,
    ExpiresAt DATE NOT NULL,
    Used NUMBER(1) DEFAULT 0,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE ServerMetrics (
    MetricID NUMBER PRIMARY KEY,
    ServerID NUMBER NOT NULL,
    CPUUsage NUMBER,
    MemoryUsage NUMBER,
    DiskUsage NUMBER,
    NetworkTraffic NUMBER,
    Timestamp DATE DEFAULT SYSDATE,
    FOREIGN KEY (ServerID) REFERENCES Servers(ServerID)
);

CREATE TABLE ServerGroups (
    GroupID NUMBER PRIMARY KEY,
    GroupName VARCHAR2(100) NOT NULL UNIQUE,
    Description VARCHAR2(200),
    CreatedBy NUMBER,
    CreatedDate DATE DEFAULT SYSDATE,
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);

CREATE TABLE ServerGroupMapping (
    MappingID NUMBER PRIMARY KEY,
    ServerID NUMBER,
    GroupID NUMBER,
    FOREIGN KEY (ServerID) REFERENCES Servers(ServerID),
    FOREIGN KEY (GroupID) REFERENCES ServerGroups(GroupID),
    UNIQUE (ServerID, GroupID)
);