using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RWA_Javni.Models.DBRepo
{
    public class DBReviewManager
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static void AddNewReview(Review review)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddNewReview), review.userId, review.stars, review.description, review.apartmentId);
        }
    }
}