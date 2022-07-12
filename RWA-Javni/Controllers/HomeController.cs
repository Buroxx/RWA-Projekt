using RWA_Javni.Models;
using RWA_Javni.Models.DBRepo;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace RWA_Javni.Controllers
{   
    public class HomeController : Controller
    {
       

        public ActionResult Index(string sortOrder)
        {

            //IList<City> cities = new List<City>();
            IList<Apartment> apartments = new List<Apartment>();
            IList<ApartmentPicture> pictureList = new List<ApartmentPicture>();

            //cities = DBCityManager.GetAllCities();
            apartments = DBApartmentManager.GetAllApartments();
            pictureList = DBPictureManager.GetAllApartmentPictures();

            if (sortOrder == "Asc")
            {
            apartments = apartments.OrderBy(x => x.Name).ToList();
            }else if (sortOrder == "Desc")
            {
                apartments= apartments.OrderByDescending(x => x.Name).ToList();
            }else if (sortOrder == "Default")
            {
                apartments = apartments.OrderBy(x => x.Id).ToList();
            }

            ViewBag.apartments = apartments;
            ViewBag.pictureList = pictureList;
            ViewBag.pickedSort = sortOrder;

            return View();
        }

        [HttpGet]
        public ActionResult Reserve(int apartmentID)
        {
            Apartment apartment = DBApartmentManager.GetApartmentByID(apartmentID);
            IList<ApartmentPicture> pictureList = DBPictureManager.GetApartmentPicturesByID(apartmentID);
            ViewBag.tags = DBApartmentManager.GetTagsByApartmentID(apartmentID);
            ViewBag.pictures = pictureList;
            ViewBag.apartment = apartment;
            ViewBag.owner = DBApartmentManager.GetOwnerByID(apartment.OwnerID);
            ViewBag.apartmentId = apartmentID;
                
            return View();
        }


        [HttpPost]
        public ActionResult Index(int rooms = 0, int adults = 0, int children = 0)
        {

            IList<Apartment> apartments = new List<Apartment>();
            apartments = DBApartmentManager.GetAllApartments();

            if (rooms != 0 && adults != 0 && children != 0)
            {
                ViewBag.apartments = apartments.Where(x => x.TotalRooms == rooms && x.MaxAdults == adults && x.MaxChildren == children).ToList();
                ViewBag.pictureList = DBPictureManager.GetAllApartmentPictures();
            }
            else if (rooms != 0 && adults != 0)
            {
                ViewBag.apartments = apartments.Where(x => x.TotalRooms == rooms && x.MaxAdults == adults).ToList();
                ViewBag.pictureList = DBPictureManager.GetAllApartmentPictures();
            }
            else if (adults != 0 && children != 0)
            {
                ViewBag.apartments = apartments.Where(x => x.MaxAdults == adults && x.MaxChildren == children).ToList();
                ViewBag.pictureList = DBPictureManager.GetAllApartmentPictures();
            }
            else if (rooms != 0 && children != 0)
            {
                ViewBag.apartments = apartments.Where(x => x.MaxChildren == children && x.TotalRooms == rooms).ToList();
                ViewBag.pictureList = DBPictureManager.GetAllApartmentPictures();
            }
            else if (rooms != 0)
            {
                ViewBag.apartments = apartments.Where(x => x.TotalRooms == rooms).ToList();
                ViewBag.pictureList = DBPictureManager.GetAllApartmentPictures();
            }
            else if (adults != 0)
            {
                ViewBag.apartments = apartments.Where(x => x.MaxAdults == adults).ToList();
                ViewBag.pictureList = DBPictureManager.GetAllApartmentPictures();
            }
            else if (children != 0)
            {
                ViewBag.apartments = apartments.Where(x => x.MaxChildren == children).ToList();
                ViewBag.pictureList = DBPictureManager.GetAllApartmentPictures();
            }


            return View();
        }



        [HttpPost]
        public JsonResult SendReservation(Reservation reservation)
        {
            if (reservation == null) return Json("failed");

            DBReservationManager.AddNewReservation(reservation);

            return Json("success");
        }  
        
        [HttpPost]
        public JsonResult SendReview(Review review)
        {
            if (review == null) return Json("failed");

            DBReviewManager.AddNewReview(review);

            return Json("success");
        }


    }
}