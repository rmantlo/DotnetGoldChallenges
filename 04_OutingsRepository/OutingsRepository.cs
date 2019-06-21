using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_OutingsRepository
{
    public class OutingsRepository
    {
        List<Outings> _outingsRepo = new List<Outings>();

        public List<Outings> GetOutingList()
        {
            return _outingsRepo;
        }
        public void CreateOuting(Outings outing)
        {
            _outingsRepo.Add(outing);
        }
        
    }
}
