
# 🚀 C# Winforms .NET(Framework) - MSSQL | Yoklama Takip Uygulaması

---

> **Note:** Bu proje, C# Winforms .NET(Framework) ile SQLite/MSSQL veritabanı kullanarak yoklama takip işlemlerini gerçekleştiren otomasyon uygulamasıdır.

## ⚙️ Kurulum:

### 📝 Geliştirme Ortamı

> **Note:** Bu projeyi çalıştırmak için aşağıdaki yazılımların yüklü olması gerekmektedir.
- 📦 Visual Studio 2022 - [Download](https://visualstudio.microsoft.com/tr/downloads/)
- 📦 .Net(Framework 4.8) - [Download](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer)
- 📦 Git - [Download](https://git-scm.com/downloads)
- 📦 Docker Desktop (Opsiyonel)
- 📦 MSSQL 2022 Server
- 📦 SQL Server Management Studio 20 (Opsiyonel)

> **Not:** SQL Server Bağlantısı:

```cs
string connectionString = "Server=127.0.0.1,1433; Database=master; User Id=sa; Password=!#1Password;";

```

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

- 🌐 SQL Server [127.0.0.1:1433](http://127.0.0.1:1433) portunda çalışmaktadır.

### 📦 Projeyi İndirme

```bash
$ git clone https://github.com/gurayalinn/burda.git
$ cd arac
```

### ⚡Projeyi Çalıştırma

📦 .NET (Framework 4.8) - [Download](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer)

- En az Windows 10 x64 işletim sistemi gereklidir.
- İndirilen dosyayı açın ve `burda.exe` dosyasını çalıştırın.

---

## 📃 LİSANS

<strong> &copy; 2024</strong> [APACHE-2.0](LICENSE)