using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2Repo
{
    public class ClaimsRepo
    {
        private Queue<ClaimsClass> _claimsQueue = new Queue<ClaimsClass>();

        public void AddClaims(ClaimsClass claim)
        {
            _claimsQueue.Enqueue(claim);
        }
        public Queue<ClaimsClass> ViewClaimsQueue()
        {
            return _claimsQueue;
        }
       
        public ClaimsClass ViewSingleClaims()
        {
            return _claimsQueue.Peek();
        }

        public void DeleteClaims()
        {
            _claimsQueue.Dequeue();
        }
    }
}








