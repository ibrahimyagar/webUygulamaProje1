using Microsoft.EntityFrameworkCore;
using webUygulamaProje1.Models;

namespace webUygulamaProje1.Utility
{
    public class UygulamaDbContext:DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext>options):base(options) { }
        public DbSet<KitapTuru>KitapTurleri { get; set; }
        public DbSet<Kitap> Kitaplar {  get; set; }
    }
}
