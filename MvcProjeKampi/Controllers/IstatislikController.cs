using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatislikController : Controller
    {
        Context c = new Context();
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var diziCount = c.Headings.GroupBy(x => x.CategoryID == 6).Count();
            var kategoriCount = c.Categories.Count();
            var yazarA = c.Writers.Where(x => x.WriterName.Contains("a")).Count();
            var categoryName = c.Categories.FirstOrDefault(c => c.Headings.Count() > 1)?.CategoryName;
            var categoryStatusTrue = c.Categories.Where(x => x.CategoryStatus == true).Count();
            var categoryStatusFalse = c.Categories.Where(x=>x.CategoryStatus == false).Count();

            var categoryStatusFark = 0;


            if (categoryStatusTrue > categoryStatusFalse)
            {
                 categoryStatusFark = categoryStatusTrue - categoryStatusFalse;
            }
            else
            {
                categoryStatusFark = categoryStatusFalse - categoryStatusTrue;
            }

            ViewBag.enfazla = categoryName;
            ViewBag.kategoriSayisi = kategoriCount;
            ViewBag.diziCount = diziCount;
            ViewBag.yazarA = yazarA;
            ViewBag.categoryFark = categoryStatusFark;
            return View();
        }
    }
}

/*
 from heading in c.Headings join categori in c.Categories on heading.CategoryID equals categori.CategoryID group categori by categori.CategoryName into grp where grp.Count() > 1 select grp.Key.Take(1);
 */ 