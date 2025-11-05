using Microsoft.AspNetCore.Mvc;
using webUygulamaProje1.Models;
using webUygulamaProje1.Utility;

namespace webUygulamaProje1.Controllers
{
    public class KitapTuruController : Controller
    {
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapTuruController(IKitapTuruRepository context)
        {
            _kitapTuruRepository = context;
        }

        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _kitapTuruRepository.GetAll().ToList();
            return View(objKitapTuruList);
        }


        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(KitapTuru kitapTuru)  //yeni kitap türü ekledik
        {
            if (ModelState.IsValid)   //KitapTuru.cs de belirttiğimiz özelliklere uygunsa devam ettir. bu şekilde programın çökmesi engellenir
            {

                _kitapTuruRepository.Ekle(kitapTuru);
                _kitapTuruRepository.kaydet();
                TempData["basarili"] = "Yeni Kitap Türü Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();
        }
        public IActionResult Guncelle(int? id)
        {
            if(id == null|| id == 0)
            {

            return NotFound(); }
            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u=>u.Id==id);
            if (kitapTuruVt == null)
            {
                return NotFound(); 
            }

            return View(kitapTuruVt);
        }
        [HttpPost]
        public IActionResult Guncelle(KitapTuru kitapTuru)  
        {
            if (ModelState.IsValid) 
            {

                _kitapTuruRepository.Guncelle(kitapTuru);
                _kitapTuruRepository.kaydet();
                TempData["basarili"] = "Yeni Kitap Türü Başarıyla Güncellendi!";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();
        }


        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }
            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);
            if (kitapTuruVt == null)
            {
                return NotFound();
            }

            return View(kitapTuruVt);
        }

        [HttpPost,ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            KitapTuru? kitapTuru = _kitapTuruRepository.Get(u => u.Id == id);
            if (kitapTuru == null)
            {
                return NotFound();
            }
            _kitapTuruRepository.Sil(kitapTuru);
            _kitapTuruRepository.kaydet();
            TempData["basarili"] = " Kayıt Silme İşlemi Başarılı!";
            return RedirectToAction("Index", "KitapTuru");

        }


    }
}
