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
<img width="1916" height="747" alt="YazarBlog_Liste" src="https://github.com/user-attachments/assets/c4c92eeb-aaa8-4775-a1da-03a97e9d83b5" />
<img width="1919" height="871" alt="Yazar_Bilgi" src="https://github.com/user-attachments/assets/f4e923b5-d5bc-498a-9145-ff370fd854bd" />
</p>
<p align="center">
<img width="1912" height="598" alt="Yazar_Yorum" src="https://github.com/user-attachments/assets/4d74e9dc-12d4-49e7-a26e-040b11edd4f8" />
<img width="1904" height="753" alt="Yazar_PanelGirisYap" src="https://github.com/user-attachments/assets/3722ef64-afc3-46da-ae47-cf91eaa9ecc6" />
</p>

### 🛡️ Admin Paneli

<p align="center">
<img width="1911" height="816" alt="Admin_AnaSayfa" src="https://github.com/user-attachments/assets/71d9e4e0-f8ac-4ce0-a3bb-56c4bd90ae43" />
<img width="1918" height="866" alt="Admin_YazarIslemleri" src="https://github.com/user-attachments/assets/9dd5ce68-c21b-4194-b6a8-c648bda89836" />
</p>
<p align="center">
<img width="1912" height="740" alt="Admin_PanelGirisYap" src="https://github.com/user-attachments/assets/364445b4-0377-4618-b8df-6c85e23d4bb9" />
<img width="1910" height="882" alt="Blog_Grafik" src="https://github.com/user-attachments/assets/e468d6d0-6719-4ed2-b83d-de5fea283359" />
<img width="1913" height="814" alt="Admin_Mail" src="https://github.com/user-attachments/assets/dc02d4d8-0266-4612-b6d7-f0e4bbb29ca5" />
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





