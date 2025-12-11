-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 15 May 2023, 16:01:51
-- Sunucu sürümü: 10.4.28-MariaDB
-- PHP Sürümü: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `demirbastakip`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanicilar`
--

CREATE TABLE `kullanicilar` (
  `kullanici_id` int(11) NOT NULL,
  `mail` varchar(255) NOT NULL,
  `sifre` varchar(40) NOT NULL,
  `ad` varchar(40) NOT NULL,
  `soyad` varchar(40) NOT NULL,
  `sicilno` int(11) NOT NULL,
  `unvan` varchar(70) NOT NULL,
  `bolum` varchar(70) NOT NULL,
  `odano` varchar(20) NOT NULL,
  `baslamatarih` varchar(70) NOT NULL,
  `aciklama` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `kullanicilar`
--

INSERT INTO `kullanicilar` (`kullanici_id`, `mail`, `sifre`, `ad`, `soyad`, `sicilno`, `unvan`, `bolum`, `odano`, `baslamatarih`, `aciklama`) VALUES
(1, 'anakinskywalker@gmail.com', '123', 'Anakin', 'Skywalker', 41, 'Çırak', 'Sith', 'JS101', '12.05.2023', 'Güce dengeyi getirecek kişi.'),
(2, 'obiwankenobi@gmail.com', '1234', 'Obi-Wan', 'Kenobi', 57, 'Usta', 'Jedi', 'J101', '2023-04-07', 'Anakin\'in Ustası'),
(3, 'lukeskywalker@gmail.com', '123', 'Luke', 'Skywalker', 19, 'Çırak', 'Jedi', 'J102', '03.07.2023', 'En iyi jedi.'),
(4, 'yoda@gmail.com', '1234', 'Yoda', '', 896, 'Usta', 'Jedi', 'J104', '08.09.2016', 'Devrik konuşuyor.'),
(5, 'ahsokatano@gmail.com', '1234', 'Ahsoka', 'Tano', 36, 'Çırak', 'Jedi', 'J202', '03.06.2023', 'İki lightsaber kullanıyor. Anakin\'e olan inancını yitirmiyor.'),
(6, 'maul@gmail.com', '123', 'Maul', '', 54, 'Darth', 'Sith', 'S101', '05.04.2021', 'Obi-wan\'la geçirdiği kaza sonucu bacaklarını kaybetti.');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urunler`
--

CREATE TABLE `urunler` (
  `urun_id` int(11) NOT NULL,
  `marka` varchar(70) NOT NULL,
  `model` varchar(70) NOT NULL,
  `tarih` varchar(70) NOT NULL,
  `aciklama` varchar(255) NOT NULL,
  `islemci` varchar(255) DEFAULT NULL,
  `ram` int(11) DEFAULT NULL,
  `disk` int(11) DEFAULT NULL,
  `ekrankarti` varchar(255) DEFAULT NULL,
  `monitorboyut` int(11) DEFAULT NULL,
  `k_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `urunler`
--

INSERT INTO `urunler` (`urun_id`, `marka`, `model`, `tarih`, `aciklama`, `islemci`, `ram`, `disk`, `ekrankarti`, `monitorboyut`, `k_id`) VALUES
(1, 'MSI', 'MAG Codex', '12.05.2023', 'Kasa', 'İ7', 16, 512, 'RTX2060', 0, 1),
(6, 'Casper', 'Excalibur', '2023-02-08', 'Monitör', '', 0, 0, '', 23, 1),
(7, 'Asus', 'Tuff Gaming', '14.04.2023', 'Laptop', 'r5', 8, 256, 'rtx4050', 21, 1),
(8, 'Asus', 'Tuff Gaming A15', '2023-05-10', 'Laptop', 'R7 7735-HS', 8, 512, 'RTX4050', 15, 2),
(14, 'Asus', 'ROG', '12.05.2023', 'Laptop', 'r7', 16, 512, 'RTX4070', 23, 1),
(19, 'Lightsaber', 'Double-bladed', '', 'Kırmızı', NULL, NULL, NULL, NULL, NULL, 6),
(20, 'Lightsaber', 'Tek', '', 'Mavi-Yeşil', '', 0, 0, '', 0, 3),
(21, 'Lightsaber', 'İkili', '', 'Yeşil-Mavi', '', 0, 0, '', 0, 5),
(22, 'Lightsaber', 'Kısa', '01.01.2017', 'Yeşil', '', 0, 0, '', 0, 4),
(23, 'Lightsaber', 'İkili', '', 'Beyaz', '', 0, 0, '', 0, 5);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `kullanicilar`
--
ALTER TABLE `kullanicilar`
  ADD PRIMARY KEY (`kullanici_id`);

--
-- Tablo için indeksler `urunler`
--
ALTER TABLE `urunler`
  ADD PRIMARY KEY (`urun_id`),
  ADD KEY `k_id` (`k_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `kullanicilar`
--
ALTER TABLE `kullanicilar`
  MODIFY `kullanici_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `urunler`
--
ALTER TABLE `urunler`
  MODIFY `urun_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `urunler`
--
ALTER TABLE `urunler`
  ADD CONSTRAINT `urunler_ibfk_1` FOREIGN KEY (`k_id`) REFERENCES `kullanicilar` (`kullanici_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
