DROP DATABASE IF EXISTS inventory_db;
CREATE DATABASE inventory_db;
USE inventory_db;

DROP TABLE IF EXISTS `city`;
CREATE TABLE `city` (
  `city_id` int(8) NOT NULL AUTO_INCREMENT,
  `city_name` varchar(50) NOT NULL,
  PRIMARY KEY (`city_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;

LOCK TABLES `city` WRITE;
INSERT INTO `city` VALUES (1,'Davao City'),(2,'General Santos City'),(3,'Digos'),(4,'Butuan'),(5,'Iligan'),(6,'N/A');
UNLOCK TABLES;

DROP TABLE IF EXISTS `street`;
CREATE TABLE `street` (
  `street_id` int(8) NOT NULL AUTO_INCREMENT,
  `street_name` varchar(50) NOT NULL,
  `city_id` int(8) DEFAULT NULL,
  PRIMARY KEY (`street_id`),
  UNIQUE KEY `street_name` (`street_name`),
  KEY `city_id` (`city_id`),
  CONSTRAINT `street_ibfk_1` FOREIGN KEY (`city_id`) REFERENCES `city` (`city_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;

LOCK TABLES `street` WRITE;
INSERT INTO `street` VALUES (1,'San Pedro Street',1),(2,'Uyanguren',1),(3,'Quimpo Boulevard',1),(4,'Bolton Street',1),(5,'Acacia Street',1),(6,'N/A',6);
UNLOCK TABLES;

DROP TABLE IF EXISTS `customer`;
CREATE TABLE `customer` (
  `customer_id` int(8) NOT NULL AUTO_INCREMENT,
  `customer_lastName` varchar(30) NOT NULL,
  `customer_firstName` varchar(30) NOT NULL,
  `customer_middleName` varchar(9) DEFAULT '',
  `customer_TIN` varchar(9) DEFAULT 'N/A',
  `customer_contact` varchar(9) DEFAULT 'N/A',
  `customer_email` varchar(30) DEFAULT 'N/A',
  `street_id` int(8) NOT NULL DEFAULT 6,
  PRIMARY KEY (`customer_id`),
  KEY `street_id` (`street_id`),
  CONSTRAINT `customer_ibfk_1` FOREIGN KEY (`street_id`) REFERENCES `street` (`street_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4;

LOCK TABLES `customer` WRITE;
INSERT INTO `customer` VALUES (1,'Ang','Matthew Szenel','Seng',NULL,'091711599','msAng@mcm.edu.ph',1),(2,'Baste','Martzel','','N/A','095512129','mBaste@mcm.edu.ph',2),(3,'Luh','Bee','','N/A','N/A','N/A',3),(4,'Kay','Luh','','N/A','N/A','N/A',4),(5,'Bay','Clark','Su','123456789',NULL,NULL,5),(13,'Bai','Clark','Su','123456789',NULL,NULL,5);
UNLOCK TABLES;

DROP TABLE IF EXISTS `paymentstatus`;
CREATE TABLE `paymentstatus` (
  `paymentStatus_id` int(2) NOT NULL AUTO_INCREMENT,
  `paymentStatus_status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`paymentStatus_id`),
  UNIQUE KEY `paymentStatus_status` (`paymentStatus_status`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

LOCK TABLES `paymentstatus` WRITE;
INSERT INTO `paymentstatus` VALUES (1,'Is Paid'),(2,'Not Yet Paid');
UNLOCK TABLES;

DROP TABLE IF EXISTS `invoice`;
CREATE TABLE `invoice` (
  `invoice_id` int(8) NOT NULL AUTO_INCREMENT,
  `customer_id` int(8) DEFAULT NULL,
  `invoice_date` date DEFAULT NULL,
  `paymentStatus_id` int(2) DEFAULT NULL,
  PRIMARY KEY (`invoice_id`),
  KEY `customer_id` (`customer_id`),
  KEY `paymentStatus_id` (`paymentStatus_id`),
  CONSTRAINT `invoice_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`customer_id`),
  CONSTRAINT `invoice_ibfk_2` FOREIGN KEY (`paymentStatus_id`) REFERENCES `paymentstatus` (`paymentStatus_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;

LOCK TABLES `invoice` WRITE;
INSERT INTO `invoice` VALUES (1,1,'2022-02-09',1),(2,2,'2023-01-09',1),(3,3,'2015-12-15',1),(4,4,'2019-05-13',2),(5,5,'2020-07-03',2);
UNLOCK TABLES;

DROP TABLE IF EXISTS `productcategory`;
CREATE TABLE `productcategory` (
  `productCategory_id` int(8) NOT NULL AUTO_INCREMENT,
  `productCategory_name` varchar(50) NOT NULL,
  PRIMARY KEY (`productCategory_id`),
  UNIQUE KEY `productCategory_name` (`productCategory_name`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;

LOCK TABLES `productcategory` WRITE;
INSERT INTO `productcategory` VALUES (4,'Computer Parts'),(5,'Electronics'),(3,'Office Supplies'),(6,'Pet Supplies'),(1,'School Supplies');
UNLOCK TABLES;

DROP TABLE IF EXISTS `producttype`;
CREATE TABLE `producttype` (
  `productType_id` int(8) NOT NULL AUTO_INCREMENT,
  `productType_name` varchar(50) NOT NULL,
  `productCategory_id` int(8) DEFAULT NULL,
  PRIMARY KEY (`productType_id`),
  UNIQUE KEY `productType_name` (`productType_name`),
  KEY `productCategory_id` (`productCategory_id`),
  CONSTRAINT `producttype_ibfk_1` FOREIGN KEY (`productCategory_id`) REFERENCES `productcategory` (`productCategory_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;

LOCK TABLES `producttype` WRITE;
INSERT INTO `producttype` VALUES (1,'Pencil',1),(2,'Motherboard',4),(3,'CPU',4),(4,'GPU',4),(5,'Keyboard',4),(6,'Headphones',5),(12,'Printer',5);
UNLOCK TABLES;

DROP TABLE IF EXISTS `productunit`;
CREATE TABLE `productunit` (
  `productUnit_id` int(3) NOT NULL AUTO_INCREMENT,
  `productUnit_name` varchar(50) NOT NULL,
  PRIMARY KEY (`productUnit_id`),
  UNIQUE KEY `productUnit_name` (`productUnit_name`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;

LOCK TABLES `productunit` WRITE;
INSERT INTO `productunit` VALUES (5,'Bag'),(4,'Bottle'),(2,'Box'),(3,'Pack'),(1,'Pcs');
UNLOCK TABLES;

DROP TABLE IF EXISTS `product`;
CREATE TABLE `product` (
  `product_id` int(8) NOT NULL AUTO_INCREMENT,
  `product_name` varchar(50) NOT NULL,
  `productType_id` int(8) DEFAULT NULL,
  `product_description` text DEFAULT NULL,
  `productUnit_id` int(3) DEFAULT NULL,
  `product_quantity` int(7) NOT NULL,
  `product_price` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`product_id`),
  KEY `productType_id` (`productType_id`),
  KEY `productUnit_id` (`productUnit_id`),
  CONSTRAINT `product_ibfk_1` FOREIGN KEY (`productType_id`) REFERENCES `producttype` (`productType_id`),
  CONSTRAINT `product_ibfk_2` FOREIGN KEY (`productUnit_id`) REFERENCES `productunit` (`productUnit_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4;

LOCK TABLES `product` WRITE;
INSERT INTO `product` VALUES (1,'Koss KSC75',6,'Clip-on headphones',1,10,1200.00),(2,'Moondrop Chu',6,'IEMs',1,10,900.99),(3,'Canon Printer',12,'Canon Printer',1,1,20000.00),(4,'Mongol Pencil No. 3',1,'Mongol Pencil Good',1,100,20.00),(5,'Dell Keyboard',5,'Cheap office keyboard',1,10,200.00),(18,'Salnotes Zero',6,'IEMs',1,10,900.99),(19,'asf',6,'test',1,1,100.00),(20,'asdf',6,'',1,1,1.00);
UNLOCK TABLES;

DROP TABLE IF EXISTS `purchase`;
CREATE TABLE `purchase` (
  `invoice_id` int(8) NOT NULL,
  `product_id` int(8) NOT NULL,
  `purchase_quantity` int(3) NOT NULL,
  PRIMARY KEY (`invoice_id`,`product_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `purchase_ibfk_1` FOREIGN KEY (`invoice_id`) REFERENCES `invoice` (`invoice_id`),
  CONSTRAINT `purchase_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

LOCK TABLES `purchase` WRITE;
INSERT INTO `purchase` VALUES (1,1,1),(1,2,1),(1,3,1),(2,3,1),(2,5,5);
UNLOCK TABLES;


-- Street_and_city için geçici tablo oluşturduğum kısım

DROP TABLE IF EXISTS `street_and_city`;
/*!50001 DROP VIEW IF EXISTS `street_and_city`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `street_and_city` (
  `street_id` tinyint NOT NULL,
  `street_name` tinyint NOT NULL,
  `city_id` tinyint NOT NULL,
  `city_name` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

-- Type_and_category için geçici tablo oluşturduğum kısım

DROP TABLE IF EXISTS `type_and_category`;
/*!50001 DROP VIEW IF EXISTS `type_and_category`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `type_and_category` (
  `productType_id` tinyint NOT NULL,
  `productType_name` tinyint NOT NULL,
  `productCategory_id` tinyint NOT NULL,
  `productCategory_name` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

-- Viewallcustomer için geçici tablo oluşturduğum kısım

DROP TABLE IF EXISTS `viewallcustomer`;
/*!50001 DROP VIEW IF EXISTS `viewallcustomer`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `viewallcustomer` (
  `customer_id` tinyint NOT NULL,
  `customer_lastName` tinyint NOT NULL,
  `customer_firstName` tinyint NOT NULL,
  `customer_middleName` tinyint NOT NULL,
  `customer_TIN` tinyint NOT NULL,
  `customer_contact` tinyint NOT NULL,
  `customer_email` tinyint NOT NULL,
  `street_name` tinyint NOT NULL,
  `city_name` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

-- Viewallinvoice için geçici tablo oluşturduğum kısım

DROP TABLE IF EXISTS `viewallinvoice`;
/*!50001 DROP VIEW IF EXISTS `viewallinvoice`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `viewallinvoice` (
  `invoice_id` tinyint NOT NULL,
  `customer_lastName` tinyint NOT NULL,
  `customer_firstName` tinyint NOT NULL,
  `customer_middleName` tinyint NOT NULL,
  `invoice_date` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

-- Viewallproducts için geçici tablo oluşturduğum kısım

DROP TABLE IF EXISTS `viewallproducts`;
/*!50001 DROP VIEW IF EXISTS `viewallproducts`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `viewallproducts` (
  `Product ID` tinyint NOT NULL,
  `Product Name` tinyint NOT NULL,
  `Type` tinyint NOT NULL,
  `Category` tinyint NOT NULL,
  `Description` tinyint NOT NULL,
  `Price` tinyint NOT NULL,
  `Qty.` tinyint NOT NULL,
  `Unit` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

-- Viewallpurchases için geçici tablo oluşturduğum kısım

DROP TABLE IF EXISTS `viewallpurchases`;
/*!50001 DROP VIEW IF EXISTS `viewallpurchases`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `viewallpurchases` (
  `invoice_id` tinyint NOT NULL,
  `customer_lastName` tinyint NOT NULL,
  `customer_firstName` tinyint NOT NULL,
  `product_name` tinyint NOT NULL,
  `product_price` tinyint NOT NULL,
  `purchase_quantity` tinyint NOT NULL,
  `Amount` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

-- Street_and_city geçici tablosunun tamamlanışı

/*!50001 DROP TABLE IF EXISTS `street_and_city`*/;
/*!50001 DROP VIEW IF EXISTS `street_and_city`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `street_and_city` AS select `street`.`street_id` AS `street_id`,`street`.`street_name` AS `street_name`,`street`.`city_id` AS `city_id`,`city`.`city_name` AS `city_name` from (`street` join `city` on(`street`.`city_id` = `city`.`city_id`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

-- Type_and_category geçici tablosunun tamamlanışı

/*!50001 DROP TABLE IF EXISTS `type_and_category`*/;
/*!50001 DROP VIEW IF EXISTS `type_and_category`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `type_and_category` AS select `producttype`.`productType_id` AS `productType_id`,`producttype`.`productType_name` AS `productType_name`,`producttype`.`productCategory_id` AS `productCategory_id`,`productcategory`.`productCategory_name` AS `productCategory_name` from (`producttype` join `productcategory` on(`producttype`.`productCategory_id` = `productcategory`.`productCategory_id`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

-- Viewallcustomer geçici tablosunun tamamlanışı

/*!50001 DROP TABLE IF EXISTS `viewallcustomer`*/;
/*!50001 DROP VIEW IF EXISTS `viewallcustomer`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `viewallcustomer` AS select `customer`.`customer_id` AS `customer_id`,`customer`.`customer_lastName` AS `customer_lastName`,`customer`.`customer_firstName` AS `customer_firstName`,`customer`.`customer_middleName` AS `customer_middleName`,`customer`.`customer_TIN` AS `customer_TIN`,`customer`.`customer_contact` AS `customer_contact`,`customer`.`customer_email` AS `customer_email`,`street`.`street_name` AS `street_name`,`city`.`city_name` AS `city_name` from ((`customer` join `street` on(`customer`.`street_id` = `street`.`street_id`)) join `city` on(`street`.`city_id` = `city`.`city_id`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

-- Viewallinvoice geçici tablosunun tamamlanışı

/*!50001 DROP TABLE IF EXISTS `viewallinvoice`*/;
/*!50001 DROP VIEW IF EXISTS `viewallinvoice`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `viewallinvoice` AS select `invoice`.`invoice_id` AS `invoice_id`,`customer`.`customer_lastName` AS `customer_lastName`,`customer`.`customer_firstName` AS `customer_firstName`,`customer`.`customer_middleName` AS `customer_middleName`,`invoice`.`invoice_date` AS `invoice_date` from (`invoice` join `customer` on(`invoice`.`customer_id` = `customer`.`customer_id`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

-- Viewallproducts geçici tablosunun tamamlanışı

/*!50001 DROP TABLE IF EXISTS `viewallproducts`*/;
/*!50001 DROP VIEW IF EXISTS `viewallproducts`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `viewallproducts` AS select `product`.`product_id` AS `Product ID`,`product`.`product_name` AS `Product Name`,`producttype`.`productType_name` AS `Type`,`productcategory`.`productCategory_name` AS `Category`,`product`.`product_description` AS `Description`,`product`.`product_price` AS `Price`,`product`.`product_quantity` AS `Qty.`,`productunit`.`productUnit_name` AS `Unit` from (((`product` join `productunit` on(`product`.`productUnit_id` = `productunit`.`productUnit_id`)) join `producttype` on(`product`.`productType_id` = `producttype`.`productType_id`)) join `productcategory` on(`producttype`.`productCategory_id` = `productcategory`.`productCategory_id`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

-- Viewallpurchases geçici tablosunun tamamlanışı

/*!50001 DROP TABLE IF EXISTS `viewallpurchases`*/;
/*!50001 DROP VIEW IF EXISTS `viewallpurchases`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `viewallpurchases` AS select `invoice`.`invoice_id` AS `invoice_id`,`customer`.`customer_lastName` AS `customer_lastName`,`customer`.`customer_firstName` AS `customer_firstName`,`product`.`product_name` AS `product_name`,`product`.`product_price` AS `product_price`,`purchase`.`purchase_quantity` AS `purchase_quantity`,`product`.`product_price` * `purchase`.`purchase_quantity` AS `Amount` from (((`purchase` join `invoice` on(`purchase`.`invoice_id` = `invoice`.`invoice_id`)) join `customer` on(`invoice`.`customer_id` = `customer`.`customer_id`)) join `product` on(`purchase`.`product_id` = `product`.`product_id`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
