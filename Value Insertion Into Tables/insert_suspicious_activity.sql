INSERT INTO SuspiciousActivity (
    AlertID,
    UserID,
    ActivityType,
    AttemptCount,
    FirstDetected,
    LastDetected,
    IPAddress,
    Details,
    Status,
    ReviewedBy,
    ReviewDate
) VALUES (
    1, -- Use appropriate sequence for real implementation
    4, -- UserID (for 'support' user)
    'Unusual Login Pattern',
    5,
    TO_DATE('2025-03-17 02:20:15', 'YYYY-MM-DD HH24:MI:SS'),
    TO_DATE('2025-03-17 02:25:09', 'YYYY-MM-DD HH24:MI:SS'),
    '118.97.164.82',
    'Multiple rapid login attempts from location in Jakarta, Indonesia. User account normally accesses system from United States IP addresses only. Potential credential stuffing attack.',
    'Open',
    NULL,
    NULL
);