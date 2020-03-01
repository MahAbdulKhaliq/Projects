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
-- Table structure for table `history`
--

CREATE TABLE `history` (
  `user` varchar(20) NOT NULL,
  `win` tinyint(1) NOT NULL,
  `attempts` int(11) NOT NULL,
  `word` varchar(20) NOT NULL,
  `dateFinished` date NOT NULL,
  `gameID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `history`
--

INSERT INTO `history` (`user`, `win`, `attempts`, `word`, `dateFinished`, `gameID`) VALUES
('test', 1, 7, 'salad', '2019-12-05', 92),
('test', 0, 0, 'cool', '2019-12-05', 93),
('test', 1, 4, 'test', '2019-12-05', 94),
('test', 1, 6, 'test', '2019-12-05', 95),
('test', 1, 6, 'sweep', '2019-12-05', 96),
('coolBeans', 1, 6, 'meatball', '2019-12-05', 98),
('coolBeans', 1, 2, 'salad', '2019-12-05', 99),
('basil', 1, 3, 'salad', '2019-12-05', 100),
('basil', 1, 8, 'mayonnaise', '2019-12-05', 101),
('basil', 0, 0, 'broom', '2019-12-05', 102),
('basil', 1, 8, 'cool', '2019-12-05', 103),
('basil', 1, 8, 'mayonnaise', '2019-12-05', 104),
('basil', 1, 4, 'salad', '2019-12-05', 105),
('basil', 1, 3, 'mouse', '2019-12-05', 106),
('test2', 1, 8, 'sweep', '2019-12-05', 109),
('test2', 1, 6, 'spice', '2019-12-05', 110),
('test2', 1, 4, 'meatball', '2019-12-05', 112),
('test2', 1, 5, 'test', '2019-12-05', 113),
('test2', 1, 8, 'test', '2019-12-05', 114),
('test2', 1, 7, 'spice', '2019-12-05', 115),
('test', 1, 7, 'spice', '2019-12-05', 119),
('test', 1, 8, 'test', '2019-12-05', 126),
('test', 1, 8, 'cool', '2019-12-06', 127),
('cheekibreeki', 1, 7, 'meatball', '2019-12-06', 128),
('cheekibreeki', 1, 8, 'meatball', '2019-12-06', 135),
('cheekibreeki', 1, 7, 'test', '2019-12-06', 147),
('cheekibreeki', 1, 7, 'test', '2019-12-06', 148),
('cheekibreeki', 1, 8, 'mayonnaise', '2019-12-06', 162),
('test', 1, 4, 'basil', '2019-12-07', 164);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `history`
--
ALTER TABLE `history`
  ADD PRIMARY KEY (`gameID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
