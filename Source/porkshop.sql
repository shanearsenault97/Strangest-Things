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
  `barId` varchar(4) NOT NULL,
  `barDescription` varchar(50) NOT NULL,
  `barType` varchar(6) NOT NULL,
  `barPrice` decimal(4,2) NOT NULL,
  `barQOH` int(4) NOT NULL,
  PRIMARY KEY (`barId`)
  
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


--
-- 2). Table structure for table `customerOrders`
--

CREATE TABLE `customerOrders` (
  `orderNum` int(6) AUTO_INCREMENT NOT NULL,
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
  `foodId` varchar(4) NOT NULL,
  `foodDescription` varchar(50) NOT NULL,
  `foodType` varchar(6) NOT NULL,
  `foodPrice` decimal(4,2) NOT NULL,
  PRIMARY KEY (`foodId`)
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
  `salaryNum` int(6) AUTO_INCREMENT NOT NULL,
  `salaryEmpNum` varchar(6) NOT NULL,
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
`reservationID` int(6) AUTO_INCREMENT NOT NULL,
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
  `payCheckNum` int(6) AUTO_INCREMENT NOT NULL,
  `payEmpNum` varchar(6) NOT NULL,
  `payFrom` date NOT NULL,
  `payTo` date NOT NULL,
  `payHours` decimal(4,2) NOT NULL,
  `payAmount` decimal(9,2) NOT NULL,
   PRIMARY KEY (payCheckNum)
  
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


