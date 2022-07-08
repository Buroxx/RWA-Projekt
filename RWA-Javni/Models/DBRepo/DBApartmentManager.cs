using Microsoft.ApplicationBlocks.Data;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace RWA_Javni.Models.DBRepo
{
    public class DBApartmentManager
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static IList<Apartment> GetAllApartments()
        {
            IList<Apartment> apartments = new List<Apartment>();

            var tblApartments = SqlHelper.ExecuteDataset(CS, nameof(GetAllApartments)).Tables[0];
            if (tblApartments == null) return null;

            foreach (DataRow row in tblApartments.Rows)
            {
                apartments.Add(new Apartment
                {
                    Id = (int)row[nameof(Apartment.Id)],
                    Name = row[nameof(Apartment.Name)].ToString(),
                    MaxAdults = (int)row[nameof(Apartment.MaxAdults)],
                    MaxChildren = (int)row[nameof(Apartment.MaxChildren)],
                    TotalRooms = (int)row[nameof(Apartment.TotalRooms)],
                    Price = row[nameof(Apartment.Price)].ToString().Substring(0, 3),
                    StatusId = row[nameof(Apartment.StatusId)].ToString(),
                    BeachDistance = row[nameof(Apartment.BeachDistance)].ToString(),
                    Review = GetApartmentReviews((int)row[nameof(Apartment.Id)])
                });
            }

            foreach (Apartment apart in apartments)
            {
                apart.City = DBCityManager.GetCityByID(apart.Id);
            }


            return apartments;
        }

        private static int GetApartmentReviews(int apartmentID)
        {

            IList<ApartmentReview> reviews = new List<ApartmentReview>();

            var tblReviews = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentReviews), apartmentID).Tables[0];
            if (tblReviews == null) return 0;

            foreach (DataRow row in tblReviews.Rows)
            {
                reviews.Add(new ApartmentReview
                {
                    Id = (int)row[nameof(ApartmentReview.Id)],
                    ApartmentId = (int)row[nameof(ApartmentReview.ApartmentId)],
                    Stars = (int)row[nameof(ApartmentReview.Stars)]
                });
            }

            if (reviews.Count == 0)
            {
                return 1;
            }

            int total = 0;
            foreach (ApartmentReview rev in reviews)
            {
                total += rev.Stars;
            }
            
            return total/reviews.Count;

        }

        public static Apartment GetApartmentByID(int id)
        {
            Apartment apartment = new Apartment();

            var tblApartment = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentByID), id).Tables[0];
            if (tblApartment.Rows.Count == 0) return null;

            DataRow row = tblApartment.Rows[0];

            apartment.Id = (int)row[nameof(Apartment.Id)];
            apartment.Name = row[nameof(Apartment.Name)].ToString();
            apartment.MaxAdults = (int)row[nameof(Apartment.MaxAdults)];
            apartment.MaxChildren = (int)row[nameof(Apartment.MaxChildren)];
            apartment.TotalRooms = (int)row[nameof(Apartment.TotalRooms)];
            apartment.Price = row[nameof(Apartment.Price)].ToString();
            apartment.City = GetCityByID(apartment.Id);
            apartment.StatusId = row[nameof(Apartment.StatusId)].ToString();
            apartment.BeachDistance = row[nameof(Apartment.BeachDistance)].ToString();
            apartment.OwnerID = (int)row[nameof(Apartment.OwnerID)];
            apartment.Review = GetApartmentReviews((int)row[nameof(Apartment.Id)]);


            return apartment;
        }

        public static string GetOwnerByID(int ownerID)
        {

            var tblOwner = SqlHelper.ExecuteDataset(CS, nameof(GetOwnerByID), ownerID).Tables[0];
            if (tblOwner.Rows.Count == 0) return null;
            DataRow row = tblOwner.Rows[0];

            return row["Name"].ToString();
        }


        private static string GetCityByID(int id)
        {

            var tblCity = SqlHelper.ExecuteDataset(CS, nameof(GetCityByID), id).Tables[0];
            if (tblCity.Rows.Count == 0) return null;
            DataRow row = tblCity.Rows[0];

            return row[nameof(City.Name)].ToString();
        }

        public static IList<ApartmentPicture> GetApartmentPicturesByID(int apartmentID)
        {
            IList<ApartmentPicture> apartments = new List<ApartmentPicture>();

            var tblApartments = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentPicturesByID), apartmentID).Tables[0];
            if (tblApartments == null) return null;

            foreach (DataRow row in tblApartments.Rows)
            {
                apartments.Add(new ApartmentPicture
                {
                    Id = (int)row[nameof(ApartmentPicture.Id)],
                    ApartmentId = (int)row[nameof(ApartmentPicture.ApartmentId)],
                    Path = row[nameof(ApartmentPicture.Path)].ToString(),
                    Name = row[nameof(ApartmentPicture.Name)].ToString(),
                    IsRepresentative = (bool)row[nameof(ApartmentPicture.IsRepresentative)]
                });
            }
            return apartments;
        }


        public static IList<Tags> GetTagsByApartmentID(int apartmentID)
        {
            IList<Tags> tags = new List<Tags>();

            var tblTags = SqlHelper.ExecuteDataset(CS, nameof(GetTagsByApartmentID), apartmentID).Tables[0];
            if (tblTags == null) return null;

            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(new Tags
                {
                    Id = (int)row[nameof(Tags.Id)],
                    Name = row[nameof(Tags.Name)].ToString(),
                    NameEng = row[nameof(Tags.NameEng)].ToString(),
                    TypeNameEng = row[nameof(Tags.TypeNameEng)].ToString(),
                    TypeID = (int)row[nameof(Tags.TypeID)]
                });
            }
            return tags;
        }
    }
}