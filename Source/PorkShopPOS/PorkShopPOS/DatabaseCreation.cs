using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PorkShopPOS
{
    class DatabaseCreation
    {
        public void createDatabase() 
        {
        try
            {
                // set up connection data
                MySqlConnection conn;
                string connectionStr = "server=localhost; user=root; password=;";
                conn = new MySqlConnection(connectionStr);
                MySqlCommand cmd;
                string query;

                conn.Open();
                query = "drop database IF EXISTS pork_shop; "
                    + " CREATE DATABASE IF NOT EXISTS `pork_shop` "
                    + " USE `pork_shop`;"                    
                   + " CREATE TABLE `bar` ( "
                   + "   `barId` int(4) NOT NULL AUTO_INCREMENT, "
                    + "  `barDescription` varchar(50) NOT NULL, "
                    + "  `barType` varchar(8) NOT NULL, "
                    + "  `barPrice` decimal(4,2) NOT NULL, "
                    + "  `barQOH` int(4) NOT NULL,"
                    + "  PRIMARY KEY (`barId`)"
                   + " ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                   + " --"
                   + " -- 2). Table structure for table `customerOrders`"
                   + " --"
                  + "  CREATE TABLE `customerOrders` ("
                  + "    `orderNum` int(6) NOT NULL AUTO_INCREMENT,"
                  + "    `empNum` varchar(6) NOT NULL,"
                  + "    `tableNum` varchar(6) NOT NULL,"
                   + "   `orderDate` date NOT NULL,"
                  + "    `orderTime` time NOT NULL,"
                  + "    `numGuests` int(3) NOT NULL,"
                  + "    `orderTotal` decimal(6,2),"
                 + "     `orderGratuity` decimal(5,2),"
                + "      PRIMARY KEY (`orderNum`)"
                 + "   ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                 + "   --"
                + "    -- 3). Table structure for table `employee`"
                + "    --"
                 + "   CREATE TABLE `employee` ("
                 + "     `empNum` varchar(6) NOT NULL COMMENT 'This is the primary key for employee',"
                  + "    `empFName` varchar(25) NOT NULL,"
                  + "    `empLName` varchar(25) NOT NULL,"
                  + "    `empAddress` varchar(50) NOT NULL,"
                  + "    `empCity` varchar(25) NOT NULL,"
                  + "    `empProv` varchar(2) NOT NULL,"
                  + "    `empPostal` varchar(7) NOT NULL,"
                  + "    `empPhone` varchar(14) NOT NULL,"
                  + "    `empSIN` varchar(11) NOT NULL,"
                  + "    `empStartDate` date NOT NULL,"
                 + "     `empStatus` varchar(25) NOT NULL,"
                   + "   `empEndDate` date DEFAULT NULL,  "
                 + "     `empPosition` varchar(15) NOT NULL,"
                  + "    PRIMARY KEY (`empNum`)"
                   + " ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"


                   + " --"
                   + " -- 4). Table structure for table `food`"
                   + " --"

                   + " CREATE TABLE `food` ("
                   + "   `foodNum` int(3) NOT NULL AUTO_INCREMENT,"
                  + "    `foodDescription` varchar(50) NOT NULL,"
                   + "   `foodType` varchar(8) NOT NULL,"
                    + "  `foodPrice` decimal(4,2) NOT NULL,"
                    + "  PRIMARY KEY (`foodNum`)"
                   + " ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



                    + "--"
                  + "  -- 5). Table structure for table `line`"
                  + "  --"

                 + "   CREATE TABLE `line` ("
                  + "    `orderNum` int(6) NOT NULL,"
                  + "    `lineNum` int(3) NOT NULL,"
                  + "    `foodId` varchar(4) DEFAULT NULL,"
                   + "   `barId` varchar(4) DEFAULT NULL,"
                   + "   `lineQty` int(3) NOT NULL,"
                    + "  `linePrice` decimal(4,2) NOT NULL,"
                    + "  PRIMARY KEY (`orderNum`, `lineNum`)"

                  + "  ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"


                  + "  --"
                 + "   -- 6). Table structure for table `salary`"
                + "    --"

                 + "   CREATE TABLE `salary` ("
                 + "     `salaryNum` int(6) NOT NULL AUTO_INCREMENT,"
                 + "     `empNum` varchar(6) NOT NULL,"
                + "      `salaryFrom` date NOT NULL,"
                 + "     `salaryTo` date DEFAULT NULL,"
                 + "     `salaryAmount` decimal(9,2) NOT NULL,"
                + "      PRIMARY KEY (`salaryNum`)"

               + "     ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

                + "    --"
                + "    -- 7). Table structure for table `tables`"
                + "    --"

                   + " CREATE TABLE `tables` ("
                  + "    `tableNum` varchar(6) NOT NULL,"
                 + "     `tableSeats` int(2) NOT NULL,"

                + "      PRIMARY KEY (`tableNum`)"
                + "    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"




                  + "  --"
                 + "   -- 8). Table structure for table `reservation`"
                + "    --"

              + "      CREATE TABLE `reservation`("
             + "       `reservationID` int(6) NOT NULL AUTO_INCREMENT,"
              + "      `tableNum` varchar(6) NOT NULL,"
              + "      `reservationDate` date NOT NULL,"
               + "     `reservationTime` time(5) NOT NULL,"
             + "       `reservationName` varchar(50) NOT NULL,"
              + "      `reservationContact` varchar(13) NOT NULL,"

              + "        PRIMARY KEY(`reservationID`)"

             + "         )ENGINE=InnoDB DEFAULT CHARSET=latin1;"

               + "                  --"
              + "      -- 9). Table structure for table `timeClock`"
               + "     --"

              + "      CREATE TABLE `timeClock` ("
                 + "     `timeClockNum` int(6) NOT NULL AUTO_INCREMENT,"
                 + "     `empNum` varchar(6) NOT NULL,"
                 + "     `shiftDate` date NOT NULL,"
                + "      `clockIn` time(0) NOT NULL,"
                 + "     `clockOut` time(0) NOT NULL,"
                 + "     PRIMARY KEY (`timeClockNum`)"

                 + "   ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



                 + "   --"
                 + "   -- 10). Table structure for table `userAccess`"
                + "    --"


                + "    CREATE TABLE `userAccess` ("

                + "      `accountId` int(6) NOT NULL AUTO_INCREMENT,"
                + "      `empNum` varchar(6) NOT NULL,"
                + "      `password` varchar(128) NOT NULL,"
                + "      `userTypeCode` int(3) NOT NULL DEFAULT '1',"
               + "       PRIMARY KEY (`accountId`)"
              + "      ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



                  + "  --"
                 + "   -- 11). Table structure for table `payroll`"
                + "    --"

                + "    CREATE TABLE `payroll` ("
                 + "     `payCheckNum` int(6) NOT NULL AUTO_INCREMENT,"
                + "      `empNum` varchar(6) NOT NULL,"
                 + "     `payFrom` date NOT NULL,"
                 + "     `payTo` date NOT NULL,"
                 + "     `hours` decimal NOT NULL,"
                  + "    `amount` decimal NOT NULL,"
                  + "     PRIMARY KEY (payCheckNum)  "
                  + "  ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"


                   + " --"
                   + " -- Dump data into tables"
                   + " --"

                + "    INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                + "    (NULL, 'Roasted Garlic Soup', 'Starter', 5);"

                + "    INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                 + "   (NULL, 'Mac n Cheese Balls', 'Starter', 8);"

                  + "  INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                  + "  (NULL, 'Pulled Pork Nachos', 'Starter', 12);"

                  + "  INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                  + "  (NULL, 'Porkzilla', 'Main', 15);"

                   + " INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                  + "  (NULL, 'Bacon Wrapped Meatloaf', 'Main', 15);"

                 + "   INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                 + "   (NULL, 'Smoked Flap Steak', 'Main', 20);"

                 + "   INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                  + "  (NULL, 'Crusty Roll', 'Side', 0.99);"

                  + "  INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                   + " (NULL, 'Cornbread', 'Side', 0.99);"

                  + "  INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                  + "  (NULL, 'Biscuit', 'Side', 0.99);"

                 + "   INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                 + "   (NULL, 'Chipotle Mayo', 'Side', 0.99);"

                 + "   INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                 + "   (NULL, 'Onion Rings', 'Side', 2.99);"

                  + "  INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                  + "  (NULL, 'Home Fries', 'Side', 2.99);"

                  + "  INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                  + "  (NULL, 'Mac n Cheese', 'Side', 2.99);"

                 + "   INSERT INTO food (foodNum, foodDescription, foodType, foodPrice) VALUES"
                 + "   (NULL, 'Mashed Potatoes', 'Side', 2.99);"

                 + "   INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                  + "  (NULL, 'Molson Canadian', 'Domestic', 5, 100);"

                   + " INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                   + " (NULL, 'Budweiser', 'Domestic', 5, 100);"

                   + " INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                  + "  (NULL, 'Alexander Keiths Red Amber Ale', 'Domestic', 5, 100);"

                  + "  INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                  + "  (NULL, 'Alpine', 'Domestic', 5, 100);"

                  + "  INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                 + "   (NULL, 'Moosehead Light', 'Domestic', 5, 100);"

                 + "   INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                  + "  (NULL, 'Coors Light', 'Domestic', 5, 100);"

                  + "  INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                  + "  (NULL, 'Guinness', 'Imported', 6.5, 100);"

                   + " INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                  + "  (NULL, 'Corona', 'Imported', 6.5, 100);"

                   + " INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                  + "  (NULL, 'Miller Genuine Draft', 'Imported', 6.5, 100);"

                   + " INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                   + " (NULL, 'Scotch', 'House', 5, 100);"

                + "    INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                   + " (NULL, 'Rye', 'House', 5, 100);"

                   + " INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                   + " (NULL, 'Vodka', 'House', 5, 100);"

                  + "  INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                  + "  (NULL, 'Rum', 'House', 5, 100);"

                 + "   INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                 + "   (NULL, 'Gin', 'House', 5, 100);"

                   + " INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                   + " (NULL, 'Margerita', 'Cocktail', 7.5, 100);"

                  + "  INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                   + " (NULL, 'Pina Colada', 'Cocktail', 7.5, 100);"

                  + "  INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                   + " (NULL, 'Long Island Iced Tea', 'Cocktail', 7.5, 100);"

                + "    INSERT INTO bar (barId, barDescription, barType, barPrice, barQOH) VALUES"
                + "    (NULL, 'Alabama Slammer', 'Cocktail', 7.5, 100);"

                 + "   INSERT into `userAccess` VALUES(1, 'M00001', 'boss', '3');"

                 + "   INSERT into `tables` (tableNum, tableSeats) VALUES('TBL001', '4'),"
                  + "  ('TBL002', '4'),"
                  + "  ('TBL003', '4'),"
                  + "  ('TBL004', '4'),"
                 + "   ('TBL005', '4'),"
                  + "  ('TBL006', '10'),"
                 + "   ('TBL007', '4'),"
                 + "   ('TBL008', '4'),"
                 + "   ('TBL009', '4'),"
                + "    ('TBL010', '4'),"
                 + "   ('BTH001', '6'),"
                  + "  ('BTH002', '6'),"
                 + "   ('BTH003', '6'),"
                  + "  ('BTH004', '6'),"
                + "    ('BTH005', '6'),"
                 + "   ('BTH006', '6');"

                 + "   INSERT INTO employee"
                 + "   VALUES ('B00002', 'Bryan', 'MacFarlane', '222 Street', 'Bedeque', 'PE', 'c1n3d2', '9024445555', '111222333', '2017-01-01', 'Active', '0000-00-00, 'Bartender'),"
                 + "   ('M00001', 'Heather', 'Watterson', '222 Street', 'Summerside', 'PE', 'c1n3d2', '9024445555', '111222333', '2017-01-01', 'Active', '0000-00-00', 'Owner'),"
                  + " ('W00003', Jonathan', 'Deschene', '222 Street', 'Summerside', 'PE', 'c1n3d2', '9024445555', '111222333', '2017-01-01', 'Active', '0000-00-00', 'Waiter'),"
                  + "  ('C00004', 'Noah', 'Gallant', '222 Street', 'Summerside', 'PE', 'c1n3d2', '9024445555', '111222333', '2017-01-01', 'Active', '0000-00-00', 'Cook'),"
                  + "  ('W00005', 'Shane', 'Arsenault', '222 Street', 'Summerside', 'PE', 'c1n3d2', '9024445555', '111222333', '2017-01-01', 'Active', '0000-00-00', 'Pit Boss');"

                   + " INSERT INTO `timeClock`"
                  + "  Values (1, 'M00001','2017-01-01', '2:00', '11:50'), "
                   + " (2, 'B00002','2017-01-01', '2:00', '11:50'), "
                  + "  (3, 'W00003','2017-01-01', '2:00', '11:50'), "
                  + "  (4, 'C00004','2017-01-01', '2:00', '11:50'), "
                  + "  (5, 'W00005','2017-01-01', '2:00', '11:50'), "
                  + "  (6, 'M00001','2017-02-01', '2:00', '11:50'), "
                  + "  (7, 'B00002','2017-02-01', '2:00', '11:50'), "
                 + "   (8, 'W00003','2017-02-01', '2:00', '11:50'),"
                  + "  (9, 'C00004','2017-02-01', '2:00', '11:50'), "
                 + "   (10, 'W00005','2017-02-01', '2:00', '11:50'), "
                 + "   (11, 'M00001','2017-03-01', '2:00', '11:50'), "
                 + "   (12, 'B00002','2017-03-01', '2:00', '11:5'), "
                 + "   (13, 'W00003','2017-03-01', '2:00', ':50'), "
                  + "  (14, 'C00004','2017-03-01', '2:00', '11:50'), "
                  + "  (15, 'W00005','2017-03-01', '2:00', '11:50'), "
                  + "  (16, 'M00001','2017-04-01', '2:00', '11:50'), "
                  + "  (17, 'B00002','2017-04-01', '2:00', '11:50'), "
                 + "   (18, 'W00003','2017-04-01', '2:00', '11:50'), "
                + "    (19, 'C00004','2017-04-01', '2:00', '11:50'), "
                  + "  (20, 'W00005','2017-04-01', '2:00', '11:50');"


                  + "  INSERT INTO salary "
                + "    Values(1, 'M00001', '2017-01-01', '2017-01-27', 20.00),"
                 + "   (2, 'B00002', '2017-01-01', '2017-01-15', 15.00),"
                 + "   (3, 'W00003', '2017-01-01', '2017-01-20', 10.00),"
                 + "   (4, 'C00004', '2017-01-01', '2017-02-10', 25.00),"
                  + "  (5, 'W00005', '2017-01-01', '2017-02-11', 10.00),"
                  + "  (6, 'M00001', '2017-01-27', '0000-00-00', 25.00),"
                 + "   (7, 'B00002', '2017-01-15', '0000-00-00', 20.00),"
                 + "   (8, 'W00003', '2017-01-20', '0000-00-00', 11.50),"
                 + "   (9, 'C00004', '2017-02-10', '0000-00-00', 20.00),"
                 + "   (10, 'W00005', '2017-02-11', '0000-00-00', 12.00);"


                   + " INSERT INTO payroll"
                    + "Values(1, 'M00001', '2017-01-01', '2017-14-01', 100, 2000),"
                  + "  (2, 'B00002', '2017-01-01', '2017-14-01', 78, 1400),"
                   + " (3, 'W00003', '2017-01-01', '2017-14-01', 89, 1670.22),"
                  + "  (4, 'C00004', '2017-01-01', '017-14-01', 69, 1234.10),"
                  + "  (5, 'W00005, '2017-01-01', '2017-14-01', 120, 2345.23);";
                    
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        }
    }

