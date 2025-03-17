-- Insert data into TaskTypes
INSERT INTO TaskTypes (TaskTypeID, TaskName, Description, RequiredPermissionLevel, IsSystem)
VALUES (1, 'ServerRestart', 'Restart server with proper shutdown procedure', 80, 1);

INSERT INTO TaskTypes (TaskTypeID, TaskName, Description, RequiredPermissionLevel, IsSystem)
VALUES (2, 'SecurityScan', 'Run comprehensive security scan', 90, 1);

INSERT INTO TaskTypes (TaskTypeID, TaskName, Description, RequiredPermissionLevel, IsSystem)
VALUES (3, 'BackupExecution', 'Trigger manual backup', 70, 1);

INSERT INTO TaskTypes (TaskTypeID, TaskName, Description, RequiredPermissionLevel, IsSystem)
VALUES (4, 'PackageUpdate', 'Update system packages', 80, 1);

INSERT INTO TaskTypes (TaskTypeID, TaskName, Description, RequiredPermissionLevel, IsSystem)
VALUES (5, 'PerformanceCheck', 'Run performance diagnostics', 50, 1);

INSERT INTO TaskTypes (TaskTypeID, TaskName, Description, RequiredPermissionLevel, IsSystem)
VALUES (6, 'DiskCleanup', 'Clean temporary files and directories', 60, 1);

INSERT INTO TaskTypes (TaskTypeID, TaskName, Description, RequiredPermissionLevel, IsSystem)
VALUES (7, 'ServiceManagement', 'Start/stop/restart specific services', 70, 1);

-- Insert data into AutomationScripts
INSERT INTO AutomationScripts (ScriptID, ScriptName, ScriptContent, TaskTypeID, CreatedBy, CreatedDate, LastModified, ModifiedBy, Version, HashValue)
VALUES (1, 'Graceful Server Restart', 
'#!/bin/bash
# Graceful Server Restart Script
# Notifies connected users, waits, then restarts

# Notify users of pending restart
wall "SERVER RESTART: This server will restart in 2 minutes. Please save your work and log off."

# Wait 2 minutes
sleep 120

# Sync filesystem to disk
sync

# Restart the server
shutdown -r now', 
1, 1, TO_DATE('2025-01-10', 'YYYY-MM-DD'), TO_DATE('2025-01-10', 'YYYY-MM-DD'), 1, 1,
'8a7b6c5d4e3f2g1h0i9j8k7l6m5n4o3p2q1r0s9t8u7v6w5x4y3z2a1b');

INSERT INTO AutomationScripts (ScriptID, ScriptName, ScriptContent, TaskTypeID, CreatedBy, CreatedDate, LastModified, ModifiedBy, Version, HashValue)
VALUES (2, 'Full Security Scan', 
'#!/bin/bash
# Comprehensive Security Scan
# Runs multiple security checks and generates report

LOG_FILE="/var/log/security_scan_$(date +%Y%m%d).log"

echo "Security scan started at $(date)" > $LOG_FILE
echo "--------------------------------------" >> $LOG_FILE

echo "Checking for rootkits..." >> $LOG_FILE
rkhunter --check --skip-keypress >> $LOG_FILE 2>&1

echo "Scanning for malware..." >> $LOG_FILE
clamscan -r /var/www /home --quiet >> $LOG_FILE 2>&1

echo "Checking for vulnerable packages..." >> $LOG_FILE
apt list --upgradable 2>/dev/null | grep security >> $LOG_FILE

echo "Checking open ports..." >> $LOG_FILE
netstat -tuln >> $LOG_FILE

echo "Checking failed login attempts..." >> $LOG_FILE
grep "Failed password" /var/log/auth.log | tail -n 50 >> $LOG_FILE

echo "Security scan completed at $(date)" >> $LOG_FILE
echo "--------------------------------------" >> $LOG_FILE

echo "Security scan completed. Results in $LOG_FILE"', 
2, 3, TO_DATE('2025-01-15', 'YYYY-MM-DD'), TO_DATE('2025-02-10', 'YYYY-MM-DD'), 3, 2,
'7b8c9d0e1f2g3h4i5j6k7l8m9n0o1p2q3r4s5t6u7v8w9x0y1z2a3b4c');

INSERT INTO AutomationScripts (ScriptID, ScriptName, ScriptContent, TaskTypeID, CreatedBy, CreatedDate, LastModified, ModifiedBy, Version, HashValue)
VALUES (3, 'Database Backup', 
'#!/bin/bash
# Database Backup Script
# Creates compressed backup with timestamp

# Configuration
TIMESTAMP=$(date +"%Y%m%d_%H%M%S")
BACKUP_DIR="/var/backups/database"
DB_NAME="production_db"
BACKUP_FILE="${BACKUP_DIR}/backup_${DB_NAME}_${TIMESTAMP}.sql.gz"

# Ensure backup directory exists
mkdir -p $BACKUP_DIR

# Perform the backup
echo "Starting backup of $DB_NAME at $(date)"
mysqldump --single-transaction --quick --lock-tables=false $DB_NAME | gzip > $BACKUP_FILE

# Check if backup was successful
if [ $? -eq 0 ]; then
    echo "Backup completed successfully at $(date)"
    echo "Backup saved to $BACKUP_FILE"
    echo "Backup size: $(du -h $BACKUP_FILE | cut -f1)"
    exit 0
else
    echo "Error: Backup failed at $(date)"
    exit 1
fi', 
3, 2, TO_DATE('2025-01-20', 'YYYY-MM-DD'), TO_DATE('2025-01-20', 'YYYY-MM-DD'), 2, 1,
'6c7d8e9f0g1h2i3j4k5l6m7n8o9p0q1r2s3t4u5v6w7x8y9z0a1b2c3d');

INSERT INTO AutomationScripts (ScriptID, ScriptName, ScriptContent, TaskTypeID, CreatedBy, CreatedDate, LastModified, ModifiedBy, Version, HashValue)
VALUES (4, 'System Update', 
'#!/bin/bash
# System Package Update Script
# Updates all packages safely

LOG_FILE="/var/log/system_update_$(date +%Y%m%d).log"

echo "System update started at $(date)" > $LOG_FILE
echo "--------------------------------------" >> $LOG_FILE

# Update package lists
echo "Updating package lists..." >> $LOG_FILE
apt-get update >> $LOG_FILE 2>&1

# Show packages that would be upgraded
echo "The following packages will be upgraded:" >> $LOG_FILE
apt-get --just-print upgrade >> $LOG_FILE 2>&1

# Perform the upgrade with automatic yes to prompts
echo "Performing upgrade..." >> $LOG_FILE
DEBIAN_FRONTEND=noninteractive apt-get -y -o Dpkg::Options::="--force-confdef" -o Dpkg::Options::="--force-confold" upgrade >> $LOG_FILE 2>&1

echo "System update completed at $(date)" >> $LOG_FILE
echo "--------------------------------------" >> $LOG_FILE

# Check if reboot is required
if [ -f /var/run/reboot-required ]; then
    echo "ALERT: System requires a reboot!" >> $LOG_FILE
else
    echo "No reboot required." >> $LOG_FILE
fi', 
4, 2, TO_DATE('2025-01-15', 'YYYY-MM-DD'), TO_DATE('2025-03-01', 'YYYY-MM-DD'), 2, 2,
'5d6e7f8g9h0i1j2k3l4m5n6o7p8q9r0s1t2u3v4w5x6y7z8a9b0c1d2e');

INSERT INTO AutomationScripts (ScriptID, ScriptName, ScriptContent, TaskTypeID, CreatedBy, CreatedDate, LastModified, ModifiedBy, Version, HashValue)
VALUES (5, 'Performance Analysis', 
'#!/bin/bash
# Server Performance Analysis Tool
# Gathers key performance metrics and generates report

OUTPUT_DIR="/var/log/perf"
REPORT_FILE="${OUTPUT_DIR}/performance_report_$(date +%Y%m%d_%H%M%S).txt"

# Create output directory if it doesn''t exist
mkdir -p $OUTPUT_DIR

# Start the report
echo "SERVER PERFORMANCE ANALYSIS" > $REPORT_FILE
echo "Generated: $(date)" >> $REPORT_FILE
echo "Hostname: $(hostname)" >> $REPORT_FILE
echo "=================================" >> $REPORT_FILE

# System uptime
echo -e "\nSYSTEM UPTIME" >> $REPORT_FILE
uptime >> $REPORT_FILE

# CPU information and load
echo -e "\nCPU INFORMATION" >> $REPORT_FILE
lscpu | grep "CPU(s):" >> $REPORT_FILE
echo -e "\nCPU LOAD (top 5 processes)" >> $REPORT_FILE
ps aux --sort=-%cpu | head -n 6 >> $REPORT_FILE

# Memory usage
echo -e "\nMEMORY USAGE" >> $REPORT_FILE
free -h >> $REPORT_FILE
echo -e "\nMEMORY CONSUMERS (top 5 processes)" >> $REPORT_FILE
ps aux --sort=-%mem | head -n 6 >> $REPORT_FILE

# Disk usage
echo -e "\nDISK USAGE" >> $REPORT_FILE
df -h >> $REPORT_FILE

# Network connections
echo -e "\nNETWORK CONNECTIONS (count)" >> $REPORT_FILE
netstat -ant | wc -l >> $REPORT_FILE

echo -e "\nCURRENT ESTABLISHED CONNECTIONS" >> $REPORT_FILE
netstat -ant | grep ESTABLISHED | wc -l >> $REPORT_FILE

# I/O Wait
echo -e "\nI/O WAIT" >> $REPORT_FILE
iostat | grep -A 1 avg-cpu >> $REPORT_FILE

echo -e "\nPERFORMANCE ANALYSIS COMPLETE" >> $REPORT_FILE
echo "Full report available at $REPORT_FILE"', 
5, 1, TO_DATE('2025-02-05', 'YYYY-MM-DD'), TO_DATE('2025-02-05', 'YYYY-MM-DD'), 1, 1,
'4e5f6g7h8i9j0k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z6a7b8c9d0e1f');

INSERT INTO AutomationScripts (ScriptID, ScriptName, ScriptContent, TaskTypeID, CreatedBy, CreatedDate, LastModified, ModifiedBy, Version, HashValue)
VALUES (6, 'Disk Space Cleanup', 
'#!/bin/bash
# Disk Space Cleanup Script
# Safely removes unnecessary files to free up disk space

LOG_FILE="/var/log/disk_cleanup_$(date +%Y%m%d).log"

echo "Disk cleanup started at $(date)" > $LOG_FILE
echo "--------------------------------------" >> $LOG_FILE

# Initial disk usage
echo "Initial disk usage:" >> $LOG_FILE
df -h / >> $LOG_FILE

# Clean apt cache
echo "Cleaning apt cache..." >> $LOG_FILE
apt-get clean >> $LOG_FILE 2>&1

# Remove old kernels (keeping the current one)
echo "Removing old kernels..." >> $LOG_FILE
apt-get autoremove -y >> $LOG_FILE 2>&1

# Clean temporary files
echo "Cleaning temporary files..." >> $LOG_FILE
find /tmp -type f -atime +10 -delete >> $LOG_FILE 2>&1

# Clean system journal logs older than 7 days
echo "Cleaning old journal logs..." >> $LOG_FILE
journalctl --vacuum-time=7d >> $LOG_FILE 2>&1

# Clean up log files larger than 100MB
echo "Cleaning large log files..." >> $LOG_FILE
find /var/log -type f -size +100M | while read file; do
    echo "Truncating $file" >> $LOG_FILE
    truncate -s 0 "$file"
done

# Final disk usage
echo "Final disk usage:" >> $LOG_FILE
df -h / >> $LOG_FILE

echo "Disk cleanup completed at $(date)" >> $LOG_FILE
echo "--------------------------------------" >> $LOG_FILE', 
6, 2, TO_DATE('2025-01-25', 'YYYY-MM-DD'), TO_DATE('2025-02-15', 'YYYY-MM-DD'), 2, 2,
'3f4g5h6i7j8k9l0m1n2o3p4q5r6s7t8u9v0w1x2y3z4a5b6c7d8e9f0g');

INSERT INTO AutomationScripts (ScriptID, ScriptName, ScriptContent, TaskTypeID, CreatedBy, CreatedDate, LastModified, ModifiedBy, Version, HashValue)
VALUES (7, 'Nginx Service Manager', 
'#!/bin/bash
# Nginx Service Manager
# Safely start/stop/restart Nginx with config test

ACTION=$1
LOG_FILE="/var/log/nginx_management_$(date +%Y%m%d).log"

echo "Nginx service management - $(date)" > $LOG_FILE
echo "Action requested: $ACTION" >> $LOG_FILE
echo "--------------------------------------" >> $LOG_FILE

# Function to test Nginx configuration
test_config() {
    echo "Testing Nginx configuration..." >> $LOG_FILE
    nginx -t >> $LOG_FILE 2>&1
    return $?
}

# Handle the requested action
case $ACTION in
    start)
        echo "Starting Nginx service..." >> $LOG_FILE
        systemctl start nginx >> $LOG_FILE 2>&1
        ;;
    stop)
        echo "Stopping Nginx service..." >> $LOG_FILE
        systemctl stop nginx >> $LOG_FILE 2>&1
        ;;
    restart)
        echo "Restarting Nginx service..." >> $LOG_FILE
        test_config
        if [ $? -eq 0 ]; then
            systemctl restart nginx >> $LOG_FILE 2>&1
        else
            echo "ERROR: Nginx configuration test failed. Service not restarted." >> $LOG_FILE
            exit 1
        fi
        ;;
    reload)
        echo "Reloading Nginx configuration..." >> $LOG_FILE
        test_config
        if [ $? -eq 0 ]; then
            systemctl reload nginx >> $LOG_FILE 2>&1
        else
            echo "ERROR: Nginx configuration test failed. Configuration not reloaded." >> $LOG_FILE
            exit 1
        fi
        ;;
    status)
        echo "Checking Nginx status:" >> $LOG_FILE
        systemctl status nginx >> $LOG_FILE 2>&1
        ;;
    *)
        echo "ERROR: Unknown action. Use start, stop, restart, reload, or status." >> $LOG_FILE
        exit 1
        ;;
esac

echo "Nginx service management completed at $(date)" >> $LOG_FILE
echo "--------------------------------------" >> $LOG_FILE', 
7, 2, TO_DATE('2025-02-20', 'YYYY-MM-DD'), TO_DATE('2025-02-20', 'YYYY-MM-DD'), 2, 1,
'2g3h4i5j6k7l8m9n0o1p2q3r4s5t6u7v8w9x0y1z2a3b4c5d6e7f8g9h');

-- Insert data into AutomationLogs
INSERT INTO AutomationLogs (TaskID, ScriptID, ServerID, ExecutedBy, Status, StartTime, EndTime, LogDetails, ErrorMessage)
VALUES (1, 5, 1, 1, 'Completed', 
        TO_DATE('2025-03-16 22:30:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-16 22:32:15', 'YYYY-MM-DD HH24:MI:SS'),
        'SERVER PERFORMANCE ANALYSIS
Generated: Sun Mar 16 22:30:05 UTC 2025
Hostname: PROD-WEB-01
=================================

SYSTEM UPTIME
22:30:05 up 12 days, 5:43, 1 user, load average: 1.52, 1.65, 1.48

CPU INFORMATION
CPU(s): 8

CPU LOAD (top 5 processes)
USER       PID %CPU %MEM    VSZ   RSS TTY      STAT START   TIME COMMAND
www-data 25136 15.2  2.1 357604 42504 ?        R    21:45   0:12 nginx: worker process
www-data 25137 14.8  2.0 358120 41896 ?        S    21:45   0:11 nginx: worker process
root     28732  3.1  1.2 185428 24936 ?        S    22:15   0:02 python3 /usr/local/bin/backup_monitor.py
mysql    12555  2.7  9.3 1857432 192844 ?      Sl   Mar15   8:26 /usr/sbin/mysqld
www-data 25138  2.5  1.9 354304 39102 ?        S    21:45   0:07 nginx: worker process

MEMORY USAGE
              total        used        free      shared  buff/cache   available
Mem:           16Gi       7.2Gi       3.1Gi       768Mi       5.7Gi       7.8Gi
Swap:          4.0Gi       156Mi       3.9Gi

DISK USAGE
Filesystem      Size  Used Avail Use% Mounted on
/dev/sda1       236G  138G   86G  62% /
/dev/sdb1       512G  285G  227G  56% /data

NETWORK CONNECTIONS (count)
289

CURRENT ESTABLISHED CONNECTIONS
164

I/O WAIT
avg-cpu:  %user   %nice %system %iowait  %steal   %idle
           18.2     0.0     4.3      1.2     0.0    76.3

PERFORMANCE ANALYSIS COMPLETE',
        NULL);

INSERT INTO AutomationLogs (TaskID, ScriptID, ServerID, ExecutedBy, Status, StartTime, EndTime, LogDetails, ErrorMessage)
VALUES (2, 6, 1, 2, 'Completed', 
        TO_DATE('2025-03-17 01:05:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-17 01:07:30', 'YYYY-MM-DD HH24:MI:SS'),
        'Disk cleanup started at Mon Mar 17 01:05:03 UTC 2025
--------------------------------------
Initial disk usage:
Filesystem      Size  Used Avail Use% Mounted on
/dev/sda1       236G  138G   86G  62% /
Cleaning apt cache...
Removing old kernels...
Reading package lists... Done
Building dependency tree... Done
Reading state information... Done
0 upgraded, 0 newly installed, 0 to remove and 0 not upgraded.
Cleaning temporary files...
Cleaning old journal logs...
Vacuum was successful.
Cleaning large log files...
Truncating /var/log/nginx/access.log
Final disk usage:
Filesystem      Size  Used Avail Use% Mounted on
/dev/sda1       236G  129G   95G  58% /
Disk cleanup completed at Mon Mar 17 01:07:26 UTC 2025
--------------------------------------',
        NULL);

INSERT INTO AutomationLogs (TaskID, ScriptID, ServerID, ExecutedBy, Status, StartTime, EndTime, LogDetails, ErrorMessage)
VALUES (3, 2, 4, 3, 'Completed', 
        TO_DATE('2025-03-16 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-16 14:28:12', 'YYYY-MM-DD HH24:MI:SS'),
        'Security scan started at Sun Mar 16 14:00:05 UTC 2025
--------------------------------------
Checking for rootkits...
Scanning for malware...
Checking for vulnerable packages...
libc6:amd64 2.31-13+deb11u7 [upgradable from: 2.31-13+deb11u6] [security]
openssl:amd64 1.1.1w-0+deb11u1 [upgradable from: 1.1.1n-0+deb11u5] [security]
Checking open ports...
Active Internet connections (only servers)
Proto Recv-Q Send-Q Local Address           Foreign Address         State      
tcp        0      0 0.0.0.0:22              0.0.0.0:*               LISTEN     
tcp        0      0 0.0.0.0:80              0.0.0.0:*               LISTEN     
tcp        0      0 0.0.0.0:443             0.0.0.0:*               LISTEN     
tcp6       0      0 :::22                   :::*                    LISTEN     
tcp6       0      0 :::80                   :::*                    LISTEN     
tcp6       0      0 :::443                  :::*                    LISTEN     
Checking failed login attempts...
Security scan completed at Sun Mar 16 14:28:10 UTC 2025
--------------------------------------',
        NULL);

INSERT INTO AutomationLogs (TaskID, ScriptID, ServerID, ExecutedBy, Status, StartTime, EndTime, LogDetails, ErrorMessage)
VALUES (4, 1, 2, 1, 'Completed', 
        TO_DATE('2025-03-16 18:45:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-16 18:49:32', 'YYYY-MM-DD HH24:MI:SS'),
        'Broadcast message from root@PROD-WEB-02 (Sun, Mar 16 18:45:03 2025):
SERVER RESTART: This server will restart in 2 minutes. Please save your work and log off.

System going down for reboot at Sun Mar 16 18:47:03 UTC 2025!',
        NULL);

INSERT INTO AutomationLogs (TaskID, ScriptID, ServerID, ExecutedBy, Status, StartTime, EndTime, LogDetails, ErrorMessage)
VALUES (5, 3, 3, 2, 'Failed', 
        TO_DATE('2025-03-17 01:00:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-17 01:00:45', 'YYYY-MM-DD HH24:MI:SS'),
        'Starting backup of production_db at Mon Mar 17 01:00:03 UTC 2025
',
        'Error: Backup failed at Mon Mar 17 01:00:45 UTC 2025. Insufficient disk space on backup volume.');

INSERT INTO AutomationLogs (TaskID, ScriptID, ServerID, ExecutedBy, Status, StartTime, EndTime, LogDetails, ErrorMessage)
VALUES (6, 7, 1, 2, 'Completed', 
        TO_DATE('2025-03-16 23:50:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-16 23:50:45', 'YYYY-MM-DD HH24:MI:SS'),
        'Nginx service management - Sun Mar 16 23:50:02 UTC 2025
Action requested: restart
--------------------------------------
Testing Nginx configuration...
nginx: the configuration file /etc/nginx/nginx.conf syntax is ok
nginx: configuration file /etc/nginx/nginx.conf test is successful
Restarting Nginx service...
Nginx service management completed at Sun Mar 16 23:50:45 UTC 2025
--------------------------------------',
        NULL);

INSERT INTO AutomationLogs (TaskID, ScriptID, ServerID, ExecutedBy, Status, StartTime, EndTime, LogDetails, ErrorMessage)
VALUES (7, 4, 6, 2, 'Completed', 
        TO_DATE('2025-03-15 02:00:00', 'YYYY-MM-DD HH24:MI:SS'), 
        TO_DATE('2025-03-15 02:12:23', 'YYYY-MM-DD HH24:MI:SS'),
        'System update started at Sat Mar 15 02:00:03 UTC 2025
--------------------------------------
Updating package lists...
Performing upgrade...
Processing triggers for libc-bin (2.31-13+deb11u7) ...
System update completed at Sat Mar 15 02:12:20 UTC 2025
--------------------------------------
No reboot required.',
        NULL);

-- Insert data into UserAccessLogs
INSERT INTO UserAccessLogs (LogID, UserID, ServerID, Action, IPAddress, UserAgent, SessionID, Timestamp, Success, FailureReason)
VALUES (1, 1, 1, 'Login', '192.168.1.100', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) Chrome/130.0.0.0', 'f7e79a8e8f9c9d8c7b6a5b4c3d2e1f0', 
        TO_DATE('2025-03-17 00:30:00', 'YYYY-MM-DD HH24:MI:SS'), 1, NULL);

INSERT INTO UserAccessLogs (LogID, UserID, ServerID, Action, IPAddress, UserAgent, SessionID, Timestamp, Success, FailureReason)
VALUES (2, 1, 1, 'Execute Command: df -h', '192.168.1.100', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) Chrome/130.0.0.0', 'f7e79a8e8f9c9d8c7b6a5b4c3d2e1f0', 
        TO_DATE('2025-03-17 00:32:15', 'YYYY-MM-DD HH24:MI:SS'), 1, NULL);

INSERT INTO UserAccessLogs (LogID, UserID, ServerID, Action, IPAddress, UserAgent, SessionID, Timestamp, Success, FailureReason)
VALUES (3, 1, 1, 'View Configuration', '192.168.1.100', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) Chrome/130.0.0.0', 'f7e79a8e8f9c9d8c7b6a5b4c3d2e1f0', 
        TO_DATE('2025-03-17 00:35:42', 'YYYY-MM-DD HH24:MI:SS'), 1, NULL);

INSERT INTO UserAccessLogs (LogID, UserID, ServerID, Action, IPAddress, UserAgent, SessionID, Timestamp, Success, FailureReason)
VALUES (4, 2, 2, 'Login', '192.168.1.101', 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15) Firefox/115.0', 'a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p', 
        TO_DATE('2025-03-17 01:15:00', 'YYYY-MM-DD HH24:MI:SS'), 1, NULL);

INSERT INTO UserAccessLogs (LogID, UserID, ServerID, Action, IPAddress, UserAgent, SessionID, Timestamp, Success, FailureReason)
VALUES (5, 2, 2, 'Edit Configuration File: /etc/nginx/nginx.conf', '192.168.1.101', 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15) Firefox/115.0', 'a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p', 
        TO_DATE('2025-03-17 01:18:25', 'YYYY-MM-DD HH24:MI:SS'), 1, NULL);

INSERT INTO UserAccessLogs (LogID, UserID, ServerID, Action, IPAddress, UserAgent, SessionID, Timestamp, Success, FailureReason)
VALUES (6, 3, 1, 'Login', '192.168.1.102', 'Mozilla/5.0 (iPhone; CPU iPhone OS 17_4 like Mac OS X) Version/17.2 Safari/605.1.15', '1a2b3c4d5e6f7g8h9i0j1k2l3m4n5o6p', 
        TO_DATE('2025-03-16 22:45:00', 'YYYY-MM-DD HH24:MI:SS'), 1, NULL);

INSERT INTO UserAccessLogs (LogID, UserID, ServerID, Action, IPAddress, UserAgent, SessionID, Timestamp, Success, FailureReason)
VALUES (7, 3, 1, 'Execute Command: netstat -tuln', '192.168.1.102', 'Mozilla/5.0 (iPhone; CPU iPhone OS 17_4 like Mac OS X) Version/17.2 Safari/605.1.15', '1a2b3c4d5e6f7g8h9i0j1k2l3m4n5o6p', 
        TO_DATE('2025-03-16 22:47:33', 'YYYY-MM-DD HH24:MI:SS'), 1, NULL);

INSERT INTO UserAccessLogs (LogID, UserID, ServerID, Action, IPAddress, UserAgent, SessionID, Timestamp, Success, FailureReason)
VALUES (8, 3, 1, 'Execute Command: tail -n 100 /var/log/auth.log', '192.168.1.102', 'Mozilla/5.0 (iPhone; CPU iPhone OS 17_4 like Mac OS X) Version/17.2 Safari/605.1.15', '1a2b3c4d5e6f7g8h9i0j1k2l3m4n5o6p', 
        TO_DATE('2025-03-16 22:50:10', 'YYYY