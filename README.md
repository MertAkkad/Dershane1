# Dershane Yönetim Sistemi

## Proje Genel Bakışı
Bu, öğrenci takibi, kurs yönetimi ve idari görevleri kolaylaştıran dershaneler (eğitim kurumları) için bir yönetim uygulamasıdır. Sistem, yöneticiler, öğretmenler ve öğrencilerin kendi iş akışlarını yönetmeleri için arayüzler sunar.

## Kullanılan Teknolojiler
- ASP.NET Core (.NET Core)
- Entity Framework Core
- C#
- HTML/CSS/JavaScript
- Bootstrap
- SQL Server

## Gereksinimler
Bu uygulamayı yerel olarak çalıştırmak için aşağıdakilere ihtiyacınız olacak:
- [.NET Core SDK](https://dotnet.microsoft.com/download) (versiyon 6.0 veya daha yenisi)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express veya Developer sürümü yeterlidir)
- [Visual Studio](https://visualstudio.microsoft.com/) (önerilen) veya [Visual Studio Code](https://code.visualstudio.com/)

## Kurulum Talimatları

### 1. Repository'i Klonlama
```bash
git clone [repository-url]
cd Dershane1
```

### 2. Veritabanı Kurulumu
Uygulama, Entity Framework Core Code-First yaklaşımını kullanır. Veritabanını kurmak için:

- `appsettings.json` dosyasındaki bağlantı dizesini SQL Server örneğinize uygun şekilde güncelleyin
- Proje dizininde bir terminal açın ve aşağıdaki komutları çalıştırın:
```bash
dotnet ef database update
```

Örnek verilerle başlamak isterseniz, şunu çalıştırabilirsiniz:
```bash
dotnet run seeddata
```

### 3. Uygulamayı Çalıştırma
- Visual Studio kullanarak:
  - `Dershane.sln` çözüm dosyasını açın
  - F5'e basın veya Çalıştır düğmesine tıklayın

- Komut Satırı kullanarak:
  - Proje dizinine gidin
  - Aşağıdaki komutu çalıştırın:
  ```bash
  dotnet run
  ```
  - Bir tarayıcı açın ve `https://localhost:5001` veya `http://localhost:5000` adresine gidin

## Proje Yapısı
- **Controllers/**: HTTP isteklerini işleyen MVC denetleyicilerini içerir
- **Models/**: Veri modellerini ve görünüm modellerini içerir
- **Views/**: Kullanıcı arayüzü için Razor görünümlerini içerir
- **Data/**: Veritabanı bağlamını ve yapılandırmalarını içerir
- **Migrations/**: Veritabanı göç dosyalarını içerir
- **wwwroot/**: CSS, JavaScript ve görseller gibi statik dosyaları içerir

## Kimlik Doğrulama
Uygulama, kimlik doğrulama ve yetkilendirme için ASP.NET Core Identity kullanır. Varsayılan yönetici kimlik bilgileri:
- Kullanıcı adı: admin@dershane.com
- Şifre: Admin123!

(Not: Bu kimlik bilgilerini üretim ortamında değiştirmelisiniz)

## Sorun Giderme
- Veritabanı göçleriyle ilgili herhangi bir sorunla karşılaşırsanız, şunları deneyin:
  ```bash
  dotnet ef database drop --force
  dotnet ef database update
  ```
- Herhangi bir izin sorunu için, SQL Server kullanıcınızın uygun izinlere sahip olduğundan emin olun

## Ek Kaynaklar
- [ASP.NET Core Dokümantasyonu](https://docs.microsoft.com/en-us/aspnet/core)
- [Entity Framework Core Dokümantasyonu](https://docs.microsoft.com/en-us/ef/core)

## Lisans
[Lisans Bilgileriniz]

## İletişim
Herhangi bir soru veya destek için, lütfen [iletişim bilgileriniz] adresine ulaşın 