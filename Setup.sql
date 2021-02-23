


-- CREATE TABLE jobs
-- (
--   Id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL UNIQUE,
--   description VARCHAR(255),


--   PRIMARY KEY (Id)
-- );


-- CREATE TABLE contractors
-- (
--   Id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL UNIQUE,
--   description VARCHAR(255),


--   PRIMARY KEY (Id)
-- );

-- CREATE TABLE contractorjobs
-- (
--   id INT AUTO_INCREMENT,
--   contractorId INT,
--   jobId INT,

--   PRIMARY KEY (id),

--   FOREIGN KEY (contractorId)
--     REFERENCES contractors(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (jobId)
--     REFERENCES jobs(id)
--     ON DELETE CASCADE
-- );