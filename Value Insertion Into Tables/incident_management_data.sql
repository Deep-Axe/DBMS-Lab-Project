-- Insert data into IncidentTypes
INSERT INTO IncidentTypes (TypeID, TypeName, Description, DefaultSeverity, SLAHours)
VALUES (1, 'Server Outage', 'Complete server unavailability', 'Critical', 2);

INSERT INTO IncidentTypes (TypeID, TypeName, Description, DefaultSeverity, SLAHours)
VALUES (2, 'Performance Degradation', 'Server responding slowly or with high latency', 'High', 4);

INSERT INTO IncidentTypes (TypeID, TypeName, Description, DefaultSeverity, SLAHours)
VALUES (3, 'Disk Space Warning', 'Server running low on disk space', 'Medium', 8);

INSERT INTO IncidentTypes (TypeID, TypeName, Description, DefaultSeverity, SLAHours)
VALUES (4, 'Security Alert', 'Potential security breach or vulnerability', 'High', 3);

INSERT INTO IncidentTypes (TypeID, TypeName, Description, DefaultSeverity, SLAHours)
VALUES (5, 'Backup Failure', 'Scheduled backup failed to complete', 'Medium', 6);

-- Insert data into IncidentLogs
INSERT INTO IncidentLogs (IncidentID, TypeID, ServerID, Title, Description, Severity, Priority, ReportedBy, AssignedTo, Status, CreatedDate, SLADeadline, ResolutionDate, ResolutionSummary, ImpactLevel)
VALUES (1, 2, 1, 'High CPU usage on PROD-WEB-01', 'Server showing sustained CPU usage above 90% for the last 30 minutes', 'High', 'High', 5, 2, 'In Progress', 
        TO_DATE('2025-03-16 23:45:00', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-17 03:45:00', 'YYYY-MM-DD HH24:MI:SS'),
        NULL, NULL, 'Medium');

INSERT INTO IncidentLogs (IncidentID, TypeID, ServerID, Title, Description, Severity, Priority, ReportedBy, AssignedTo, Status, CreatedDate, SLADeadline, ResolutionDate, ResolutionSummary, ImpactLevel)
VALUES (2, 3, 3, 'Low disk space on PROD-DB-01', 'Database server has less than 10% free disk space on data volume', 'Medium', 'Medium', 1, 2, 'Open', 
        TO_DATE('2025-03-17 01:15:00', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-17 09:15:00', 'YYYY-MM-DD HH24:MI:SS'),
        NULL, NULL, 'Low');

INSERT INTO IncidentLogs (IncidentID, TypeID, ServerID, Title, Description, Severity, Priority, ReportedBy, AssignedTo, Status, CreatedDate, SLADeadline, ResolutionDate, ResolutionSummary, ImpactLevel)
VALUES (3, 1, 2, 'PROD-WEB-02 unresponsive', 'Server not responding to ping or SSH connection attempts', 'Critical', 'Urgent', 4, 1, 'Resolved', 
        TO_DATE('2025-03-16 18:20:00', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-16 20:20:00', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-16 19:45:00', 'YYYY-MM-DD HH24:MI:SS'),
        'Restart required due to kernel panic. System logs analyzed and no data corruption found.', 'High');

INSERT INTO IncidentLogs (IncidentID, TypeID, ServerID, Title, Description, Severity, Priority, ReportedBy, AssignedTo, Status, CreatedDate, SLADeadline, ResolutionDate, ResolutionSummary, ImpactLevel)
VALUES (4, 4, 1, 'Suspicious login attempts on PROD-WEB-01', 'Multiple failed login attempts detected from IP range 185.22.x.x', 'High', 'High', 3, 3, 'In Progress', 
        TO_DATE('2025-03-17 00:10:00', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-17 03:10:00', 'YYYY-MM-DD HH24:MI:SS'),
        NULL, NULL, 'High');

INSERT INTO IncidentLogs (IncidentID, TypeID, ServerID, Title, Description, Severity, Priority, ReportedBy, AssignedTo, Status, CreatedDate, SLADeadline, ResolutionDate, ResolutionSummary, ImpactLevel)
VALUES (5, 5, 5, 'Nightly backup failed on DR-DB-01', 'Error in backup job: insufficient storage space in backup volume', 'Medium', 'Medium', 2, 4, 'Open', 
        TO_DATE('2025-03-17 01:30:00', 'YYYY-MM-DD HH24:MI:SS'),
        TO_DATE('2025-03-17 07:30:00', 'YYYY-MM-DD HH24:MI:SS'),
        NULL, NULL, 'Medium');

-- Insert data into IncidentComments
INSERT INTO IncidentComments (CommentID, IncidentID, CommentText, CommentedBy, Timestamp, IsInternal)
VALUES (1, 1, 'Initial investigation shows a runaway process with PID 4582. Checking process details now.', 2, TO_DATE('2025-03-17 00:05:00', 'YYYY-MM-DD HH24:MI:SS'), 0);

INSERT INTO IncidentComments (CommentID, IncidentID, CommentText, CommentedBy, Timestamp, IsInternal)
VALUES (2, 1, 'Process identified as search indexer gone rogue. Will need to restart the indexing service.', 2, TO_DATE('2025-03-17 00:30:00', 'YYYY-MM-DD HH24:MI:SS'), 0);

INSERT INTO IncidentComments (CommentID, IncidentID, CommentText, CommentedBy, Timestamp, IsInternal)
VALUES (3, 3, 'Server restart initiated via iLO remote console.', 1, TO_DATE('2025-03-16 19:10:00', 'YYYY-MM-DD HH24:MI:SS'), 0);

INSERT INTO IncidentComments (CommentID, IncidentID, CommentText, CommentedBy, Timestamp, IsInternal)
VALUES (4, 3, 'Post-mortem needed to determine root cause of kernel panic - schedule for tomorrow.', 1, TO_DATE('2025-03-16 19:50:00', 'YYYY-MM-DD HH24:MI:SS'), 1);

INSERT INTO IncidentComments (CommentID, IncidentID, CommentText, CommentedBy, Timestamp, IsInternal)
VALUES (5, 4, 'Updated firewall rules to block offending IP range. Reviewing authentication logs.', 3, TO_DATE('2025-03-17 00:40:00', 'YYYY-MM-DD HH24:MI:SS'), 0);

INSERT INTO IncidentComments (CommentID, IncidentID, CommentText, CommentedBy, Timestamp, IsInternal)
VALUES (6, 4, 'Note: This appears to be part of the botnet activity we''ve seen across other clients as well. Coordinate with SOC team.', 3, TO_DATE('2025-03-17 01:05:00', 'YYYY-MM-DD HH24:MI:SS'), 1);

INSERT INTO IncidentComments (CommentID, IncidentID, CommentText, CommentedBy, Timestamp, IsInternal)
VALUES (7, 2, 'Will clean up temp files and analyze disk usage patterns.', 2, TO_DATE('2025-03-17 01:25:00', 'YYYY-MM-DD HH24:MI:SS'), 0);

-- Insert data into IncidentStatusHistory
INSERT INTO IncidentStatusHistory (HistoryID, IncidentID, OldStatus, NewStatus, ChangedBy, ChangeTime, Comment)
VALUES (1, 1, NULL, 'Open', 5, TO_DATE('2025-03-16 23:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'Initial incident creation');

INSERT INTO IncidentStatusHistory (HistoryID, IncidentID, OldStatus, NewStatus, ChangedBy, ChangeTime, Comment)
VALUES (2, 1, 'Open', 'In Progress', 2, TO_DATE('2025-03-16 23:55:00', 'YYYY-MM-DD HH24:MI:SS'), 'Starting investigation');

INSERT INTO IncidentStatusHistory (HistoryID, IncidentID, OldStatus, NewStatus, ChangedBy, ChangeTime, Comment)
VALUES (3, 3, NULL, 'Open', 4, TO_DATE('2025-03-16 18:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'Initial incident creation');

INSERT INTO IncidentStatusHistory (HistoryID, IncidentID, OldStatus, NewStatus, ChangedBy, ChangeTime, Comment)
VALUES (4, 3, 'Open', 'In Progress', 1, TO_DATE('2025-03-16 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Emergency response initiated');

INSERT INTO IncidentStatusHistory (HistoryID, IncidentID, OldStatus, NewStatus, ChangedBy, ChangeTime, Comment)
VALUES (5, 3, 'In Progress', 'Resolved', 1, TO_DATE('2025-03-16 19:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'Server successfully restarted and verified operational');

INSERT INTO IncidentStatusHistory (HistoryID, IncidentID, OldStatus, NewStatus, ChangedBy, ChangeTime, Comment)
VALUES (6, 4, NULL, 'Open', 3, TO_DATE('2025-03-17 00:10:00', 'YYYY-MM-DD HH24:MI:SS'), 'Initial incident creation');

INSERT INTO IncidentStatusHistory (HistoryID, IncidentID, OldStatus, NewStatus, ChangedBy, ChangeTime, Comment)
VALUES (7, 4, 'Open', 'In Progress', 3, TO_DATE('2025-03-17 00:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'Security team investigating');

INSERT INTO IncidentStatusHistory (HistoryID, IncidentID, OldStatus, NewStatus, ChangedBy, ChangeTime, Comment)
VALUES (8, 2, NULL, 'Open', 1, TO_DATE('2025-03-17 01:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'Initial incident creation');

INSERT INTO IncidentStatusHistory (HistoryID, IncidentID, OldStatus, NewStatus, ChangedBy, ChangeTime, Comment)
VALUES (9, 5, NULL, 'Open', 2, TO_DATE('2025-03-17 01:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Initial incident creation');

-- Insert data into NotificationChannels
INSERT INTO NotificationChannels (ChannelID, ChannelName, ChannelType, Configuration, Active, CreatedBy, CreatedDate)
VALUES (1, 'Email Notifications', 'EMAIL', 
        '{"smtpServer":"smtp.company.com","port":587,"username":"alerts@company.com","useTLS":true}', 
        1, 1, TO_DATE('2025-01-15', 'YYYY-MM-DD'));

INSERT INTO NotificationChannels (ChannelID, ChannelName, ChannelType, Configuration, Active, CreatedBy, CreatedDate)
VALUES (2, 'SMS Alerts', 'SMS', 
        '{"provider":"Twilio","accountSid":"AC123456789abcdef","authToken":"auth_token_here"}', 
        1, 1, TO_DATE('2025-01-15', 'YYYY-MM-DD'));

INSERT INTO NotificationChannels (ChannelID, ChannelName, ChannelType, Configuration, Active, CreatedBy, CreatedDate)
VALUES (3, 'Teams Webhook', 'WEBHOOK', 
        '{"url":"https://outlook.office.com/webhook/123456789/IncomingWebhook/abcdef123456789/ghijklm"}', 
        1, 1, TO_DATE('2025-01-15', 'YYYY-MM-DD'));

INSERT INTO NotificationChannels (ChannelID, ChannelName, ChannelType, Configuration, Active, CreatedBy, CreatedDate)
VALUES (4, 'Slack Channel', 'WEBHOOK', 
        '{"url":"https://hooks.slack.com/services/T00000000/B00000000/XXXXXXXXXXXXXXXXXXXXXXXX"}', 
        1, 2, TO_DATE('2025-02-10', 'YYYY-MM-DD'));

-- Insert data into NotificationTemplates
INSERT INTO NotificationTemplates (TemplateID, TemplateName, Subject, BodyTemplate, EventType, CreatedBy, CreatedDate)
VALUES (1, 'Critical Incident Alert', 'CRITICAL ALERT: {{IncidentTitle}}', 
        'A critical incident has been reported:\n\nServer: {{ServerName}}\nIncident: {{IncidentTitle}}\nTime: {{ReportTime}}\n\nPlease respond immediately.', 
        'INCIDENT_CREATED', 1, TO_DATE('2025-01-15', 'YYYY-MM-DD'));

INSERT INTO NotificationTemplates (TemplateID, TemplateName, Subject, BodyTemplate, EventType, CreatedBy, CreatedDate)
VALUES (2, 'Incident Assignment', 'Incident Assigned: {{IncidentTitle}}', 
        'An incident has been assigned to you:\n\nIncident ID: {{IncidentID}}\nServer: {{ServerName}}\nDescription: {{IncidentDescription}}\n\nPlease review and update the status.', 
        'INCIDENT_ASSIGNED', 1, TO_DATE('2025-01-15', 'YYYY-MM-DD'));

INSERT INTO NotificationTemplates (TemplateID, TemplateName, Subject, BodyTemplate, EventType, CreatedBy, CreatedDate)
VALUES (3, 'Incident Resolution', 'Resolved: {{IncidentTitle}}', 
        'Incident has been resolved:\n\nIncident ID: {{IncidentID}}\nServer: {{ServerName}}\nResolution: {{ResolutionSummary}}\nResolved by: {{ResolvedBy}}\nTime to resolution: {{TimeToResolve}}', 
        'INCIDENT_RESOLVED', 1, TO_DATE('2025-01-15', 'YYYY-MM-DD'));

INSERT INTO NotificationTemplates (TemplateID, TemplateName, Subject, BodyTemplate, EventType, CreatedBy, CreatedDate)
VALUES (4, 'SLA Warning', 'SLA WARNING: {{IncidentTitle}}', 
        'An incident is approaching its SLA deadline:\n\nIncident ID: {{IncidentID}}\nTitle: {{IncidentTitle}}\nTime Remaining: {{TimeRemaining}} hours\nCurrent Status: {{Status}}', 
        'SLA_WARNING', 1, TO_DATE('2025-01-15', 'YYYY-MM-DD'));

-- Insert data into Notifications
INSERT INTO Notifications (NotificationID, IncidentID, UserID, ChannelID, TemplateID, SentTime, Status, Retries, Content)
VALUES (1, 3, 1, 1, 1, TO_DATE('2025-03-16 18:21:00', 'YYYY-MM-DD HH24:MI:SS'), 'Delivered', 0, 
        'A critical incident has been reported:

Server: PROD-WEB-02
Incident: PROD-WEB-02 unresponsive
Time: 2025-03-16 18:20:00

Please respond immediately.');

INSERT INTO Notifications (NotificationID, IncidentID, UserID, ChannelID, TemplateID, SentTime, Status, Retries, Content)
VALUES (2, 3, 1, 2, 1, TO_DATE('2025-03-16 18:21:30', 'YYYY-MM-DD HH24:MI:SS'), 'Delivered', 0, 
        'CRITICAL ALERT: PROD-WEB-02 unresponsive. Please respond immediately.');

INSERT INTO Notifications (NotificationID, IncidentID, UserID, ChannelID, TemplateID, SentTime, Status, Retries, Content)
VALUES (3, 1, 2, 1, 2, TO_DATE('2025-03-16 23:50:00', 'YYYY-MM-DD HH24:MI:SS'), 'Delivered', 0, 
        'An incident has been assigned to you:

Incident ID: 1
Server: PROD-WEB-01
Description: Server showing sustained CPU usage above 90% for the last 30 minutes

Please review and update the status.');

INSERT INTO Notifications (NotificationID, IncidentID, UserID, ChannelID, TemplateID, SentTime, Status, Retries, Content)
VALUES (4, 3, 4, 1, 3, TO_DATE('2025-03-16 19:46:00', 'YYYY-MM-DD HH24:MI:SS'), 'Delivered', 0, 
        'Incident has been resolved:

Incident ID: 3
Server: PROD-WEB-02
Resolution: Restart required due to kernel panic. System logs analyzed and no data corruption found.
Resolved by: System Administrator
Time to resolution: 1 hour 25 minutes');

INSERT INTO Notifications (NotificationID, IncidentID, UserID, ChannelID, TemplateID, SentTime, Status, Retries, Content)
VALUES (5, 4, 3, 1, 2, TO_DATE('2025-03-17 00:11:00', 'YYYY-MM-DD HH24:MI:SS'), 'Delivered', 0, 
        'An incident has been assigned to you:

Incident ID: 4
Server: PROD-WEB-01
Description: Multiple failed login attempts detected from IP range 185.22.x.x

Please review and update the status.');

-- Insert data into LoadBalancingEvents
INSERT INTO LoadBalancingEvents (EventID, InitiatedBy, TriggerReason, Status, StartTime, EndTime, SuccessRate)
VALUES (1, 1, 'High Load Detected', 'Completed', 
        TO_DATE('2025-03-16 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-16 15:35:00', 'YYYY-MM-DD HH24:MI:SS'), 
        100);

INSERT INTO LoadBalancingEvents (EventID, InitiatedBy, TriggerReason, Status, StartTime, EndTime, SuccessRate)
VALUES (2, 2, 'Scheduled Rebalancing', 'Completed', 
        TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-17 01:05:00', 'YYYY-MM-DD HH24:MI:SS'), 
        100);

INSERT INTO LoadBalancingEvents (EventID, InitiatedBy, TriggerReason, Status, StartTime, EndTime, SuccessRate)
VALUES (3, NULL, 'Automatic - CPU Threshold', 'Processing', 
        TO_DATE('2025-03-17 01:35:00', 'YYYY-MM-DD HH24:MI:SS'), 
        NULL, 
        NULL);

-- Insert data into LoadBalancingDetails
INSERT INTO LoadBalancingDetails (DetailID, EventID, ServerID, LoadBefore, LoadAfter, StatusBefore, StatusAfter)
VALUES (1, 1, 1, 92, 65, 'Running', 'Running');

INSERT INTO LoadBalancingDetails (DetailID, EventID, ServerID, LoadBefore, LoadAfter, StatusBefore, StatusAfter)
VALUES (2, 1, 2, 45, 72, 'Running', 'Running');

INSERT INTO LoadBalancingDetails (DetailID, EventID, ServerID, LoadBefore, LoadAfter, StatusBefore, StatusAfter)
VALUES (3, 2, 1, 75, 60, 'Running', 'Running');

INSERT INTO LoadBalancingDetails (DetailID, EventID, ServerID, LoadBefore, LoadAfter, StatusBefore, StatusAfter)
VALUES (4, 2, 2, 40, 55, 'Running', 'Running');

INSERT INTO LoadBalancingDetails (DetailID, EventID, ServerID, LoadBefore, LoadAfter, StatusBefore, StatusAfter)
VALUES (5, 3, 1, 80, NULL, 'Running', NULL);

INSERT INTO LoadBalancingDetails (DetailID, EventID, ServerID, LoadBefore, LoadAfter, StatusBefore, StatusAfter)
VALUES (6, 3, 2, 50, NULL, 'Running', NULL);