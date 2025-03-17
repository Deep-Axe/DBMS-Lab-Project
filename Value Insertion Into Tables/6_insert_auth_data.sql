-- Insert Locations
INSERT INTO Locations (LocationID, LocationName, Address, ContactPerson, ContactEmail)
VALUES (seq_locations.NEXTVAL, 'Primary Datacenter', '123 Server St, Cloud City', 'John Admin', 'john.admin@example.com');

INSERT INTO Locations (LocationID, LocationName, Address, ContactPerson, ContactEmail)
VALUES (seq_locations.NEXTVAL, 'Disaster Recovery Site', '456 Backup Ave, Secure Valley', 'Sarah Backup', 'sarah.backup@example.com');

INSERT INTO Locations (LocationID, LocationName, Address, ContactPerson, ContactEmail)
VALUES (seq_locations.NEXTVAL, 'Edge Location East', '789 Edge Blvd, East Region', 'Mike Edge', 'mike.edge@example.com');

-- Insert Roles
INSERT INTO Roles (RoleID, RoleName, Description, PermissionLevel, IsSystem)
VALUES (seq_roles.NEXTVAL, 'System Administrator', 'Full system access with all privileges', 100, 1);

INSERT INTO Roles (RoleID, RoleName, Description, PermissionLevel, IsSystem)
VALUES (seq_roles.NEXTVAL, 'Server Administrator', 'Can manage and configure servers', 80, 1);

INSERT INTO Roles (RoleID, RoleName, Description, PermissionLevel, IsSystem)
VALUES (seq_roles.NEXTVAL, 'Security Officer', 'Oversees security policies and alerts', 90, 1);

INSERT INTO Roles (RoleID, RoleName, Description, PermissionLevel, IsSystem)
VALUES (seq_roles.NEXTVAL, 'Support Technician', 'Handles incidents and basic server tasks', 50, 1);

INSERT INTO Roles (RoleID, RoleName, Description, PermissionLevel, IsSystem)
VALUES (seq_roles.NEXTVAL, 'Read-Only User', 'Can only view system information', 10, 1);

-- Insert Users with proper password hashing (these are example hashes)
-- In a real C# application, you would use a secure hashing method like BCrypt or PBKDF2
INSERT INTO Users (UserID, UserName, PasswordHash, Salt, Email, FullName, Active, TwoFactorEnabled, LastPasswordChange, CreatedDate)
VALUES (seq_users.NEXTVAL, 'admin', 
        'D8F14CC599B554CE9DB435F22B3D9C24CA84225B3821C033CD61958DB817C657', -- Example hash for 'admin123!'
        '7A9D736AE3B5CFCB557740AB8B347CF8', -- Example salt
        'admin@example.com', 'System Administrator', 1, 1, SYSDATE, SYSDATE);

INSERT INTO Users (UserID, UserName, PasswordHash, Salt, Email, FullName, Active, TwoFactorEnabled, LastPasswordChange, CreatedDate)
VALUES (seq_users.NEXTVAL, 'serveradmin', 
        '5E1B3A6E11A3C55CC211553425D2F9256305B90AC7B9F91204C7D1AF4897F220', -- Example hash for 'server123!'
        '4D8A1F3B2C7E9A6D5F2E8B3C7D9A6F5E', -- Example salt
        'server.admin@example.com', 'Server Administrator', 1, 1, SYSDATE, SYSDATE);

INSERT INTO Users (UserID, UserName, PasswordHash, Salt, Email, FullName, Active, TwoFactorEnabled, LastPasswordChange, CreatedDate)
VALUES (seq_users.NEXTVAL, 'security', 
        'A76C7B55F07212C45E7B6A0EF8A0E69A7B5FE4FD86C901DE8C57A4BCB49F8CBB', -- Example hash for 'security123!'
        '1A2B3C4D5E6F7A8B9C0D1E2F3A4B5C6D', -- Example salt
        'security@example.com', 'Security Officer', 1, 1, SYSDATE, SYSDATE);

INSERT INTO Users (UserID, UserName, PasswordHash, Salt, Email, FullName, Active, LastPasswordChange, CreatedDate)
VALUES (seq_users.NEXTVAL, 'support', 
        'F5EA1F59FB6F757E082FD57176F776AE1F585CB7138EE798851B4ADC65886C20', -- Example hash for 'support123!'
        'B7C8D9E0F1A2B3C4D5E6F7A8B9C0D1E2', -- Example salt
        'support@example.com', 'Support Technician', 1, SYSDATE, SYSDATE);

INSERT INTO Users (UserID, UserName, PasswordHash, Salt, Email, FullName, Active, LastPasswordChange, CreatedDate)
VALUES (seq_users.NEXTVAL, 'readonly', 
        '6CB7B18A94553857DEA9331D539D192E9809FBC382A8894CE4E4C43913A51BEA', -- Example hash for 'readonly123!'
        'F7E6D5C4B3A2F1E0D9C8B7A6F5E4D3C2', -- Example salt
        'readonly@example.com', 'Read Only User', 1, SYSDATE, SYSDATE);

-- Assign Roles to Users
INSERT INTO UserRoles (UserRoleID, UserID, RoleID, AssignedDate)
VALUES (seq_user_roles.NEXTVAL, 1, 1, SYSDATE);  -- admin -> System Administrator

INSERT INTO UserRoles (UserRoleID, UserID, RoleID, AssignedDate)
VALUES (seq_user_roles.NEXTVAL, 2, 2, SYSDATE);  -- serveradmin -> Server Administrator

INSERT INTO UserRoles (UserRoleID, UserID, RoleID, AssignedDate)
VALUES (seq_user_roles.NEXTVAL, 3, 3, SYSDATE);  -- security -> Security Officer

INSERT INTO UserRoles (UserRoleID, UserID, RoleID, AssignedDate)
VALUES (seq_user_roles.NEXTVAL, 4, 4, SYSDATE);  -- support -> Support Technician

INSERT INTO UserRoles (UserRoleID, UserID, RoleID, AssignedDate)
VALUES (seq_user_roles.NEXTVAL, 5, 5, SYSDATE);  -- readonly -> Read-Only User