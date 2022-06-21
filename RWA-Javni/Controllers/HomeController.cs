using RWA_Javni.Models.DBRepo;
using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Javni.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //string path = Request.PhysicalApplicationPath.ToString();
            //string imagePath = path.Remove(path.Length - 10);
            //imagePath = imagePath + "RWA-Projekt"
            //ViewBag.Path = imagePath;

            IList<City> cities = new List<City>();
            cities = DBCityManager.GetAllCities();

            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (City city in cities)
            {
                selectList.Add(new SelectListItem() { Text = city.Name, Value = city.Id.ToString()});
            }

            ViewBag.itemsToPick = selectList;

            return View();
        }
    }
}