using AYS_DAL.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AYS_DAL.Data
{
    /// <summary>
    /// Bu sayfa içerisinde veri tabanı bağlantıları yapılır entityFrameworkCore pakedi üzerinden gelen
    /// DbContext sınıfından bağlantı alınarak onConfiguring üzerinden veri tabanı sunucusuna bağlanılır.
    /// </summary>
    public class AYS_DBContext : DbContext
    {
        // Burada admin sınıfının veritabanı içerisinde admins adında bir tabloyla eşleşeceği anlamını taşır
        // bu yapı codefirst yapısı olduğundan burda belirtilene göre bir tablo oluşturulur.
        // bu aşamada dbset oluşturulduğunda migration atmak gerekir database içerisinde eklenen entity propları gözükür.
        public DbSet<Admin> Admins
        {
            get; set;
        }
        public DbSet<Album> Albums
        {
            get; set;
        }

        // gelen sifre metnini sha yapısına göre şifreler
        private string sha256_hash(string sifre)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(sifre)).Select(l => l.ToString("X2")));
            }
        }
        /// <summary>
        /// OnmodelCreating yapısı oluşturulan dbsetler için seed data yani çekirdek data oluşturmamızı sağlar.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // seed datalar girlirken id verilmeleri zorunludur ve dikkat edilmesi gerekir.
            modelBuilder.Entity<Admin>().HasData(
                 new Admin()
                 {
                     Id = 1,
                     IsActive = true,
                     Name = "mustafa",
                     Password = sha256_hash("123456m"),
                     CreatedDate = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                 },
                 new Admin()
                 {
                     Id = 2,
                     IsActive = true,
                     Name = "yonca",
                     Password = sha256_hash("123456m"),
                     CreatedDate = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                 },
                 new Admin()
                 {
                     Id = 3,
                     IsActive = true,
                     Name = "göksel",
                     Password = sha256_hash("123456m"),
                     CreatedDate = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                 });

            modelBuilder.Entity<Album>().HasData(
                new Album()
                {
                    Id = 1,
                    Name = "Mesafe",
                    Artist = "Serdar Ortaç",
                    ReleaseDate = new DateOnly(2006, 01, 05),
                    Price = 55,
                    Discount = 0,
                    Status = true,
                    CreatedDate = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                },
                new Album()
                {
                    Id = 2,
                    Name = "Onyedi",
                    Artist = "Teoman",
                    ReleaseDate = new DateOnly(2000, 04, 28),
                    Price = 955,
                    Discount = 0,
                    Status = true,
                    CreatedDate = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                },
                new Album()
                {
                    Id = 3,
                    Name = "Touch",
                    Artist = "Eurythmics",
                    ReleaseDate = new DateOnly(1983, 01, 01),
                    Price = 455,
                    Discount = 0,
                    Status = true,
                    CreatedDate = new DateTime(2024, 10, 10, 11, 43,33, 234, DateTimeKind.Local).AddTicks(5286),
                }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Server=DESKTOP-U76CSFK\\ANK18MSSQLSERVER;Database=AYSDb;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(conn);
        }
    }
}
