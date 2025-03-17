-- Insert Permissions
INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (1, 'VIEW_SERVERS', 'Can view server details', 'SERVER_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (2, 'EDIT_SERVERS', 'Can edit server details', 'SERVER_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (3, 'RESTART_SERVERS', 'Can restart servers', 'SERVER_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (4, 'VIEW_CONFIGURATIONS', 'Can view configurations', 'CONFIGURATION');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (5, 'EDIT_CONFIGURATIONS', 'Can edit configurations', 'CONFIGURATION');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (6, 'MANAGE_USERS', 'Can manage user accounts', 'USER_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (7, 'VIEW_INCIDENTS', 'Can view incidents', 'INCIDENT_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (8, 'MANAGE_INCIDENTS', 'Can manage incidents', 'INCIDENT_MANAGEMENT');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (9, 'EXECUTE_AUTOMATION', 'Can execute automation tasks', 'AUTOMATION');

INSERT INTO Permissions (PermissionID, PermissionName, Description, PermissionCategory)
VALUES (10, 'MANAGE_LOAD_BALANCING', 'Can manage load balancing', 'SERVER_MANAGEMENT');

-- Assign permissions to roles
-- System Administrator gets all permissions
INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
SELECT seq_user_roles.NEXTVAL, 1, PermissionID FROM Permissions;

-- Server Administrator permissions
INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 2, 1); -- VIEW_SERVERS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 2, 2); -- EDIT_SERVERS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 2, 3); -- RESTART_SERVERS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 2, 4); -- VIEW_CONFIGURATIONS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 2, 5); -- EDIT_CONFIGURATIONS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 2, 9); -- EXECUTE_AUTOMATION

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 2, 10); -- MANAGE_LOAD_BALANCING

-- Security Officer permissions
INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 3, 1); -- VIEW_SERVERS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 3, 4); -- VIEW_CONFIGURATIONS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 3, 6); -- MANAGE_USERS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 3, 7); -- VIEW_INCIDENTS

-- Support Technician permissions
INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 4, 1); -- VIEW_SERVERS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 4, 3); -- RESTART_SERVERS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 4, 7); -- VIEW_INCIDENTS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 4, 8); -- MANAGE_INCIDENTS

-- Read-Only User permissions
INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 5, 1); -- VIEW_SERVERS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 5, 4); -- VIEW_CONFIGURATIONS

INSERT INTO RolePermissions (RolePermissionID, RoleID, PermissionID)
VALUES (seq_user_roles.NEXTVAL, 5, 7); -- VIEW_INCIDENTS

-- Insert Server Groups
INSERT INTO ServerGroups (GroupID, GroupName, Description, CreatedBy,