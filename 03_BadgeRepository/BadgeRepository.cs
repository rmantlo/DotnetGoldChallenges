using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepository
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string> > _badgeRepo = new Dictionary<int, List<string> >();
        public Dictionary<int, List<string> > GetListOfBadges()
        {
            return _badgeRepo;
        }
        public List<string> GetBadgeDoorList(int badgeID)
        {
            return _badgeRepo[badgeID];
        }

        public void AddToBadgeRepository(int badgeID, List<string> doorKeys)
        {
            _badgeRepo.Add(badgeID, doorKeys);
        }
        public void RemoveDoorsFromBadge(int badgeID)
        {
            _badgeRepo[badgeID] = null;
        }
        public void UpdateBadgeInformation()
        {

        }
    }
}
