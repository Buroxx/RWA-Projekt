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
    public class DBPictureManager
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

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
     public static IList<ApartmentPicture> GetAllApartmentPictures()
        {
            IList<ApartmentPicture> apartments = new List<ApartmentPicture>();

            var tblApartments = SqlHelper.ExecuteDataset(CS, nameof(GetAllApartmentPictures)).Tables[0];
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
    }









}