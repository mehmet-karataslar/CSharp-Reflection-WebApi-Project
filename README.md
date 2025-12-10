# C# Temelleri, Reflection ve ASP.NET Core Web API Entegrasyonu

Modern yazılım geliştirme tekniklerini bütüncül bir senaryo içerisinde birleştiren kapsamlı bir C# projesi. Bu proje, Struct, Exception Handling, Attribute ve Reflection gibi temel C# konseptlerini, ASP.NET Core Web API mimarisi (Middleware, Filters, Routing) ile harmanlayarak çalışır bir sistem ortaya koymaktadır.

## 📋 İçindekiler

- [Proje Yapısı](#proje-yapısı)
- [Özellikler](#özellikler)
- [Teknolojiler](#teknolojiler)
- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Proje Bileşenleri](#proje-bileşenleri)
- [Örnek Senaryolar](#örnek-senaryolar)
- [API Endpoint'leri](#api-endpointleri)
- [Geliştirici Bilgileri](#geliştirici-bilgileri)

## 🏗️ Proje Yapısı

```
Odev5/
├── ConsoleApp/              # Windows Forms Uygulaması
│   ├── Student.cs           # Struct örneği
│   ├── ObsoleteExample.cs   # Obsolete attribute örnekleri
│   ├── DeveloperInfoAttribute.cs  # Custom attribute
│   ├── ExampleClass.cs      # Reflection için örnek sınıf
│   ├── MainForm.cs          # Ana form (4 sekme)
│   └── Program.cs           # Giriş noktası
│
└── WebApi/                  # ASP.NET Core Web API
    ├── Controllers/
    │   ├── ProductsController.cs   # CRUD işlemleri
    │   └── SystemController.cs      # Reflection endpoint
    ├── Models/
    │   ├── ProductDto.cs           # Validasyonlu model
    │   ├── ErrorResponse.cs        # Hata yanıt modeli
    │   └── ControllerMetadata.cs   # Metadata modelleri
    ├── Middleware/
    │   └── RequestLoggingMiddleware.cs  # Request/Response loglama
    ├── Filters/
    │   ├── PerformanceActionFilter.cs   # Performans ölçümü
    │   └── GlobalExceptionFilter.cs     # Global hata yakalama
    └── Program.cs           # API yapılandırması
```

## ✨ Özellikler

### BÖLÜM 1: Windows Forms Uygulaması

#### 1.1. Struct ve Değer Tipleri
- `Student` struct'ı ile değer tipi örneği
- Id, Name, Gpa alanları
- ListBox ile görsel gösterim
- Değer tipi davranışının gözlemlenmesi

#### 1.2. Exception Handling
- Try/Catch/Finally yapısı
- `DivideByZeroException` yakalama
- `FormatException` yakalama
- Etkileşimli form ile kullanıcı girişi
- Finally bloğunun her durumda çalıştığının kanıtlanması

#### 1.3. Obsolete Attribute
- İki farklı Obsolete kullanımı:
  - **Uyarı (Warning)**: `[Obsolete(..., false)]` - Derleme uyarısı verir
  - **Hata (Error)**: `[Obsolete(..., true)]` - Derleme hatası verir (yorum satırında)
- Butonlar ile metot çağrıları

#### 1.4. Custom Attribute ve Reflection
- `DeveloperInfoAttribute` custom attribute sınıfı
- Reflection ile sınıf ve metot analizi
- Attribute değerlerinin okunması
- Detaylı Reflection raporu (RichTextBox ile formatlanmış)

### BÖLÜM 2: ASP.NET Core Web API

#### 2.1. Model Validasyon ve Controller
- `ProductDto` modeli ile validation attribute'ları:
  - `[Required]` - Zorunlu alan kontrolü
  - `[Range]` - Aralık kontrolü
  - `[StringLength]` - String uzunluk kontrolü
- `ProductsController` ile CRUD işlemleri:
  - `GET /api/products` - Tüm ürünleri listele
  - `GET /api/products/{id}` - ID ile ürün getir
  - `POST /api/products` - Yeni ürün ekle
  - `DELETE /api/products/{id}` - Ürün sil

#### 2.2. Middleware ve Filter Mimarisi

**Custom Middleware (RequestLoggingMiddleware)**
- Her gelen isteğin HTTP metodunu loglama
- URL yolunu loglama
- İstek zamanını loglama
- Response Status Code bilgisini loglama

**Action Filter (PerformanceActionFilter)**
- Action başlangıç zamanını kaydetme
- Action bitiş zamanını ölçme
- Geçen süreyi milisaniye cinsinden hesaplama
- Konsola performans bilgisi yazdırma

**Exception Filter (GlobalExceptionFilter)**
- API genelinde beklenmeyen hataları yakalama
- Standart JSON hata modeli döndürme
- Development ortamında StackTrace bilgisi
- Production ortamında güvenli hata mesajları

#### 2.3. İleri Seviye: Metadata Haritası (Reflection Endpoint)

**SystemController - `/api/system/attribute-map`**
- Reflection kullanarak tüm controller'ları bulma
- Her controller'daki action metotlarını listeleme
- HTTP attribute'larını analiz etme (`[HttpGet]`, `[HttpPost]`, vb.)
- Detaylı JSON metadata döndürme
- Controller ve action bilgilerini içeren kapsamlı harita

## 🛠️ Teknolojiler

- **.NET 8.0** - Framework
- **C# 12** - Programlama dili
- **Windows Forms** - Desktop uygulama arayüzü
- **ASP.NET Core Web API** - RESTful API
- **Reflection** - Runtime tip analizi
- **Attributes** - Metadata ve validasyon

## 📦 Kurulum

### Gereksinimler
- .NET 8.0 SDK veya üzeri
- Visual Studio 2022 veya Visual Studio Code
- Windows işletim sistemi (Windows Forms için)

### Adımlar

1. **Repository'yi klonlayın:**
```bash
git clone https://github.com/mehmet-karataslar/CSharp-Reflection-WebApi-Project.git
cd CSharp-Reflection-WebApi-Project
```

2. **Projeyi derleyin:**
```bash
dotnet restore
dotnet build
```

3. **Windows Forms uygulamasını çalıştırın:**
```bash
dotnet run --project ConsoleApp
```

4. **Web API'yi çalıştırın:**
```bash
dotnet run --project WebApi
```

API varsayılan olarak `https://localhost:5001` veya `http://localhost:5000` adresinde çalışacaktır.

## 🚀 Kullanım

### Windows Forms Uygulaması

Uygulama açıldığında 4 sekme görürsünüz:

1. **Struct ve Değer Tipleri**: "Öğrencileri Göster" butonuna tıklayarak struct örneklerini görüntüleyin.

2. **Exception Handling**: İki sayı girin ve "Bölme İşlemi Yap" butonuna tıklayın. Sıfıra bölme veya geçersiz format hatalarını test edin.

3. **Obsolete Attribute**: Eski ve yeni metotları test edin. Eski metot çağrısında uyarı göreceksiniz.

4. **Reflection Raporu**: "Reflection Raporu Oluştur" butonuna tıklayarak custom attribute'ları ve metot bilgilerini görüntüleyin.

### Web API Kullanımı

#### Postman veya HTTP İstemcisi ile Test

**1. Tüm Ürünleri Listele:**
```http
GET https://localhost:5001/api/products
```

**2. ID ile Ürün Getir:**
```http
GET https://localhost:5001/api/products/1
```

**3. Yeni Ürün Ekle:**
```http
POST https://localhost:5001/api/products
Content-Type: application/json

{
  "name": "Yeni Ürün",
  "description": "Ürün açıklaması",
  "price": 99.99,
  "stock": 50
}
```

**4. Ürün Sil:**
```http
DELETE https://localhost:5001/api/products/1
```

**5. Reflection Metadata Haritası:**
```http
GET https://localhost:5001/api/system/attribute-map
```

## 📚 Proje Bileşenleri

### ConsoleApp Bileşenleri

#### Student.cs
```csharp
public struct Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Gpa { get; set; }
}
```
Değer tipi (value type) örneği. Struct'lar stack'te saklanır ve kopyalanır.

#### DeveloperInfoAttribute.cs
```csharp
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class DeveloperInfoAttribute : Attribute
{
    public string DeveloperName { get; }
    public string Version { get; }
    public string Description { get; }
    public DateTime CreatedDate { get; }
}
```
Custom attribute sınıfı. Sınıf ve metotlara geliştirici bilgisi ekler.

#### ExampleClass.cs
Reflection analizi için örnek sınıf. 3 metodu `DeveloperInfoAttribute` ile işaretlenmiştir.

### WebApi Bileşenleri

#### ProductDto.cs
Validation attribute'ları ile donatılmış DTO modeli:
- `[Required]` - Name ve Price zorunlu
- `[StringLength(100)]` - Name maksimum 100 karakter
- `[Range(0.01, 1000000)]` - Price aralığı kontrolü

#### RequestLoggingMiddleware.cs
Her HTTP isteğini ve yanıtını loglayan middleware. Pipeline'ın en başında çalışır.

#### PerformanceActionFilter.cs
Action'ların çalışma süresini ölçen filter. Her action için milisaniye cinsinden süre bilgisi verir.

#### GlobalExceptionFilter.cs
Tüm beklenmeyen hataları yakalayan global filter. Standart `ErrorResponse` modeli döndürür.

#### SystemController.cs
Reflection kullanarak API'nin kendi yapısını analiz eden controller. Tüm controller'ları, action'ları ve HTTP attribute'larını listeler.

## 🎯 Örnek Senaryolar

### Senaryo 1: Struct Değer Tipi Davranışı

**Amaç**: Struct'ların değer tipi olarak nasıl davrandığını göstermek.

**Adımlar**:
1. Windows Forms uygulamasını açın
2. "Struct ve Değer Tipleri" sekmesine gidin
3. "Öğrencileri Göster" butonuna tıklayın
4. ListBox'ta 3 öğrenci görüntülenecek

**Sonuç**: Her öğrenci bağımsız bir kopya olarak saklanır. Struct'lar değer tipi olduğu için referans değil, değer kopyalanır.

### Senaryo 2: Exception Handling Testi

**Amaç**: Farklı exception türlerini yakalamak ve finally bloğunun çalıştığını kanıtlamak.

**Test 1 - FormatException**:
1. "Exception Handling" sekmesine gidin
2. Birinci sayı: `abc` (geçersiz format)
3. İkinci sayı: `5`
4. "Bölme İşlemi Yap" butonuna tıklayın
5. **Sonuç**: FormatException yakalanır, hata mesajı gösterilir, finally bloğu çalışır

**Test 2 - DivideByZeroException**:
1. Birinci sayı: `10`
2. İkinci sayı: `0`
3. "Bölme İşlemi Yap" butonuna tıklayın
4. **Sonuç**: DivideByZeroException yakalanır, hata mesajı gösterilir, finally bloğu çalışır

**Test 3 - Başarılı İşlem**:
1. Birinci sayı: `20`
2. İkinci sayı: `4`
3. "Bölme İşlemi Yap" butonuna tıklayın
4. **Sonuç**: İşlem başarılı, sonuç gösterilir, finally bloğu çalışır

### Senaryo 3: Reflection ile Metadata Analizi

**Amaç**: Custom attribute'ları Reflection ile okumak.

**Adımlar**:
1. Windows Forms uygulamasında "Reflection Raporu" sekmesine gidin
2. "Reflection Raporu Oluştur" butonuna tıklayın
3. RichTextBox'ta detaylı rapor görüntülenecek:
   - Sınıf bilgileri (ad, namespace, tip)
   - Sınıf üzerindeki attribute bilgileri
   - Tüm metotlar ve parametreleri
   - Her metot üzerindeki attribute bilgileri

**Sonuç**: Reflection sayesinde runtime'da tip bilgilerine ve attribute'lara erişilebilir.

### Senaryo 4: Web API CRUD İşlemleri

**Amaç**: RESTful API endpoint'lerini test etmek.

**Test 1 - Ürün Listeleme**:
```bash
GET /api/products
```
**Yanıt**: Tüm ürünlerin listesi (JSON)

**Test 2 - Ürün Ekleme (Validasyon Başarılı)**:
```bash
POST /api/products
Content-Type: application/json

{
  "name": "Tablet",
  "description": "Yüksek performanslı tablet",
  "price": 2500.00,
  "stock": 15
}
```
**Yanıt**: 201 Created - Yeni oluşturulan ürün

**Test 3 - Ürün Ekleme (Validasyon Hatası)**:
```bash
POST /api/products
Content-Type: application/json

{
  "name": "AB",  // Çok kısa (min 3 karakter)
  "price": -10   // Negatif fiyat
}
```
**Yanıt**: 400 Bad Request - Validasyon hata mesajları

### Senaryo 5: Middleware ve Filter Testi

**Amaç**: Middleware ve filter'ların çalıştığını doğrulamak.

**Test**:
1. Web API'yi çalıştırın
2. Herhangi bir endpoint'e istek atın
3. Konsol çıktısını kontrol edin:

**Middleware Çıktısı**:
```
>>> GELEN İSTEK - Metod: GET, URL: /api/products, Zaman: 2024-01-15 10:30:45.123
<<< DÖNEN YANIT - Status Code: 200, Zaman: 2024-01-15 10:30:45.456
```

**Filter Çıktısı**:
```
[PERFORMANCE] Controller: Products, Action: GetAll, Süre: 2.34 ms
```

### Senaryo 6: Reflection Endpoint ile API Haritası

**Amaç**: API'nin kendi yapısını analiz etmek.

**İstek**:
```bash
GET /api/system/attribute-map
```

**Yanıt Örneği**:
```json
{
  "timestamp": "2024-01-15T10:30:45Z",
  "total_controllers": 2,
  "controllers": [
    {
      "controllerName": "Products",
      "fullName": "WebApi.Controllers.ProductsController",
      "actions": [
        {
          "actionName": "GetAll",
          "returnType": "ActionResult`1",
          "httpMethods": ["GET"],
          "attributes": ["HttpGetAttribute"],
          "parameters": []
        },
        {
          "actionName": "GetById",
          "returnType": "ActionResult`1",
          "httpMethods": ["GET"],
          "attributes": ["HttpGetAttribute"],
          "parameters": [
            {
              "name": "id",
              "type": "Int32"
            }
          ]
        }
      ]
    }
  ]
}
```

## 🔌 API Endpoint'leri

### Products Controller

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/products` | Tüm ürünleri listele |
| GET | `/api/products/{id}` | ID ile ürün getir |
| POST | `/api/products` | Yeni ürün ekle |
| DELETE | `/api/products/{id}` | Ürün sil |

### System Controller

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/system/attribute-map` | Reflection ile API metadata haritası |

## 📝 Kod Örnekleri

### Custom Attribute Kullanımı

```csharp
[DeveloperInfo("Ahmet Yılmaz", "1.0.0", "Bu sınıf reflection örneği için oluşturulmuştur")]
public class ExampleClass
{
    [DeveloperInfo("Ahmet Yılmaz", "1.0.0", "Toplama işlemi yapan metot")]
    public int Topla(int a, int b)
    {
        return a + b;
    }
}
```

### Reflection ile Attribute Okuma

```csharp
Type type = typeof(ExampleClass);
var attributes = type.GetCustomAttributes(typeof(DeveloperInfoAttribute), false);
foreach (DeveloperInfoAttribute attr in attributes)
{
    Console.WriteLine($"Geliştirici: {attr.DeveloperName}");
    Console.WriteLine($"Versiyon: {attr.Version}");
}
```

### Middleware Kullanımı

```csharp
app.UseMiddleware<RequestLoggingMiddleware>();
```

### Global Filter Kaydı

```csharp
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<PerformanceActionFilter>();
});
```

## 🐛 Hata Ayıklama

### Yaygın Sorunlar

1. **Port Çakışması**: Web API başlatılamıyorsa, `launchSettings.json` dosyasındaki port numaralarını değiştirin.

2. **Windows Forms Çalışmıyor**: .NET 8.0 Windows Desktop Runtime'ın yüklü olduğundan emin olun.

3. **Reflection Hatası**: `System.Reflection` namespace'inin import edildiğinden emin olun.

## 📄 Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

## 👤 Geliştirici Bilgileri

**Geliştirici**: Mehmet Karataşlar  
**E-posta**: mehmetkarataslar@gmail.com  
**Proje**: C# Temelleri, Reflection ve ASP.NET Core Web API Entegrasyonu

## 🙏 Teşekkürler

Bu proje, modern C# ve ASP.NET Core tekniklerini öğrenmek ve uygulamak için kapsamlı bir örnek sunmaktadır.

---

**Not**: Bu proje eğitim amaçlıdır ve production ortamında kullanılmadan önce güvenlik ve performans iyileştirmeleri yapılmalıdır.

