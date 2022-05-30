using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    [Serializable]
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int TotalRooms { get; set; }
        public int Pictures { get; set; }
        public string Price { get; set; }
        public string StatusId { get; set; }
        public string BeachDistance { get; set; }
    }
}
