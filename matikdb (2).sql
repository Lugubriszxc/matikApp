-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 09, 2023 at 04:16 PM
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
-- Table structure for table `assignsubject`
--

CREATE TABLE `assignsubject` (
  `a_id` int(11) NOT NULL,
  `a_subjectID` int(11) NOT NULL,
  `a_classID` int(11) NOT NULL,
  `a_semester` varchar(250) NOT NULL,
  `a_instructorID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
(1, 'RAFI 1'),
(3, 'Tests');

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
(1, 'Bachelor of Science in Information Technology', 1),
(2, 'Bachelor of Science in Psychology', 5),
(3, 'Bachelor of Elementary Education', 2),
(4, 'Bachelor of Secondary Education major in English', 2),
(5, 'Bachelor of Secondary Education major in Mathematics', 2),
(6, 'Bachelor of Secondary Education major in Science', 2),
(7, 'Bachelor of Secondary Education major in Social Studies', 2),
(8, 'Bachelor of Science in Criminology', 3),
(9, 'Bachelor of Science in Accountancy', 4),
(11, 'Bachelor of Science in Business Administration Major in Financial Management', 4),
(12, 'Bachelor of Science in Business Management', 4),
(13, 'Bachelor of Science in Hospitality Management', 4),
(14, 'Bachelor of Science in Hospitality Management Major in Food and Beverage', 4),
(16, 'Bachelor of Ambot', 6),
(17, 'College of asd', 6);

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
(1, 'Jonel', 'Dignos', 'Gelig', 1),
(2, 'Dean', 'of', 'Teachers', 2),
(3, 'Dean', 'of', 'Crim', 3),
(4, 'Dean', 'of', 'Commerce', 4),
(5, 'Dean', 'of', 'Psychology', 5);

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
(1, 'College of Computer Studies'),
(2, 'College of Teacher Education'),
(3, 'College of Criminal Justice'),
(4, 'College of Commerce'),
(5, 'Psychology Program'),
(16, ' Testing Department');

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
(8, 'Test', '', 'Testing', 1),
(9, 'Test', 'Hello', 'Testing', 16);

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
(1, 'Room 1', 'Computer Laboratory', 60, 1),
(3, 'Test Room', 'Lecture Room', 60, 3);

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
(1, 'CC101', 'Introduction', 'Computer Laboratory', 3, 120),
(4, 'CC101', 'Test', 'Lecture Room', 3, 90);

-- --------------------------------------------------------

--
-- Table structure for table `timeslots`
--

CREATE TABLE `timeslots` (
  `timeID` int(11) NOT NULL,
  `day` varchar(250) NOT NULL,
  `startTime` varchar(250) NOT NULL,
  `endTime` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `timeslots`
--

INSERT INTO `timeslots` (`timeID`, `day`, `startTime`, `endTime`) VALUES
(1, 'Sunday', '21:00', '22:30'),
(2, 'Monday', '22:30', '00:00'),
(4, 'Sunday', '10:00', '12:00');

-- --------------------------------------------------------

--
-- Table structure for table `unavailableperiod`
--

CREATE TABLE `unavailableperiod` (
  `uaID` int(11) NOT NULL,
  `instructorID` int(11) NOT NULL,
  `timeID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `unavailableperiod`
--

INSERT INTO `unavailableperiod` (`uaID`, `instructorID`, `timeID`) VALUES
(5, 8, 2),
(7, 9, 1);

--
-- Indexes for dumped tables
--

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
-- AUTO_INCREMENT for table `assignsubject`
--
ALTER TABLE `assignsubject`
  MODIFY `a_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `authorization`
--
ALTER TABLE `authorization`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `building`
--
ALTER TABLE `building`
  MODIFY `buildingID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `course`
--
ALTER TABLE `course`
  MODIFY `courseID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `dean`
--
ALTER TABLE `dean`
  MODIFY `deanID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `departmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `instructor`
--
ALTER TABLE `instructor`
  MODIFY `instructorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `roomID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `section`
--
ALTER TABLE `section`
  MODIFY `sectionID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `subject`
--
ALTER TABLE `subject`
  MODIFY `subjectID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `timeslots`
--
ALTER TABLE `timeslots`
  MODIFY `timeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `unavailableperiod`
--
ALTER TABLE `unavailableperiod`
  MODIFY `uaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
