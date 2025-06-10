 Create People Table
CREATE TABLE People (
    id INT AUTO_INCREMENT PRIMARY KEY,

    first_name VARCHAR(18),
    
    last_name VARCHAR(18),

    secret_code VARCHAR(18) UNIQUE,
    
    type ENUM('reporter', 'target', 'both', 'potential_agent'),
    
    num_reports INT DEFAULT 0,
    
    num_mentions INT DEFAULT 0
);

 Create IntelReports Table
CREATE TABLE IntelReports (
    id INT AUTO_INCREMENT PRIMARY KEY,
    reporter_id INT,
    target_id INT,
    text TEXT,
    timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (reporter_id) REFERENCES People(id),
    FOREIGN KEY (target_id) REFERENCES People(id)
);
