using Microsoft.ApplicationBlocks.Data;
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
                    Password = row[nameof(User.Password)].ToString(),
                });
            }

            return users;
        }

    }
}