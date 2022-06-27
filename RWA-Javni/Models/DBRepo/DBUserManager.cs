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
    public class DBUserManager
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static IList<User> GetAllUsers()
        {
            IList<User> users = new List<User>();

            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(GetAllUsers)).Tables[0];
            if (tblUsers == null) return null;

            foreach (DataRow row in tblUsers.Rows)
            {
                users.Add(new User
                {
                    UserName = row[nameof(User.UserName)].ToString(),
                    Email = row[nameof(User.Email)].ToString(),
                    Password = row["PasswordHash"].ToString(),
                });
            }

            return users;
        }


        public static User AuthUser(string username, string password)
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


        public static void CreateNewUser(User u)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(CreateNewUser), u.UserName, u.Email, Cryptography.HashPassword(u.Password), u.PhoneNumber, u.Address);
        }



    }
}