using Microsoft.ApplicationBlocks.Data;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Dal
{
    public class DBRepo : IRepo
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public IList<Apartment> GetAllApartments()
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
                    Price = row[nameof(Apartment.Price)].ToString().Substring(0, 3) + "€",
                    StatusId = row[nameof(Apartment.StatusId)].ToString()
                });
            }

            foreach (Apartment apart in apartments)
            {
                apart.City = GetCityByID(apart.Id);
            }


            return apartments;
        }




        public User AuthUser(string username, string password)
        {
            var tblAuth = SqlHelper.ExecuteDataset(CS, nameof(AuthUser), username, password).Tables[0];
            if (tblAuth.Rows.Count == 0) return null;

            
            DataRow row = tblAuth.Rows[0];

           
            return new User
            {
                Id = (int)row[nameof(User.Id)],
                UserName = row[nameof(User.UserName)].ToString(),
                Email = row[nameof(User.Email)].ToString(),
                PhoneNumber = row[nameof(User.PhoneNumber)].ToString(),
                Address = row[nameof(User.Address)].ToString()
            };
        }

        public IList<User> GetAllUsers()
        {
            IList<User> users = new List<User>();

            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(GetAllUsers)).Tables[0];
            if (tblUsers == null) return null;

                foreach (DataRow row in tblUsers.Rows)
                {
                    users.Add(new User
                    {
                        Id = (int)row[nameof(User.Id)],
                        UserName = row[nameof(User.UserName)].ToString(),
                        Email = row[nameof(User.Email)].ToString(),
                        PhoneNumber = row[nameof(User.PhoneNumber)].ToString(),
                        Address = row[nameof(User.Address)].ToString()
                });
                }

            return users;
        }

        public IList<User> GetUserByID(int userID)
        {
            IList<User> user = new List<User>();

            var tblUser = SqlHelper.ExecuteDataset(CS, nameof(GetUserByID), userID).Tables[0];
            if (tblUser.Rows.Count == 0) return null;


            DataRow row = tblUser.Rows[0];


            user.Add(new User
            {
                Id = (int)row[nameof(User.Id)],
                UserName = row[nameof(User.UserName)].ToString(),
                Email = row[nameof(User.Email)].ToString(),
                PhoneNumber = row[nameof(User.PhoneNumber)].ToString(),
                Address = row[nameof(User.Address)].ToString()
            });
            return user;
        }

        public IList<Apartment> GetApartmentByOwnerID(int id)
        {
            IList<Apartment> apartments = new List<Apartment>();

            var tblApartments = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentByOwnerID), id).Tables[0];
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
                    Price = row[nameof(Apartment.Price)].ToString().Substring(0, 3) + "€",
                    StatusId = row[nameof(Apartment.StatusId)].ToString()
            });
            }

            foreach (Apartment apart in apartments)
            {
                apart.City = GetCityByID(apart.Id);
            }


            return apartments;
        }


        public Apartment GetApartmentByID(int id)
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
            apartment.Price = row[nameof(Apartment.Price)].ToString().Substring(0, 3) + "€";              
            apartment.City = GetCityByID(apartment.Id);
            apartment.StatusId = row[nameof(Apartment.StatusId)].ToString();

            return apartment;
        }

        private string GetCityByID(int id)
        {

            var tblCity = SqlHelper.ExecuteDataset(CS,nameof(GetCityByID),id).Tables[0];
            if(tblCity == null) return null;
            DataRow row = tblCity.Rows[0];

            return row[nameof(City.Name)].ToString();
        }


        public IList<ApartmentPicture> GetApartmentPicturesByID(int apartmentID)
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








        //public IList<Apartment> LoadApartmentsByTagID(int tagID)
        //{
        //    IList<Apartment> apartments = new List<Apartment>();

        //    var tblApartments = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadApartmentsByTagID), tagID).Tables[0];
        //    foreach (DataRow row in tblApartments.Rows)
        //    {
        //        apartments.Add(
        //            new Apartment
        //            {
        //                Name = row[nameof(Tags.Name)].ToString()
        //            }
        //        );
        //    }

        //    return apartments;
        //}

        //public void AddUser(User user)
        //{
        //    SqlHelper.ExecuteNonQuery(CS, nameof(AddUser), user.FName, user.LName, user.City.IDCity, user.Username, user.Password);
        //}

        //public User AuthUser(string username, string password)
        //{
        //    var tblAuth = SqlHelper.ExecuteDataset(CS, nameof(AuthUser), username, password).Tables[0];
        //    if (tblAuth.Rows.Count == 0) return null;

        //    DataRow row = tblAuth.Rows[0];
        //    return new User
        //    {
        //        IDAuth = (int)row[nameof(User.IDAuth)],
        //        FName = row[nameof(User.FName)].ToString(),
        //        LName = row[nameof(User.LName)].ToString(),
        //        City = new City((int)row[nameof(City.IDCity)], row[nameof(City.Name)].ToString()),
        //        Username = row[nameof(User.Username)].ToString(),
        //        Password = row[nameof(User.Password)].ToString()
        //    };
        //}

        //public IList<City> LoadCities()
        //{
        //    IList<City> cities = new List<City>();

        //    var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(LoadCities)).Tables[0];
        //    foreach (DataRow row in tblUsers.Rows)
        //    {
        //        cities.Add(
        //            new City
        //            {
        //                IDCity = (int)row[nameof(City.IDCity)],
        //                Name = row[nameof(City.Name)].ToString(),
        //            }
        //        );
        //    }

        //    return cities;
        //}

        //public IList<User> LoadUsers()
        //{
        //    IList<User> users = new List<User>();

        //    var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(LoadUsers)).Tables[0];
        //    foreach (DataRow row in tblUsers.Rows)
        //    {
        //        users.Add(
        //            new User
        //            {
        //                IDAuth = (int)row[nameof(User.IDAuth)],
        //                FName = row[nameof(User.FName)].ToString(),
        //                LName = row[nameof(User.LName)].ToString(),
        //                City = new City((int)row[nameof(City.IDCity)], row[nameof(City.Name)].ToString()),
        //                Username = row[nameof(User.Username)].ToString(),
        //                Password = row[nameof(User.Password)].ToString()
        //            }
        //        );
        //    }

        //    return users;
        //}

        //public void SaveUser(User user)
        //{
        //    SqlHelper.ExecuteNonQuery(CS, nameof(SaveUser), user.FName, user.LName, user.Username, user.IDAuth);
        //}
    }
}
