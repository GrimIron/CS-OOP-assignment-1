using System;

namespace Vote_Calc
{
    class main
    {
        static void Main()
        {
            
            
        }
    }
    //Class for containing information regarding the countries
    class Country
    {
        string name;            // Stores name 
        double pop;             // Country Population
        bool eu;                // Wether the country is in the eu or not
        bool is_included;

        static void generate_countries()
        {
            Country Austria = new Country();
            Austria.name = "Austria";
            Austria.pop = 9006398;
            Austria.eu = true;
            Austria.is_included = ask_user();

            Country Belgeium = new Country();
            Belgeium.name = "Belgeium";
            Belgeium.pop = 11589623;
            Belgeium.eu = true;

            Country Bulgaria = new Country();
            Bulgaria.name = "Bulgaria";
            Bulgaria.pop = 6948445;
            Bulgaria.eu = false;

            Country Croatia = new Country();
            Croatia.name = "Croatia";
            Croatia.pop = 4105267;
            Croatia.eu = false;

            Country Cyprus = new Country();
            Cyprus.name = "Cyprus";
            Cyprus.pop = 1207359;
            Cyprus.eu = true;

            Country Czech_Republic = new Country();
            Czech_Republic.name = "Czech Republic";
            Czech_Republic.pop = 10708981;
            Czech_Republic.eu = false;

            Country Denmark = new Country();
            Denmark.name = "Denmark";
            Denmark.pop = 5792202;
            Denmark.eu = false;

            Country Estonia = new Country();
            Estonia.name = "Estonia";
            Estonia.pop = 1326535;
            Estonia.eu = true;

            Country Finland = new Country();
            Finland.name = "Finland";
            Finland.pop = 5540720;
            Finland.eu = true;

            Country France = new Country();
            France.name = "France";
            France.pop = 65273511;
            France.eu = true;

            Country Germany = new Country();
            Germany.name = "Germany";
            Germany.pop = 83783942;
            Germany.eu = true;

        }

        static bool ask_user()
        {
            while (true) // Loop indefinitely
            {
                Console.WriteLine("Is this country included in the vote:");
                Console.WriteLine("Please enter yes or no");

                string line = Console.ReadLine().ToLower().Trim(); // gets input and sets to lower and removes whitespace

                if (line == "yes") // Check string
                {
                    return true;
                }
                else if (line == "no")
                {
                    return false;
                }
                

            }
        }
    }

    class VotingType
    {
        private static void Qualified_Majority()
        {
            // Member states == Minimum “Yes” required for adoption: (55%)
            // Population == Minimum “Yes” required for adoption: 65%

        }

        private static void Reinforced_Qualified_Majority()
        {
            // Member states == Minimum “Yes” required for adoption: (72%)
            // Population == Minimum “Yes” required for adoption: 65%
        }

        private static void Simple_majority()
        {
            // Member states == Minimum “Yes” required for adoption: (50%)
            // Population == Minimum “Yes” required for adoption: 0%
        }

        private static void Unanimity()
        {
            // Member states == Minimum “Yes” required for adoption: (100%)
            // Population == Minimum “Yes” required for adoption: 0%
        }
    }
    