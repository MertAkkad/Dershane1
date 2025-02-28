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
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (`dotnet tool install --global dotnet-ef`)

## Kurulum Talimatları

### 1. Repository'i Klonlama
```bash
git clone [repository-url]
cd Dershane1
```

### 2. Veritabanı Kurulumu
Uygulama, Entity Framework Core Code-First yaklaşımını kullanır. Veritabanını kurmak için:

#### SQL Server Yapılandırması:
1. SQL Server Management Studio'yu (SSMS) açın veya tercih ettiğiniz SQL Server yönetim aracını kullanın
2. Yeni bir veritabanı oluşturun (örneğin 'DershaneDB')
3. Veritabanına erişmek için bir kullanıcı oluşturun veya Windows kimlik doğrulaması kullanın

#### Bağlantı dizesini güncelleyin:
`appsettings.json` dosyasındaki bağlantı dizesini SQL Server örneğinize uygun şekilde güncelleyin:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SUNUCU_ADI;Database=DershaneDB;User Id=KULLANICI_ADI;Password=SIFRE;TrustServerCertificate=True;"
}
```

Windows kimlik doğrulaması kullanıyorsanız:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SUNUCU_ADI;Database=DershaneDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Burada:
- SUNUCU_ADI: SQL Server örneğinizin adı (örn. "localhost" veya "localhost\\SQLEXPRESS")
- DershaneDB: Oluşturduğunuz veritabanının adı
- KULLANICI_ADI ve SIFRE: SQL Server kullanıcı kimlik bilgileriniz (SQL kimlik doğrulaması kullanıyorsanız)

#### Entity Framework Migrasyon Adımları:

1. **Entity Framework Core Tools Kurulumu** (eğer kurulu değilse):
```bash
dotnet tool install --global dotnet-ef
```

2. **Mevcut Migrasyonları Kontrol Etme**:
```bash
dotnet ef migrations list
```

3. **Eğer migrasyonlar mevcut değilse, ilk migrasyonu oluşturun**:
```bash
dotnet ef migrations add InitialCreate
```

4. **Veritabanını Güncelleyin**:
```bash
dotnet ef database update
```

5. **İleri düzey kullanıcılar için komutlar**:
   - Belirli bir migrasyona kadar veritabanını güncellemek için:
   ```bash
   dotnet ef database update MigrasyonAdı
   ```
   - Migrasyona ait SQL komutlarını görmek için:
   ```bash
   dotnet ef migrations script
   ```
   - Veritabanını sıfırlamak için:
   ```bash
   dotnet ef database drop --force
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
  dotnet ef migrations remove // Son migrasyonu kaldırmak için
  dotnet ef migrations add YeniMigrasyon
  dotnet ef database update
  ```
- SQL Server bağlantı sorunları için:
  - SQL Server hizmetinin çalıştığından emin olun
  - Bağlantı dizesinin doğru formatta olduğunu kontrol edin
  - SQL Server kimlik bilgilerinizin doğru olduğundan emin olun
  - Firewall ayarlarının SQL Server bağlantısına izin verdiğinden emin olun
- Herhangi bir izin sorunu için, SQL Server kullanıcınızın uygun izinlere sahip olduğundan emin olun (db_owner rolü genellikle yeterlidir)

## Ek Kaynaklar
- [ASP.NET Core Dokümantasyonu](https://docs.microsoft.com/en-us/aspnet/core)
- [Entity Framework Core Dokümantasyonu](https://docs.microsoft.com/en-us/ef/core)
- [Entity Framework Core Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/)

## Lisans
[Lisans Bilgileriniz]

## İletişim
Herhangi bir soru veya destek için, lütfen [iletişim bilgileriniz] adresine ulaşın 