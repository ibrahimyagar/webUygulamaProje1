using webUygulamaProje1.Utility;

namespace webUygulamaProje1.Models
{
    public interface IKitapTuruRepository:IRepository<KitapTuru>
    {
        void Guncelle(KitapTuru kitapTuru);
        void kaydet();
    }
}

