use datachase;
-- CREATE TABLE contractors
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255),
--   phone VARCHAR(255),
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE jobs
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   task VARCHAR(255),
--   rate FLOAT,
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE contractJobs
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   jobId INT,
--   contractorId INT,
--   PRIMARY KEY (id),
--   FOREIGN KEY (jobId)
--     REFERENCES jobs(id)
--     ON DELETE CASCADE,
--   FOREIGN KEY (contractorId)
--     REFERENCES contractors(id)
--     ON DELETE CASCADE
-- );