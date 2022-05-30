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
                    Price = row[nameof(Apartment.Price)].ToString().Substring(0, 3),
                    StatusId = row[nameof(Apartment.StatusId)].ToString(),
                    BeachDistance = row[nameof(Apartment.BeachDistance)].ToString()
                });
            }

            foreach (Apartment apart in apartments)
            {
                apart.City = GetCityByID(apart.Id);
            }


            return apartments;
        }


        public void SetRepresentativePicture(int novi, int stari)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(SetRepresentativePicture), novi, stari);

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
                    Price = row[nameof(Apartment.Price)].ToString().Substring(0, 3),
                    StatusId = row[nameof(Apartment.StatusId)].ToString(),
                    BeachDistance = row[nameof(Apartment.BeachDistance)].ToString()
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
            apartment.Price = row[nameof(Apartment.Price)].ToString().Substring(0, 3);
            apartment.City = GetCityByID(apartment.Id);
            apartment.StatusId = row[nameof(Apartment.StatusId)].ToString();
            apartment.BeachDistance = row[nameof(Apartment.BeachDistance)].ToString();


            return apartment;
        }

        public IList<Tags> GetTagsByApartmentID(int apartmentID)
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
                    TypeName = row[nameof(Tags.TypeName)].ToString(),
                    TypeID = (int)row[nameof(Tags.TypeID)]
                });
            }
            return tags;
        }

        public IList<Tags> GetUnusedTagsOnTaggedApartmentByID(int apartmentID)
        {
            IList<Tags> tags = new List<Tags>();

            var tblTags = SqlHelper.ExecuteDataset(CS, nameof(GetUnusedTagsOnTaggedApartmentByID), apartmentID).Tables[0];
            if (tblTags == null) return null;

            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(new Tags
                {
                    Id = (int)row[nameof(Tags.Id)],
                    NameEng = row[nameof(Tags.NameEng)].ToString(),
                    TypeID = (int)row[nameof(Tags.TypeID)],
                    TypeName = row[nameof(Tags.TypeName)].ToString(),
                });
            }
            return tags;
        }
        public void DeleteApartmentTagByID(int tagID, int apartmentID)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteApartmentTagByID), tagID, apartmentID);
        }


        public void AddNewTagToApartment(int tagID, int apartmentID)
        {
            Guid guid = Guid.NewGuid();
            SqlHelper.ExecuteNonQuery(CS, nameof(AddNewTagToApartment), tagID, apartmentID, guid);
        }

        public void UpdateApartmentInfo(Apartment newInfo, int apartmentID)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(UpdateApartmentInfo), newInfo.Name, newInfo.TotalRooms, newInfo.MaxChildren, newInfo.MaxAdults, newInfo.BeachDistance, Decimal.Parse(newInfo.Price), apartmentID);
        }

        private string GetCityByID(int id)
        {

            var tblCity = SqlHelper.ExecuteDataset(CS, nameof(GetCityByID), id).Tables[0];
            if (tblCity == null) return null;
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

        public void UnregisteredApartmentReservation(User u, string details, int apartmentID)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(UnregisteredApartmentReservation), u.UserName, u.Email, u.PhoneNumber, u.Address, details, apartmentID);
        }

        public void RegisteredApartmentReservation(int userID, int apartmentID, string details)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(RegisteredApartmentReservation),userID,apartmentID,details);
        }
    }
}
