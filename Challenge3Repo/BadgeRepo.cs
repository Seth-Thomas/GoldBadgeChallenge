using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3Repo
{
    public class BadgeRepo
    {
        private Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();


        public void AddNewBadge(BadgeClass badge)
        {
            _badges.Add(badge.BadgeId, badge.Doors);
        }
        public bool AddDoorToExistingBadge(int badgeId, string door)
        {
            List<string> badgeAdd = GetBadgeById(badgeId);

            if (badgeAdd == null)
            {
                return false;
            }
            else
            {
                badgeAdd.Add(door);
                return true;
            }

        }
        public bool DeleteDoorsOnExistingBadge(int badgeId, string door)
        {
            List<string> badgeDelete = GetBadgeById(badgeId);

            if (badgeDelete == null)
            {
                return false;
            }
            else
            {
                badgeDelete.Remove(door);
                return true;
            }
            //which badge and to which door
            //need ID, door number
        }

        public Dictionary<int, List<string>> GetBadgeList()
        {
            return _badges;
        }

        public List<string> GetBadgeById(int badgeId)
        {
            foreach (KeyValuePair<int, List<string>> badge in _badges)
            {
                if (badgeId == badge.Key)
                {
                    return badge.Value;
                }
            }
            return null;
        }
       

        
        
    
    }
}
