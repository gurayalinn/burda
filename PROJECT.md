# BURDA: Yoklama Takip Uygulaması

## Proje Ekibi :
- [Güray Alın](https://github.com/gurayalinn)
- [Emirhan Uysal](https://github.com/emirhanuysall)
- [Hilmi Enginar](https://github.com/Healmengnr)

## Prompt İçeriği :
- **BURDA: Yoklama Takip Uygulaması**

1. Prompt:
Merhaba, Görsel Programlama dersi için final projesi hazırlıyorum.
Proje C# WinForms .NET Framework 4.8 ile geliştirilecek MS-Sql ve EntityFramework 6.5.1 kullanılacak. Projenin şartları aşağıdaki şekilde olacak.

Öğrenci yoklama takip sistemi olacak. Kiosk ve RFID ile her sınıfta sabit durarak çalışacak.
Yetkilendirme ile admin kartı basıldığında dashboard da veriler ve istatistik bilgiler yer alacak.
Projenin adı, BURDA: Yoklama Takip Uygulaması olacak.
Proje ekibi 3 kişi olacak.

Proje adımları ve şartları aşağıdaki gibidir:
1. OOP yapısına uyacak
2. Kod tekrarı olmayacak
3. DB - MS-SQL - normalizasyonu yapılmış ilişkisel veritabanı olacak
4. Prog. standartlarına uygun - Değişken - class - method isimleri uyumlu olacak
5. CRUD MVC yapısı olacak 
6. Entity framework kullanılacak
7. Login - Register - Password reset - Session
8. Yetkilendirme - Admin - user
9. Vize tarihinde raporlama
10. Loglama ve hata denetimi yapılacak
11. Farklı teknolojiler (RFID okuma vs.) kullanılacak
12. Proje Tam kontrolü ve testleri yapılacak
13. Proje sorunsuz çalışıyor mu ?
14. Proje Teslimi Final Raporu ve sunumu yapılacak

--------------------------------------------

2. Prompt:
Docker ile MSSQL server kurulumu aşağıdaki gibidir.

```powershell
$ docker pull mcr.microsoft.com/mssql/server:2022-latest
$ docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=!#1Password" -p 1433:1433 --name mssql --hostname mssql -d mcr.microsoft.com/mssql/server:2022-latest
```


- SSMS - Login
- Server Type: Database Engine
- Server name: 127.0.0.1, 1433
- Authentication: SQL Server Authentication
- Login: sa
- Password: !#1Password
- Connection Security - Encryption: Optional
- 🌐 SQL Server [127.0.0.1:1433](http://127.0.0.1:1433/) portunda çalışmaktadır.

--------------------------------------------

3. Prompt:
Proje için gerekli yazılımların listesi aşağıdaki gibidir.

- Visual Studio 2022 - [Download](https://visualstudio.microsoft.com/tr/downloads/)
- .Net Framework 4.8 - [Download](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
- Entity Framework 6.5.1 - [Download](https://learn.microsoft.com/en-us/ef/core/get-started/winforms)
- Git - [Download](https://git-scm.com/downloads/win)
- Docker Desktop - [Download](https://docs.docker.com/desktop/install/windows-install/)
- MSSQL 2022 Server - [Download](https://hub.docker.com/r/microsoft/mssql-server)
- SQL Server Management Studio 20 - [Download](https://aka.ms/ssmsfullsetup)

--------------------------------------------

4. Prompt:
Projeye Entity Framework eklemek için aşağıdaki adımları takip edebilirsiniz.

- Visual Studio'da projenizi açın.
- Solution Explorer'da projenizin üzerine sağ tıklayın ve "Manage NuGet Packages" seçeneğine tıklayın.
- Browse sekmesine tıklayın ve "EntityFramework" arayın.
- EntityFramework paketini projenize yükleyin.

--------------------------------------------

5. Prompt:

Projenin veritabanı şeması aşağıdaki gibidir.

```sql

CREATE DATABASE DB;
GO

USE DB;
GO

CREATE TABLE Roles (
    ID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(256) NOT NULL
);
GO

CREATE TABLE Users(
    ID INT PRIMARY KEY IDENTITY(1,1),
    RoleID INT NOT NULL,
    StudentID NVARCHAR(20) NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Password NVARCHAR(256) NOT NULL,
    Email NVARCHAR(254) NOT NULL UNIQUE,
    UserStatus BIT DEFAULT 1,
    ProgramName NVARCHAR(100) NULL,
    ProfileImage NVARCHAR(256) NULL,
    FOREIGN KEY (RoleID) REFERENCES Roles(ID),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE RFIDCards (
    ID INT PRIMARY KEY IDENTITY(1,1),
    RFIDNumber NVARCHAR(50) NOT NULL UNIQUE,
    UserID INT NULL UNIQUE,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(ID)
    );
GO

CREATE TABLE Classes (
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
    FOREIGN KEY (ClassID) REFERENCES Classes(ID)
);
GO

CREATE TABLE Logs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
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

INSERT INTO Users (RoleID, StudentID, FirstName, LastName, Password, Email, ProgramName, ProfileImage) VALUES

(1, 000000000, 'ADMIN', 'ACCOUNT', 'Burda16!', 'admin@burda.local', NULL, NULL),

(2, 002942369, 'EBRU', 'YENİMAN', '123456', 'yeniman@uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/ebru_yeniman_yildirim.jpg'),
(2, 002942387, 'HATİCE', 'ÇAVUŞ', '123456', 'hyilmaz@uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/hatice_cavus.jpg'),
(2, 002942372, 'UĞUR', 'FIKDIKOĞLU', '123456', 'ugurf@uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/ugur_findikoglu.jpg'),
(2, 002942378, 'HÜLYA', 'BOZYOKUŞ', '123456', 'hulya@uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://uludag.edu.tr/dosyalar/tby/akademik-personel-foto/hulya_bozyokus.jpg'),
(2, 002942379, 'MURAT', 'ÇALIŞ', '123456', 'murat.calis@uludag.edu.tr', 'Bilgisayar Programcılığı', NULL),
(2, 002942380, 'KADİR BURAK', 'OLGUN', '123456', 'kadirburak.olgun@uludag.edu.tr', 'Bilgisayar Programcılığı', NULL),

(3, 222203578, 'GÜRAY', 'ALIN', '123456', '222203578@ogr.uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://media.licdn.com/dms/image/v2/D4D03AQFI6TN8tmVmpw/profile-displayphoto-shrink_400_400/profile-displayphoto-shrink_400_400/0/1688223104883?e=1736380800&v=beta&t=j16LUsIuICc24Jv4uUK_JmcVWn9DfcNYVqcpBPRKZiI'),
(3, 222303507, 'EMİRHAN', 'UYSAL', '123456', '222303507@ogr.uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://media.licdn.com/dms/image/v2/D4D03AQHLZvZyj3se6g/profile-displayphoto-shrink_800_800/profile-displayphoto-shrink_800_800/0/1702578194368?e=1736380800&v=beta&t=9gs8ncBKToHWUNgsu_DuFD91ET_mdaDq7CRZBTVHgus'),
(3, 222303519, 'HİLMİ', 'ENGİNAR', '123456', '222303519@ogr.uludag.edu.tr', 'Bilgisayar Programcılığı', 'https://media.licdn.com/dms/image/v2/D4D35AQHpgKZT9j4seA/profile-framedphoto-shrink_800_800/profile-framedphoto-shrink_800_800/0/1722868325917?e=1731225600&v=beta&t=TR4lS7hhyeW60Jm-J9uiiDZcBmBauHpvq6NI5XIvKns');
GO

INSERT INTO RFIDCards (RFIDNumber, UserID) VALUES
('000000000000', 1),
('000000000001', 2),
('000000000002', 3),
('000000000003', 4),
('000000000004', 5),
('000000000005', 6),
('000000000006', 7),
('000000000007', 8),
('000000000008', 9),
('000000000009', 10);
GO

INSERT INTO Classes (ClassName, TeacherID, LessonName, ClassDate, StartTime, EndTime, IsExam) VALUES
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

```

--------------------------------------------
