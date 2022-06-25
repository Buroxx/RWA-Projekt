using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    public class ApartmentReview
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int Stars { get; set; }
    }
}
