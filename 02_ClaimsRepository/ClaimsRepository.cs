using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public class ClaimsRepository
    {
        private Queue<Claims> _claimRepo = new Queue<Claims>();

        public Queue<Claims> GetListOfClaims()
        {
            return _claimRepo;
        }
        public Claims GetClaimByID(int claimID)
        {
            foreach(Claims claim in _claimRepo)
            {
                if(claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
        public void MoveClaimToEnd()
        {
            Claims claimPopped = _claimRepo.Dequeue();
            _claimRepo.Enqueue(claimPopped);
        }
        public void RemoveClaimFromQueue(int claimID)
        {
            Claims claimToRemove = GetClaimByID(claimID);
            Claims claimPopped = _claimRepo.Dequeue();
        }
        public void AddNewClaim(Claims claim)
        {
            _claimRepo.Enqueue(claim);
        }
    }
}
