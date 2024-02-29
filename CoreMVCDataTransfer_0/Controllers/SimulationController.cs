using CoreMVCDataTransfer_0.Models.Tools;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCDataTransfer_0.Controllers
{
    public class SimulationController : Controller
    {

        //Bütün Data Transfer yapıları ilkel tipler ile calısmaya uygundur...Her ne kadar kompleks tiplere destek verseler de kompleks tipler ile kullanılmaları kesinlikle saglıklı degildir...

        //Eger siz Model gönderme yöntemiyle veri göndermiyorsanız o verinin karsılanmasına gerek yoktur... Zaten isteseniz de karsılayamazsınız...


        //ViewBag : Sadece Controller'iniz icerisindeki Action'dan View'iniza veri gönderme görevini uygular...Dinamik tipte veri tutar

        //ViewData: Action'dan View'a veri gönderir lakin ViewBag'den farklı olarak object tipte veri tutar...

        //TempData: Diger Data Transfer yapılarına ek olarak aynı zamanda Action'dan ACtion'a da veri gönderebilen bir Data Transfer yapınızdır...Lakin bu temporary bir data'dır(Tek kullanımlıktır)





        public SimulationController()
        {

        }

       

        public IActionResult Index()
        {
            //ViewBag.Mesaj = "Hello World";

            Egitmen egt = new()
            {
                FirstName = "Cagri",
                LastName = "Yolyapar"
            };

            ViewBag.Egitmen = egt;

            ViewBag.Mesaj = 12; //Eger aynı isimle bir ViewBag olusturuyorsanız bir önceki ViewBag'iniz ezilecektir...
            
            return View();
        }

        public IActionResult ViewDataUsage()
        {


            ViewData["sayi"] = 12;

            Egitmen egt = new()
            {
                FirstName = "Cagri",
                LastName = "Yolyapar"
            };

            ViewData["egitmen"] = egt;

            //DataTransfer yapılarında aynı isimde bir yapıyı tekrar acarsanız son actıgınız öncekini ezer...
            return View();
        }
        public IActionResult TempDataUsage()
        {
            TempData["sayi"] = 100;
            TempData.Keep("sayi"); //Keep metodu ilgili TempData verisinin kullanımını bir tur daha uzatır...
            return View();
        }

        public IActionResult DenemeAction()
        {
            int sayi = Convert.ToInt32(TempData["sayi"]);
            
            return View();
        }
    }
}
