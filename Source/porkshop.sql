drop database IF EXISTS pork_shop;

CREATE DATABASE IF NOT EXISTS `pork_shop` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `pork_shop`;

/*create a user in database*/
grant select, insert, update, delete on pork_shop.*
             to 'pork_shop_admin'@'localhost'
             identified by '5tr&ng3rTh!ng$';
flush privileges;





--
-- 1). Table structure for table `bar`
--


CREATE TABLE `bar` (
  `barId` int(4) NOT NULL AUTO_INCREMENT,
  `barDescription` varchar(50) NOT NULL,
  `barType` varchar(8) NOT NULL,
  `barPrice` decimal(4,2) NOT NULL,
  `barQOH` int(4) NOT NULL,
  PRIMARY KEY (`barId`)
  
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


--
-- 2). Table structure for table `customerOrders`
--

CREATE TABLE `customerOrders` (
  `orderNum` int(6) NOT NULL AUTO_INCREMENT,
  `empNum` varchar(6) NOT NULL,
  `tableNum` varchar(6) NOT NULL,
  `orderDate` date NOT NULL,
  `numGuests` int(3) NOT NULL,
  `orderTotal` decimal(6,2),
  `orderGratuity` decimal(5,2),
  PRIMARY KEY (`orderNum`)
 
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



--
-- 3). Table structure for table `employee`
--

CREATE TABLE `employee` (
  `empNum` varchar(6) NOT NULL COMMENT 'This is the primary key for employee',
  `empFName` varchar(25) NOT NULL,
  `empLName` varchar(25) NOT NULL,
  `empAddress` varchar(50) NOT NULL,
  `empCity` varchar(25) NOT NULL,
  `empProv` varchar(2) NOT NULL,
  `empPostal` varchar(7) NOT NULL,
  `empPhone` varchar(14) NOT NULL,
  `empSIN` varchar(11) NOT NULL,
  `empStartDate` date NOT NULL,
  `empStatus` varchar(25) NOT NULL,
  `empEndDate` date DEFAULT NULL,  
  `empPosition` varchar(15) NOT NULL,
  PRIMARY KEY (`empNum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


--
-- 4). Table structure for table `food`
--

CREATE TABLE `food` (
  `foodNum` int(3) NOT NULL AUTO_INCREMENT,
  `foodDescription` varchar(50) NOT NULL,
  `foodType` varchar(8) NOT NULL,
  `foodPrice` decimal(4,2) NOT NULL,
  PRIMARY KEY (`foodNum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



--
-- 5). Table structure for table `line`
--

CREATE TABLE `line` (
  `orderNum` int(6) NOT NULL,
  `lineNum` int(3) NOT NULL,
  `foodId` varchar(4) DEFAULT NULL,
  `barId` varchar(4) DEFAULT NULL,
  `lineQty` int(3) NOT NULL,
  `linePrice` decimal(4,2) NOT NULL,
  PRIMARY KEY (`orderNum`, `lineNum`)
 
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




--
-- 6). Table structure for table `salary`
--

CREATE TABLE `salary` (
  `salaryNum` int(6) NOT NULL AUTO_INCREMENT,
  `empNum` varchar(6) NOT NULL,
  `salaryFrom` date NOT NULL,
  `salaryTo` date DEFAULT NULL,
  `salaryAmount` decimal(9,2) NOT NULL,
  PRIMARY KEY (`salaryNum`)
 
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



--
-- 7). Table structure for table `tables`
--

CREATE TABLE `tables` (
  `tableNum` varchar(6) NOT NULL,
  `tableSeats` int(2) NOT NULL,
   
  PRIMARY KEY (`tableNum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




--
-- 8). Table structure for table `reservation`
--

CREATE TABLE `reservation`(
`reservationID` int(6) NOT NULL AUTO_INCREMENT,
`tableNum` varchar(6) NOT NULL,
`reservationDate` date NOT NULL,
`reservationTime` time(5) NOT NULL,
`reservationName` varchar(50) NOT NULL,
`reservationContact` varchar(13) NOT NULL,

  PRIMARY KEY(`reservationID`)
 
  )ENGINE=InnoDB DEFAULT CHARSET=latin1;



--
-- 9). Table structure for table `timeClock`
--

CREATE TABLE `timeClock` (
  `empNum` varchar(6) NOT NULL,
  `shiftDate` date NOT NULL,
  `clockIn` time(5) NOT NULL,
  `clockOut` time(5) NOT NULL,
  `empHours` decimal(4,2),
  PRIMARY KEY (`empNum`, `shiftDate`)
 
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



--
-- 10). Table structure for table `userAccess`
--


CREATE TABLE `userAccess` (
  `empNum` varchar(6) NOT NULL,
  `password` varchar(128) NOT NULL,
  `userTypeCode` int(3) NOT NULL DEFAULT '1',
  PRIMARY KEY (`empNum`, `password`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



--
-- 11). Table structure for table `payroll`
--

CREATE TABLE `payroll` (
  `payCheckNum` int(6) NOT NULL AUTO_INCREMENT,
  `empNum` varchar(6) NOT NULL,
  `payFrom` date NOT NULL,
  `payTo` date NOT NULL,
  `payHours` decimal(4,2) NOT NULL,
  `payAmount` decimal(9,2) NOT NULL,
   PRIMARY KEY (payCheckNum)
  
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES
(NULL, 'Roasted Garlic Soup', 'Starter', 5);

INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES
(NULL, 'Mac n Cheese Balls', 'Starter', 8);

INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES
(NULL, 'Pulled Pork Nachos', 'Starter', 12);

INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES
(NULL, 'Porkzilla', 'Main', 15);

INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES
(NULL, 'Bacon Wrapped Meatloaf', 'Main', 15);

INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES
(NULL, 'Smoked Flap Steak', 'Main', 20);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Molson Canadian', 'Domestic', 5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Budweiser', 'Domestic', 5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Alexander Keiths Red Amber Ale', 'Domestic', 5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Alpine', 'Domestic', 5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Moosehead Light', 'Domestic', 5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Guinness', 'Imported', 6.5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Corona', 'Imported', 6.5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Miller Genuine Draft', 'Imported', 6.5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Scotch', 'House', 5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Rye', 'House', 5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Vodka', 'House', 5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Rum', 'House', 5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Gin', 'House', 5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Margerita', 'Cocktail', 7.5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Pina Colada', 'Cocktail', 7.5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Long Island Iced Tea', 'Cocktail', 7.5, 100);

INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES
(NULL, 'Alabama Slammer', 'Cocktail', 7.5, 100);