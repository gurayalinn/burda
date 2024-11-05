
# 🙋 BURDA: Yoklama Takip Uygulaması

## 📝 Proje Tanımı

- **BURDA** adlı uygulama, öğrencilerin sınıf yoklamasını sağlayan bir uygulamadır.
- Öğrencilerin derslere katılım durumlarını takip eden, RFID gibi teknolojileri kullanan bir uygulamadır.
> **Not:** Bu proje, C# WinForms .NET Framework 4.8 ve MSSQL veritabanı kullanarak geliştirilmiştir. [<ins>**_PROJE DETAYLARI_**</ins>](PROJECT.md)

## ⚙️ Geliştirme Ortamı

> **Not:** Bu projeyi çalıştırmak için aşağıdaki gereksinimlerin yüklü olması gerekmektedir.
- 📦 Visual Studio 2022 - [Download](https://visualstudio.microsoft.com/tr/downloads/)
- 📦 .Net Framework 4.8 - [Download](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
- 📦 Entity Framework 6.5.1 - [Download](https://learn.microsoft.com/en-us/ef/core/get-started/winforms)
- 📦 Git - [Download](https://git-scm.com/downloads/win)
- 📦 Docker Desktop - [Download](https://docs.docker.com/desktop/install/windows-install/)
- 📦 MSSQL 2022 Server - [Download](https://hub.docker.com/r/microsoft/mssql-server)
- 📦 SQL Server Management Studio 20 - [Download](https://aka.ms/ssmsfullsetup)

### 📦 Projeyi İndirme

```bash
$ git clone https://github.com/gurayalinn/burda.git
$ cd burda
$ start burda.sln
```

### 📦 MSSQL Server 2022  Docker Container
```powershell
$ docker pull mcr.microsoft.com/mssql/server:2022-latest
```

> Container Oluşturma
```powershell
$ docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=!#1Password" -p 1433:1433 --name mssql --hostname mssql -d mcr.microsoft.com/mssql/server:2022-latest
```

> Container İşlemleri
```powershell
$ docker exec -it mssql /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P '!#1Password'
```

> Database Backup & Restore
```powershell
$ docker exec -it mssql /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P '!#1Password' -d db -i /var/opt/mssql/backup/db.sql
```

### 📦 SQL Server Management Studio 20

- SSMS - Login
- Server Type: Database Engine
- Server name: 127.0.0.1, 1433
- Authentication: SQL Server Authentication
- Login: sa
- Password: !#1Password
- Connection Security - Encryption: Optional

- 🌐 SQL Server [127.0.0.1:1433](http://127.0.0.1:1433) portunda çalışmaktadır.

### 📦 Entity Framework 6.5.1

- Solution Explorer > burda > NuGet Package Manager > Browse
- EntityFramework & System.Data.SQLite yükleyin.
- Veritabanı işlemleri için Package Manager Console kullanın.
- Visual Studio 2022 > Tools > NuGet Package Manager > Package Manager Console
- PM > `NuGet\Install-Package Microsoft.Data.SqlClient -Version 5.2.2` > Enter
- PM > `NuGet\Install-Package EntityFramework -Version 6.5.1` > Enter
- PM > `NuGet\Install-Package Microsoft.EntityFramework.SqlServer -Version 6.5.1` > Enter
- PM > `NuGet\Install-Package System.Data.SQLite.EF6 -Version 1.0.119` > Enter

- Visual Studio 2022 > Solution Explorer > burda > App.config
```xml
	<connectionStrings>
		<add name="DbConnectionString"
			 connectionString="Server=localhost\\mssql,1433;Database=db;User Id=sa;Password=!#1Password;Encrypt=False;trustServerCertificate=true"
			 providerName="System.Data.SqlClient" />
	</connectionStrings>
```

### ⚡ Projeyi Çalıştırma

- En az Windows 10 x64 işletim sistemi gereklidir.

- 📦 .Net Framework 4.7.2 Runtime - [Download](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer)

- 📦 Uygulamayı indirin - [Download](https://github.com/gurayalinn/burda/releases/latest)

- İndirilen arşivden çıkarın ve `burda.exe` dosyasını çalıştırın.
> **_Kullanıcı Adı:_** `admin@burda.local` **_Şifre:_** `Burda16!`

---

## 📃 LİSANS

<strong> &copy; 2024</strong> [APACHE-2.0](LICENSE)