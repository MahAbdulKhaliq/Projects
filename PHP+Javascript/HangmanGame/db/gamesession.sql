-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 07, 2019 at 03:39 AM
-- Server version: 10.1.34-MariaDB
-- PHP Version: 7.2.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `000788833`
--

-- --------------------------------------------------------

--
-- Table structure for table `gamesession`
--

CREATE TABLE `gamesession` (
  `user` varchar(20) NOT NULL,
  `inProgress` tinyint(1) NOT NULL DEFAULT '1',
  `word` varchar(20) NOT NULL,
  `attempts` int(11) NOT NULL DEFAULT '8',
  `guessedLetters` varchar(26) NOT NULL DEFAULT '',
  `gameID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `gamesession`
--

INSERT INTO `gamesession` (`user`, `inProgress`, `word`, `attempts`, `guessedLetters`, `gameID`) VALUES
('basil', 1, 'spice', 8, '', 107),
('test2', 1, 'spice', 8, '', 116),
('cheekibreeki', 1, 'cool', 6, 'se', 163);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `gamesession`
--
ALTER TABLE `gamesession`
  ADD PRIMARY KEY (`gameID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `gamesession`
--
ALTER TABLE `gamesession`
  MODIFY `gameID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=165;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
