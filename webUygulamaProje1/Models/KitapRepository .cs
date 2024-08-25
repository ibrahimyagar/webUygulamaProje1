using webUygulamaProje1.Utility;

namespace webUygulamaProje1.Models
{
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        private  UygulamaDbContext _uygulamaDbContext;
        public KitapRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Kitap kitap)
        {
           _uygulamaDbContext.Update(kitap);
        }

        public void kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
