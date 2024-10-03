# BookVerse: Kütüphane Yönetim Sistemi 📚

Bu proje, kitapların, yazarların ve kategorilerin yönetimini sağlayan kapsamlı bir kütüphane yönetim sistemidir. Bu proje, kütüphaneler için kullanıcı dostu bir arayüz ile kitapların takibi, yazar bilgileri ve kategorik düzenleme gibi özellikler sunarak kitap okuma deneyimini geliştirmeyi hedefler.

<p>📌Projenin frontend kısmına <a href=https://github.com/Fatmabirel/BookVerse-Frontend>buradan</a> ulaşabilirsiniz.</p>

#### GEREKSİNİMLER 🛠
- [x] Web projesi: 
  ![Asp.NET Web API](https://img.shields.io/badge/asp.net%20web%20api-%231BA3E8.svg?style=for-the-badge&logo=dotnet&logoColor=white)
  ![Angular](https://img.shields.io/badge/angular-%23DD0031.svg?style=for-the-badge&logo=angular&logoColor=white)
- [x] Veri tabanı: 
  ![PostgreSQL](https://img.shields.io/badge/postgresql-%23336791.svg?style=for-the-badge&logo=postgresql&logoColor=white)
- [x] Dökümantasyon için:
  ![Swagger](https://img.shields.io/badge/swagger-%2385EA2D.svg?style=for-the-badge&logo=swagger&logoColor=black)

#### PROJEDE KULLANILAN PROGRAMLAMA DİLLERİ VE TEKNOLOJİLER 💻🔧
<p>
  <img alt="C#" src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white" />
  <img alt=".NET" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" />
  <img alt="Entity Framework" src="https://img.shields.io/badge/entity%20framework-%2358B9C9.svg?style=for-the-badge&logo=dotnet&logoColor=white" />
</p>

#### 🎯 NASIL BİR PROJE OLUŞTURDUK?

BookVerse, kitapların, yazarların ve kategorilerin yönetimini kolaylaştıran bir kütüphane yönetim sistemi projesidir. Proje, kullanıcıların kütüphane içindeki kaynakları daha verimli bir şekilde takip etmelerini sağlamak amacıyla geliştirilmiştir.

Proje, kullanıcı dostu bir arayüz ile birlikte, arka planda güçlü bir API altyapısı kullanarak veri işlemlerini gerçekleştirmektedir. Kullanıcılar, kitapları, yazarları ve kategorileri listeleyebilir ve detaylı bilgiye erişebilirler.

Projenin bazı ana özellikleri şunlardır:

- **Kitap Listeleme**: Kullanıcılar, mevcut kitapların listesini görüntüleyebilir ve her bir kitabın bilgilerini detaylı bir şekilde inceleyebilir.
- **Yazar Listeleme**: Yazarların bilgileri hızlı bir şekilde incelenebilir.
- **Kategori Listeleme**: Kullanıcılar, mevcut kategorileri görüntüleyebilir.
- **Kullanıcı Arayüzü**: Modern ve kullanıcı dostu bir arayüz ile, listeleme işlemleri kolay ve hızlı bir şekilde gerçekleştirilebilir.

Bu proje, kütüphane yönetim süreçlerini dijitalleştirerek, hem kullanıcı deneyimini iyileştirmeyi hem de kütüphanelerin verimliliğini artırmayı hedeflemektedir.

## PROJE DETAYLARI📝

**BookVerse** projesinde, ***PostgreSQL*** veri tabanı kullanılarak **DbFirst (Veritabanı Öncelikli)** yaklaşımı benimsenmiştir. Bu yapı, mevcut veri tabanı şeması üzerinden ***Entity Framework*** aracılığıyla modellerin otomatik olarak oluşturulmasını sağlamıştır. Proje, basit bir mimari ile geliştirilmiş olup, veri tabanı işlemleri doğrudan ***Entity Framework*** kullanılarak yapılmaktadır. Backend tarafında **Controllers**, **Entities**, **DTOs** ve **Contexts** klasörleri bulunmaktadır ve bu bileşenler birbirleriyle doğrudan iletişim kurmaktadır.

### 🌱 Kitap, Yazar ve Kategori Yönetimi
Controller'lar aracılığıyla kullanıcılar kitaplar, yazarlar ve kategoriler üzerinde işlemler yapabilir.
Her bir işlem, Entity Framework'ün sunduğu CRUD işlemleriyle doğrudan ilişkilendirilmiştir. Aşağıda ***Book Entity*** sınıfı gösterilmiştir.

```csharp
 public class Book
 {
     public int id { get; set; }
     public string title { get; set; }
     public int author_id { get; set; }
     public int publication_year { get; set; }
     public int stock { get; set; }
     public int category_id { get; set; }
     public string image_url { get; set; }
     public virtual Author Author { get; set; } // Author ile ilişki
     public virtual Category Category { get; set; } // Category ile ilişki
 }
```

### 🌱 Veri Tabanı ve Entity Framework
Proje kapsamında ***PostgreSQL*** veri tabanı ile doğrudan çalışmak amacıyla ***Entity Framework Core*** kullanılmıştır. DbFirst yaklaşımı ile mevcut veri tabanı şemasına bağlı olarak 
sınıflar oluşturulmuştur. Bu sınıflar, veri tabanındaki tabloları temsil eder ve **Contexts** klasörü altındaki **DbContext** sınıfı, bu tablolar üzerinden veri
tabanı işlemlerini yürütmek için kullanılmıştır. Aşağıda BookVerse projesinin ***LibraryContext*** sınıfını görebilirsiniz.

```csharp
public class LibraryContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localHost;port=5432;Database=library;user ID=postgres; Password=123");
    }

    public DbSet<Author> authors { get; set; }
    public DbSet<Category> categories { get; set; }
    public DbSet<Book> books { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.author_id);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(b => b.category_id)
    }
}
```

### 🌱 DTO (Data Transfer Objects)
***DTOs (Data Transfer Objects)*** yapıları, veri katmanından gelen veya giden verileri taşımak için kullanılmıştır. 
Bu yapılar, yalnızca gerekli alanları frontend'e veya API'ye taşımak amacıyla sadeleştirilmiş veri modelleridir. 
Bu sayede, gereksiz büyük verilerin taşınması engellenmiş ve veri güvenliği sağlanmıştır. Aşağıda örnek olarak ***BookDto*** sınıfını görebilirsiniz.

```csharp
 public class BookDto
 {
     public int Id { get; set; }
     public string Title { get; set; }
     public string AuthorName { get; set; }
     public string CategoryName { get; set; }
     public int PublicationYear { get; set; }
     public int Stock { get; set; }
     public string ImageUrl { get; set; }
 }
```

### 🌱 Controllers
***Controllers*** klasörü, projenin ***API*** kısmını temsil eden ve ***RESTful*** prensiplerine uygun olarak geliştirilen uç noktaları (endpoint) barındırır.
Her bir controller, veri tabanındaki işlemleri yürütmek için ***Entity Framework Context*** sınıfını doğrudan kullanır ve 
CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştiren metodlara sahiptir. Aşağıda örnek olarak ***BooksController*** sınıfı örnek olarak verilmiştir. 


```csharp
public class BooksController : ControllerBase
{
    LibraryContext context = new LibraryContext();

    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var books = await context.books
             .Include(b => b.Author) 
             .Include(b => b.Category) 
             .ToListAsync();

        var bookDtos = books.Select(b => new BookDto
        {
            Id = b.id,
            Title = b.title,
            PublicationYear = b.publication_year,
            Stock = b.stock,
            ImageUrl = b.image_url,
            AuthorName = b.Author.name,
            CategoryName = b.Category.name
        }).ToList();

        return Ok(bookDtos);
    }
}
```

-----------------------------------------------------------------------
#### 🗂️ Proje Veri Tabanı Yedek Dosyası

Projenin PostgreSQL veri tabanı yedek dosyasını aşağıdaki linkten indirebilirsiniz. Bu dosya, BookVerse projesine ait tüm kitaplar, yazarlar, kategoriler ve diğer veri tabanı yapılarıyla birlikte gelir. Dosyayı indirerek yerel ortamınızda projeyi çalıştırabilirsiniz.

📥 **[Veri Tabanı Yedeğini İndir]**(https://drive.google.com/file/d/1oZ0bdF02bcGN3CsZZSUKmiUfjf4Rn-FY/view?usp=drive_link)


Görüşürüz 🎉
