using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepository
{
    public class DoorKey
    {
        public string DoorKeys { get; set; }
        public DoorKey()
        {
                
        }
        public DoorKey(string doorKey)
        {
            DoorKeys = doorKey;
        }
    }
}
