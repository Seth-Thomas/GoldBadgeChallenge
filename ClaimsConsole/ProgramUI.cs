using Challenge2Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsConsole
//    Show a claims agent a menu:
//Choose a menu item:
//1. See all claims
//2. Take care of next claim
//3. Enter a new claim
//For #1, a claims agent could see all items in the queue listed out like this:

//ClaimID Type    Description Amount  DateOfAccident DateOfClaim IsValid
//1	Car Car accident on 465.	$400.00	4/25/18	4/27/18	true
//2	Home House fire in kitchen.  $4000.00	4/11/18	4/12/18	true
//3	Theft Stolen pancakes.    $4.00	4/27/18	6/01/18	false
//For #2, when a claims agent needs to deal with an item they see the next item in the queue.

//Here are the details for the next claim to be handled:
//ClaimID: 1
//Type: Car
//Description: Car Accident on 464.
//Amount: $400.00
//DateOfAccident: 4/25/18
//DateOfClaim: 4/27/18
//IsValid: True
//Do you want to deal with this claim now(y/n)? y
//When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.

//For #3, when a claims agent enters new data about a claim they will be prompted for questions about it:

//Enter the claim id: 4
//Enter the claim type: Car
//Enter a claim description: Wreck on I-70.
//Amount of Damage: $2000.00
//Date Of Accident: 4/27/18
//Date of Claim: 4/28/18
//This claim is valid.

{
    public class ProgramUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {
            SeedClaimsList();
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option from the menu:\n" +
                    "1. See All Claim\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
        public void SeeAllClaims()
        {
            Console.Clear();
            Queue<ClaimsClass> claimsQueue = _claimsRepo.ViewClaimsQueue();
            Console.WriteLine($"{"ClaimID",-10}{"Claim Type",-15}{"Description",-25}{"Claim Amount",-15}{"Date of Incidient",-20}{"Date Of Claim",-15}{"Claim is Valid"}");

            foreach (ClaimsClass claims in claimsQueue)
            {
                Console.WriteLine($"{claims.ClaimId,-10}{claims.ClaimType,-15}{claims.ClaimDescription,-25}{claims.ClaimAmount.ToString("C2"),-15}{claims.DateOfIncident.ToString("MM/dd/yy"),-20}{claims.DateOfClaim.ToString("MM/dd/yy"),-15}{claims.IsValid}");
            }
        }
        public void TakeCareOfNextClaim()
        {
            Console.Clear();

            Queue<ClaimsClass> claimsQueue = new Queue<ClaimsClass>();
            claimsQueue = _claimsRepo.ViewClaimsQueue();
            ClaimsClass claims = claimsQueue.Peek();

            Console.WriteLine("Here is the next claim\n");
            Console.WriteLine($"ClaimID : {claims.ClaimId}\n" +
                $"Claim Type : {claims.ClaimType}\n" +
                $"Claim Description : {claims.ClaimDescription}\n" +
                $"Claim Amounnt : {claims.ClaimAmount.ToString("C2")}\n" +
                $"Date of Incident : {claims.DateOfIncident.ToString("MM/dd/yy")}\n" +
                $"Date of Claim : {claims.DateOfClaim.ToString("MM/dd/yy")}\n" +
                $"Claim Is Valid : {claims.IsValid}");

            Console.WriteLine("Do you want to deal with this claim now? Type y/n");
            string input = Console.ReadLine();

            if (input == "y")
            {
                claimsQueue.Dequeue();
            }
            if (input == "n") // Need to set method to return to main menu 
            {

            }

        }
        //Enter the claim id: 4
        //Enter the claim type: Car
        //Enter a claim description: Wreck on I-70.
        //Amount of Damage: $2000.00
        //Date Of Accident: 4/27/18
        //Date of Claim: 4/28/18
        //This claim is valid.
        public void EnterNewClaim()
        {
            ClaimsClass newClaim = new ClaimsClass();
            Console.Clear();
            
            Console.WriteLine("Enter all following claim information. Press enter after each response.\n");

            Console.WriteLine("Claim ID:");
            string claimIdAsString = Console.ReadLine();
            newClaim.ClaimId = int.Parse(claimIdAsString);
            Console.Clear();

            Console.WriteLine("Enter claim type from list below.\n");
            Console.WriteLine("Car\n" +
                "Home\n" +
                "Theft\n");
            newClaim.ClaimType = Console.ReadLine().ToLower();
            Console.Clear();

            Console.WriteLine("Enter claim description");
            newClaim.ClaimDescription = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter claim amount");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Enter date of incident in the following format mm/dd/yy");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Enter date of claim in following format mm/dd/yy");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("This claim is valid");
            Console.Clear();

            _claimsRepo.AddClaims(newClaim);
        }
               

        public void SeedClaimsList()
        {
            ClaimsClass claim1 = new ClaimsClass(1, "Car", "Fender bender", 200.00, new DateTime(2020,01,01), new DateTime(2020,02,03), false);
            ClaimsClass claim2 = new ClaimsClass(2, "Theft", "Stolen necklace", 1500.00, new DateTime(2020,03,13), new DateTime (2020,03,14), true);
            ClaimsClass claim3 = new ClaimsClass(3, "Home", "Christmas tree fire", 2000.00, new DateTime(2020, 04, 05), new DateTime(2020, 04, 06), true);

            _claimsRepo.AddClaims(claim1);
            _claimsRepo.AddClaims(claim2);
            _claimsRepo.AddClaims(claim3);
        }

    }


}

