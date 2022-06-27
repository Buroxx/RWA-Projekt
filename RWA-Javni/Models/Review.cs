using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Javni.Models
{
    public class Review
    {
        public int userId { get; set; }
        public int apartmentId { get; set; }
        public string description { get; set; }
        public int stars { get; set; }
    }
}