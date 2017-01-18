
CREATE DATABASE IF NOT EXISTS `pork_shop` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `pork_shop`;

DROP TABLE IF EXISTS `bar`;
CREATE TABLE `bar` (
  `barId` varchar(4) NOT NULL,
  `barDescription` varchar(50) NOT NULL,
  `barType` varchar(6) NOT NULL,
  `barPrice` decimal(4,2) NOT NULL,
  `barQOH` int(4) NOT NULL,
  PRIMARY KEY (`barId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `customerOrders`;
CREATE TABLE `customerOrders` (
  `orderNum` int(6) AUTO_INCREMENT NOT NULL,
  `empNum` varchar(6) NOT NULL,
  `tableNum` varchar(6) NOT NULL,
  `orderDate` date NOT NULL,
  `numGuests` int(3) NOT NULL,
  PRIMARY KEY (`orderNum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `employee`;
CREATE TABLE `employee` (
  `empNum` varchar(6) NOT NULL,
  `empFName` varchar(25) NOT NULL,
  `empLName` varchar(25) NOT NULL,
  `empAddress` varchar(50) NOT NULL,
  `empCity` varchar(25) NOT NULL,
  `empProv` varchar(2) NOT NULL,
  `empPostal` varchar(7) NOT NULL,
  `empPhone` varchar(13) NOT NULL,
  `empSIN` varchar(11) NOT NULL,
  `empStart` date NOT NULL,
  `empPosition` varchar(15) NOT NULL,
  PRIMARY KEY (`empNum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `food`;
CREATE TABLE `food` (
  `foodId` varchar(4) NOT NULL,
  `foodDescription` varchar(50) NOT NULL,
  `foodType` varchar(6) NOT NULL,
  `foodPrice` decimal(4,2) NOT NULL,
  PRIMARY KEY (`foodId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `line`;
CREATE TABLE `line` (
  `orderNum` int(6) NOT NULL,
  `lineNum` int(3) NOT NULL,
  `foodId` varchar(4) DEFAULT NULL,
  `barId` varchar(4) DEFAULT NULL,
  `lineQty` int(3) NOT NULL,
  `linePrice` decimal(4,2) NOT NULL,
  PRIMARY KEY (`orderNum`, `lineNum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `salary`;
CREATE TABLE `salary` (
  `empNum` varchar(6) NOT NULL,
  `salaryFrom` date NOT NULL,
  `salaryTo` date NOT NULL,
  `salaryAmount` decimal(5,2) NOT NULL,
  PRIMARY KEY (`empNum`, `salaryFrom`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `tables`;
CREATE TABLE `tables` (
  `tableNum` varchar(6) NOT NULL,
  `tableSeats` int(2) NOT NULL,
  
  
  PRIMARY KEY (`tableNum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `reservation`;
CREATE TABLE `reservation`(
`reservationID` int(6) AUTO_INCREMENT NOT NULL,
`tableNum` varchar(6) NOT NULL,
`reservationDate` date NOT NULL,
`reservationTime` time(5) NOT NULL,
`reservationName` varchar(50) NOT NULL,
`reservationContact` varchar(13) NOT NULL,

  PRIMARY KEY(`reservationID`)
  )ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `timeclock`;
CREATE TABLE `timeclock` (
  `empNum` varchar(6) NOT NULL,
  `shiftDate` date NOT NULL,
  `clockIn` time(5) NOT NULL,
  `clockOut` time(5) NOT NULL,
  PRIMARY KEY (`empNum`, `shiftDate`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `userAccess`;
CREATE TABLE `userAccess` (
  `empNum` varchar(6) NOT NULL,
  `password` varchar(128) NOT NULL,
  `userTypeCode` int(3) NOT NULL DEFAULT '1',
  PRIMARY KEY (`empNum`, `password`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

