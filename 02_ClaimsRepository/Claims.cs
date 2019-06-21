using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public enum TypeOfClaim
    {
        Car,
        Home,
        Theft
    }
    public class Claims
    {
        public int ClaimID { get; set; }
        public string Description { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfClaim { get; set; }
        public DateTime DateOfIncident { get; set; }
        public bool IsValid { get; set; }
        public Claims() { }
        public Claims(int claimID, string description, TypeOfClaim claimType, decimal claimAmount, DateTime dateOfClaim, DateTime dateOfIncident, bool isValid)
        {
            ClaimID = claimID;
            Description = description;
            ClaimType = claimType;
            ClaimAmount = claimAmount;
            DateOfClaim = dateOfClaim;
            DateOfIncident = dateOfIncident;
            IsValid = isValid;
        }
    }
}
