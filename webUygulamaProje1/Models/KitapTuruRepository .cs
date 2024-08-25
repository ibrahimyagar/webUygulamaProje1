using webUygulamaProje1.Utility;

namespace webUygulamaProje1.Models
{
    public class KitapTuruRepository : Repository<KitapTuru>, IKitapTuruRepository
    {
        private  UygulamaDbContext _uygulamaDbContext;
        public KitapTuruRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(KitapTuru kitapTuru)
        {
           _uygulamaDbContext.Update(kitapTuru);
        }

        public void kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
