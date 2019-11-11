-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.33-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win32
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for blog
CREATE DATABASE IF NOT EXISTS `blog` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `blog`;

-- Dumping structure for table blog.articles
CREATE TABLE IF NOT EXISTS `articles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `content` text NOT NULL,
  `image` text NOT NULL,
  `date` datetime NOT NULL,
  `authorId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `authorId` (`authorId`),
  CONSTRAINT `articles_ibfk_1` FOREIGN KEY (`authorId`) REFERENCES `users` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Dumping data for table blog.articles: ~5 rows (approximately)
/*!40000 ALTER TABLE `articles` DISABLE KEYS */;
REPLACE INTO `articles` (`id`, `title`, `content`, `image`, `date`, `authorId`) VALUES
	(1, 'proektut na Gosho', 'Tova e render nomer 1 ', 'https://static.turbosquid.com/Preview/001166/779/9W/scene-scandinavian-apartment-3D-model_0.jpg', '2018-07-22 20:26:28', 1),
	(2, 'proektut na Gosho', 'Tova e render nomer 2', 'http://www.decodefablab.com/wp-content/uploads/2015/12/TRUSS-HOUSE-1.jpg', '2018-07-22 20:26:52', 1),
	(3, 'proektut na Gosho', 'Tova e render nomer 3', 'https://i.ytimg.com/vi/raxoyqpOayM/maxresdefault.jpg', '2018-07-22 20:27:13', 1),
	(4, 'proektut na Gosho', 'tova e render nomer 4', 'https://assets.flatpyramid.com/wp-content/uploads/2017/07/11000938/vray_night_scene_-_rendering_modern_house_tutorial-3d-model-41456-852331.jpg', '2018-07-22 20:27:37', 1),
	(5, 'proektut na Stavri i Gosho', 'tova e render nomer 5', 'https://www.rockcote.com.au/sites/default/files/Marrakesh_shower_bathroom.jpg', '2018-07-25 23:19:00', 3);
/*!40000 ALTER TABLE `articles` ENABLE KEYS */;

-- Dumping structure for table blog.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(255) NOT NULL,
  `passwordHash` varchar(255) DEFAULT NULL,
  `fullName` varchar(255) DEFAULT NULL,
  `salt` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Dumping data for table blog.users: ~2 rows (approximately)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
REPLACE INTO `users` (`id`, `email`, `passwordHash`, `fullName`, `salt`) VALUES
	(2, 'gosho@abv.bg', '86df4b5c961ab192b536aa553b28ac45a99bb1575ec4dfd081e64f563a2dba1e', 'gosheto', 'TZegV6XAdhJg+81V9ZVMc69w4Ff0C9VCXbuhyTCltejEi/63+1xdAjMq+uXE/XCkyAKSiJu6SaFDaeJ6jok+H/awHRjUrMyw3mOgWyeNnZNKbwwJwkUchXIqwAS1itfHXYIlEMp7XE9AsO2Ij+97k9bJas9nA0c0lZEUjAkOXNo='),
	(3, 'stavri@mail.bg', '437d5fae87bb14d7b534d7a999d2a2f0938476a2ad36ef59fb54a98b2a252fbf', 'stavri', 'yLaGPjLo2nnOtz/1NKDKe1C9XWwwAMNCOrydduRDo8nmRiBCCA37dn1L5g3H9vROclytJaAvFgGop3WKPBIVQ5Ao1kgRy91n1d+cEAuaoL1yxoobd1TBGTcTgrOpqswKY8mVXlDm9C7kzyFHUJA7NcZVncpHXlWRaLWtqEEay3U=');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
