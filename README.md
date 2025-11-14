# ASP.NET MVC Blog Yönetim Sistemi

📌 Ziyaretçi + Yazar + Admin Rollerini Destekleyen Profesyonel Blog Platformu  
📌 MVC 5.2.9 • EF 6.5 • Repository Pattern • Katmanlı Mimari • MSSQL Server 2022 Express Edition

---

## 👀 Ziyaretçi (Kullanıcı) Neler Görebilir?

Giren herhangi biri şu özellikleri kullanabilir:

- 📰 Tüm blogları liste halinde görebilir
- 📄 Blog detay sayfasını okuyabilir
- 💬 Bloglara yorum yapabilir
- 🔍 Yazar profillerini görüntüleyebilir

> Ziyaretçiler sadece okur ve yorum yapar. Blog ekleme sadece yazar hakkıdır.

---

## ✍️ Yazar Paneli – Yazar Ne Yapabilir?

Kullanıcı Yazar Paneli’ne giriş yaparak şu işlemleri gerçekleştirir:

- ➕ Yeni blog ekler
- 📝 Yazdığı blogları düzenler
- 🗑️ Blog siler
- 👤 Kendi profil bilgilerini günceller
- 💬 Bloglarına yapılan yorumları yönetir
- 📊 Yazar dashboard’unda kısa özetleri görür

> Yazar sadece kendi içeriklerini yönetir.

---

## 🛡️ Admin Paneli – Admin Neler Yapabilir?

Admin tüm sistemi kontrol eder:

- 👥 Yazar ve kullanıcı yönetimi
- ✍️ Blog yönetimi (onay, düzenleme, silme)
- 📊 Dashboard grafikleri (kategori/blog/yorum grafikleri)
- 📬 Mail gönderme paneli
- 🗂️ Kategori yönetimi
- 💬 Yorum yönetimi

> Admin her şeye erişir—tam yetkili kullanıcıdır.

---

## 📸 Ekran Görselleri

### 🖥️ Ziyaretçi & Blog Arayüzleri
<p align="center">
<img width="1897" height="799" alt="Blog_Liste" src="https://github.com/user-attachments/assets/aed40a07-5c6c-4497-8074-51914339f4f0" />
<img width="1913" height="830" alt="Blog_Detay" src="https://github.com/user-attachments/assets/2179e4cb-4421-4497-9c06-fb002d34f6f4" />


### ✍️ Yazar Paneli
<p align="center">
<img src="Images/YazarBlog_Liste.jpeg" width="330" />
<img src="Images/Yazar_Bilgi.jpeg" width="330" />
</p>
<p align="center">
<img src="Images/Yazar_Yorum.jpeg" width="330" />
<img src="Images/Yazar_PanelGirisYap.jpeg" width="330" />
</p>

### 🛡️ Admin Paneli
<p align="center">
<img src="Images/Admin_AnaSayfa.jpeg" width="330" />
<img src="Images/Admin_YazarIslemleri.jpeg" width="330" />
</p>
<p align="center">
<img src="Images/Blog_Grafik.jpeg" width="330" />
<img src="Images/Admin_Mail.jpeg" width="330" />
</p>

---

## 🏗️ Mimari Yapı (Katmanlı Mimari + Repository Pattern)

BlogProject
│
├── 📂 EntityLayer → Tüm entity (model) sınıfları
├── 📂 DataAccessLayer → EF, Repository, Context
├── 📂 BusinessLayer → Service + Manager yapıları
├── 📂 UI (MVC) → Controller + View + Images
└── 📂 Core → Ortak altyapı

yaml
Kodu kopyala

- ✔ Temiz kod  
- ✔ Bağımlılıkları azaltan yapı  
- ✔ Gerçek kurumsal mimariye yakın tasarım  

---

## 🧩 Kullanılan Teknolojiler

| Teknoloji              | Sürüm |
|------------------------|-------|
| ASP.NET MVC            | 5.2.9 |
| Entity Framework       | 6.5   |
| MSSQL Server           | 2022 Express Edition |
| Repository Pattern     | ✔     |
| N-Tier Architecture    | ✔     |
| Bootstrap 4            | ✔     |
| LINQ                   | ✔     |
| Chart.js               | ✔     |

---

## ⚙️ Kurulum

1️⃣ Projeyi klonla:  
```bash
git clone https://github.com/kullaniciadi/BlogProject.git
2️⃣ SQL bağlantısını yap (DataAccessLayer/Context.cs):

public BlogContext() : base("server=.;database=BlogDb;integrated security=true")
{
}
3️⃣ Migration işlemi (EF 6.5):

powershell
Kodu kopyala
Enable-Migrations
Add-Migration InitialCreate
Update-Database
4️⃣ Çalıştır:

Visual Studio

IIS Express

🔐 Giriş Bilgileri (Varsayılan)
Rol	Kullanıcı	Şifre
Admin	admin@gmail.com	1234
Yazar	emrehac66@gmail.com	Emre'123


