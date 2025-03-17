-- Insert data into Servers table
INSERT INTO Servers (ServerID, ServerName, IPAddress, OperatingSystem, Status, LastRestartTime, LastCheckedTime, MaxLoadCapacity, LocationID, CreatedDate, CreatedBy)
VALUES (seq_servers.NEXTVAL, 'PROD-WEB-01', '10.0.1.101', 'Ubuntu 22.04 LTS', 'Running', TO_DATE('2025-03-15 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'), 85, 1, SYSDATE, 1);

INSERT INTO Servers (ServerID, ServerName, IPAddress, OperatingSystem, Status, LastRestartTime, LastCheckedTime, MaxLoadCapacity, LocationID, CreatedDate, CreatedBy)
VALUES (seq_servers.NEXTVAL, 'PROD-WEB-02', '10.0.1.102', 'Ubuntu 22.04 LTS', 'Running', TO_DATE('2025-03-14 23:45:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'), 85, 1, SYSDATE, 1);

INSERT INTO Servers (ServerID, ServerName, IPAddress, OperatingSystem, Status, LastRestartTime, LastCheckedTime, MaxLoadCapacity, LocationID, CreatedDate, CreatedBy)
VALUES (seq_servers.NEXTVAL, 'PROD-DB-01', '10.0.1.201', 'Oracle Linux 8.5', 'Running', TO_DATE('2025-03-10 02:15:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'), 90, 1, SYSDATE, 1);

INSERT INTO Servers (ServerID, ServerName, IPAddress, OperatingSystem, Status, LastRestartTime, LastCheckedTime, MaxLoadCapacity, LocationID, CreatedDate, CreatedBy)
VALUES (seq_servers.NEXTVAL, 'DR-WEB-01', '10.0.2.101', 'Ubuntu 22.04 LTS', 'Standby', TO_DATE('2025-03-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'), 85, 2, SYSDATE, 1);

INSERT INTO Servers (ServerID, ServerName, IPAddress, OperatingSystem, Status, LastRestartTime, LastCheckedTime, MaxLoadCapacity, LocationID, CreatedDate, CreatedBy)
VALUES (seq_servers.NEXTVAL, 'DR-DB-01', '10.0.2.201', 'Oracle Linux 8.5', 'Standby', TO_DATE('2025-03-01 00:15:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'), 90, 2, SYSDATE, 1);

INSERT INTO Servers (ServerID, ServerName, IPAddress, OperatingSystem, Status, LastRestartTime, LastCheckedTime, MaxLoadCapacity, LocationID, CreatedDate, CreatedBy)
VALUES (seq_servers.NEXTVAL, 'EDGE-CDN-01', '10.0.3.101', 'Alpine Linux 3.15', 'Running', TO_DATE('2025-03-16 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'), 70, 3, SYSDATE, 2);

-- Insert data into ServerGroups
INSERT INTO ServerGroups (GroupID, GroupName, Description, CreatedBy, CreatedDate)
VALUES (seq_server_groups.NEXTVAL, 'Production Web Servers', 'Web servers in production environment', 1, SYSDATE);

INSERT INTO ServerGroups (GroupID, GroupName, Description, CreatedBy, CreatedDate)
VALUES (seq_server_groups.NEXTVAL, 'Production Database Servers', 'Database servers in production environment', 1, SYSDATE);

INSERT INTO ServerGroups (GroupID, GroupName, Description, CreatedBy, CreatedDate)
VALUES (seq_server_groups.NEXTVAL, 'Disaster Recovery', 'All DR site servers', 1, SYSDATE);

INSERT INTO ServerGroups (GroupID, GroupName, Description, CreatedBy, CreatedDate)
VALUES (seq_server_groups.NEXTVAL, 'Edge Network', 'Edge location servers for content delivery', 2, SYSDATE);

-- Insert data into ServerGroupMapping
INSERT INTO ServerGroupMapping (MappingID, ServerID, GroupID)
VALUES (seq_server_group_mapping.NEXTVAL, 1, 1); -- PROD-WEB-01 -> Production Web Servers

INSERT INTO ServerGroupMapping (MappingID, ServerID, GroupID)
VALUES (seq_server_group_mapping.NEXTVAL, 2, 1); -- PROD-WEB-02 -> Production Web Servers

INSERT INTO ServerGroupMapping (MappingID, ServerID, GroupID)
VALUES (seq_server_group_mapping.NEXTVAL, 3, 2); -- PROD-DB-01 -> Production Database Servers

INSERT INTO ServerGroupMapping (MappingID, ServerID, GroupID)
VALUES (seq_server_group_mapping.NEXTVAL, 4, 3); -- DR-WEB-01 -> Disaster Recovery

INSERT INTO ServerGroupMapping (MappingID, ServerID, GroupID)
VALUES (seq_server_group_mapping.NEXTVAL, 5, 3); -- DR-DB-01 -> Disaster Recovery

INSERT INTO ServerGroupMapping (MappingID, ServerID, GroupID)
VALUES (seq_server_group_mapping.NEXTVAL, 6, 4); -- EDGE-CDN-01 -> Edge Network

-- Insert data into AuthTokens
INSERT INTO AuthTokens (TokenID, UserID, TokenValue, IssuedAt, ExpiresAt, TokenType, DeviceInfo, IPAddress)
VALUES (1, 1, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwibmFtZSI6ImFkbWluIiwiaWF0IjoxNjc5MTMzMDc1LCJleHAiOjE2NzkxMzY2NzV9', 
        TO_DATE('2025-03-17 00:30:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-17 06:30:00', 'YYYY-MM-DD HH24:MI:SS'), 
        'Bearer', 'Chrome 130.0, Windows 11', '192.168.1.100');

INSERT INTO AuthTokens (TokenID, UserID, TokenValue, IssuedAt, ExpiresAt, TokenType, DeviceInfo, IPAddress)
VALUES (2, 2, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIyIiwibmFtZSI6InNlcnZlcmFkbWluIiwiaWF0IjoxNjc5MTMzMDc1LCJleHAiOjE2NzkxMzY2NzV9', 
        TO_DATE('2025-03-17 01:15:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-17 07:15:00', 'YYYY-MM-DD HH24:MI:SS'), 
        'Bearer', 'Firefox 115.0, macOS 14.3', '192.168.1.101');

INSERT INTO AuthTokens (TokenID, UserID, TokenValue, IssuedAt, ExpiresAt, TokenType, DeviceInfo, IPAddress)
VALUES (3, 3, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzIiwibmFtZSI6InNlY3VyaXR5IiwiaWF0IjoxNjc5MTMzMDc1LCJleHAiOjE2NzkxMzY2NzV9', 
        TO_DATE('2025-03-16 22:45:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-17 04:45:00', 'YYYY-MM-DD HH24:MI:SS'), 
        'Bearer', 'Safari 17.2, iOS 17.4', '192.168.1.102');

-- Insert data into UserSessions
INSERT INTO UserSessions (SessionID, UserID, SessionToken, LoginTime, LastActivityTime, ExpiryTime, IPAddress, UserAgent)
VALUES (1, 1, 'f7e79a8e8f9c9d8c7b6a5b4c3d2e1f0', 
        TO_DATE('2025-03-17 00:30:00', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-17 01:23:45', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-17 08:30:00', 'YYYY-MM-DD HH24:MI:SS'),
        '192.168.1.100', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) Chrome/130.0.0.0');

INSERT INTO UserSessions (SessionID, UserID, SessionToken, LoginTime, LastActivityTime, ExpiryTime, IPAddress, UserAgent)
VALUES (2, 2, 'a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p', 
        TO_DATE('2025-03-17 01:15:00', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-17 01:22:30', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-17 09:15:00', 'YYYY-MM-DD HH24:MI:SS'),
        '192.168.1.101', 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15) Firefox/115.0');

INSERT INTO UserSessions (SessionID, UserID, SessionToken, LoginTime, LastActivityTime, ExpiryTime, IPAddress, UserAgent)
VALUES (3, 3, '1a2b3c4d5e6f7g8h9i0j1k2l3m4n5o6p', 
        TO_DATE('2025-03-16 22:45:00', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-16 23:50:10', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-17 06:45:00', 'YYYY-MM-DD HH24:MI:SS'),
        '192.168.1.102', 'Mozilla/5.0 (iPhone; CPU iPhone OS 17_4 like Mac OS X) Version/17.2 Safari/605.1.15');

-- Insert data into PasswordResetTokens
INSERT INTO PasswordResetTokens (TokenID, UserID, ResetToken, CreatedAt, ExpiresAt, Used)
VALUES (1, 4, 'e7d6c5b4a3f2e1d0c9b8a7f6e5d4c3b2', 
        TO_DATE('2025-03-16 14:30:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-16 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), 
        1); -- Used token for support user

INSERT INTO PasswordResetTokens (TokenID, UserID, ResetToken, CreatedAt, ExpiresAt, Used)
VALUES (2, 5, 'f8e7d6c5b4a3f2e1d0c9b8a7f6e5d4c3', 
        TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-17 02:00:00', 'YYYY-MM-DD HH24:MI:SS'), 
        0); -- Unused token for readonly user

-- Insert data into ServerMetrics
INSERT INTO ServerMetrics (MetricID, ServerID, CPUUsage, MemoryUsage, DiskUsage, NetworkTraffic, Timestamp)
VALUES (seq_server_metrics.NEXTVAL, 1, 45.7, 62.3, 58.1, 78.5, TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO ServerMetrics (MetricID, ServerID, CPUUsage, MemoryUsage, DiskUsage, NetworkTraffic, Timestamp)
VALUES (seq_server_metrics.NEXTVAL, 1, 47.2, 63.5, 58.2, 82.1, TO_DATE('2025-03-17 01:15:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO ServerMetrics (MetricID, ServerID, CPUUsage, MemoryUsage, DiskUsage, NetworkTraffic, Timestamp)
VALUES (seq_server_metrics.NEXTVAL, 2, 38.9, 55.4, 47.2, 65.3, TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO ServerMetrics (MetricID, ServerID, CPUUsage, MemoryUsage, DiskUsage, NetworkTraffic, Timestamp)
VALUES (seq_server_metrics.NEXTVAL, 2, 42.1, 56.8, 47.3, 68.7, TO_DATE('2025-03-17 01:15:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO ServerMetrics (MetricID, ServerID, CPUUsage, MemoryUsage, DiskUsage, NetworkTraffic, Timestamp)
VALUES (seq_server_metrics.NEXTVAL, 3, 72.5, 81.3, 65.8, 32.4, TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO ServerMetrics (MetricID, ServerID, CPUUsage, MemoryUsage, DiskUsage, NetworkTraffic, Timestamp)
VALUES (seq_server_metrics.NEXTVAL, 3, 75.8, 83.2, 66.1, 30.9, TO_DATE('2025-03-17 01:15:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO ServerMetrics (MetricID, ServerID, CPUUsage, MemoryUsage, DiskUsage, NetworkTraffic, Timestamp)
VALUES (seq_server_metrics.NEXTVAL, 4, 5.2, 12.7, 25.9, 0.7, TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO ServerMetrics (MetricID, ServerID, CPUUsage, MemoryUsage, DiskUsage, NetworkTraffic, Timestamp)
VALUES (seq_server_metrics.NEXTVAL, 5, 4.8, 13.1, 24.5, 0.5, TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO ServerMetrics (MetricID, ServerID, CPUUsage, MemoryUsage, DiskUsage, NetworkTraffic, Timestamp)
VALUES (seq_server_metrics.NEXTVAL, 6, 62.3, 45.7, 38.2, 87.9, TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO ServerMetrics (MetricID, ServerID, CPUUsage, MemoryUsage, DiskUsage, NetworkTraffic, Timestamp)
VALUES (seq_server_metrics.NEXTVAL, 6, 67.5, 48.2, 38.5, 92.3, TO_DATE('2025-03-17 01:15:00', 'YYYY-MM-DD HH24:MI:SS'));