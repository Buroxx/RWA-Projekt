using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    [Serializable]

    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string TypeNameHrv { get; set; }
        public string TypeNameEng { get; set; }
        public int TypeID { get; set; }
        public int Usage { get; set; }



        public bool IsUsed(object obj)
        {
            if(this.Usage == 0)
            {
                return false;
            }
            return true;
        }

    }


}
