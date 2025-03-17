-- Insert data into ConfigurationProfiles
INSERT INTO ConfigurationProfiles (ConfigID, ProfileName, Description, CreatedBy, CreatedDate)
VALUES (1, 'Web Server Standard', 'Standard configuration for production web servers', 1, TO_DATE('2025-01-10', 'YYYY-MM-DD'));

INSERT INTO ConfigurationProfiles (ConfigID, ProfileName, Description, CreatedBy, CreatedDate)
VALUES (2, 'Database Server Standard', 'Standard configuration for production database servers', 1, TO_DATE('2025-01-10', 'YYYY-MM-DD'));

INSERT INTO ConfigurationProfiles (ConfigID, ProfileName, Description, CreatedBy, CreatedDate)
VALUES (3, 'DR Server Profile', 'Configuration for disaster recovery servers', 1, TO_DATE('2025-01-15', 'YYYY-MM-DD'));

INSERT INTO ConfigurationProfiles (ConfigID, ProfileName, Description, CreatedBy, CreatedDate)
VALUES (4, 'Edge Server Profile', 'Configuration for edge servers with content delivery', 2, TO_DATE('2025-01-20', 'YYYY-MM-DD'));

INSERT INTO ConfigurationProfiles (ConfigID, ProfileName, Description, CreatedBy, CreatedDate)
VALUES (5, 'High Security Profile', 'Enhanced security configuration for sensitive servers', 3, TO_DATE('2025-02-05', 'YYYY-MM-DD'));

-- Insert data into ServerConfigurations
INSERT INTO ServerConfigurations (ServerConfigID, ServerID, ConfigID, ConfigData, IsBaseline, Version, LastUpdated, UpdatedBy)
VALUES (1, 1, 1, 
'{ 
  "web": {
    "maxConnections": 1000,
    "keepAliveTimeout": 75,
    "requestTimeout": 60,
    "staticFilesCaching": "enabled",
    "compressionLevel": "high"
  },
  "security": {
    "sslEnabled": true,
    "tlsMinimumVersion": "1.2",
    "cipherPreference": "strong",
    "autoUpdateCertificates": true
  },
  "resources": {
    "maxThreads": 200,
    "maxFileDescriptors": 65535,
    "maxRequestSize": "10MB"
  }
}', 1, 1, TO_DATE('2025-01-15', 'YYYY-MM-DD'), 1);

INSERT INTO ServerConfigurations (ServerConfigID, ServerID, ConfigID, ConfigData, IsBaseline, Version, LastUpdated, UpdatedBy)
VALUES (2, 2, 1, 
'{ 
  "web": {
    "maxConnections": 1000,
    "keepAliveTimeout": 75,
    "requestTimeout": 60,
    "staticFilesCaching": "enabled",
    "compressionLevel": "high"
  },
  "security": {
    "sslEnabled": true,
    "tlsMinimumVersion": "1.2",
    "cipherPreference": "strong",
    "autoUpdateCertificates": true
  },
  "resources": {
    "maxThreads": 200,
    "maxFileDescriptors": 65535,
    "maxRequestSize": "10MB"
  }
}', 1, 1, TO_DATE('2025-01-15', 'YYYY-MM-DD'), 1);

INSERT INTO ServerConfigurations (ServerConfigID, ServerID, ConfigID, ConfigData, IsBaseline, Version, LastUpdated, UpdatedBy)
VALUES (3, 3, 2, 
'{ 
  "database": {
    "maxConnections": 500,
    "sharedBuffers": "4GB",
    "effectiveCacheSize": "12GB",
    "workMem": "64MB",
    "maintenanceWorkMem": "1GB",
    "maxWalSize": "2GB"
  },
  "security": {
    "sslEnabled": true,
    "networkAuthentication": "md5",
    "failedLoginThreshold": 3,
    "loginTimeout": 60
  },
  "backups": {
    "schedule": "0 1 * * *",
    "retentionDays": 14,
    "compressionLevel": 6,
    "validateAfterBackup": true
  }
}', 1, 1, TO_DATE('2025-01-16', 'YYYY-MM-DD'), 1);

INSERT INTO ServerConfigurations (ServerConfigID, ServerID, ConfigID, ConfigData, IsBaseline, Version, LastUpdated, UpdatedBy)
VALUES (4, 4, 3, 
'{ 
  "web": {
    "maxConnections": 500,
    "keepAliveTimeout": 60,
    "requestTimeout": 30,
    "staticFilesCaching": "disabled",
    "compressionLevel": "medium"
  },
  "security": {
    "sslEnabled": true,
    "tlsMinimumVersion": "1.2",
    "cipherPreference": "strong",
    "autoUpdateCertificates": true
  },
  "resources": {
    "maxThreads": 100,
    "maxFileDescriptors": 32768,
    "maxRequestSize": "5MB"
  }
}', 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD'), 1);

INSERT INTO ServerConfigurations (ServerConfigID, ServerID, ConfigID, ConfigData, IsBaseline, Version, LastUpdated, UpdatedBy)
VALUES (5, 5, 3, 
'{ 
  "database": {
    "maxConnections": 200,
    "sharedBuffers": "2GB",
    "effectiveCacheSize": "6GB",
    "workMem": "32MB",
    "maintenanceWorkMem": "512MB",
    "maxWalSize": "1GB"
  },
  "security": {
    "sslEnabled": true,
    "networkAuthentication": "md5",
    "failedLoginThreshold": 3,
    "loginTimeout": 60
  },
  "backups": {
    "schedule": "0 3 * * *",
    "retentionDays": 30,
    "compressionLevel": 6,
    "validateAfterBackup": true
  }
}', 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD'), 1);

INSERT INTO ServerConfigurations (ServerConfigID, ServerID, ConfigID, ConfigData, IsBaseline, Version, LastUpdated, UpdatedBy)
VALUES (6, 6, 4, 
'{ 
  "cdn": {
    "cacheMaxAge": 86400,
    "enableGzip": true,
    "enableBrotli": true,
    "httpCacheControl": "public, max-age=86400",
    "edgeCacheTtl": 604800
  },
  "security": {
    "sslEnabled": true,
    "tlsMinimumVersion": "1.2",
    "cipherPreference": "strong",
    "ddosProtection": true,
    "rateLimiting": {
      "enabled": true,
      "maxRequests": 1000,
      "windowSeconds": 60
    }
  },
  "resources": {
    "maxThreads": 50,
    "maxFileDescriptors": 16384,
    "maxRequestSize": "2MB"
  }
}', 1, 1, TO_DATE('2025-01-25', 'YYYY-MM-DD'), 2);

-- Version update for ServerID 1
INSERT INTO ServerConfigurations (ServerConfigID, ServerID, ConfigID, ConfigData, IsBaseline, Version, LastUpdated, UpdatedBy)
VALUES (7, 1, 1, 
'{ 
  "web": {
    "maxConnections": 1500,
    "keepAliveTimeout": 65,
    "requestTimeout": 45,
    "staticFilesCaching": "enabled",
    "compressionLevel": "maximum"
  },
  "security": {
    "sslEnabled": true,
    "tlsMinimumVersion": "1.3",
    "cipherPreference": "stronger",
    "autoUpdateCertificates": true,
    "httpHeaders": {
      "strictTransportSecurity": true,
      "xContentTypeOptions": "nosniff",
      "xFrameOptions": "DENY"
    }
  },
  "resources": {
    "maxThreads": 300,
    "maxFileDescriptors": 131072,
    "maxRequestSize": "15MB"
  }
}', 1, 2, TO_DATE('2025-03-10', 'YYYY-MM-DD'), 2);

-- Insert data into ConfigurationHistory
INSERT INTO ConfigurationHistory (HistoryID, ServerConfigID, ChangeType, ChangedDate, ChangedBy, PreviousVersion, ChangeDetails)
VALUES (1, 7, 'UPDATE', TO_DATE('2025-03-10', 'YYYY-MM-DD'), 2, 1, 'Increased max connections to 1500, upgraded TLS to 1.3, added HTTP security headers, increased thread count and file descriptors for higher load');

INSERT INTO ConfigurationHistory (HistoryID, ServerConfigID, ChangeType, ChangedDate, ChangedBy, PreviousVersion, ChangeDetails)
VALUES (2, 1, 'CREATE', TO_DATE('2025-01-15', 'YYYY-MM-DD'), 1, NULL, 'Initial configuration setup for PROD-WEB-01');

INSERT INTO ConfigurationHistory (HistoryID, ServerConfigID, ChangeType, ChangedDate, ChangedBy, PreviousVersion, ChangeDetails)
VALUES (3, 2, 'CREATE', TO_DATE('2025-01-15', 'YYYY-MM-DD'), 1, NULL, 'Initial configuration setup for PROD-WEB-02');

INSERT INTO ConfigurationHistory (HistoryID, ServerConfigID, ChangeType, ChangedDate, ChangedBy, PreviousVersion, ChangeDetails)
VALUES (4, 3, 'CREATE', TO_DATE('2025-01-16', 'YYYY-MM-DD'), 1, NULL, 'Initial configuration setup for PROD-DB-01');

INSERT INTO ConfigurationHistory (HistoryID, ServerConfigID, ChangeType, ChangedDate, ChangedBy, PreviousVersion, ChangeDetails)
VALUES (5, 4, 'CREATE', TO_DATE('2025-01-20', 'YYYY-MM-DD'), 1, NULL, 'Initial configuration setup for DR-WEB-01');

-- Insert data into AlertDefinitions
INSERT INTO AlertDefinitions (AlertDefID, MetricType, Condition, Threshold, Severity, Description, CreatedBy, CreatedDate)
VALUES (1, 'CPU', '>', 90, 'High', 'CPU usage exceeds 90%', 1, TO_DATE('2025-01-10', 'YYYY-MM-DD'));

INSERT INTO AlertDefinitions (AlertDefID, MetricType, Condition, Threshold, Severity, Description, CreatedBy, CreatedDate)
VALUES (2, 'CPU', '>', 80, 'Medium', 'CPU usage exceeds 80%', 1, TO_DATE('2025-01-10', 'YYYY-MM-DD'));

INSERT INTO AlertDefinitions (AlertDefID, MetricType, Condition, Threshold, Severity, Description, CreatedBy, CreatedDate)
VALUES (3, 'Memory', '>', 90, 'High', 'Memory usage exceeds 90%', 1, TO_DATE('2025-01-10', 'YYYY-MM-DD'));

INSERT INTO AlertDefinitions (AlertDefID, MetricType, Condition, Threshold, Severity, Description, CreatedBy, CreatedDate)
VALUES (4, 'Memory', '>', 80, 'Medium', 'Memory usage exceeds 80%', 1, TO_DATE('2025-01-10', 'YYYY-MM-DD'));

INSERT INTO AlertDefinitions (AlertDefID, MetricType, Condition, Threshold, Severity, Description, CreatedBy, CreatedDate)
VALUES (5, 'Disk', '>', 90, 'High', 'Disk usage exceeds 90%', 1, TO_DATE('2025-01-10', 'YYYY-MM-DD'));

INSERT INTO AlertDefinitions (AlertDefID, MetricType, Condition, Threshold, Severity, Description, CreatedBy, CreatedDate)
VALUES (6, 'Disk', '>', 80, 'Medium', 'Disk usage exceeds 80%', 1, TO_DATE('2025-01-10', 'YYYY-MM-DD'));

INSERT INTO AlertDefinitions (AlertDefID, MetricType, Condition, Threshold, Severity, Description, CreatedBy, CreatedDate)
VALUES (7, 'Network', '>', 90, 'Medium', 'Network traffic exceeds 90% capacity', 1, TO_DATE('2025-01-10', 'YYYY-MM-DD'));

INSERT INTO AlertDefinitions (AlertDefID, MetricType, Condition, Threshold, Severity, Description, CreatedBy, CreatedDate)
VALUES (8, 'ConnectionCount', '>', 800, 'Medium', 'Connection count exceeds 800', 2, TO_DATE('2025-01-25', 'YYYY-MM-DD'));

INSERT INTO AlertDefinitions (AlertDefID, MetricType, Condition, Threshold, Severity, Description, CreatedBy, CreatedDate)
VALUES (9, 'ResponseTime', '>', 500, 'Medium', 'Response time exceeds 500ms', 2, TO_DATE('2025-01-25', 'YYYY-MM-DD'));

INSERT INTO AlertDefinitions (AlertDefID, MetricType, Condition, Threshold, Severity, Description, CreatedBy, CreatedDate)
VALUES (10, 'ErrorRate', '>', 5, 'High', 'Error rate exceeds 5%', 2, TO_DATE('2025-01-25', 'YYYY-MM-DD'));

-- Insert data into AlertsConfig
INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (1, 1, 1, 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD')); -- PROD-WEB-01 CPU > 90% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (2, 1, 3, 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD')); -- PROD-WEB-01 Memory > 90% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (3, 1, 5, 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD')); -- PROD-WEB-01 Disk > 90% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (4, 1, 10, 1, 2, TO_DATE('2025-01-30', 'YYYY-MM-DD')); -- PROD-WEB-01 ErrorRate > 5% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (5, 2, 1, 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD')); -- PROD-WEB-02 CPU > 90% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (6, 2, 3, 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD')); -- PROD-WEB-02 Memory > 90% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (7, 2, 5, 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD')); -- PROD-WEB-02 Disk > 90% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (8, 3, 1, 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD')); -- PROD-DB-01 CPU > 90% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (9, 3, 3, 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD')); -- PROD-DB-01 Memory > 90% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (10, 3, 5, 1, 1, TO_DATE('2025-01-20', 'YYYY-MM-DD')); -- PROD-DB-01 Disk > 90% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (11, 6, 1, 1, 2, TO_DATE('2025-01-30', 'YYYY-MM-DD')); -- EDGE-CDN-01 CPU > 90% High

INSERT INTO AlertsConfig (AlertID, ServerID, AlertDefID, Active, CreatedBy, CreatedDate)
VALUES (12, 6, 7, 1, 2, TO_DATE('2025-01-30', 'YYYY-MM-DD')); -- EDGE-CDN-01 Network > 90% Medium

-- Insert data into Alerts
INSERT INTO Alerts (AlertLogID, AlertID, TriggerValue, TriggerTime, Acknowledged, AcknowledgedBy, AcknowledgedTime)
VALUES (1, 1, 94.2, TO_DATE('2025-03-16 23:30:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 2, TO_DATE('2025-03-16 23:40:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO Alerts (AlertLogID, AlertID, TriggerValue, TriggerTime, Acknowledged, AcknowledgedBy, AcknowledgedTime)
VALUES (2, 1, 95.7, TO_DATE('2025-03-16 23:45:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 2, TO_DATE('2025-03-16 23:48:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO Alerts (AlertLogID, AlertID, TriggerValue, TriggerTime, Acknowledged, AcknowledgedBy, AcknowledgedTime)
VALUES (3, 10, 92.5, TO_DATE('2025-03-17 01:15:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 2, TO_DATE('2025-03-17 01:18:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO Alerts (AlertLogID, AlertID, TriggerValue, TriggerTime, Acknowledged, AcknowledgedBy, AcknowledgedTime)
VALUES (4, 5, 94.8, TO_DATE('2025-03-16 18:10:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 1, TO_DATE('2025-03-16 18:15:00', 'YYYY-MM-DD HH24:MI:SS'));

INSERT INTO Alerts (AlertLogID, AlertID, TriggerValue, TriggerTime, Acknowledged, AcknowledgedBy, AcknowledgedTime)
VALUES (5, 12, 93.7, TO_DATE('2025-03-17 01:35:00', 'YYYY-MM-DD HH24:MI:SS'), 0, NULL, NULL);

INSERT INTO Alerts (AlertLogID, AlertID, TriggerValue, TriggerTime, Acknowledged, AcknowledgedBy, AcknowledgedTime)
VALUES (6, 4, 8.7, TO_DATE('2025-03-17 01:45:00', 'YYYY-MM-DD HH24:MI:SS'), 0, NULL, NULL);