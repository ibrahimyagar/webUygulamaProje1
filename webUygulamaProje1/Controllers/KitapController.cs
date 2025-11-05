using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webUygulamaProje1.Models;
using webUygulamaProje1.Utility;

namespace webUygulamaProje1.Controllers
{
    public class KitapController : Controller
    {
        private readonly IKitapRepository _kitapRepository;
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapController(IKitapRepository kitapRepository, IKitapTuruRepository kitapTuruRepository)
        {
            _kitapRepository = kitapRepository;
            _kitapTuruRepository = kitapTuruRepository;
        }
        public IActionResult index()
        {
            List<Kitap>objkitaplist= _kitapRepository.GetAll().ToList();
          
            return View(objkitaplist);
        }

        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> kitapTuruList = _kitapTuruRepository.GetAll()
              .Select(k => new SelectListItem

              {
                  Text = k.Ad,
                  Value = k.Id.ToString()
              });
            ViewBag.KitapTuruList= kitapTuruList;
            if(id==null || id == 0)
            {
                return View();  //ekleme
            }
            else
            {
                Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
                if (kitapVt == null)
                {
                    return NotFound();
                }

                return View(kitapVt);

            }
           
        }
        [HttpPost]
        public IActionResult EkleGuncelle(Kitap kitap,IFormFile? file)  //yeni kitap türü ekledik
        {
            if (ModelState.IsValid)   //Kitap.cs de belirttiğimiz özelliklere uygunsa devam ettir. bu şekilde programın çökmesi engellenir
            {

                _kitapRepository.Ekle(kitap);
                _kitapRepository.kaydet();
                TempData["basarili"] = "Yeni Kitap Türü Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "Kitap");
            }
            return View();
        }
       /*
        public IActionResult Guncelle(int? id)
        {
            if(id == null|| id == 0)
            {

            return NotFound(); }
            Kitap? kitapVt = _kitapRepository.Get(u=>u.Id==id);
            if (kitapVt == null)
            {
                return NotFound(); 
            }

            return View(kitapVt);
        }
       */

       /*
        [HttpPost]
        public IActionResult Guncelle(Kitap kitap)  
        {
            if (ModelState.IsValid) 
            {

                _kitapRepository.Guncelle(kitap);
                _kitapRepository.kaydet();
                TempData["basarili"] = "Yeni Kitap Türü Başarıyla Güncellendi!";
                return RedirectToAction("Index", "Kitap");
            }
            return View();
        }
        */


        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }
            Kitap? kitap = _kitapRepository.Get(u => u.Id == id);
            if (kitap ==null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        [HttpPost,ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Kitap? kitap = _kitapRepository.Get(u => u.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }
            _kitapRepository.Sil(kitap);
            _kitapRepository.kaydet();
            TempData["basarili"] = " Kayıt Silme İşlemi Başarılı!";
            return RedirectToAction("Index", "Kitap");

        }


    }
}
