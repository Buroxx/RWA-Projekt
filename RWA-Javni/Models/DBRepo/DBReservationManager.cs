using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RWA_Javni.Models.DBRepo
{
    public class DBReservationManager
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static void AddNewReservation(Reservation reservation)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddNewReservation), reservation.ApartmentId, reservation.FirstName + " " + reservation.LastName, reservation.Email, reservation.Phone, reservation.DateFrom + " - " + reservation.DateTo + " odrasli: " + reservation.Adults + " djeca: " + reservation.Children);
        }

    }
}