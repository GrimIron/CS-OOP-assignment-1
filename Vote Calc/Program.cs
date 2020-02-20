using System;

namespace Vote_Calc
{
    class main
    {
        static void Main()
        {
            Generate_Countries();
        }

        static void Generate_Countries()
        {
            list<Country> countries = new list<Country>();

            countries.add(new Country() { num = 1, name = "Austria", pop = 9006398, eu = true });
            countries.add(new Country() { num = 2, name = "Belgeium", pop = 11589623, eu = true });
            countries.add(new Country() { num = 3, name = "Bulgaria", pop = 6948445, eu = false });
            countries.add(new Country() { num = 4, name = "Croatia", pop = 4105267, eu = false });
            countries.add(new Country() { num = 5, name = "Cyprus", pop = 1207359, eu = true });
            countries.add(new Country() { num = 6, name = "Czech Republic", pop = 10708981, eu = false });
            countries.add(new Country() { num = 7, name = "Denmark", pop = 5792202, eu = false });
            countries.add(new Country() { num = 8, name = "Estonia", pop = 1326535, eu = true });
            countries.add(new Country() { num = 9, name = "Finland", pop = 5540720, eu = true });
            countries.add(new Country() { num = 10, name = "France", pop = 65273511, eu = true });
            countries.add(new Country() { num = 11, name = "Germany", pop = 83783942, eu = true });
            countries.add(new Country() { num = 12, name = "Greece", pop = 10423054, eu = false });
            countries.add(new Country() { num = 13, name = "Hungary", pop = 9660351, eu = false });
            countries.add(new Country() { num = 14, name = "Ireland", pop = 4937786, eu = true });
            countries.add(new Country() { num = 15, name = "Italy", pop = 60461826, eu = false });
            countries.add(new Country() { num = 16, name = "Lativia", pop = 1886198, eu = false });
            countries.add(new Country() { num = 17, name = "Lithuania", pop = 2722289, eu = true });
            countries.add(new Country() { num = 18, name = "Luxembourg", pop = 625978, eu = true });
            countries.add(new Country() { num = 19, name = "Malta", pop = 441543, eu = true });
            countries.add(new Country() { num = 20, name = "Netherlands", pop = 17134872, eu = false });
            countries.add(new Country() { num = 21, name = "Poland", pop = 37846611, eu = true });
            countries.add(new Country() { num = 22, name = "Portugal", pop = 10196709, eu = true });
            countries.add(new Country() { num = 23, name = "Romania", pop = 19237691, eu = true });
            countries.add(new Country() { num = 24, name = "Slovakia", pop = 5459642, eu = true });
            countries.add(new Country() { num = 25, name = "Slovenia", pop = 2078938, eu = true });
            countries.add(new Country() { num = 26, name = "Spain", pop = 46754778, eu = true });
            countries.add(new Country() { num = 27, name = "Sweden", pop = 10099265, eu = true });

        }
            


        }
    }
    //Class for containing information regarding the countries
    class Country
    {
        int num;
        string name;            // Stores name 
        double pop;             // Country Population
        bool eu;                // Wether the country is in the eu or not

 
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
        /// int required_pop = function();
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
        }

        private static void Unanimity()
        {
            // Member states == Minimum “Yes” required for adoption: (100%)
        }
    }
}
    