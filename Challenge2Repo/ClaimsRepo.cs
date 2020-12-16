using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2Repo
{
    public class ClaimsRepo
    {
        public Queue<ClaimsClass> _claimsQueue = new Queue<ClaimsClass>();

        public void AddClaims(ClaimsClass claim)
        {
            _claimsQueue.Enqueue(claim);
        }
        public Queue<ClaimsClass> ViewClaimsQueue()
        {
            return _claimsQueue;
        }

        //public bool UpdateClaims(int oldClaimId, ClaimsClass newClaimId)
        //{
        //    ClaimsClass oldClaim = GetClaimsById(oldClaimId);

        //    if (oldClaim != null)
        //    {
        //        oldClaim.ClaimAmount = newClaimId.ClaimAmount;
        //        oldClaim.ClaimDescription = newClaimId.ClaimDescription;
        //        oldClaim.ClaimId = newClaimId.ClaimId;
        //        oldClaim.ClaimType = newClaimId.ClaimType;
        //        oldClaim.DateOfClaim = newClaimId.DateOfClaim;
        //        oldClaim.DateOfIncident = newClaimId.DateOfIncident;
        //        oldClaim.IsValid = newClaimId.IsValid;

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
        public void ViewSingleClaims()
        {
            ClaimsClass claim = _claimsQueue.Peek();
        }

        public void DeleteClaims()
        {
            _claimsQueue.Dequeue();
        }





        //    if (claim == null)
        //    {
        //        return false;
        //    }
        //    int initialCount = _claimsQueue.Count;
        //    _claimsQueue.Dequeue(claim);

        //    if (initialCount > _claimsQueue.Count)
        //    {
        //        return true;
        //    }

        //    else
        //    {
        //        return false;
        //    }
        //}



    }
}








