# CodeShareClone

**Gerçek zamanlı kod paylaşım uygulaması.** ASP.NET Core MVC + SignalR + SQLite ile yazılmıştır. Aynı bağlantı linkini açan birden çok kişi, kodu canlı olarak senkronize eder; yazdığınız içerik anında diğerlerinde görünür ve veritabanına kaydedilir.

> Pastebin benzeri, ama canlı senkronize çalışan basit bir kod editörü.

---

## 🚀 Özellikler

- **Gerçek zamanlı senkronizasyon** — SignalR ile aynı odaya (oda = kod ID'si) bağlı tüm tarayıcılar anlık güncellenir.
- **Otomatik kaydetme** — Yazdığınız kod debounce ile (800 ms) `codes.db` SQLite veritabanına kaydedilir. Sayfayı kapatsanız bile kalıcıdır.
- **Paylaşılabilir link** — Her kod parçası benzersiz bir GUID ile oluşturulur. Linki paylaşan herkes aynı kodu canlı görür.
- **Satır numarası + Tab desteği** — Basit ama işlevsel editör deneyimi.
- **Listeleme & Silme** — Kayıtlı tüm kodları görüntüleme, tek tıkla silme.
- **Karanlık tema** — Göz yormayan arayüz.

---

## 🧰 Teknolojiler

| Katman | Teknoloji |
|--------|-----------|
| Backend | ASP.NET Core 6.0 (net6.0) MVC |
| Gerçek zamanlı | SignalR (`Microsoft.AspNetCore.SignalR`) |
| Veritabanı | SQLite + Entity Framework Core 6.0 |
| Frontend | Razor Views, Bootstrap 5, jQuery |
| Editör istemci | `@microsoft/signalr` (CDN) |

---

## 📋 Gereksinimler

- **[.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)** (proje `net6.0` hedefler — 8.0 değil)
- EF Core araçları (veritabanı güncellemesi için): `dotnet tool install --global dotnet-ef`

> Makinenizde .NET SDK yoksa [buradan indirin](https://dotnet.microsoft.com/download/dotnet/6.0). Sürü kontrolü: `dotnet --version`.

---

## ⚙️ Kurulum & Çalıştırma

```bash
# 1. Repoyu klonla
git clone https://github.com/<kullanici-adin>/CodeShareClone.git
cd CodeShareClone

# 2. Bağımlılıkları geri yükle
dotnet restore

# 3. Veritabanını oluştur (migration'ları uygula)
cd CodeShareClone
dotnet ef database update

# 4. Uygulamayı çalıştır
dotnet run
```

Uygulama çalışınca tarayıcıda aç:

- **HTTPS:** https://localhost:7209
- **HTTP:** http://localhost:5192

Geliştirme sertifikası ilk açılışta uyarı verirse, "Gelişmiş → Yine de devam et" diyerek geçin (yerel dev sertifikası).

> **Veritabanı konumu:** SQLite dosyası `CodeShareClone/codes.db` olarak oluşturulur. Silinirse uygulama veri kaybeder; migration yeniden çalıştırınca sıfırdan kurulur.

---

## 🎯 Kullanım

1. Ana sayfadaki **"Share code now!"** butonuna tıkla → yeni boş kod otomatik oluşturulur ve editöre yönlendirilirsin.
2. Editöre kod yaz. Aynı linki başka bir tarayıcıda/sekmekte açtığında yazdığın anında orada da görünür.
3. Linki kopyala (`/Share/<GUID>`) ve paylaş.
4. **"List of codes"** menüsünden tüm kayıtlı kodları gör, "View" ile aç, "Delete" ile sil.

---

## 🗂️ Proje Yapısı

```
CodeShareClone/
├── CodeShareClone.sln
├── README.md
└── CodeShareClone/
    ├── Program.cs              # Uygulama başlangıç (DI, SignalR, EF, routing)
    ├── CodeShareClone.csproj   # Paket referansları
    ├── appsettings.json        # Bağlantı dizesi (codes.db)
    ├── Hubs/
    │   └── CodeHub.cs          # SignalR hub: JoinRoom, BroadcastContent, PersistContent
    ├── Controllers/
    │   ├── HomeController.cs   # Ana sayfa, Privacy
    │   └── ShareController.cs  # Create, Listele, ViewCode, Sil
    ├── Models/
    │   ├── Code.cs             # Kod entity (Id, Content)
    │   └── AppDbContext.cs     # EF DbContext
    ├── Migrations/             # EF migration'ları
    └── Views/                  # Razor görünümleri
        ├── Home/, Share/
        └── Shared/_Layout.cshtml
```

### SignalR Akışı

```
Kullanıcı yaz → throttledBroadcast (60ms) → diğer oda üyelerine anlık gönder
             → debouncedPersist (800ms) → veritabanına kaydet
```

- **Throttle (60 ms):** Yazma sırasında flood'u önler, canlı senkron akıcı kalır.
- **Debounce (800 ms):** Yazmayı bırakınca veritabanına kaydeder.

---

## 🔧 Sorun Giderme

| Sorun | Çözüm |
|-------|-------|
| `No .NET SDKs were found` | [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) yüklü değil. |
| `dotnet ef` komutu yok | `dotnet tool install --global dotnet-ef` |
| HTTPS sertifikası hatası | `dotnet dev-certs https --trust` |
| SignalR bağlanmıyor | Tarayıcı konsolunu aç; CDN erişimini kontrol et. |
| Veritabanı sıfırlansın | `codes.db` dosyasını sil, `dotnet ef database update` yeniden çalıştır. |

---

## 📄 Lisans

Bu proje eğitim/dem amaçlıdır. Dilediğiniz gibi kullanabilirsiniz.

---

## 👤 Yazar

**Dark Creative** — GitHub repository linki eklendiğinde burada görünür.
