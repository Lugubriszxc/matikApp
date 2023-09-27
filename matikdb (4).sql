-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 27, 2023 at 01:03 AM
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
  `subjectID` int(11) NOT NULL,
  `sectionID` int(11) NOT NULL,
  `semester` varchar(250) NOT NULL,
  `instructorID` int(11) NOT NULL,
  `departmentID` int(11) NOT NULL,
  `courseID` int(11) NOT NULL,
  `studentCount` int(11) NOT NULL
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
(6, 'Maxwell');

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
(35, 'Bachelor of Science in Business Management', 19),
(36, 'Bachelor of Science in Hospitality Management', 19),
(37, 'Bachelor of Science in Hospitality Management Major in Food and Beverage', 19),
(38, 'Bachelor of Science in Tourism Management', 19),
(39, 'Bachelor of Science in Information Technology', 20),
(40, 'Bachelor of Science in Psychology', 21);

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
(12, 'Marjorie', '', 'Reso', 20);

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
(10, 'BSIT-1A', '1st Year', 20, 39);

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
(17, 'NSTP 1', 'Reserve Officers\' Training Corps 1', 'Lecture Room', 3, 150),
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
(44, 'NSTP 1', 'Civil Welfare Training Service 1', 'Speech Laboratory', 3, 90),
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
(199, 'PE 1', 'Fundamentals of Martial Arts', 'Lecture Room', 2, 60),
(200, 'Forensic 1', 'Forensic Photography', 'Lecture Room', 3, 90),
(201, 'Criminology 3', 'Human Behavior and Victimology', 'Lecture Room', 3, 90),
(202, 'LEA 2', 'Comparative Models in Policing', 'Lecture Room', 3, 90),
(203, 'LEA 3', 'Introduction to Industrial Security Concepts', 'Lecture Room', 3, 90),
(204, 'CDI 1', 'Fundamentals of Investigation and Intelligence', 'Lecture Room', 4, 120),
(205, 'CLJ 2', 'Human Rights Education', 'Lecture Room', 3, 90),
(206, 'AdGE', 'General Chemistry (Inorganic)', 'Lecture Room', 3, 90),
(207, 'PE 3', 'First Aid and Water Survival', 'Lecture Room', 2, 60),
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
(11, 'Monday', '10:30', '12:00');

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
-- AUTO_INCREMENT for table `assignsubject`
--
ALTER TABLE `assignsubject`
  MODIFY `a_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `authorization`
--
ALTER TABLE `authorization`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `building`
--
ALTER TABLE `building`
  MODIFY `buildingID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `course`
--
ALTER TABLE `course`
  MODIFY `courseID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `dean`
--
ALTER TABLE `dean`
  MODIFY `deanID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `departmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `instructor`
--
ALTER TABLE `instructor`
  MODIFY `instructorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `roomID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `section`
--
ALTER TABLE `section`
  MODIFY `sectionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `subject`
--
ALTER TABLE `subject`
  MODIFY `subjectID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=220;

--
-- AUTO_INCREMENT for table `subjecthandled`
--
ALTER TABLE `subjecthandled`
  MODIFY `shID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `timeslots`
--
ALTER TABLE `timeslots`
  MODIFY `timeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `unavailableperiod`
--
ALTER TABLE `unavailableperiod`
  MODIFY `uaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
