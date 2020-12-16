using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2Repo
{
    public class ClaimsClass
    {
        public int ClaimId
        {
            get; set;
        }
        public string ClaimType
        {
            get; set;
        }

        public string ClaimDescription
        {
            get; set;
        }
        public double  ClaimAmount
        {
            get; set;
        }
        public DateTime DateOfIncident
        {
            get; set;
        }

        public DateTime DateOfClaim
        {
            get; set;
        }

        public bool IsValid
        {
            get; set;
        }
        public ClaimsClass()
        {
        }
        public ClaimsClass(int claimId, string claimType, string claimDescription, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;

        }

    }
}
