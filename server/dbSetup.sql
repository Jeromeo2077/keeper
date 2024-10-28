CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) UNIQUE COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE keeps (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    img VARCHAR(1000) NOT NULL,
    views INT NOT NULL,
    kept INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
)

CREATE TABLE vaults (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    img VARCHAR(1000) NOT NULL,
    isPrivate BOOLEAN NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
)

CREATE TABLE vaultkeeps (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    vaultId INT NOT NULL,
    keepId INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    Foreign Key (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
    Foreign Key (keepId) REFERENCES keeps (id) ON DELETE CASCADE,
    Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

SELECT keeps.*, vaultkeeps.*, accounts.*
FROM
    vaultkeeps
    JOIN keeps ON vaultkeeps.keepId = keeps.id
    JOIN accounts ON vaultkeeps.creatorId = accounts.id
WHERE
    vaultkeeps.vaultId = 94;