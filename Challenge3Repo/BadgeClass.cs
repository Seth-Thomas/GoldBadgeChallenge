using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3Repo
{
    public class BadgeClass
    {
        public int BadgeId
        {
            get; set;
        }
        public List<string> Doors
        {
            get; set;
        }
        public BadgeClass(int badgeId, List<string> doors)
        {
            BadgeId = badgeId;
            Doors = doors;
        }

    }
}
   
