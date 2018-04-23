/*
SQLyog Community v13.0.0 (64 bit)
MySQL - 8.0.11 : Database - upravitelj
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`upravitelj` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;

USE `upravitelj`;

/*Table structure for table `financije` */

DROP TABLE IF EXISTS `financije`;

CREATE TABLE `financije` (
  `id_financija` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_zgrada` int(10) unsigned NOT NULL,
  `datum` datetime NOT NULL,
  `stanje` int(10) unsigned NOT NULL,
  KEY `id_financija` (`id_financija`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `financije` */

/*Table structure for table `obavijest` */

DROP TABLE IF EXISTS `obavijest`;

CREATE TABLE `obavijest` (
  `id_obavijest` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `datum` datetime NOT NULL,
  `naslov` varchar(20) NOT NULL,
  `opis` varchar(50) NOT NULL,
  `dokument` varchar(50) NOT NULL,
  `slika(da/ne)` tinyint(1) NOT NULL DEFAULT '0',
  `kategorija(dnevni/stalni)` tinyint(1) NOT NULL DEFAULT '0',
  `vidljiv(da/ne)` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_obavijest`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `obavijest` */

/*Table structure for table `stanar` */

DROP TABLE IF EXISTS `stanar`;

CREATE TABLE `stanar` (
  `id_stanar` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ime+prezime` varchar(40) NOT NULL,
  `id_zgrada` int(5) unsigned NOT NULL,
  `vrsta_korisnika` varchar(30) NOT NULL,
  `mob` int(15) unsigned NOT NULL,
  `email` varchar(40) NOT NULL,
  `lozinka` int(20) NOT NULL,
  `aktivacijski_link` varchar(30) NOT NULL,
  `aktivan(da/ne)` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_stanar`,`id_zgrada`,`mob`,`email`,`aktivacijski_link`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `stanar` */

/*Table structure for table `upit` */

DROP TABLE IF EXISTS `upit`;

CREATE TABLE `upit` (
  `id_upit` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_stanar` int(10) unsigned NOT NULL,
  `datum` datetime NOT NULL,
  `naslov` varchar(20) NOT NULL,
  `opis` varchar(50) NOT NULL,
  `dogovoreno(da/ne)` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_upit`,`id_stanar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `upit` */

/*Table structure for table `upravitelj` */

DROP TABLE IF EXISTS `upravitelj`;

CREATE TABLE `upravitelj` (
  `id_upravitelj` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ime+prezime` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `email` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `lozinka` int(25) NOT NULL,
  PRIMARY KEY (`id_upravitelj`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

/*Data for the table `upravitelj` */

/*Table structure for table `zgrada` */

DROP TABLE IF EXISTS `zgrada`;

CREATE TABLE `zgrada` (
  `id_zgrada` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `naziv` varchar(30) NOT NULL,
  `ulica` varchar(30) NOT NULL,
  `grad` varchar(30) NOT NULL,
  `broj stanara` int(5) unsigned NOT NULL,
  PRIMARY KEY (`id_zgrada`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `zgrada` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
