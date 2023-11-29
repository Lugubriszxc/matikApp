-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 29, 2023 at 09:02 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 7.4.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `matikdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `acadyear`
--

CREATE TABLE `acadyear` (
  `acadYearID` int(11) NOT NULL,
  `acadYearName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `acadyear`
--

INSERT INTO `acadyear` (`acadYearID`, `acadYearName`) VALUES
(1, '2023-2024');

-- --------------------------------------------------------

--
-- Table structure for table `assignsubject`
--

CREATE TABLE `assignsubject` (
  `a_id` int(11) NOT NULL,
  `subjectID` int(11) NOT NULL,
  `semester` varchar(250) NOT NULL,
  `departmentID` int(11) NOT NULL,
  `courseID` int(11) NOT NULL,
  `yearLevel` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `assignsubject`
--

INSERT INTO `assignsubject` (`a_id`, `subjectID`, `semester`, `departmentID`, `courseID`, `yearLevel`) VALUES
(30, 9, '1st Semester', 20, 39, '1st Year'),
(31, 10, '1st Semester', 20, 39, '1st Year'),
(32, 11, '1st Semester', 20, 39, '1st Year'),
(33, 12, '1st Semester', 20, 39, '1st Year'),
(34, 13, '1st Semester', 20, 39, '1st Year'),
(35, 14, '1st Semester', 20, 39, '1st Year'),
(36, 15, '1st Semester', 20, 39, '1st Year'),
(37, 44, '1st Semester', 20, 39, '1st Year'),
(38, 17, '1st Semester', 20, 39, '1st Year'),
(40, 19, '1st Semester', 20, 39, '2nd Year'),
(41, 20, '1st Semester', 20, 39, '2nd Year'),
(42, 21, '1st Semester', 20, 39, '2nd Year'),
(43, 22, '1st Semester', 20, 39, '2nd Year'),
(44, 24, '1st Semester', 20, 39, '2nd Year'),
(45, 25, '1st Semester', 20, 39, '2nd Year'),
(46, 26, '1st Semester', 20, 39, '2nd Year'),
(47, 27, '1st Semester', 20, 39, '3rd Year'),
(48, 28, '1st Semester', 20, 39, '3rd Year'),
(49, 29, '1st Semester', 20, 39, '3rd Year'),
(50, 30, '1st Semester', 20, 39, '3rd Year'),
(51, 31, '1st Semester', 20, 39, '3rd Year'),
(52, 32, '1st Semester', 20, 39, '3rd Year'),
(53, 33, '1st Semester', 20, 39, '3rd Year'),
(54, 34, '1st Semester', 20, 39, '4th Year'),
(55, 35, '1st Semester', 20, 39, '4th Year'),
(56, 36, '1st Semester', 20, 39, '4th Year'),
(57, 37, '1st Semester', 20, 39, '4th Year'),
(58, 38, '1st Semester', 20, 39, '4th Year'),
(59, 39, '1st Semester', 20, 39, '4th Year'),
(60, 40, '1st Semester', 21, 40, '1st Year'),
(61, 41, '1st Semester', 21, 40, '1st Year'),
(62, 42, '1st Semester', 21, 40, '1st Year'),
(63, 24, '1st Semester', 21, 40, '1st Year'),
(64, 43, '1st Semester', 21, 40, '1st Year'),
(66, 44, '1st Semester', 21, 40, '1st Year'),
(67, 17, '1st Semester', 21, 40, '1st Year'),
(68, 45, '1st Semester', 21, 40, '2nd Year'),
(69, 46, '1st Semester', 21, 40, '2nd Year'),
(70, 47, '1st Semester', 21, 40, '2nd Year'),
(71, 48, '1st Semester', 21, 40, '2nd Year'),
(72, 49, '1st Semester', 21, 40, '2nd Year'),
(73, 33, '1st Semester', 21, 40, '2nd Year'),
(74, 50, '1st Semester', 21, 40, '2nd Year'),
(75, 51, '1st Semester', 21, 40, '3rd Year'),
(76, 52, '1st Semester', 21, 40, '3rd Year'),
(77, 53, '1st Semester', 21, 40, '3rd Year'),
(78, 21, '1st Semester', 21, 40, '3rd Year'),
(79, 54, '1st Semester', 21, 40, '3rd Year'),
(80, 55, '1st Semester', 21, 40, '4th Year'),
(81, 56, '1st Semester', 21, 40, '4th Year'),
(82, 13, '1st Semester', 21, 40, '4th Year'),
(83, 57, '1st Semester', 21, 40, '4th Year'),
(84, 38, '1st Semester', 21, 40, '4th Year'),
(85, 58, '1st Semester', 21, 40, '4th Year'),
(86, 197, '1st Semester', 18, 31, '1st Year'),
(87, 198, '1st Semester', 18, 31, '1st Year'),
(88, 11, '1st Semester', 18, 31, '1st Year'),
(89, 48, '1st Semester', 18, 31, '1st Year'),
(90, 12, '1st Semester', 18, 31, '1st Year'),
(91, 64, '1st Semester', 18, 31, '1st Year'),
(92, 33, '1st Semester', 18, 31, '1st Year'),
(93, 199, '1st Semester', 18, 31, '1st Year'),
(94, 17, '1st Semester', 18, 31, '1st Year'),
(95, 200, '1st Semester', 18, 31, '2nd Year'),
(96, 201, '1st Semester', 18, 31, '2nd Year'),
(97, 202, '1st Semester', 18, 31, '2nd Year'),
(98, 203, '1st Semester', 18, 31, '2nd Year'),
(99, 204, '1st Semester', 18, 31, '2nd Year'),
(100, 205, '1st Semester', 18, 31, '2nd Year'),
(101, 206, '1st Semester', 18, 31, '2nd Year'),
(102, 21, '1st Semester', 18, 31, '2nd Year'),
(103, 207, '1st Semester', 18, 31, '2nd Year'),
(104, 208, '1st Semester', 18, 31, '3rd Year'),
(105, 209, '1st Semester', 18, 31, '3rd Year'),
(106, 210, '1st Semester', 18, 31, '3rd Year'),
(107, 211, '1st Semester', 18, 31, '3rd Year'),
(108, 212, '1st Semester', 18, 31, '3rd Year'),
(109, 213, '1st Semester', 18, 31, '3rd Year'),
(110, 214, '1st Semester', 18, 31, '3rd Year'),
(111, 49, '1st Semester', 18, 31, '3rd Year'),
(112, 25, '1st Semester', 18, 31, '3rd Year'),
(113, 215, '1st Semester', 18, 31, '4th Year'),
(114, 216, '1st Semester', 18, 31, '4th Year'),
(115, 217, '1st Semester', 18, 31, '4th Year'),
(116, 218, '1st Semester', 18, 31, '4th Year'),
(117, 219, '1st Semester', 18, 31, '4th Year'),
(118, 41, '1st Semester', 19, 32, '1st Year'),
(119, 42, '1st Semester', 19, 32, '1st Year'),
(120, 24, '1st Semester', 19, 32, '1st Year'),
(121, 128, '1st Semester', 19, 32, '1st Year'),
(122, 129, '1st Semester', 19, 32, '1st Year'),
(123, 130, '1st Semester', 19, 32, '1st Year'),
(124, 131, '1st Semester', 19, 32, '1st Year'),
(125, 44, '1st Semester', 19, 32, '1st Year'),
(126, 17, '1st Semester', 19, 32, '1st Year'),
(127, 15, '1st Semester', 19, 32, '1st Year'),
(128, 48, '1st Semester', 19, 32, '2nd Year'),
(129, 33, '1st Semester', 19, 32, '2nd Year'),
(130, 132, '1st Semester', 19, 32, '2nd Year'),
(131, 133, '1st Semester', 19, 32, '2nd Year'),
(132, 134, '1st Semester', 19, 32, '2nd Year'),
(133, 135, '1st Semester', 19, 32, '2nd Year'),
(134, 136, '1st Semester', 19, 32, '2nd Year'),
(135, 26, '1st Semester', 19, 32, '2nd Year'),
(136, 49, '1st Semester', 19, 32, '3rd Year'),
(137, 25, '1st Semester', 19, 32, '3rd Year'),
(138, 137, '1st Semester', 19, 32, '3rd Year'),
(139, 138, '1st Semester', 19, 32, '3rd Year'),
(140, 139, '1st Semester', 19, 32, '3rd Year'),
(141, 141, '1st Semester', 19, 32, '3rd Year'),
(142, 142, '1st Semester', 19, 32, '3rd Year'),
(143, 140, '1st Semester', 19, 32, '3rd Year'),
(144, 12, '1st Semester', 19, 32, '4th Year'),
(145, 57, '1st Semester', 19, 32, '4th Year'),
(146, 39, '1st Semester', 19, 32, '4th Year'),
(147, 143, '1st Semester', 19, 32, '4th Year'),
(148, 144, '1st Semester', 19, 32, '4th Year'),
(149, 145, '1st Semester', 19, 32, '4th Year'),
(150, 146, '1st Semester', 19, 32, '4th Year'),
(151, 147, '1st Semester', 19, 32, '4th Year'),
(152, 41, '1st Semester', 19, 43, '1st Year'),
(153, 42, '1st Semester', 19, 43, '1st Year'),
(154, 24, '1st Semester', 19, 43, '1st Year'),
(155, 128, '1st Semester', 19, 43, '1st Year'),
(156, 129, '1st Semester', 19, 43, '1st Year'),
(157, 130, '1st Semester', 19, 43, '1st Year'),
(158, 131, '1st Semester', 19, 43, '1st Year'),
(159, 15, '1st Semester', 19, 43, '1st Year'),
(160, 44, '1st Semester', 19, 43, '1st Year'),
(161, 17, '1st Semester', 19, 43, '1st Year'),
(162, 48, '1st Semester', 19, 43, '2nd Year'),
(163, 25, '1st Semester', 19, 43, '2nd Year'),
(164, 132, '1st Semester', 19, 43, '2nd Year'),
(165, 133, '1st Semester', 19, 43, '2nd Year'),
(166, 134, '1st Semester', 19, 43, '2nd Year'),
(167, 135, '1st Semester', 19, 43, '2nd Year'),
(168, 136, '1st Semester', 19, 43, '2nd Year'),
(169, 26, '1st Semester', 19, 43, '2nd Year'),
(170, 12, '1st Semester', 19, 33, '3rd Year'),
(171, 64, '1st Semester', 19, 33, '3rd Year'),
(172, 49, '1st Semester', 19, 33, '3rd Year'),
(173, 148, '1st Semester', 19, 33, '3rd Year'),
(174, 137, '1st Semester', 19, 33, '3rd Year'),
(175, 149, '1st Semester', 19, 33, '3rd Year'),
(176, 138, '1st Semester', 19, 33, '3rd Year'),
(177, 150, '1st Semester', 19, 33, '3rd Year'),
(178, 151, '1st Semester', 19, 33, '4th Year'),
(179, 38, '1st Semester', 19, 33, '4th Year'),
(180, 39, '1st Semester', 19, 33, '4th Year'),
(181, 152, '1st Semester', 19, 33, '4th Year'),
(182, 153, '1st Semester', 19, 33, '4th Year'),
(184, 154, '1st Semester', 19, 33, '4th Year'),
(185, 41, '1st Semester', 19, 34, '1st Year'),
(186, 42, '1st Semester', 19, 34, '1st Year'),
(187, 24, '1st Semester', 19, 34, '1st Year'),
(188, 59, '1st Semester', 19, 34, '1st Year'),
(189, 156, '1st Semester', 19, 34, '1st Year'),
(190, 128, '1st Semester', 19, 34, '1st Year'),
(191, 15, '1st Semester', 19, 34, '1st Year'),
(192, 44, '1st Semester', 19, 34, '1st Year'),
(193, 17, '1st Semester', 19, 34, '1st Year'),
(194, 12, '1st Semester', 19, 34, '2nd Year'),
(195, 21, '1st Semester', 19, 34, '2nd Year'),
(196, 157, '1st Semester', 19, 34, '2nd Year'),
(197, 158, '1st Semester', 19, 34, '2nd Year'),
(198, 159, '1st Semester', 19, 34, '2nd Year'),
(199, 160, '1st Semester', 19, 34, '2nd Year'),
(200, 26, '1st Semester', 19, 34, '2nd Year'),
(201, 64, '1st Semester', 19, 34, '3rd Year'),
(202, 142, '1st Semester', 19, 34, '3rd Year'),
(203, 162, '1st Semester', 19, 34, '3rd Year'),
(204, 163, '1st Semester', 19, 34, '3rd Year'),
(205, 164, '1st Semester', 19, 34, '3rd Year'),
(206, 165, '1st Semester', 19, 34, '3rd Year'),
(207, 57, '1st Semester', 19, 34, '4th Year'),
(208, 39, '1st Semester', 19, 34, '4th Year'),
(209, 166, '1st Semester', 19, 34, '4th Year'),
(210, 167, '1st Semester', 19, 34, '4th Year'),
(211, 168, '1st Semester', 19, 34, '4th Year'),
(212, 169, '1st Semester', 19, 34, '4th Year'),
(213, 41, '1st Semester', 19, 36, '1st Year'),
(214, 42, '1st Semester', 19, 36, '1st Year'),
(215, 24, '1st Semester', 19, 36, '1st Year'),
(216, 170, '1st Semester', 19, 36, '1st Year'),
(217, 171, '1st Semester', 19, 36, '1st Year'),
(218, 15, '1st Semester', 19, 36, '1st Year'),
(219, 44, '1st Semester', 19, 36, '1st Year'),
(220, 17, '1st Semester', 19, 36, '1st Year'),
(221, 59, '1st Semester', 19, 36, '2nd Year'),
(222, 11, '1st Semester', 19, 36, '2nd Year'),
(223, 12, '1st Semester', 19, 36, '2nd Year'),
(224, 49, '1st Semester', 19, 36, '2nd Year'),
(225, 172, '1st Semester', 19, 36, '2nd Year'),
(226, 173, '1st Semester', 19, 36, '2nd Year'),
(227, 174, '1st Semester', 19, 36, '2nd Year'),
(228, 26, '1st Semester', 19, 36, '2nd Year'),
(229, 151, '1st Semester', 19, 36, '3rd Year'),
(230, 64, '1st Semester', 19, 36, '3rd Year'),
(231, 175, '1st Semester', 19, 36, '3rd Year'),
(232, 176, '1st Semester', 19, 36, '3rd Year'),
(233, 177, '1st Semester', 19, 36, '3rd Year'),
(234, 178, '1st Semester', 19, 36, '3rd Year'),
(235, 179, '1st Semester', 19, 36, '3rd Year'),
(236, 180, '1st Semester', 19, 36, '4th Year'),
(237, 181, '1st Semester', 19, 36, '4th Year'),
(238, 182, '1st Semester', 19, 36, '4th Year'),
(239, 183, '1st Semester', 19, 36, '4th Year'),
(240, 184, '1st Semester', 19, 36, '4th Year'),
(241, 185, '1st Semester', 19, 36, '4th Year'),
(242, 39, '1st Semester', 19, 36, '4th Year'),
(243, 41, '1st Semester', 19, 37, '1st Year'),
(244, 42, '1st Semester', 19, 37, '1st Year'),
(245, 24, '1st Semester', 19, 37, '1st Year'),
(246, 170, '1st Semester', 19, 37, '1st Year'),
(247, 171, '1st Semester', 19, 37, '1st Year'),
(248, 186, '1st Semester', 19, 37, '1st Year'),
(249, 15, '1st Semester', 19, 37, '1st Year'),
(250, 44, '1st Semester', 19, 37, '1st Year'),
(251, 17, '1st Semester', 19, 37, '1st Year'),
(252, 59, '1st Semester', 19, 37, '2nd Year'),
(253, 11, '1st Semester', 19, 37, '2nd Year'),
(254, 12, '1st Semester', 19, 37, '2nd Year'),
(255, 172, '1st Semester', 19, 37, '2nd Year'),
(256, 173, '1st Semester', 19, 37, '2nd Year'),
(257, 174, '1st Semester', 19, 37, '2nd Year'),
(258, 187, '1st Semester', 19, 37, '2nd Year'),
(259, 33, '1st Semester', 19, 37, '2nd Year'),
(260, 26, '1st Semester', 19, 37, '2nd Year'),
(261, 151, '1st Semester', 19, 37, '3rd Year'),
(262, 64, '1st Semester', 19, 37, '3rd Year'),
(263, 175, '1st Semester', 19, 37, '3rd Year'),
(264, 176, '1st Semester', 19, 37, '3rd Year'),
(265, 177, '1st Semester', 19, 37, '3rd Year'),
(266, 178, '1st Semester', 19, 37, '3rd Year'),
(267, 179, '1st Semester', 19, 37, '3rd Year'),
(268, 188, '1st Semester', 19, 37, '3rd Year'),
(269, 189, '1st Semester', 19, 37, '3rd Year'),
(270, 181, '1st Semester', 19, 37, '4th Year'),
(271, 182, '1st Semester', 19, 37, '4th Year'),
(272, 183, '1st Semester', 19, 37, '4th Year'),
(273, 184, '1st Semester', 19, 37, '4th Year'),
(274, 185, '1st Semester', 19, 37, '4th Year'),
(275, 190, '1st Semester', 19, 37, '4th Year'),
(276, 39, '1st Semester', 19, 37, '4th Year'),
(277, 41, '1st Semester', 19, 38, '1st Year'),
(278, 42, '1st Semester', 19, 38, '1st Year'),
(279, 24, '1st Semester', 19, 38, '1st Year'),
(280, 170, '1st Semester', 19, 38, '1st Year'),
(281, 171, '1st Semester', 19, 38, '1st Year'),
(282, 15, '1st Semester', 19, 38, '1st Year'),
(283, 44, '1st Semester', 19, 38, '1st Year'),
(284, 17, '1st Semester', 19, 38, '1st Year'),
(285, 59, '1st Semester', 19, 38, '2nd Year'),
(286, 11, '1st Semester', 19, 38, '2nd Year'),
(287, 12, '1st Semester', 19, 38, '2nd Year'),
(288, 172, '1st Semester', 19, 38, '2nd Year'),
(289, 191, '1st Semester', 19, 38, '2nd Year'),
(290, 174, '1st Semester', 19, 38, '2nd Year'),
(291, 13, '1st Semester', 19, 38, '2nd Year'),
(292, 26, '1st Semester', 19, 38, '2nd Year'),
(293, 151, '1st Semester', 19, 38, '3rd Year'),
(294, 64, '1st Semester', 19, 38, '3rd Year'),
(295, 180, '1st Semester', 19, 38, '3rd Year'),
(296, 192, '1st Semester', 19, 38, '3rd Year'),
(297, 193, '1st Semester', 19, 38, '3rd Year'),
(298, 175, '1st Semester', 19, 38, '3rd Year'),
(299, 176, '1st Semester', 19, 38, '3rd Year'),
(300, 179, '1st Semester', 19, 38, '3rd Year'),
(301, 182, '1st Semester', 19, 38, '4th Year'),
(302, 194, '1st Semester', 19, 38, '4th Year'),
(303, 195, '1st Semester', 19, 38, '4th Year'),
(304, 196, '1st Semester', 19, 38, '4th Year'),
(305, 39, '1st Semester', 19, 38, '4th Year'),
(306, 42, '1st Semester', 17, 26, '1st Year'),
(307, 59, '1st Semester', 17, 26, '1st Year'),
(308, 60, '1st Semester', 17, 26, '1st Year'),
(309, 61, '1st Semester', 17, 26, '1st Year'),
(310, 62, '1st Semester', 17, 26, '1st Year'),
(311, 63, '1st Semester', 17, 26, '1st Year'),
(312, 43, '1st Semester', 17, 26, '1st Year'),
(313, 44, '1st Semester', 17, 26, '1st Year'),
(314, 17, '1st Semester', 17, 26, '1st Year'),
(315, 64, '1st Semester', 17, 26, '2nd Year'),
(316, 13, '1st Semester', 17, 26, '2nd Year'),
(317, 65, '1st Semester', 17, 26, '2nd Year'),
(318, 66, '1st Semester', 17, 26, '2nd Year'),
(319, 67, '1st Semester', 17, 26, '2nd Year'),
(320, 68, '1st Semester', 17, 26, '2nd Year'),
(321, 69, '1st Semester', 17, 26, '2nd Year'),
(322, 70, '1st Semester', 17, 26, '2nd Year'),
(323, 50, '1st Semester', 17, 26, '2nd Year'),
(324, 57, '1st Semester', 17, 26, '3rd Year'),
(325, 49, '1st Semester', 17, 26, '3rd Year'),
(326, 72, '1st Semester', 17, 26, '3rd Year'),
(327, 73, '1st Semester', 17, 26, '3rd Year'),
(328, 74, '1st Semester', 17, 26, '3rd Year'),
(329, 75, '1st Semester', 17, 26, '3rd Year'),
(330, 76, '1st Semester', 17, 26, '3rd Year'),
(331, 77, '1st Semester', 17, 26, '3rd Year'),
(332, 78, '1st Semester', 17, 26, '4th Year'),
(333, 79, '1st Semester', 17, 26, '4th Year'),
(334, 42, '1st Semester', 17, 27, '1st Year'),
(335, 59, '1st Semester', 17, 27, '1st Year'),
(336, 80, '1st Semester', 17, 27, '1st Year'),
(337, 61, '1st Semester', 17, 27, '1st Year'),
(338, 81, '1st Semester', 17, 27, '1st Year'),
(339, 43, '1st Semester', 17, 27, '1st Year'),
(340, 44, '1st Semester', 17, 27, '1st Year'),
(341, 17, '1st Semester', 17, 27, '1st Year'),
(342, 24, '1st Semester', 17, 27, '2nd Year'),
(343, 13, '1st Semester', 17, 27, '2nd Year'),
(344, 65, '1st Semester', 17, 27, '2nd Year'),
(345, 66, '1st Semester', 17, 27, '2nd Year'),
(346, 82, '1st Semester', 17, 27, '2nd Year'),
(347, 83, '1st Semester', 17, 27, '2nd Year'),
(348, 84, '1st Semester', 17, 27, '2nd Year'),
(349, 85, '1st Semester', 17, 27, '2nd Year'),
(350, 50, '1st Semester', 17, 27, '2nd Year'),
(351, 57, '1st Semester', 17, 27, '3rd Year'),
(352, 49, '1st Semester', 17, 27, '3rd Year'),
(353, 72, '1st Semester', 17, 27, '3rd Year'),
(354, 86, '1st Semester', 17, 27, '3rd Year'),
(355, 74, '1st Semester', 17, 27, '3rd Year'),
(356, 87, '1st Semester', 17, 27, '3rd Year'),
(357, 88, '1st Semester', 17, 27, '3rd Year'),
(358, 89, '1st Semester', 17, 27, '3rd Year'),
(359, 78, '1st Semester', 17, 27, '4th Year'),
(360, 79, '1st Semester', 17, 27, '4th Year'),
(361, 42, '1st Semester', 17, 42, '1st Year'),
(362, 59, '1st Semester', 17, 42, '1st Year'),
(363, 90, '1st Semester', 17, 42, '1st Year'),
(364, 61, '1st Semester', 17, 42, '1st Year'),
(365, 91, '1st Semester', 17, 42, '1st Year'),
(366, 43, '1st Semester', 17, 42, '1st Year'),
(367, 44, '1st Semester', 17, 42, '1st Year'),
(368, 17, '1st Semester', 17, 42, '1st Year'),
(369, 24, '1st Semester', 17, 42, '2nd Year'),
(370, 13, '1st Semester', 17, 42, '2nd Year'),
(371, 65, '1st Semester', 17, 42, '2nd Year'),
(372, 66, '1st Semester', 17, 42, '2nd Year'),
(373, 92, '1st Semester', 17, 42, '2nd Year'),
(374, 93, '1st Semester', 17, 42, '2nd Year'),
(375, 94, '1st Semester', 17, 42, '2nd Year'),
(376, 95, '1st Semester', 17, 42, '2nd Year'),
(377, 50, '1st Semester', 17, 42, '2nd Year'),
(378, 57, '1st Semester', 17, 42, '3rd Year'),
(379, 49, '1st Semester', 17, 42, '3rd Year'),
(380, 72, '1st Semester', 17, 42, '3rd Year'),
(381, 86, '1st Semester', 17, 42, '3rd Year'),
(382, 74, '1st Semester', 17, 42, '3rd Year'),
(383, 96, '1st Semester', 17, 42, '3rd Year'),
(384, 97, '1st Semester', 17, 42, '3rd Year'),
(385, 98, '1st Semester', 17, 42, '3rd Year'),
(386, 78, '1st Semester', 17, 42, '4th Year'),
(387, 79, '1st Semester', 17, 42, '4th Year'),
(388, 42, '1st Semester', 17, 28, '1st Year'),
(389, 59, '1st Semester', 17, 28, '1st Year'),
(390, 61, '1st Semester', 17, 28, '1st Year'),
(391, 99, '1st Semester', 17, 28, '1st Year'),
(392, 100, '1st Semester', 17, 28, '1st Year'),
(393, 43, '1st Semester', 17, 28, '1st Year'),
(394, 44, '1st Semester', 17, 28, '1st Year'),
(395, 17, '1st Semester', 17, 28, '1st Year'),
(396, 24, '1st Semester', 17, 28, '2nd Year'),
(397, 13, '1st Semester', 17, 28, '2nd Year'),
(398, 65, '1st Semester', 17, 28, '2nd Year'),
(399, 66, '1st Semester', 17, 28, '2nd Year'),
(400, 101, '1st Semester', 17, 28, '2nd Year'),
(401, 102, '1st Semester', 17, 28, '2nd Year'),
(402, 103, '1st Semester', 17, 28, '2nd Year'),
(403, 104, '1st Semester', 17, 28, '2nd Year'),
(404, 50, '1st Semester', 17, 28, '2nd Year'),
(405, 57, '1st Semester', 17, 28, '3rd Year'),
(406, 49, '1st Semester', 17, 28, '3rd Year'),
(407, 72, '1st Semester', 17, 28, '3rd Year'),
(408, 86, '1st Semester', 17, 28, '3rd Year'),
(409, 74, '1st Semester', 17, 28, '3rd Year'),
(410, 105, '1st Semester', 17, 28, '3rd Year'),
(411, 106, '1st Semester', 17, 28, '3rd Year'),
(412, 107, '1st Semester', 17, 28, '3rd Year'),
(413, 108, '1st Semester', 17, 28, '3rd Year'),
(414, 78, '1st Semester', 17, 28, '4th Year'),
(415, 79, '1st Semester', 17, 28, '4th Year'),
(416, 42, '1st Semester', 17, 30, '1st Year'),
(417, 59, '1st Semester', 17, 30, '1st Year'),
(418, 109, '1st Semester', 17, 30, '1st Year'),
(419, 61, '1st Semester', 17, 30, '1st Year'),
(420, 110, '1st Semester', 17, 30, '1st Year'),
(421, 43, '1st Semester', 17, 30, '1st Year'),
(422, 44, '1st Semester', 17, 30, '1st Year'),
(423, 17, '1st Semester', 17, 30, '1st Year'),
(424, 24, '1st Semester', 17, 30, '2nd Year'),
(425, 13, '1st Semester', 17, 30, '2nd Year'),
(426, 65, '1st Semester', 17, 30, '2nd Year'),
(427, 66, '1st Semester', 17, 30, '2nd Year'),
(428, 111, '1st Semester', 17, 30, '2nd Year'),
(429, 112, '1st Semester', 17, 30, '2nd Year'),
(430, 113, '1st Semester', 17, 30, '2nd Year'),
(431, 114, '1st Semester', 17, 30, '2nd Year'),
(432, 50, '1st Semester', 17, 30, '2nd Year'),
(433, 57, '1st Semester', 17, 30, '3rd Year'),
(434, 49, '1st Semester', 17, 30, '3rd Year'),
(435, 72, '1st Semester', 17, 30, '3rd Year'),
(436, 86, '1st Semester', 17, 30, '3rd Year'),
(437, 74, '1st Semester', 17, 30, '3rd Year'),
(438, 115, '1st Semester', 17, 30, '3rd Year'),
(439, 116, '1st Semester', 17, 30, '3rd Year'),
(440, 117, '1st Semester', 17, 30, '3rd Year'),
(441, 78, '1st Semester', 17, 30, '4th Year'),
(442, 79, '1st Semester', 17, 30, '4th Year'),
(443, 42, '1st Semester', 17, 29, '1st Year'),
(444, 59, '1st Semester', 17, 29, '1st Year'),
(445, 61, '1st Semester', 17, 29, '1st Year'),
(446, 54, '1st Semester', 17, 29, '1st Year'),
(447, 118, '1st Semester', 17, 29, '1st Year'),
(448, 119, '1st Semester', 17, 29, '1st Year'),
(449, 43, '1st Semester', 17, 29, '1st Year'),
(450, 44, '1st Semester', 17, 29, '1st Year'),
(451, 17, '1st Semester', 17, 29, '1st Year'),
(452, 24, '1st Semester', 17, 29, '2nd Year'),
(453, 13, '1st Semester', 17, 29, '2nd Year'),
(454, 65, '1st Semester', 17, 29, '2nd Year'),
(455, 120, '1st Semester', 17, 29, '2nd Year'),
(456, 121, '1st Semester', 17, 29, '2nd Year'),
(457, 122, '1st Semester', 17, 29, '2nd Year'),
(458, 123, '1st Semester', 17, 29, '2nd Year'),
(459, 124, '1st Semester', 17, 29, '2nd Year'),
(460, 50, '1st Semester', 17, 29, '2nd Year'),
(461, 57, '1st Semester', 17, 29, '3rd Year'),
(462, 49, '1st Semester', 17, 29, '3rd Year'),
(463, 86, '1st Semester', 17, 29, '3rd Year'),
(464, 74, '1st Semester', 17, 29, '3rd Year'),
(465, 66, '1st Semester', 17, 29, '3rd Year'),
(466, 125, '1st Semester', 17, 29, '3rd Year'),
(467, 126, '1st Semester', 17, 29, '3rd Year'),
(468, 127, '1st Semester', 17, 29, '3rd Year'),
(469, 78, '1st Semester', 17, 29, '4th Year'),
(470, 79, '1st Semester', 17, 29, '4th Year');

-- --------------------------------------------------------

--
-- Table structure for table `authorization`
--

CREATE TABLE `authorization` (
  `userID` int(11) NOT NULL,
  `username` varchar(250) NOT NULL,
  `password` varchar(250) NOT NULL,
  `userType` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `building`
--

CREATE TABLE `building` (
  `buildingID` int(11) NOT NULL,
  `buildingName` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `building`
--

INSERT INTO `building` (`buildingID`, `buildingName`) VALUES
(6, 'Maxwell Building'),
(8, 'Main Building');

-- --------------------------------------------------------

--
-- Table structure for table `course`
--

CREATE TABLE `course` (
  `courseID` int(11) NOT NULL,
  `courseName` varchar(250) NOT NULL,
  `departmentID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `course`
--

INSERT INTO `course` (`courseID`, `courseName`, `departmentID`) VALUES
(26, 'Bachelor of Elementary Education', 17),
(27, 'Bachelor of Secondary Education major in English', 17),
(28, 'Bachelor of Secondary Education major in Mathematics', 17),
(29, 'Bachelor of Secondary Education major in Science', 17),
(30, 'Bachelor of Secondary Education major in Social Studies', 17),
(31, 'Bachelor of Science in Criminology', 18),
(32, 'Bachelor of Science in Accountancy', 19),
(33, 'Bachelor of Science in Accounting Technology', 19),
(34, 'Bachelor of Science in Business Administration Major in Financial Management', 19),
(36, 'Bachelor of Science in Hospitality Management', 19),
(37, 'Bachelor of Science in Hospitality Management Major in Food and Beverage', 19),
(38, 'Bachelor of Science in Tourism Management', 19),
(39, 'Bachelor of Science in Information Technology', 20),
(40, 'Bachelor of Science in Psychology', 21),
(42, 'Bachelor of Secondary Education major in Filipino', 17),
(43, 'Bachelor of Science in Management Accounting', 19);

-- --------------------------------------------------------

--
-- Table structure for table `dean`
--

CREATE TABLE `dean` (
  `deanID` int(11) NOT NULL,
  `dean_fname` varchar(250) NOT NULL,
  `dean_mname` varchar(250) DEFAULT NULL,
  `dean_lname` varchar(250) NOT NULL,
  `departmentID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `dean`
--

INSERT INTO `dean` (`deanID`, `dean_fname`, `dean_mname`, `dean_lname`, `departmentID`) VALUES
(16, 'Jonel', '', 'Gelig', 20);

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `departmentID` int(11) NOT NULL,
  `departmentName` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`departmentID`, `departmentName`) VALUES
(17, 'College of Teacher Education'),
(18, 'Criminal Justice Education'),
(19, 'College of Commerce'),
(20, 'College of Computer Studies'),
(21, 'Psychology Program');

-- --------------------------------------------------------

--
-- Table structure for table `instructor`
--

CREATE TABLE `instructor` (
  `instructorID` int(11) NOT NULL,
  `instructor_fname` varchar(250) NOT NULL,
  `instructor_mname` varchar(250) NOT NULL,
  `instructor_lname` varchar(250) NOT NULL,
  `departmentID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `instructor`
--

INSERT INTO `instructor` (`instructorID`, `instructor_fname`, `instructor_mname`, `instructor_lname`, `departmentID`) VALUES
(12, 'Marjorie', '', 'Reso', 20),
(13, 'Windel', '', 'Pelayo', 20),
(14, 'Leonard', '', 'Balabat', 20),
(16, 'Jonel', '', 'Gelig', 20),
(17, 'Jonna Mae', '', 'Lequin', 17),
(18, 'Leo', '', 'Ranile', 17),
(19, 'Wilma', '', 'Diano', 17),
(20, 'Lorena', '', 'Mandal', 17),
(21, 'Louis de Vincent', '', 'Unabia', 17),
(22, 'Martha', '', 'Ylanan', 17),
(23, 'NROTC', '', 'Unit', 18),
(24, 'Hilarion', '', 'Raganas', 20),
(25, 'Janine', '', 'Recopelacion', 17),
(26, 'Carl Joshua', '', 'Cosep', 20),
(27, 'Ivy', '', 'Colina', 17),
(28, 'Christian', '', 'Lahoylahoy', 17),
(29, 'Kristine Jho-ir', '', 'Lequin', 17),
(30, 'Rengie', '', 'Gomez', 17),
(31, 'Angeli', '', 'Tillor', 17),
(32, 'Joel', '', 'Lim', 20),
(33, 'Renita', '', 'Aragon', 17),
(34, 'Jennifer', '', 'Cinco', 20),
(35, 'Jovan', '', 'Canama', 17),
(36, 'Violy Jane', '', 'Tan', 21),
(37, 'Erma', '', 'Monterola', 20),
(38, 'Melry Joy ', '', 'Cabahug', 17),
(39, 'Ethel Grace', '', 'Abendan', 17),
(40, 'Hamjay', '', 'Diano', 17),
(41, 'Patcris', '', 'Moncada', 17),
(42, 'Metchi', '', 'Ochea', 17),
(43, 'Fatima', '', 'Alicos', 17),
(44, 'Quennie', '', 'Ybanez', 17),
(45, 'Meshel', '', 'Gamao', 17),
(46, 'Manolo', '', 'Hilo', 17),
(47, 'Ma. Claudine', '', 'Inot', 17),
(48, 'Kimberly', '', 'Lepiten', 17),
(49, 'James', '', 'Samillano', 17),
(50, 'Lorenzo', '', 'Ruiz', 17),
(51, 'Riza Mariz', '', 'Ornopia', 17),
(52, 'Janel', '', 'Artiaga', 17),
(53, 'Mary Joy', '', 'Nogas', 17),
(55, 'Jane', '', 'Mandawe', 17),
(56, 'Nino', '', 'Matillano', 17),
(57, 'Sunshine', '', 'Tuico', 17),
(58, 'Minnie', '', 'Quinatadcan', 17),
(59, 'Daryl', '', 'Barrientos', 17),
(60, 'Maria Cristina', '', 'Faciol', 19),
(61, 'Kristin Jazz', '', 'Telen', 17),
(62, 'Ariel', '', 'Tinapay', 17),
(63, 'Christina', '', 'Lepiten', 17),
(64, 'Reglyn', '', 'Ylanan', 17),
(65, 'Sheila', '', 'Tirol', 17),
(66, 'Jay Ann Mae', '', 'Geonzon', 21),
(67, 'Marisse', '', 'Urot', 19),
(68, 'Raymund', '', 'Cometa', 19),
(69, 'Charlene', '', 'Aton', 19),
(71, 'Danilo', '', 'Velasco', 17),
(72, 'Ronell', '', 'Pacumio', 17),
(73, 'Shane', '', 'Conson', 19),
(74, 'Steven', '', 'Alburo', 19),
(75, 'Edgar', '', 'Decena', 19),
(76, 'Anthony', '', 'Baluyot', 19),
(77, 'Honey Mae', '', 'Casas', 19),
(78, 'Cherry', '', 'Nadela', 19),
(79, 'Jess Ian', '', 'Olivar', 19),
(80, 'Kerr', '', 'Pevida', 19),
(81, 'Daisy Joan', '', 'Pantuan', 19),
(82, 'Jessa', '', 'Pianar', 19),
(83, 'Johanna', '', 'Abao', 19),
(84, 'Judichelle', '', 'Mollejon', 19),
(85, 'Vince', '', 'Pelaez', 21),
(86, 'Joel', '', 'Ancot', 19),
(87, 'Renato', '', 'Ngoho', 17),
(88, 'Kelvin', '', 'Estrera', 19),
(89, 'Rowell', '', 'Nadela', 19),
(90, 'Nelson', '', 'Navares', 19),
(91, 'Irish', '', 'Terol', 19),
(92, 'Princess Mae', '', 'Bagon', 19),
(93, 'Abenaza', '', 'Carenh', 19),
(94, 'Edgardo', '', 'Parilla Jr.', 19),
(95, 'Art John', '', 'Rosaroso', 19),
(96, 'Glenn', '', 'Ostia', 19),
(97, 'Cherish Aiza', '', 'Crisostomo', 19),
(98, 'Emel', '', 'Abenaza', 19),
(99, 'Wilfredo', '', 'Pedroza', 19),
(100, 'Miraflor', '', 'Enclonar', 21),
(101, 'Divine Grace', '', 'Sunggayan', 18),
(102, 'Rosalyn', '', 'Gallo', 18),
(103, 'Henry', '', 'Lepon', 18),
(104, 'Anavinaflor', '', 'Ursal', 18),
(105, 'Richelle', '', 'Moninio', 18),
(106, 'Lileth', '', 'Lepiten', 17),
(107, 'Jay', '', 'Dadula', 18),
(108, 'Shynee', '', 'Adolfo', 18),
(109, 'Jessa', '', 'Arnado', 18),
(110, 'Karen Mae', '', 'Monato', 18),
(111, 'Gabriel', '', 'Masong', 18),
(112, 'Renato', '', 'Mandawe', 18),
(113, 'Morena', '', 'Tan', 17),
(114, 'Marfe', '', 'Andrino', 18),
(115, 'Samuel', '', 'Ocao', 18),
(116, 'Edlyn Felice', '', 'Cuyos', 18),
(117, 'Dayan Rhose', '', 'Pino', 18),
(118, 'Socrates Jr.', '', 'Bacalso', 18),
(119, 'Vincent', '', 'Navarro', 18),
(120, 'Nova', '', 'Frias', 18),
(121, 'Jayson', '', 'Sopsop', 18),
(122, 'Rhett Vincent', '', 'Minguez', 18),
(123, 'Ronnie', '', 'Ranile', 18),
(124, 'Judd Marx', '', 'Colina', 18),
(125, 'Maria Kristina', '', 'Aratia', 18),
(126, 'Jonel', '', 'Retuya', 18),
(127, 'Darryl', '', 'Barrientos', 17),
(128, 'Romeo', '', 'Torrizo', 18),
(129, 'Francis', '', 'Olila', 21),
(130, 'Mary Mabelle', '', 'Espanillo', 21),
(131, 'Janice', '', 'Mandal', 21),
(132, 'Harold', '', 'Cabatingan', 21);

-- --------------------------------------------------------

--
-- Table structure for table `regissection`
--

CREATE TABLE `regissection` (
  `regisSectionID` int(11) NOT NULL,
  `sectionID` int(11) NOT NULL,
  `acadYearID` int(11) NOT NULL,
  `semester` varchar(255) NOT NULL,
  `totalStudents` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `regissection`
--

INSERT INTO `regissection` (`regisSectionID`, `sectionID`, `acadYearID`, `semester`, `totalStudents`) VALUES
(11, 10, 1, '1st Semester', 30),
(12, 12, 1, '1st Semester', 30),
(13, 13, 1, '1st Semester', 30),
(14, 14, 1, '1st Semester', 30),
(15, 15, 1, '1st Semester', 30),
(16, 16, 1, '1st Semester', 30),
(17, 17, 1, '1st Semester', 30),
(18, 18, 1, '1st Semester', 40),
(19, 19, 1, '1st Semester', 40),
(20, 20, 1, '1st Semester', 40),
(21, 21, 1, '1st Semester', 40),
(22, 22, 1, '1st Semester', 40),
(23, 23, 1, '1st Semester', 40),
(24, 24, 1, '1st Semester', 40),
(25, 25, 1, '1st Semester', 40),
(26, 26, 1, '1st Semester', 40),
(27, 27, 1, '1st Semester', 40),
(28, 28, 1, '1st Semester', 40),
(29, 29, 1, '1st Semester', 40),
(30, 30, 1, '1st Semester', 40),
(31, 31, 1, '1st Semester', 40),
(32, 32, 1, '1st Semester', 40),
(33, 33, 1, '1st Semester', 40),
(34, 34, 1, '1st Semester', 40),
(35, 35, 1, '1st Semester', 40),
(36, 36, 1, '1st Semester', 40),
(37, 37, 1, '1st Semester', 40),
(38, 38, 1, '1st Semester', 40),
(39, 39, 1, '1st Semester', 40),
(40, 40, 1, '1st Semester', 40),
(41, 41, 1, '1st Semester', 40),
(42, 42, 1, '1st Semester', 40),
(43, 43, 1, '1st Semester', 40),
(44, 44, 1, '1st Semester', 40),
(45, 45, 1, '1st Semester', 40),
(46, 46, 1, '1st Semester', 40),
(47, 47, 1, '1st Semester', 40),
(48, 48, 1, '1st Semester', 40),
(49, 49, 1, '1st Semester', 40),
(50, 50, 1, '1st Semester', 40),
(51, 51, 1, '1st Semester', 40),
(52, 52, 1, '1st Semester', 40),
(53, 53, 1, '1st Semester', 40),
(54, 54, 1, '1st Semester', 40),
(55, 55, 1, '1st Semester', 40),
(56, 56, 1, '1st Semester', 40),
(57, 57, 1, '1st Semester', 40),
(58, 58, 1, '1st Semester', 40),
(59, 59, 1, '1st Semester', 40),
(60, 60, 1, '1st Semester', 40),
(61, 61, 1, '1st Semester', 40),
(62, 62, 1, '1st Semester', 40),
(63, 63, 1, '1st Semester', 40),
(64, 64, 1, '1st Semester', 40),
(65, 65, 1, '1st Semester', 40),
(66, 66, 1, '1st Semester', 40),
(67, 67, 1, '1st Semester', 40),
(68, 68, 1, '1st Semester', 40),
(69, 69, 1, '1st Semester', 40),
(70, 70, 1, '1st Semester', 40),
(71, 71, 1, '1st Semester', 40),
(72, 72, 1, '1st Semester', 40),
(73, 73, 1, '1st Semester', 40),
(74, 74, 1, '1st Semester', 40),
(75, 75, 1, '1st Semester', 40),
(76, 76, 1, '1st Semester', 40),
(77, 77, 1, '1st Semester', 40),
(78, 79, 1, '1st Semester', 40),
(79, 78, 1, '1st Semester', 40),
(80, 80, 1, '1st Semester', 40),
(81, 81, 1, '1st Semester', 40),
(82, 82, 1, '1st Semester', 40),
(83, 83, 1, '1st Semester', 40),
(84, 84, 1, '1st Semester', 40),
(85, 85, 1, '1st Semester', 40),
(86, 86, 1, '1st Semester', 40),
(87, 87, 1, '1st Semester', 40),
(88, 88, 1, '1st Semester', 40),
(89, 89, 1, '1st Semester', 40),
(90, 90, 1, '1st Semester', 40),
(91, 91, 1, '1st Semester', 40),
(92, 92, 1, '1st Semester', 40),
(93, 93, 1, '1st Semester', 40),
(94, 94, 1, '1st Semester', 40),
(95, 95, 1, '1st Semester', 40),
(96, 96, 1, '1st Semester', 40),
(97, 97, 1, '1st Semester', 40),
(98, 98, 1, '1st Semester', 40),
(99, 99, 1, '1st Semester', 40),
(100, 100, 1, '1st Semester', 40),
(101, 101, 1, '1st Semester', 40),
(102, 102, 1, '1st Semester', 40),
(103, 103, 1, '1st Semester', 40),
(104, 104, 1, '1st Semester', 40),
(105, 105, 1, '1st Semester', 40),
(106, 106, 1, '1st Semester', 40),
(107, 107, 1, '1st Semester', 40),
(108, 108, 1, '1st Semester', 40),
(109, 109, 1, '1st Semester', 40);

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `roomID` int(11) NOT NULL,
  `roomName` varchar(250) NOT NULL,
  `roomType` varchar(255) NOT NULL,
  `roomCapacity` int(11) NOT NULL,
  `buildingID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`roomID`, `roomName`, `roomType`, `roomCapacity`, `buildingID`) VALUES
(12, 'CL 1', 'Computer Laboratory', 60, 8),
(13, 'CL 2', 'Computer Laboratory', 60, 8),
(14, 'CL 3', 'Computer Laboratory', 60, 8),
(15, 'CL 4', 'Computer Laboratory', 60, 8),
(16, '316', 'Lecture Room', 60, 8),
(17, '429', 'Lecture Room', 60, 8),
(18, 'M-301', 'Lecture Room', 60, 6),
(19, '431', 'Lecture Room', 60, 8),
(20, 'M-402', 'Lecture Room', 60, 6),
(21, 'M-403', 'Lecture Room', 60, 6),
(22, 'Quadrangle', 'Practical', 60, 8),
(23, '318', 'Lecture Room', 60, 8),
(24, '206', 'Lecture Room', 60, 8),
(25, 'Sci. Lab (main)', 'Science Laboratory', 60, 8),
(26, '204', 'Lecture Room', 60, 8),
(27, 'M-401', 'Lecture Room', 60, 8),
(28, '208', 'Lecture Room', 60, 8),
(29, '315', 'Lecture Room', 60, 8),
(30, '424', 'Lecture Room', 60, 8),
(31, '425', 'Lecture Room', 60, 8),
(32, '319', 'Lecture Room', 60, 8),
(33, '313', 'Lecture Room', 60, 8),
(34, '209', 'Lecture Room', 60, 8),
(35, '428', 'Lecture Room', 60, 8),
(36, '205', 'Lecture Room', 60, 8),
(37, '207', 'Lecture Room', 60, 8),
(38, '312', 'Lecture Room', 60, 8),
(39, 'M-GF', 'Lecture Room', 60, 6),
(40, 'M-302', 'Lecture Room', 60, 6),
(41, '314', 'Lecture Room', 60, 8),
(42, '317', 'Lecture Room', 60, 8),
(43, 'Speech Lab', 'Speech Laboratory', 60, 8),
(44, 'Psych Lab', 'Psychology Laboratory', 60, 8),
(45, '422', 'Lecture Room', 60, 8),
(46, '423', 'Lecture Room', 60, 8),
(47, '0', 'Lecture Room', 60, 8),
(48, 'Sci.L(maxwell)', 'Science Laboratory', 60, 6),
(49, '203', 'Lecture Room', 60, 8),
(50, 'Rooftop', 'Lecture Room', 60, 8),
(51, 'Food Lab(main)', 'Food Laboratory', 60, 8),
(52, '430', 'Lecture Room', 60, 8),
(53, 'TM LAB', 'Food Laboratory', 60, 8),
(54, 'CB-2F', 'Lecture Room', 60, 8),
(55, 'FL (MAXWELL)', 'Food Laboratory', 60, 6),
(56, '427', 'Lecture Room', 60, 8),
(57, '533', 'Lecture Room', 60, 8),
(58, '534', 'Lecture Room', 60, 8),
(59, '426', 'Lecture Room', 60, 8),
(60, 'Pandan', 'Practical', 60, 8),
(61, '535', 'Lecture Room', 60, 8),
(62, '537', 'Lecture Room', 60, 8),
(63, '536', 'Lecture Room', 60, 8);

-- --------------------------------------------------------

--
-- Table structure for table `section`
--

CREATE TABLE `section` (
  `sectionID` int(11) NOT NULL,
  `sectionName` varchar(250) NOT NULL,
  `yearLevel` varchar(250) NOT NULL,
  `departmentID` int(11) NOT NULL,
  `courseID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `section`
--

INSERT INTO `section` (`sectionID`, `sectionName`, `yearLevel`, `departmentID`, `courseID`) VALUES
(10, 'BSIT-1A', '1st Year', 20, 39),
(12, 'BSIT-1B', '1st Year', 20, 39),
(13, 'BSIT-1C', '1st Year', 20, 39),
(14, 'BSIT-1D', '1st Year', 20, 39),
(15, 'BSIT-2A', '2nd Year', 20, 39),
(16, 'BSIT-2B', '2nd Year', 20, 39),
(17, 'BSIT-2C', '2nd Year', 20, 39),
(18, 'BSIT-3A', '3rd Year', 20, 39),
(19, 'BSIT-3B', '3rd Year', 20, 39),
(20, 'BSIT-4A', '4th Year', 20, 39),
(21, 'BSIT-4B', '4th Year', 20, 39),
(22, 'BEED-1A', '1st Year', 17, 26),
(23, 'BEED-2A', '2nd Year', 17, 26),
(24, 'BEED-3A', '3rd Year', 17, 26),
(25, 'BEED-3B', '3rd Year', 17, 26),
(26, 'BEED-4A', '4th Year', 17, 26),
(27, 'BSEdEnglish-1A', '1st Year', 17, 27),
(28, 'BSEdEnglish-2A', '2nd Year', 17, 27),
(29, 'BSEdEnglish-3A', '3rd Year', 17, 27),
(30, 'BSEdEnglish-4A', '4th Year', 17, 27),
(31, 'BSEdFilipino-1A', '1st Year', 17, 42),
(32, 'BSEdFilipino-2A', '2nd Year', 17, 42),
(33, 'BSEdFilipino-3A', '3rd Year', 17, 42),
(34, 'BSEdFilipino-4A', '4th Year', 17, 42),
(35, 'BSEdMathematics-1A', '1st Year', 17, 28),
(36, 'BSEdMathematics-2A', '2nd Year', 17, 28),
(37, 'BSEdMathematics-3A', '3rd Year', 17, 28),
(38, 'BSEdMathematics-4A', '4th Year', 17, 28),
(39, 'BSEdSStudies-1A', '1st Year', 17, 30),
(40, 'BSEdSStudies-2A', '2nd Year', 17, 30),
(41, 'BSEdSStudies-3A', '3rd Year', 17, 30),
(42, 'BSEdSStudies-4A', '4th Year', 17, 30),
(43, 'BSEdScience-1A', '1st Year', 17, 29),
(44, 'BSEdScience-2A', '2nd Year', 17, 29),
(45, 'BSEdScience-3A', '3rd Year', 17, 29),
(46, 'BSEdScience-4A', '4th Year', 17, 29),
(47, 'BSA-1A', '1st Year', 19, 32),
(48, 'BSA-2A', '2nd Year', 19, 32),
(49, 'BSA-3A', '3rd Year', 19, 32),
(50, 'BSA-4A', '4th Year', 19, 32),
(51, 'BSMA-1A', '1st Year', 19, 43),
(52, 'BSMA-2A', '2nd Year', 19, 43),
(53, 'BSAT-3A', '3rd Year', 19, 33),
(54, 'BSAT-4A', '4th Year', 19, 33),
(55, 'BSA-1B', '1st Year', 19, 32),
(56, 'BSBAFManagement-1A', '1st Year', 19, 34),
(57, 'BSBAFManagement-1B', '1st Year', 19, 34),
(58, 'BSBAFManagement-2A', '2nd Year', 19, 34),
(59, 'BSBAFManagement-2B', '2nd Year', 19, 34),
(60, 'BSBAFManagement-3A', '3rd Year', 19, 34),
(61, 'BSBAFManagement-3B', '3rd Year', 19, 34),
(62, 'BSBAFManagement-4A', '4th Year', 19, 34),
(63, 'BSHM-1A', '1st Year', 19, 36),
(64, 'BSHM-2A', '2nd Year', 19, 36),
(65, 'BSHM-3A', '3rd Year', 19, 36),
(66, 'BSHM-4A', '4th Year', 19, 36),
(67, 'BSHMFBeverage-1A', '1st Year', 19, 37),
(68, 'BSHMFBeverage-2A', '2nd Year', 19, 37),
(69, 'BSHMFBeverage-3A', '3rd Year', 19, 37),
(70, 'BSHMFBeverage-4A', '4th Year', 19, 37),
(71, 'BSTM-1A', '1st Year', 19, 38),
(72, 'BSTM-2A', '2nd Year', 19, 38),
(73, 'BSTM-3A', '3rd Year', 19, 38),
(74, 'BSTM-4A', '4th Year', 19, 38),
(75, 'BSCrim-1A', '1st Year', 18, 31),
(76, 'BSCrim-1B', '1st Year', 18, 31),
(77, 'BSCrim-1C', '1st Year', 18, 31),
(78, 'BSCrim-1D', '1st Year', 18, 31),
(79, 'BSCrim-1E', '1st Year', 18, 31),
(80, 'BSCrim-1F', '1st Year', 18, 31),
(81, 'BSCrim-1G', '1st Year', 18, 31),
(82, 'BSCrim-1H', '1st Year', 18, 31),
(83, 'BSCrim-2A', '2nd Year', 18, 31),
(84, 'BSCrim-2B', '2nd Year', 18, 31),
(85, 'BSCrim-2C', '2nd Year', 18, 31),
(86, 'BSCrim-2D', '2nd Year', 18, 31),
(87, 'BSCrim-2E', '2nd Year', 18, 31),
(88, 'BSCrim-2F', '2nd Year', 18, 31),
(89, 'BSCrim-2G', '2nd Year', 18, 31),
(90, 'BSCrim-2H', '2nd Year', 18, 31),
(91, 'BSCrim-2I', '2nd Year', 18, 31),
(92, 'BSCrim-2J', '2nd Year', 18, 31),
(93, 'BSCrim-3A', '3rd Year', 18, 31),
(94, 'BSCrim-3B', '3rd Year', 18, 31),
(95, 'BSCrim-3C', '3rd Year', 18, 31),
(96, 'BSCrim-3D', '3rd Year', 18, 31),
(97, 'BSCrim-3E', '3rd Year', 18, 31),
(98, 'BSCrim-3F', '3rd Year', 18, 31),
(99, 'BSCrim-3G', '3rd Year', 18, 31),
(100, 'BSCrim-3H', '3rd Year', 18, 31),
(101, 'BSCrim-4A', '4th Year', 18, 31),
(102, 'BSCrim-4B', '4th Year', 18, 31),
(103, 'BSCrim-4C', '4th Year', 18, 31),
(104, 'BSCrim-4D', '4th Year', 18, 31),
(105, 'BSPsych-1A', '1st Year', 21, 40),
(106, 'BSPsych-1B', '1st Year', 21, 40),
(107, 'BSPsych-2A', '2nd Year', 21, 40),
(108, 'BSPsych-3A', '3rd Year', 21, 40),
(109, 'BSPsych-4A', '4th Year', 21, 40);

-- --------------------------------------------------------

--
-- Table structure for table `subject`
--

CREATE TABLE `subject` (
  `subjectID` int(11) NOT NULL,
  `subjectCode` varchar(250) NOT NULL,
  `subjectName` varchar(250) NOT NULL,
  `roomType` varchar(250) NOT NULL,
  `subjectUnit` int(11) NOT NULL,
  `subjectMinutes` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `subject`
--

INSERT INTO `subject` (`subjectID`, `subjectCode`, `subjectName`, `roomType`, `subjectUnit`, `subjectMinutes`) VALUES
(9, 'CC 100', 'Introduction to Computing', 'Computer Laboratory', 5, 150),
(10, 'CC 101', 'Computer Programming 1', 'Computer Laboratory', 5, 150),
(11, 'GE 5', 'Purposive Communication', 'Lecture Room', 3, 90),
(12, 'GE 7', 'Science, Technology and Society', 'Lecture Room', 3, 90),
(13, 'IS 2', 'Advanced Grammar and Composition', 'Lecture Room', 3, 90),
(14, 'BC 1', 'Mathematical Translation and Transformation', 'Lecture Room', 3, 90),
(15, 'PE 1', 'Movement Enhancement', 'Lecture Room', 2, 60),
(17, 'NSTP 1', 'Reserve Officers\' Training Corps 1 (ROTC)', 'Practical', 3, 150),
(19, 'CC 104A', 'Information Management 1', 'Computer Laboratory', 5, 150),
(20, 'DIGITAL 1', 'Digital Logic Design', 'Computer Laboratory', 5, 150),
(21, 'GE 9', 'The Life and Works of Rizal', 'Lecture Room', 3, 90),
(22, 'GE 11', 'Ang Panitikan ng Pilipinas', 'Lecture Room', 3, 90),
(24, 'GE 3', 'The Contemporary World', 'Lecture Room', 3, 90),
(25, 'IS 1', 'Dimensional Analysis', 'Lecture Room', 3, 90),
(26, 'PE 3', 'Physical Activities towards Health and Fitness (PATH-Fit 1) Dance, Sports, Outdoor and Adventure', 'Lecture Room', 2, 60),
(27, 'QM 1', 'Quantitative Methods', 'Lecture Room', 3, 90),
(28, 'IT ELEC 1', 'IT Elective 1', 'Computer Laboratory', 5, 150),
(29, 'CC 105', 'Applications Development & Emerging Technologies', 'Computer Laboratory', 5, 150),
(30, 'SAD 1', 'Systems Analysis and Design', 'Computer Laboratory', 5, 150),
(31, 'OS 1', 'Operating Systems', 'Computer Laboratory', 3, 90),
(32, 'CC104B', 'Information Management 2', 'Computer Laboratory', 5, 150),
(33, 'IS 3', 'Gender and Development', 'Lecture Room', 3, 90),
(34, 'SA 1', 'Systems Administration and Maintenance', 'Computer Laboratory', 5, 150),
(35, 'CAPSTONE 2', 'Capstone Project 2', 'Computer Laboratory', 3, 90),
(36, 'IT REVIEW 1', 'Certification Examination Review', 'Computer Laboratory', 3, 90),
(37, 'IT ELEC 4', 'IT Elective 4', 'Computer Laboratory', 5, 150),
(38, 'GE 14', 'World Literature', 'Lecture Room', 3, 90),
(39, 'IS 4', 'Career Development and Work Values', 'Lecture Room', 3, 90),
(40, 'Psych 101', 'Introduction to Psychology', 'Lecture Room', 3, 90),
(41, 'GE 1', 'Understanding the Self', 'Lecture Room', 3, 90),
(42, 'GE 2', 'Readings in Philippine History', 'Lecture Room', 3, 90),
(43, 'PE 1', 'Physical Activities towards Health & Fitness (PATH-Fit) 1 (Movement Compentency Training MCT)', 'Lecture Room', 2, 60),
(44, 'NSTP 1', 'Civil Welfare Training Service 1 (CWTS)', 'Lecture Room', 3, 90),
(45, 'Psych 104', 'Developmental Psychology', 'Lecture Room', 3, 90),
(46, 'Psych 105', 'Physiological Psychology', 'Lecture Room', 3, 90),
(47, 'Natscie 4', 'Environmental Science', 'Science Laboratory', 5, 150),
(48, 'GE 6', 'Art Appreciation', 'Lecture Room', 3, 90),
(49, 'GE 13', 'Philippine Literature', 'Lecture Room', 3, 90),
(50, 'PE 3', 'Physical Activities towards Health & Fitness (PATH FIT) 3 (Choice of Dance, Sports, Martial Arts, Group Exercise, Outdoor & Adventure Activities)', 'Lecture Room', 2, 60),
(51, 'Psych 108', 'Cognitive Psychology', 'Lecture Room', 3, 90),
(52, 'Psych 109', 'Psychological Assessments', 'Psychology Laboratory', 5, 150),
(53, 'Psych 110', 'Social Psychology', 'Lecture Room', 3, 90),
(54, 'Natscie 2', 'Inorganic Chemistry', 'Science Laboratory', 5, 150),
(55, 'Psych 114', 'Research 1', 'Psychology Laboratory', 3, 90),
(56, 'Psych Elective 1', 'Current Issues in Psychology', 'Lecture Room', 3, 90),
(57, 'GE 12', 'Mga Anyo ng Kontemporaryong Panitikang Pilipino', 'Lecture Room', 3, 90),
(58, '--', 'Practicum', 'Psychology Laboratory', 3, 90),
(59, 'GE 4', 'Mathematics in the Modern World', 'Lecture Room', 3, 90),
(60, 'Cognate1', 'Teaching Multi-Grade Classes', 'Lecture Room', 3, 90),
(61, 'ED1', 'The Child and Adolescent Learners and Learning Principles', 'Lecture Room', 3, 90),
(62, 'ES-Eed 100', 'Teaching Science in Elementary Grades(Biology & Chemistry)', 'Lecture Room', 3, 90),
(63, 'ES-Eed 101', 'Teaching Math in the Primary Grades', 'Lecture Room', 3, 90),
(64, 'GE 10', 'Masining na Pagpapahayag', 'Lecture Room', 3, 90),
(65, 'ED3', 'The Teacher and the Community, School Culture and Organizational Leadership', 'Lecture Room', 3, 90),
(66, 'ED8', 'Technology for Teaching and Learning 1', 'Lecture Room', 3, 90),
(67, 'ES-Eed 105', 'Teaching Science in the Elementary Grades(Physics, Earth and Space Science)', 'Lecture Room', 3, 90),
(68, 'ES-Eed 106', 'Teaching Math in the Intermediate Grades', 'Lecture Room', 3, 90),
(69, 'ES-Eed 107', 'Content and Pedagogy in the Mother Tounge', 'Lecture Room', 3, 90),
(70, 'ES-Eed 108', 'Teaching Social Studies in Elementary Grades (Culture and Geography)', 'Lecture Room', 3, 90),
(72, 'ED5', 'Facilitating Learner-Centered Teaching', 'Lecture Room', 3, 90),
(73, 'ED6', 'Assesment in Learning 1', 'Lecture Room', 3, 90),
(74, 'ED9', 'The Teacher and the School Curriculum', 'Lecture Room', 3, 90),
(75, 'ES-Eed 113', 'Teaching English in the Elementary Grades through Literature', 'Lecture Room', 3, 90),
(76, 'ES-Eed 114', 'Teaching Arts in the Elementary Grades', 'Lecture Room', 3, 90),
(77, 'ES-Eed 115', 'Teaching PE and Health in the Elementary Grades', 'Lecture Room', 3, 90),
(78, 'FS1', 'Field Study1', 'Lecture Room', 3, 90),
(79, 'FS2', 'Field Study2', 'Lecture Room', 3, 90),
(80, 'Cognate 1', 'Remedial Instruction', 'Lecture Room', 3, 90),
(81, 'EES 100', 'Introduction to Linguistics', 'Lecture Room', 3, 90),
(82, 'EES 103', 'Principles and Theories of Language Acquisition and Learning', 'Lecture Room', 3, 90),
(83, 'EES 108', 'Teaching and Assessment of the Grammar', 'Lecture Room', 3, 90),
(84, 'EES 111', 'Children and Adolescent Literature', 'Lecture Room', 3, 90),
(85, 'EES 112', 'Mythology and Folklore', 'Lecture Room', 3, 90),
(86, 'ED 6', 'Assessment in Learning 1', 'Lecture Room', 3, 90),
(87, 'EES 109', 'Speech and Theater Arts', 'Lecture Room', 3, 90),
(88, 'EES 115', 'Survey of English and American Literature', 'Lecture Room', 3, 90),
(89, 'EES 116', 'Contemporary, Popular, and Emergent Literature', 'Lecture Room', 3, 90),
(90, 'Cognate 1', 'Malikhaing Pagsulat', 'Lecture Room', 3, 90),
(91, 'FES 100', 'Introduksiyon sa Pag-aaral ng Wika', 'Lecture Room', 3, 90),
(92, 'FES 104', 'Estruktura ng Wikang Filipino', 'Lecture Room', 3, 90),
(93, 'FES 105', 'Pagtuturo at Pagtataya ng Makrong Kasanayang Pangwika', 'Lecture Room', 3, 90),
(94, 'FES 106', 'Ugnayan ng Wika, Kultura at Lipunan', 'Lecture Room', 3, 90),
(95, 'FES 107', 'Paghahanda at Ebalwasyon ng Kagamitang Panturo', 'Lecture Room', 3, 90),
(96, 'FES 114', 'Introduksiyon sa Pananaliksik - Wika at Panitikan', 'Lecture Room', 3, 90),
(97, 'FES 115', 'Barayti at Baryasyon ng Wika', 'Lecture Room', 3, 90),
(98, 'FES 116', 'Mga Natatanging Diskurso sa Wika at Panitikan', 'Lecture Room', 3, 90),
(99, 'MES 100', 'History of Mathematics', 'Lecture Room', 3, 90),
(100, 'MES 101', 'College and Advanced Algebra', 'Lecture Room', 3, 90),
(101, 'MES 104', 'Logic and Set Theory', 'Lecture Room', 3, 90),
(102, 'MES 105', 'Elementary Statistics and Probability', 'Lecture Room', 3, 90),
(103, 'MES 106', 'Calculus I with Analytical Geometry', 'Lecture Room', 4, 90),
(104, 'MES 108', 'Mathematics of Investment', 'Lecture Room', 3, 90),
(105, 'MES 113', 'Calculus III', 'Lecture Room', 3, 90),
(106, 'MES 114', 'Problem Solving, Mathematical Investigation and Modeling', 'Lecture Room', 3, 90),
(107, 'MES 115', 'Principles and Strategies in Teaching Mathematics', 'Lecture Room', 3, 90),
(108, 'MES 116', 'Technology for Teaching and Learning 2 (Instrumentation and Technology in Mathematics)', 'Lecture Room', 3, 90),
(109, 'Cognate 1', 'Human Resources Management', 'Lecture Room', 3, 90),
(110, 'SOES 100', 'Foundation of Social Studies', 'Lecture Room', 3, 90),
(111, 'SOES 104', 'Geography 1', 'Lecture Room', 3, 90),
(112, 'SOES 105', 'Microeconomics', 'Lecture Room', 3, 90),
(113, 'SOES 106', 'World History 1', 'Lecture Room', 3, 90),
(114, 'SOES 107', 'Asian Studies', 'Lecture Room', 3, 90),
(115, 'SOES 114', 'Geography 3', 'Lecture Room', 3, 90),
(116, 'SOES 115', 'World History 2', 'Lecture Room', 3, 90),
(117, 'SOES 116', 'Comparative Economic Planning', 'Lecture Room', 3, 90),
(118, 'SES 102', 'Electricity and Magnetism', 'Science Laboratory', 4, 120),
(119, 'SES 103', 'Earth Science', 'Science Laboratory', 3, 90),
(120, 'ED 4', 'Foundation of Special and Inclusive Education', 'Science Laboratory', 3, 90),
(121, 'SES 107', 'Biochemistry', 'Science Laboratory', 3, 90),
(122, 'SES 108', 'Waves and Optics', 'Science Laboratory', 4, 120),
(123, 'SES 109', 'Genetics', 'Science Laboratory', 4, 120),
(124, 'SES 110', 'Meteorology', 'Science Laboratory', 3, 90),
(125, 'SES 115', 'Modern Physics', 'Science Laboratory', 3, 90),
(126, 'SES 116', 'Anatomy and Physiology', 'Science Laboratory', 4, 120),
(127, 'SES 117', 'The Teaching of Science', 'Science Laboratory', 3, 90),
(128, 'BC 1', 'Fundamentals of Accounting', 'Lecture Room', 6, 180),
(129, 'AE 1', 'Conceptual Framework and Accounting Standards', 'Lecture Room', 3, 90),
(130, 'AE 2', 'Law on Obligations and Contracts', 'Lecture Room', 3, 90),
(131, 'AE 3', 'Management Science', 'Lecture Room', 3, 90),
(132, 'AE 8', 'Intermediate Accounting 1', 'Lecture Room', 6, 180),
(133, 'AE 9', 'Managerial Economics', 'Lecture Room', 3, 90),
(134, 'AE 10', 'Governance, Business Ethics, Risk Management and Internal Control', 'Lecture Room', 3, 90),
(135, 'AE 11', 'Regulatory Framework and Legal Issues in Business', 'Lecture Room', 3, 90),
(136, 'AE 12', 'International Business and Trade', 'Lecture Room', 3, 90),
(137, 'AE 18', 'Business Taxation', 'Lecture Room', 3, 90),
(138, 'AE 19', 'Cost Accounting and Control', 'Lecture Room', 3, 90),
(139, 'AE 20', 'Accounting Information System', 'Lecture Room', 3, 90),
(140, 'PrE 1', 'Accounting for Business Combinations', 'Lecture Room', 3, 90),
(141, 'PrE 2', 'Auditing and Assurance Principles', 'Lecture Room', 3, 90),
(142, 'CBME 2', 'Strategic Management', 'Lecture Room', 3, 90),
(143, 'AE 25', 'Strategic Business Analysis', 'Lecture Room', 3, 90),
(144, 'AE 26', 'Strategic Cost Management', 'Lecture Room', 3, 90),
(145, 'PrE 6', 'Auditing in a CIS Environment', 'Lecture Room', 3, 90),
(146, 'PrE 7', 'Accounting for Government and Non-Profit Organization', 'Lecture Room', 3, 90),
(147, 'PrE 8', 'Auditing and Assurance: Specialized Industries', 'Lecture Room', 3, 90),
(148, 'AE 17', 'Intermediate Accounting 3', 'Lecture Room', 3, 90),
(149, 'AE 19', 'Accounting Information System', 'Lecture Room', 3, 90),
(150, 'PrE 1', 'Valuation Methods', 'Lecture Room', 3, 90),
(151, 'GE 8', 'Ethics', 'Lecture Room', 3, 90),
(152, 'PrE 4', 'Performance Management Systems', 'Lecture Room', 3, 90),
(153, 'PrE 5', 'Accounting for Government and Non-profit Organizations', 'Lecture Room', 3, 90),
(154, 'AE 25', 'Management Consultancy with Strategic Business Analysis', 'Lecture Room', 3, 90),
(155, 'MA-PrE', 'Prof.  El 1- Update in Managerial Accounting', 'Lecture Room', 3, 90),
(156, 'BA 1', 'Basic Microeconomics (Eco)', 'Lecture Room', 3, 90),
(157, 'GE 13', 'Introduction to Literature', 'Lecture Room', 3, 90),
(158, 'BA 2', 'Business Laws (Obligation & Contracts)', 'Lecture Room', 3, 90),
(159, 'BA 3', 'Taxation (Income Taxation)', 'Lecture Room', 3, 90),
(160, 'Prof 2', 'Financial Analysis and Reporting', 'Lecture Room', 3, 90),
(161, 'CBME 1', 'Strategic Management', 'Lecture Room', 3, 90),
(162, 'BA 6', 'International Trade and Agreements', 'Lecture Room', 3, 90),
(163, 'BA 7', 'Business Research', 'Lecture Room', 3, 90),
(164, 'Prof 4', 'Monetary Policy and Central Banking', 'Lecture Room', 3, 90),
(165, 'EC 1', 'Public Finance', 'Lecture Room', 3, 90),
(166, 'Prof 8', 'Special Topics in Financial Management', 'Lecture Room', 3, 90),
(167, 'EC 3', 'Entrepreneurial Management', 'Lecture Room', 3, 90),
(168, 'EC 4', 'Risk Management', 'Lecture Room', 3, 90),
(169, 'BA 8', 'Thesis or Feasibility Study', 'Lecture Room', 3, 90),
(170, 'THC 1', 'Macro Perspective of Tourism and Hospitality', 'Food Laboratory', 3, 90),
(171, 'THC 2', 'Risk Management as Applied to Safety, Security and Sanitation', 'Food Laboratory', 3, 90),
(172, 'HPC 3', 'Applied Business Tools and Technologies (GDS)', 'Food Laboratory', 3, 90),
(173, 'HPC 4', 'Supply Chain Management in Hospitality Industry', 'Food Laboratory', 3, 90),
(174, 'HPC 5', 'Basic Niponggo (Foreign Language 1)', 'Lecture Room', 3, 90),
(175, 'THC 6', 'Entrepreneurship in Tourism and Hospitality', 'Food Laboratory', 3, 90),
(176, 'THC 7', 'Tourism and Hospitality Marketing', 'Food Laboratory', 3, 90),
(177, 'HMFE 2', 'Food and Beverage Cost Control', 'Food Laboratory', 3, 90),
(178, 'HMFE 3', 'Front Office Operations', 'Food Laboratory', 3, 90),
(179, 'BMEC 1', 'Operations Management', 'Food Laboratory', 3, 90),
(180, 'GE 14', 'British Literature', 'Lecture Room', 3, 90),
(181, 'THC 9', 'Legal Aspects in Tourism and Hospitality', 'Food Laboratory', 3, 90),
(182, 'THC 10', 'Multicultural Diversity in Workplace for the Tourism Professional', 'Food Laboratory', 3, 90),
(183, 'HPC 9', 'Ergonomics & Facilities Planning for the Hospitality Industry', 'Food Laboratory', 3, 90),
(184, 'HPC 10', 'Research in Hospitality', 'Food Laboratory', 3, 90),
(185, 'HMFE 5', 'Rooms Division', 'Lecture Room', 3, 90),
(186, 'FB 1', 'Butchery, Fish Monger', 'Food Laboratory', 3, 90),
(187, 'FB 3', 'Specialty Cuisine', 'Food Laboratory', 3, 90),
(188, 'FB 5', 'Oenology', 'Food Laboratory', 3, 90),
(189, 'FB 6', 'Asian Cuisine', 'Food Laboratory', 3, 90),
(190, 'FB 8', 'Classical French Cuisine', 'Food Laboratory', 3, 90),
(191, 'TPC 4', 'Sustainable Tourism', 'Food Laboratory', 3, 90),
(192, 'TMFE 2', 'Recreational and Leisure Management', 'Food Laboratory', 3, 90),
(193, 'TMFE 3', 'Cruise Tourism', 'Food Laboratory', 3, 90),
(194, 'TPC 9', 'Transportation Management', 'Food Laboratory', 3, 90),
(195, 'TPC 10', 'Research in Tourism', 'Food Laboratory', 3, 90),
(196, 'TMFE 5', 'Accommodation Operations Management', 'Food Laboratory', 3, 90),
(197, 'LEA 1', 'Law Enforcement Organization and Administration', 'Lecture Room', 4, 120),
(198, 'Criminology 1', 'Introduction to Criminology', 'Lecture Room', 3, 90),
(199, 'PE 1', 'Fundamentals of Martial Arts', 'Practical', 2, 60),
(200, 'Forensic 1', 'Forensic Photography', 'Lecture Room', 3, 90),
(201, 'Criminology 3', 'Human Behavior and Victimology', 'Lecture Room', 3, 90),
(202, 'LEA 2', 'Comparative Models in Policing', 'Lecture Room', 3, 90),
(203, 'LEA 3', 'Introduction to Industrial Security Concepts', 'Lecture Room', 3, 90),
(204, 'CDI 1', 'Fundamentals of Investigation and Intelligence', 'Lecture Room', 4, 120),
(205, 'CLJ 2', 'Human Rights Education', 'Lecture Room', 3, 90),
(206, 'AdGE', 'General Chemistry (Inorganic)', 'Lecture Room', 3, 90),
(207, 'PE 3', 'First Aid and Water Survival', 'Practical', 2, 60),
(208, 'Forensic 3', 'Forensic Chemistry and Toxicology', 'Lecture Room', 5, 150),
(209, 'CDI 4', 'Traffic Management and Accident Investigation with Driving ', 'Lecture Room', 3, 90),
(210, 'CDI 5', 'Technical English 1 (Investigative Report Writing and Presentation ', 'Lecture Room', 3, 90),
(211, 'Criminology 4', 'Professional Conduct and Ethical Standards ', 'Lecture Room', 3, 90),
(212, 'Criminology 5', 'Juvenile Delinquency and Juvenile Justice System', 'Lecture Room', 3, 90),
(213, 'Forensic 4', 'Questioned Documents Examination', 'Lecture Room', 3, 90),
(214, 'CLJ 4', 'Criminal Law (Book 2)', 'Lecture Room', 4, 120),
(215, 'CDI 9', 'Introduction to Cybercrime and Environmental Laws and Protection', 'Lecture Room', 3, 90),
(216, 'Forensic 6', 'Forensic Ballistics ', 'Lecture Room', 3, 90),
(217, 'Criminology8', 'Criminological Research 2 (Thesis Writing and Presentation)', 'Lecture Room', 3, 90),
(218, 'CP 1', 'Internship (On the Job Training 1 - 270 hours)', 'Lecture Room', 3, 90),
(219, 'CLJ 6', 'Criminal Procedure and Court Testimony ', 'Lecture Room', 3, 90);

-- --------------------------------------------------------

--
-- Table structure for table `subjecthandled`
--

CREATE TABLE `subjecthandled` (
  `shID` int(11) NOT NULL,
  `instructorID` int(11) NOT NULL,
  `subjectID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `subjecthandled`
--

INSERT INTO `subjecthandled` (`shID`, `instructorID`, `subjectID`) VALUES
(4, 12, 9),
(9, 15, 220),
(10, 16, 10),
(11, 17, 11),
(12, 18, 12),
(13, 19, 13),
(14, 20, 14),
(15, 21, 15),
(16, 22, 44),
(17, 23, 17),
(18, 24, 9),
(19, 24, 10),
(20, 25, 12),
(21, 14, 9),
(22, 26, 19),
(23, 13, 20),
(24, 27, 21),
(25, 28, 22),
(26, 29, 24),
(27, 30, 25),
(28, 21, 26),
(29, 31, 27),
(30, 14, 28),
(31, 13, 29),
(32, 14, 30),
(33, 32, 31),
(34, 26, 32),
(35, 33, 33),
(36, 24, 34),
(37, 12, 35),
(38, 34, 36),
(39, 32, 37),
(40, 35, 38),
(41, 36, 39),
(42, 37, 36),
(43, 38, 42),
(44, 39, 59),
(45, 40, 60),
(46, 40, 61),
(47, 41, 62),
(48, 30, 63),
(49, 42, 43),
(50, 18, 44),
(51, 43, 64),
(52, 44, 65),
(53, 17, 66),
(54, 45, 67),
(55, 30, 68),
(56, 44, 69),
(57, 46, 70),
(58, 21, 50),
(59, 47, 57),
(60, 48, 49),
(61, 40, 72),
(62, 49, 86),
(63, 50, 74),
(64, 51, 75),
(65, 52, 76),
(66, 52, 77),
(67, 53, 78),
(68, 38, 79),
(69, 55, 80),
(70, 19, 81),
(71, 56, 43),
(72, 27, 24),
(73, 55, 82),
(74, 57, 83),
(75, 51, 84),
(76, 55, 85),
(77, 58, 57),
(78, 57, 49),
(79, 44, 72),
(80, 59, 74),
(81, 19, 87),
(82, 19, 88),
(83, 44, 89),
(84, 46, 42),
(85, 28, 91),
(86, 59, 13),
(87, 43, 92),
(88, 43, 93),
(89, 28, 94),
(90, 58, 95),
(91, 53, 57),
(92, 53, 96),
(93, 43, 97),
(94, 58, 98),
(95, 20, 99),
(96, 39, 100),
(97, 39, 101),
(98, 30, 102),
(99, 31, 103),
(100, 31, 105),
(101, 39, 106),
(102, 25, 107),
(103, 25, 108),
(104, 60, 109),
(105, 29, 110),
(106, 61, 111),
(107, 29, 112),
(108, 62, 113),
(109, 38, 114),
(110, 46, 115),
(111, 62, 116),
(112, 38, 117),
(113, 63, 54),
(114, 45, 118),
(115, 64, 119),
(116, 40, 120),
(117, 65, 121),
(118, 45, 122),
(119, 18, 123),
(120, 18, 124),
(121, 45, 125),
(122, 65, 126),
(123, 45, 127),
(124, 66, 41),
(125, 67, 128),
(126, 68, 129),
(127, 69, 130),
(128, 60, 131),
(129, 42, 15),
(130, 71, 44),
(131, 68, 130),
(132, 72, 48),
(133, 67, 132),
(134, 73, 133),
(135, 74, 134),
(136, 69, 135),
(137, 75, 136),
(138, 52, 26),
(139, 51, 49),
(140, 68, 137),
(141, 73, 138),
(142, 76, 139),
(143, 73, 140),
(144, 77, 141),
(145, 78, 142),
(146, 41, 12),
(147, 77, 143),
(148, 73, 144),
(149, 77, 145),
(150, 79, 146),
(151, 74, 147),
(152, 80, 134),
(153, 81, 148),
(154, 82, 137),
(155, 77, 150),
(156, 61, 151),
(157, 83, 152),
(158, 79, 153),
(159, 83, 154),
(160, 84, 155),
(161, 85, 41),
(162, 61, 42),
(163, 31, 59),
(164, 81, 156),
(165, 86, 128),
(166, 87, 42),
(167, 74, 156),
(168, 45, 12),
(169, 51, 157),
(170, 88, 158),
(171, 82, 159),
(172, 79, 160),
(173, 89, 161),
(174, 71, 162),
(175, 75, 163),
(176, 84, 164),
(177, 90, 165),
(178, 91, 161),
(179, 83, 166),
(180, 71, 167),
(181, 60, 168),
(182, 75, 169),
(183, 92, 170),
(184, 93, 171),
(185, 94, 172),
(186, 94, 173),
(187, 95, 174),
(188, 47, 64),
(189, 96, 175),
(190, 93, 176),
(191, 97, 177),
(192, 98, 178),
(193, 94, 179),
(194, 50, 180),
(195, 74, 181),
(196, 92, 182),
(197, 92, 183),
(198, 96, 184),
(199, 97, 185),
(200, 99, 186),
(201, 97, 187),
(202, 62, 33),
(203, 98, 177),
(204, 97, 178),
(205, 94, 188),
(206, 94, 189),
(207, 97, 190),
(208, 100, 39),
(209, 92, 191),
(210, 97, 192),
(211, 92, 193),
(212, 96, 194),
(213, 96, 195),
(214, 96, 196),
(215, 101, 197),
(216, 102, 198),
(217, 57, 11),
(218, 61, 33),
(219, 103, 199),
(220, 28, 64),
(221, 95, 199),
(222, 104, 197),
(223, 101, 198),
(224, 104, 198),
(225, 105, 197),
(226, 52, 48),
(227, 22, 33),
(228, 58, 64),
(229, 105, 198),
(230, 106, 48),
(231, 107, 200),
(232, 108, 201),
(233, 109, 202),
(234, 110, 203),
(235, 111, 204),
(236, 112, 205),
(237, 64, 206),
(238, 113, 21),
(239, 114, 207),
(240, 107, 204),
(241, 115, 204),
(242, 116, 201),
(243, 117, 202),
(244, 108, 203),
(245, 118, 204),
(246, 46, 21),
(247, 119, 200),
(248, 101, 203),
(249, 103, 207),
(250, 120, 200),
(251, 116, 202),
(252, 121, 204),
(253, 122, 205),
(254, 18, 206),
(255, 123, 208),
(256, 119, 209),
(257, 55, 210),
(258, 109, 211),
(259, 117, 212),
(260, 117, 213),
(261, 124, 214),
(262, 42, 49),
(263, 116, 212),
(264, 20, 25),
(265, 125, 208),
(266, 126, 209),
(267, 104, 212),
(268, 35, 49),
(269, 108, 211),
(270, 110, 212),
(271, 88, 214),
(272, 104, 211),
(273, 110, 213),
(274, 122, 214),
(275, 127, 210),
(276, 120, 212),
(277, 119, 215),
(278, 111, 216),
(279, 102, 217),
(280, 107, 218),
(281, 128, 219),
(282, 115, 216),
(283, 108, 217),
(284, 119, 218),
(285, 112, 215),
(286, 129, 40),
(287, 21, 43),
(288, 66, 45),
(289, 36, 46),
(290, 65, 47),
(291, 52, 50),
(292, 130, 51),
(293, 131, 52),
(294, 132, 53),
(295, 125, 54),
(296, 131, 55),
(297, 132, 56),
(298, 127, 13),
(299, 19, 38),
(300, 131, 58);

-- --------------------------------------------------------

--
-- Table structure for table `timeslots`
--

CREATE TABLE `timeslots` (
  `timeID` int(11) NOT NULL,
  `startTime` varchar(250) NOT NULL,
  `endTime` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `timeslots`
--

INSERT INTO `timeslots` (`timeID`, `startTime`, `endTime`) VALUES
(166, '07:30', '08:00'),
(167, '08:00', '08:30'),
(168, '08:30', '09:00'),
(169, '09:00', '09:30'),
(170, '09:30', '10:00'),
(171, '10:00', '10:30'),
(172, '10:30', '11:00'),
(173, '11:00', '11:30'),
(174, '11:30', '12:00'),
(175, '13:00', '13:30'),
(176, '13:30', '14:00'),
(177, '14:00', '14:30'),
(178, '14:30', '15:00'),
(179, '15:00', '15:30'),
(180, '15:30', '16:00'),
(181, '16:00', '16:30'),
(182, '16:30', '17:00'),
(183, '17:00', '17:30'),
(184, '17:30', '18:00'),
(185, '18:00', '18:30'),
(186, '18:30', '19:00'),
(187, '12:00', '13:00');

-- --------------------------------------------------------

--
-- Table structure for table `unavailableperiod`
--

CREATE TABLE `unavailableperiod` (
  `uaID` int(11) NOT NULL,
  `instructorID` int(11) NOT NULL,
  `day` varchar(250) NOT NULL,
  `timeID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `unavailableperiod`
--

INSERT INTO `unavailableperiod` (`uaID`, `instructorID`, `day`, `timeID`) VALUES
(13, 12, 'Monday', 166);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `acadyear`
--
ALTER TABLE `acadyear`
  ADD PRIMARY KEY (`acadYearID`);

--
-- Indexes for table `assignsubject`
--
ALTER TABLE `assignsubject`
  ADD PRIMARY KEY (`a_id`);

--
-- Indexes for table `authorization`
--
ALTER TABLE `authorization`
  ADD PRIMARY KEY (`userID`);

--
-- Indexes for table `building`
--
ALTER TABLE `building`
  ADD PRIMARY KEY (`buildingID`);

--
-- Indexes for table `course`
--
ALTER TABLE `course`
  ADD PRIMARY KEY (`courseID`);

--
-- Indexes for table `dean`
--
ALTER TABLE `dean`
  ADD PRIMARY KEY (`deanID`);

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`departmentID`);

--
-- Indexes for table `instructor`
--
ALTER TABLE `instructor`
  ADD PRIMARY KEY (`instructorID`);

--
-- Indexes for table `regissection`
--
ALTER TABLE `regissection`
  ADD PRIMARY KEY (`regisSectionID`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`roomID`);

--
-- Indexes for table `section`
--
ALTER TABLE `section`
  ADD PRIMARY KEY (`sectionID`);

--
-- Indexes for table `subject`
--
ALTER TABLE `subject`
  ADD PRIMARY KEY (`subjectID`);

--
-- Indexes for table `subjecthandled`
--
ALTER TABLE `subjecthandled`
  ADD PRIMARY KEY (`shID`);

--
-- Indexes for table `timeslots`
--
ALTER TABLE `timeslots`
  ADD PRIMARY KEY (`timeID`);

--
-- Indexes for table `unavailableperiod`
--
ALTER TABLE `unavailableperiod`
  ADD PRIMARY KEY (`uaID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `acadyear`
--
ALTER TABLE `acadyear`
  MODIFY `acadYearID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `assignsubject`
--
ALTER TABLE `assignsubject`
  MODIFY `a_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=471;

--
-- AUTO_INCREMENT for table `authorization`
--
ALTER TABLE `authorization`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `building`
--
ALTER TABLE `building`
  MODIFY `buildingID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `course`
--
ALTER TABLE `course`
  MODIFY `courseID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT for table `dean`
--
ALTER TABLE `dean`
  MODIFY `deanID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `departmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `instructor`
--
ALTER TABLE `instructor`
  MODIFY `instructorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=133;

--
-- AUTO_INCREMENT for table `regissection`
--
ALTER TABLE `regissection`
  MODIFY `regisSectionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=110;

--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `roomID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=64;

--
-- AUTO_INCREMENT for table `section`
--
ALTER TABLE `section`
  MODIFY `sectionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=110;

--
-- AUTO_INCREMENT for table `subject`
--
ALTER TABLE `subject`
  MODIFY `subjectID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=221;

--
-- AUTO_INCREMENT for table `subjecthandled`
--
ALTER TABLE `subjecthandled`
  MODIFY `shID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=301;

--
-- AUTO_INCREMENT for table `timeslots`
--
ALTER TABLE `timeslots`
  MODIFY `timeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=188;

--
-- AUTO_INCREMENT for table `unavailableperiod`
--
ALTER TABLE `unavailableperiod`
  MODIFY `uaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
