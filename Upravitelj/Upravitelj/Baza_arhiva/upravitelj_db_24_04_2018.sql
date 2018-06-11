-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 24, 2018 at 06:53 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `upravitelj_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `financije`
--

CREATE TABLE IF NOT EXISTS `financije` (
  `id_financija` bigint(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_zgrada` int(10) unsigned NOT NULL,
  `datum` date NOT NULL,
  `stanje` double unsigned NOT NULL,
  KEY `id_financija` (`id_financija`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `obavijest`
--

CREATE TABLE IF NOT EXISTS `obavijest` (
  `id_obavijest` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `datum` date NOT NULL,
  `naslov` varchar(60) COLLATE utf8_croatian_ci NOT NULL,
  `opis` text COLLATE utf8_croatian_ci NOT NULL,
  `dokument` varchar(50) COLLATE utf8_croatian_ci NOT NULL,
  `slika` varchar(50) COLLATE utf8_croatian_ci NOT NULL,
  `kategorija` int(11) NOT NULL,
  `vidljiv` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_obavijest`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `stanar`
--

CREATE TABLE IF NOT EXISTS `stanar` (
  `id_stanar` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `ime_prezime` varchar(50) COLLATE utf8_croatian_ci NOT NULL,
  `id_zgrada` int(5) unsigned NOT NULL,
  `vrsta_korisnika` int(11) NOT NULL,
  `mob` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `email` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `lozinka` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `aktivacijski_link` varchar(100) COLLATE utf8_croatian_ci NOT NULL,
  `aktivan` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_stanar`,`id_zgrada`,`mob`,`email`,`aktivacijski_link`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `upit`
--

CREATE TABLE IF NOT EXISTS `upit` (
  `id_upit` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `id_stanar` int(11) unsigned NOT NULL,
  `datum` datetime NOT NULL,
  `naslov` varchar(40) COLLATE utf8_croatian_ci NOT NULL,
  `opis` text COLLATE utf8_croatian_ci NOT NULL,
  `dogovoreno` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_upit`,`id_stanar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `upravitelj`
--

CREATE TABLE IF NOT EXISTS `upravitelj` (
  `id_upravitelj` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ime_prezime` varchar(50) COLLATE utf8_croatian_ci NOT NULL,
  `email` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `lozinka` varchar(25) COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_upravitelj`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `zgrada`
--

CREATE TABLE IF NOT EXISTS `zgrada` (
  `id_zgrada` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `naziv` varchar(50) COLLATE utf8_croatian_ci NOT NULL,
  `ulica` varchar(40) COLLATE utf8_croatian_ci NOT NULL,
  `grad` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `broj stanara` int(11) unsigned NOT NULL,
  PRIMARY KEY (`id_zgrada`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;


/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
