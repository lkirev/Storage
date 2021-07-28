-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: localhost    Database: sklad1m
-- ------------------------------------------------------
-- Server version	8.0.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `locations`
--

DROP TABLE IF EXISTS `locations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `locations` (
  `id` int NOT NULL AUTO_INCREMENT,
  `loc_name` varchar(10) NOT NULL,
  `sub_loc` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=84 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `locations`
--

LOCK TABLES `locations` WRITE;
/*!40000 ALTER TABLE `locations` DISABLE KEYS */;
INSERT INTO `locations` VALUES (1,'T2','0'),(2,'T4','0'),(3,'T2','1-1'),(4,'T2','1-2'),(5,'T2','1-3'),(6,'T2','1-4'),(7,'T2','1-5'),(8,'T2','1-6'),(9,'T2','2-1'),(10,'T2','2-2'),(11,'T2','2-3'),(12,'T2','2-4'),(13,'T2','2-5'),(14,'T2','2-6'),(15,'T2','3-1'),(16,'T2','3-2'),(17,'T2','3-3'),(18,'T2','3-4'),(19,'T2','3-5'),(20,'T2','3-6'),(21,'T2','4-1'),(22,'T2','4-2'),(23,'T2','4-3'),(24,'T2','4-4'),(25,'T2','4-5'),(26,'T2','4-6'),(27,'T2','5-1'),(28,'T2','5-2'),(29,'T2','5-3'),(30,'T2','5-4'),(31,'T2','5-5'),(32,'T2','5-6'),(33,'T2','6-1'),(34,'T2','6-2'),(35,'T2','6-3'),(36,'T2','6-4'),(37,'T2','6-5'),(38,'T2','6-6'),(39,'T2','7-1'),(40,'T2','7-2'),(41,'T2','7-3'),(42,'T2','7-4'),(43,'T2','7-5'),(44,'T2','7-6'),(45,'T2','8-1'),(46,'T2','8-2'),(47,'T2','8-3'),(48,'T2','8-4'),(49,'T2','8-5'),(50,'T2','8-6'),(51,'T2','9-1'),(52,'T2','9-2'),(53,'T2','9-3'),(54,'T2','9-4'),(55,'T2','9-5'),(56,'T2','9-6'),(57,'T2','10-1'),(58,'T2','10-2'),(59,'T2','10-3'),(60,'T2','10-4'),(61,'T2','10-5'),(62,'T2','10-6'),(63,'T2','11-1'),(64,'T2','11-2'),(65,'T2','11-3'),(66,'T2','11-4'),(67,'T2','11-5'),(68,'T2','11-6'),(69,'T2','12-1'),(70,'T2','12-2'),(71,'T2','12-3'),(72,'T2','12-4'),(73,'T2','12-5'),(74,'T2','12-6'),(75,'T2','13-1'),(76,'T2','13-2'),(77,'T2','13-3'),(78,'T2','13-4'),(79,'T2','13-5'),(80,'T2','13-6'),(82,'T1','0');
/*!40000 ALTER TABLE `locations` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-26 15:56:41
