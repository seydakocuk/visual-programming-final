-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 03 Oca 2023, 09:48:57
-- Sunucu sürümü: 10.4.27-MariaDB
-- PHP Sürümü: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `sinema_bileti`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin_girisi`
--

CREATE TABLE `admin_girisi` (
  `id` int(11) NOT NULL,
  `kullanici_adi` varchar(200) NOT NULL,
  `sifre` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `admin_girisi`
--

INSERT INTO `admin_girisi` (`id`, `kullanici_adi`, `sifre`) VALUES
(1, 'admin', 'sifre');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `film_bilgileri`
--

CREATE TABLE `film_bilgileri` (
  `FilmId` int(11) NOT NULL,
  `FilmAdi` varchar(50) NOT NULL,
  `Yönetmen` varchar(50) DEFAULT NULL,
  `FilmTuru` varchar(50) DEFAULT NULL,
  `FilmSuresi` varchar(50) DEFAULT NULL,
  `tarih` varchar(50) DEFAULT NULL,
  `YapimYili` varchar(50) DEFAULT NULL,
  `Resim` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `film_bilgileri`
--

INSERT INTO `film_bilgileri` (`FilmId`, `FilmAdi`, `Yönetmen`, `FilmTuru`, `FilmSuresi`, `tarih`, `YapimYili`, `Resim`) VALUES
(0, 'Avatar:Suyun Yolu', 'James Cameron', 'Macera , Fantastik , Aksiyon', '3 saat 10 dakika', '30.03.2023', '2022', 'C:\\Users\\ASUS\\Desktop\\4691827.jpg'),
(0, 'Ayı Kardeşler', 'Huida Lin', 'Komedi, Animasyon, Aile, 3 Boyutlu', '1 saat 26 dakika', '05.01.2023', '2022', 'C:\\Users\\ASUS\\Desktop\\dunya.png'),
(0, 'Çakallarla Dans', 'Murat Şeker', 'Komedi', '120 dakika', '05.01.2023', '2022', 'C:\\Users\\ASUS\\Desktop\\cakallarladans.jpg');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanici_girisi`
--

CREATE TABLE `kullanici_girisi` (
  `id` int(11) NOT NULL,
  `kullanici_adi` varchar(200) NOT NULL,
  `sifre` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `kullanici_girisi`
--

INSERT INTO `kullanici_girisi` (`id`, `kullanici_adi`, `sifre`) VALUES
(1, 'şeyda', '123');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `salon_bilgileri`
--

CREATE TABLE `salon_bilgileri` (
  `SalonId` int(11) NOT NULL,
  `SalonAdi` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `salon_bilgileri`
--

INSERT INTO `salon_bilgileri` (`SalonId`, `SalonAdi`) VALUES
(0, 'salon-1'),
(0, 'salon-2'),
(0, 'salon-3'),
(0, 'salon-5');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `satis_bilgileri`
--

CREATE TABLE `satis_bilgileri` (
  `SatisId` int(11) NOT NULL,
  `KoltukNo` int(50) DEFAULT NULL,
  `SalonAdi` varchar(50) DEFAULT NULL,
  `FilmAdi` varchar(50) DEFAULT NULL,
  `tarih` varchar(50) DEFAULT NULL,
  `Saat` varchar(50) DEFAULT NULL,
  `Ad` varchar(50) DEFAULT NULL,
  `Soyad` varchar(50) DEFAULT NULL,
  `Ucret` varchar(50) DEFAULT NULL,
  `Tarih2` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `satis_bilgileri`
--

INSERT INTO `satis_bilgileri` (`SatisId`, `KoltukNo`, `SalonAdi`, `FilmAdi`, `tarih`, `Saat`, `Ad`, `Soyad`, `Ucret`, `Tarih2`) VALUES
(0, 1, 'salon-1', 'Çakallarla Dans', '10.01.2023', '20:00', 'Şeyda', 'Koçuk', '45', '02.01.2023'),
(0, 26, 'salon-1', 'Avatar:Suyun Yolu', '13.02.2023', '13:00', 'Şeydanur', 'Koçuk', '30', '02.01.2023'),
(0, 33, 'salon-2', 'Avatar:Suyun Yolu', '30.03.2023', '19:00', 'ayşe', 'kılıç', '45', '02.01.2023'),
(0, 40, 'salon-1', 'Ayı Kardeşler', '12.01.2023', '10:00', 'ali', 'veli', '45', '02.01.2023'),
(0, 13, 'salon-2', 'Ayı Kardeşler', '05.01.2023', '21:00', 'arzu', 'çakır', '45', '03.01.2023');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `seans_bilgileri`
--

CREATE TABLE `seans_bilgileri` (
  `SeansId` int(11) NOT NULL,
  `FilmAdi` varchar(50) DEFAULT NULL,
  `SalonAdi` varchar(50) DEFAULT NULL,
  `tarih` varchar(50) DEFAULT NULL,
  `Seans` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `seans_bilgileri`
--

INSERT INTO `seans_bilgileri` (`SeansId`, `FilmAdi`, `SalonAdi`, `tarih`, `Seans`) VALUES
(0, 'Çakallarla Dans', 'salon-1', '10.01.2023', '20:00'),
(0, 'Avatar:Suyun Yolu', 'salon-1', '13.02.2023', '15:00'),
(0, 'Avatar:Suyun Yolu', 'salon-1', '13.02.2023', '13:00'),
(0, 'Avatar:Suyun Yolu', 'salon-2', '30.03.2023', '19:00'),
(0, 'Ayı Kardeşler', 'salon-1', '12.01.2023', '10:00'),
(0, 'Ayı Kardeşler', 'salon-2', '05.01.2023', '21:00');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `admin_girisi`
--
ALTER TABLE `admin_girisi`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `film_bilgileri`
--
ALTER TABLE `film_bilgileri`
  ADD PRIMARY KEY (`FilmAdi`);

--
-- Tablo için indeksler `kullanici_girisi`
--
ALTER TABLE `kullanici_girisi`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `salon_bilgileri`
--
ALTER TABLE `salon_bilgileri`
  ADD PRIMARY KEY (`SalonAdi`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `admin_girisi`
--
ALTER TABLE `admin_girisi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `kullanici_girisi`
--
ALTER TABLE `kullanici_girisi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
