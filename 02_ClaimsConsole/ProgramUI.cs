using _02_ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsConsole
{
    public class ProgramUI
    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository();
        public void Run()
        {
            SeedClaims();
            RunMenu();
        }

        private void SeedClaims()
        {
            Claims claimOne = new Claims(1, "Hit by car", TypeOfClaim.Car, 500.25m, DateTime.Today, DateTime.Today, true);
            Claims claimTwo = new Claims(3, "Hit by House", TypeOfClaim.Home, 120000.25m, DateTime.Today, DateTime.Today, false);
            Claims claimThree = new Claims(3, "Hit by car", TypeOfClaim.Theft, 4600.25m, DateTime.Today, DateTime.Today, true);
            _claimsRepo.AddNewClaim(claimOne);
            _claimsRepo.AddNewClaim(claimTwo);
            _claimsRepo.AddNewClaim(claimThree);
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Insurance.\n" +
                    "Please select an option to continue: \n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit Program");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        GetNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option. press any key to return to menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void SeeAllClaims()
        {
            Queue<Claims> listOfClaims = _claimsRepo.GetListOfClaims();
            Console.WriteLine("ClaimID   Type    Description      Amount     DateOfAccident   DateOfClaim  IsValid");
            foreach(Claims claim in listOfClaims)
            {
                Console.WriteLine($"{claim.ClaimID}.        {claim.ClaimType}    {claim.Description}          {claim.ClaimAmount}   {claim.DateOfIncident}   {claim.DateOfClaim}   {claim.IsValid}");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
        public void GetNextClaim()
        {
            Queue<Claims> claims = _claimsRepo.GetListOfClaims();
            foreach(Claims claim in claims) //cant modify list while in loop
            {
                Console.Clear();
                Console.WriteLine($"{claim.ClaimID}- {claim.ClaimType}\n" +
                    $"{claim.Description}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfClaim}\n" +
                    $"Is Valid: {claim.IsValid}");
                Console.WriteLine("Do you want to deal with this claim now? y/n");
                string response = Console.ReadLine();
                if(response.ToLower() == "y" || response.ToLower() == "yes")
                {
                    _claimsRepo.RemoveClaimFromQueue(claim.ClaimID);
                    Console.WriteLine("Claim delt with.\n" +
                        "Press any key to move to next claim");
                    Console.ReadKey();
                }
                else if (response.ToLower() == "n" || response.ToLower() == "no")
                {
                    //_claimsRepo.MoveClaimToEnd();
                    Console.WriteLine("Claim skipped to deal with later.\n" +
                        "Press any key to return to menu...");
                    Console.ReadKey();
                }
            }
        }
        public void EnterNewClaim()
        {
            Claims newClaim = new Claims();
            Console.WriteLine("Entering new claim: \n" +
                "Enter the claim id: ");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Select the claim type: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            int claimTNum = int.Parse(Console.ReadLine());

            newClaim.ClaimType = (TypeOfClaim)claimTNum;


            Console.WriteLine("Enter claim description: ");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine("Amoutn of damage in $: ");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Date of Accident: mm/dd/yyyy");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfClaim = DateTime.Today;

            TimeSpan date = newClaim.DateOfClaim.Subtract(newClaim.DateOfIncident);
            double dateDays = date.TotalDays;
            if (dateDays > 30)
            {
                newClaim.IsValid = false;
            }
            else
            {
                newClaim.IsValid = true;
            }
            _claimsRepo.AddNewClaim(newClaim);
            Console.WriteLine("Claim added. \nPress any key to return to menu...");
            Console.ReadKey();
        }

    }
}
