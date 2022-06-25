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
    public class DBCityManager
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static IList<City> GetAllCities()
        {
            IList<City> cities = new List<City>();

            var tblCities = SqlHelper.ExecuteDataset(CS, nameof(GetAllCities)).Tables[0];
            if (tblCities == null) return null;

            foreach (DataRow row in tblCities.Rows)
            {
                cities.Add(new City
                {
                    Id = (int)row[nameof(City.Id)],
                    Name = row[nameof(City.Name)].ToString(),
                });
            }
            return cities;
        }

        public static string GetCityByID(int id)
        {

            var tblCity = SqlHelper.ExecuteDataset(CS, nameof(GetCityByID), id).Tables[0];
            if (tblCity.Rows.Count == 0) return null;
            DataRow row = tblCity.Rows[0];

            return row[nameof(City.Name)].ToString();
        }







    }
}