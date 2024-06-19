
-- 
-- Disable foreign keys
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Set SQL mode
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE asmin;

--
-- Drop table `incomingvisitors`
--
DROP TABLE IF EXISTS incomingvisitors;

--
-- Drop table `operationclaims`
--
DROP TABLE IF EXISTS operationclaims;

--
-- Drop table `useroperationclaims`
--
DROP TABLE IF EXISTS useroperationclaims;

--
-- Drop table `users`
--
DROP TABLE IF EXISTS users;

--
-- Set default database
--
USE asmin;

--
-- Create table `users`
--
CREATE TABLE users (
  Id int NOT NULL AUTO_INCREMENT,
  FirstName varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  LastName varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Email varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Password varchar(255) DEFAULT NULL,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 1,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create table `useroperationclaims`
--
CREATE TABLE useroperationclaims (
  Id int NOT NULL AUTO_INCREMENT,
  UserId int DEFAULT 0,
  OperationClaimId int DEFAULT 0,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 1,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create table `operationclaims`
--
CREATE TABLE operationclaims (
  Id int NOT NULL AUTO_INCREMENT,
  Name varchar(255) DEFAULT NULL,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 1,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create table `incomingvisitors`
--
CREATE TABLE incomingvisitors (
  Id int NOT NULL AUTO_INCREMENT,
  IpAddress varchar(255) DEFAULT NULL,
  CreatedDate datetime DEFAULT CURRENT_TIMESTAMP,
  ModifiedDate datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 1,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table users
--
INSERT INTO users VALUES
(1, 'Yusuf', 'Yılmaz', 'yusufyilmazfr@gmail.com', '202cb962ac59075b964b07152d234b70', '2021-02-03 13:15:37', '2021-02-03 13:15:37');

-- 
-- Dumping data for table useroperationclaims
--
INSERT INTO useroperationclaims VALUES
(1, 1, 1, '2021-02-03 13:15:54', '2021-02-03 13:15:54');
INSERT INTO useroperationclaims VALUES
(2, 1, 2, '2021-02-03 13:15:58', '2021-02-03 13:15:58');

-- 
-- Dumping data for table operationclaims
--
INSERT INTO operationclaims VALUES
(1, 'Admin', '2021-01-26 11:27:07', '2021-01-26 11:27:07');
INSERT INTO operationclaims VALUES
(2, 'User', '2021-01-26 11:27:13', '2021-01-26 11:27:13');

-- 
-- Dumping data for table incomingvisitors
--
-- Table asmin.incomingvisitors does not contain any data (it is empty)

-- 
-- Restore previous SQL mode
-- 
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Enable foreign keys
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;