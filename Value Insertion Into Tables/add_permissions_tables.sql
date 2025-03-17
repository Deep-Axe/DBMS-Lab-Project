-- Create sequence for Permissions table
CREATE SEQUENCE seq_permissions START WITH 1 INCREMENT BY 1;

-- Create sequence for RolePermissions table
CREATE SEQUENCE seq_role_permissions START WITH 1 INCREMENT BY 1;

-- Create Permissions table - stores individual granular permissions
CREATE TABLE Permissions (
    PermissionID NUMBER PRIMARY KEY,
    PermissionName VARCHAR2(100) NOT NULL UNIQUE,
    Description VARCHAR2(200),
    PermissionCategory VARCHAR2(50) NOT NULL,
    IsActive NUMBER(1) DEFAULT 1,
    CreatedDate DATE DEFAULT SYSDATE,
    LastModifiedDate DATE DEFAULT SYSDATE
);

-- Create RolePermissions table - maps roles to permissions
CREATE TABLE RolePermissions (
    RolePermissionID NUMBER PRIMARY KEY,
    RoleID NUMBER NOT NULL,
    PermissionID NUMBER NOT NULL,
    AssignedDate DATE DEFAULT SYSDATE,
    AssignedBy NUMBER,
    LastModifiedDate DATE DEFAULT SYSDATE,
    LastModifiedBy NUMBER,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    FOREIGN KEY (PermissionID) REFERENCES Permissions(PermissionID),
    FOREIGN KEY (AssignedBy) REFERENCES Users(UserID),
    FOREIGN KEY (LastModifiedBy) REFERENCES Users(UserID),
    UNIQUE (RoleID, PermissionID)
);

-- Insert standard permissions
INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'VIEW_SERVERS', 'Can view server details', 'SERVER_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'EDIT_SERVERS', 'Can edit server details', 'SERVER_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'RESTART_SERVERS', 'Can restart servers', 'SERVER_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'VIEW_CONFIGURATIONS', 'Can view configurations', 'CONFIGURATION');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'EDIT_CONFIGURATIONS', 'Can edit configurations', 'CONFIGURATION');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'MANAGE_USERS', 'Can manage user accounts', 'USER_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'VIEW_INCIDENTS', 'Can view incidents', 'INCIDENT_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'MANAGE_INCIDENTS', 'Can manage incidents', 'INCIDENT_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'EXECUTE_AUTOMATION', 'Can execute automation tasks', 'AUTOMATION');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'MANAGE_LOAD_BALANCING', 'Can manage load balancing', 'SERVER_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'VIEW_METRICS', 'Can view server metrics', 'MONITORING');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'VIEW_ALERTS', 'Can view alerts', 'MONITORING');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'MANAGE_ALERTS', 'Can manage alert configurations', 'MONITORING');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'VIEW_AUDIT_LOGS', 'Can view system audit logs', 'SECURITY');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (seq_permissions.NEXTVAL, 'MANAGE_SERVER_GROUPS', 'Can manage server groups', 'SERVER_MANAGEMENT');

-- Assign permissions to roles based on their permission levels
-- System Administrator (permission level 100) gets all permissions
INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
SELECT seq_role_permissions.NEXTVAL, 
       (SELECT RoleID FROM Roles WHERE RoleName = 'System Administrator'), 
       PermissionID 
FROM Permissions;

-- Server Administrator (permission level 80) gets server management permissions
INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Server Administrator'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'VIEW_SERVERS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Server Administrator'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'EDIT_SERVERS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Server Administrator'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'RESTART_SERVERS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Server Administrator'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'VIEW_CONFIGURATIONS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Server Administrator'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'EDIT_CONFIGURATIONS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Server Administrator'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'EXECUTE_AUTOMATION'));

-- Security Officer (permission level 90) gets security-related permissions
INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Security Officer'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'VIEW_SERVERS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Security Officer'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'MANAGE_USERS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Security Officer'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'VIEW_AUDIT_LOGS'));

-- Support Technician (permission level 50) gets basic support permissions
INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Support Technician'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'VIEW_SERVERS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Support Technician'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'VIEW_INCIDENTS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Support Technician'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'MANAGE_INCIDENTS'));

-- Read-Only User (permission level 10) gets only view permissions
INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Read-Only User'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'VIEW_SERVERS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Read-Only User'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'VIEW_METRICS'));

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_role_permissions.NEXTVAL, 
        (SELECT RoleID FROM Roles WHERE RoleName = 'Read-Only User'), 
        (SELECT PermissionID FROM Permissions WHERE PermissionName = 'VIEW_INCIDENTS'));