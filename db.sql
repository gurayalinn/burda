CREATE DATABASE DB;
GO

USE DB;
GO

CREATE TABLE Roles (
    ID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(256) NOT NULL
);
GO

CREATE TABLE RFIDCards (
    ID BIGINT PRIMARY KEY IDENTITY(1,1),
    RFIDNumber NVARCHAR(50) NOT NULL UNIQUE,
    RawData NVARCHAR(MAX) DEFAULT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Users(
    ID INT PRIMARY KEY IDENTITY(1,1),
    RFIDCardID BIGINT UNIQUE,
    RoleID INT NOT NULL,
    StudentID NVARCHAR(20) NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Password NVARCHAR(256) NOT NULL,
    Email NVARCHAR(254) NOT NULL UNIQUE,
    ProgramName NVARCHAR(100) NOT NULL,
    ProfileImage NVARCHAR(256) NULL,
    FOREIGN KEY (RoleID) REFERENCES Roles(ID),
    FOREIGN KEY (RFIDCardID) REFERENCES RFIDCards(ID),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE ClassRooms (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TeacherID INT NOT NULL,
    ClassName NVARCHAR(256) NOT NULL,
    LessonName NVARCHAR(256) NOT NULL,
    ClassDate DATE DEFAULT GETDATE(),
    StartTime TIME DEFAULT '08:00:00',
    EndTime TIME DEFAULT '23:00:00',
    IsExam BIT DEFAULT 0,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (TeacherID) REFERENCES Users(ID)
);
GO

CREATE TABLE Attendance (
    ID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    ClassID INT NOT NULL,
    AttType NVARCHAR(50) DEFAULT 'RFID',
    AttTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(ID),
    FOREIGN KEY (ClassID) REFERENCES ClassRooms(ID)
);
GO


CREATE TABLE Logs (
    ID INT PRIMARY KEY IDENTITY(1,1),
    LogType NVARCHAR(50) NOT NULL,
    Message NVARCHAR(MAX) NOT NULL,
    LogTime DATETIME DEFAULT GETDATE()
);
GO

INSERT INTO Roles (RoleName) VALUES 
('ADMIN'), 
('TEACHER'), 
('STUDENT');
GO


INSERT INTO RFIDCards (RFIDNumber) VALUES
('000000000000'),
('000000000001'),
('000000000002'),
('000000000003'),
('000000000004'),
('000000000005'),
('000000000006'),
('000000000007'),
('000000000008'),
('000000000009');
GO

INSERT INTO Users (RoleID, RFIDCardID, StudentID, FirstName, LastName, Password, Email, ProgramName, ProfileImage) VALUES

(1, '000000000', 1, 'ADMIN', 'ACCOUNT', 'Burda16!', 'admin@burda.local', NULL, NULL),

(2, '002942369', 2, 'EBRU', 'YENİMAN', '123456', 'yeniman@uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/ebru_yeniman_yildirim.jpg'),
(2, '002942387', 3, 'HATİCE', 'ÇAVUŞ', '123456', 'hyilmaz@uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/hatice_cavus.jpg'),
(2, '002942372', 4, 'UĞUR', 'FIKDIKOĞLU', '123456', 'ugurf@uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/ugur_findikoglu.jpg'),
(2, '002942378', 5, 'HÜLYA', 'BOZYOKUŞ', '123456', 'hulya@uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/hulya_bozyokus.jpg'),
(2, '002942379', 6, 'MURAT', 'ÇALIŞ', '123456', 'murat.calis@uludag.edu.tr', 'Bilgisayar Programcılığı', NULL),
(2, '002942380', 7, 'KADİR BURAK', 'OLGUN', '123456', 'kadirburak.olgun@uludag.edu.tr', 'Bilgisayar Programcılığı', NULL),

(3, '222203578', 8, 'GÜRAY', 'ALIN', '123456', '222203578@ogr.uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://media.licdn.com/dms/image/v2/D4D03AQFI6TN8tmVmpw/profile-displayphoto-shrink_400_400/profile-displayphoto-shrink_400_400/0/1688223104883?e=1736380800&v=beta&t=j16LUsIuICc24Jv4uUK_JmcVWn9DfcNYVqcpBPRKZiI'),
(3, '222303507', 9, 'EMİRHAN', 'UYSAL', '123456', '222303507@ogr.uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://media.licdn.com/dms/image/v2/D4D03AQHLZvZyj3se6g/profile-displayphoto-shrink_800_800/profile-displayphoto-shrink_800_800/0/1702578194368?e=1736380800&v=beta&t=9gs8ncBKToHWUNgsu_DuFD91ET_mdaDq7CRZBTVHgus'),
(3, '222303519', 10, 'HİLMİ', 'ENGİNAR', '123456', '222303519@ogr.uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://media.licdn.com/dms/image/v2/D4D35AQHpgKZT9j4seA/profile-framedphoto-shrink_800_800/profile-framedphoto-shrink_800_800/0/1722868325917?e=1731225600&v=beta&t=TR4lS7hhyeW60Jm-J9uiiDZcBmBauHpvq6NI5XIvKns');
GO

INSERT INTO ClassRooms (ClassName, TeacherID, LessonName, ClassDate, StartTime, EndTime, IsExam) VALUES
('BİL. LAB. 1', 3, 'VERİ TABANI I', '2024-10-01', '10:30:00', '12:00:00', 0),
('BİL. LAB. 1', 3, 'VERİ TABANI II', '2024-10-01', '13:00:00', '14:30:00', 0),
('BİL. LAB. 2', 2, 'PROGRAMLAMA TEMELLERİ', '2024-10-01', '08:30:00', '10:00:00', 0),
('BİL. LAB. 2', 7, 'NESNE TABANLI PROGRAMLAMA', '2024-10-01', '08:30:00', '10:00:00', 0),
('BİL. LAB. 2', 6, 'GÖRSEL PROGRAMLA', '2024-10-01', '08:30:00', '10:00:00', 0),
('C BLOK D6', 5, 'TEMEL MATEMATİK', '2024-10-01', '10:30:00', '12:00:00', 0);
GO

INSERT INTO Attendance (UserID, ClassID, AttType, AttTime) VALUES
(8, 1, 'RFID', '2024-10-01 08:30:00'),
(9, 1, 'RFID', '2024-10-01 10:30:00'),
(10, 1, 'RFID', '2024-10-01 13:00:00');
GO

-- Logs tablosuna örnek log verileri ekleyelim
INSERT INTO Logs (LogType, Message, LogTime) VALUES
('INFO', 'Sistem başlatıldı.', '2024-10-01 08:30:00'),
('INFO', 'ADMIN sisteme giriş yaptı.', '2024-10-01 09:00:00'),
('ERROR', 'GÜRAY ALIN adlı kullanıcı yoklama sırasında hata aldı.', '2024-10-01 09:15:00'),
('INFO', 'HATİCE ÇAVUŞ yoklama kaydı yaptı.', '2024-10-01 10:00:00'),
('WARNING', 'Sistem bağlantısı geçici olarak kesildi.', '2024-10-01 10:30:00'),
('INFO', 'EMİRHAN UYSAL sisteme yeniden giriş yaptı.', '2024-10-01 11:00:00'),
('ERROR', 'RFID kart doğrulama hatası.', '2024-10-02 09:00:00'),
('INFO', 'Yeni kullanıcı kaydı eklendi: Öğrenci HİLMİ ENGİNAR.', '2024-10-02 12:00:00');
GO