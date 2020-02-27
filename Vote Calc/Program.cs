using System;
using System.Collections.Generic;

namespace Vot_calculator_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Voting Calculator!");
            Console.WriteLine();
            Console.WriteLine("please press anykey to begin the voting...");
            Console.ReadKey();

            Vote_type vt = new Vote_type();
            Voting_Calculator vc = new Voting_Calculator();

            vc.list_countries();
            vc.list_votes();
            vc.votes_to_countries();
            vt.qualified_majority();


        }
    }            // Face of the program that calls together the other classes 

    class Voting_Calculator     // Contains the list of countries and functions that have effects on them        
    {
        //Data
        private static List<Country> countries = new List<Country>();
        private static List<Country> yes_votes = new List<Country>();
        private static List<Country> no_votes = new List<Country>();
        private static List<Country> abstain_votes = new List<Country>();
        public static double total_pop = calculation();
        public static double total_states;


        //Methods
        public List<Country> return_list()
        {
            return countries;
        }            //Returns the list of countries
        public double return_total_pop()
        {
            return total_pop;
        }
        public double return_total_states()
        {
            return total_states;
        }

        public List<Country> list_countries()
        {
            // Populate list
            countries.Add(new Country() { num = 1, name = "Austria", pop = 9006398 });
            countries.Add(new Country() { num = 2, name = "Belgeium", pop = 11589623 });
            countries.Add(new Country() { num = 3, name = "Bulgaria", pop = 6948445 });
            countries.Add(new Country() { num = 4, name = "Croatia", pop = 4105267 });
            countries.Add(new Country() { num = 5, name = "Cyprus", pop = 1207359 });
            countries.Add(new Country() { num = 6, name = "Czech Republic", pop = 10708981 });
            countries.Add(new Country() { num = 7, name = "Denmark", pop = 5792202 });
            countries.Add(new Country() { num = 8, name = "Estonia", pop = 1326535 });
            countries.Add(new Country() { num = 9, name = "Finland", pop = 5540720 });
            countries.Add(new Country() { num = 10, name = "France", pop = 65273511 });
            countries.Add(new Country() { num = 11, name = "Germany", pop = 83783942 });
            countries.Add(new Country() { num = 12, name = "Greece", pop = 10423054 });
            countries.Add(new Country() { num = 13, name = "Hungary", pop = 9660351 });
            countries.Add(new Country() { num = 14, name = "Ireland", pop = 4937786 });
            countries.Add(new Country() { num = 15, name = "Italy", pop = 60461826 });
            countries.Add(new Country() { num = 16, name = "Lativia", pop = 1886198 });
            countries.Add(new Country() { num = 17, name = "Lithuania", pop = 2722289 });
            countries.Add(new Country() { num = 18, name = "Luxembourg", pop = 625978 });
            countries.Add(new Country() { num = 19, name = "Malta", pop = 441543 });
            countries.Add(new Country() { num = 20, name = "Netherlands", pop = 17134872 });
            countries.Add(new Country() { num = 21, name = "Poland", pop = 37846611 });
            countries.Add(new Country() { num = 22, name = "Portugal", pop = 10196709 });
            countries.Add(new Country() { num = 23, name = "Romania", pop = 19237691 });
            countries.Add(new Country() { num = 24, name = "Slovakia", pop = 5459642 });
            countries.Add(new Country() { num = 25, name = "Slovenia", pop = 2078938 });
            countries.Add(new Country() { num = 26, name = "Spain", pop = 46754778 });
            countries.Add(new Country() { num = 27, name = "Sweden", pop = 10099265 });
            return countries;
        }      //Generates the list of countries
        public string list_votes()
        {
            int counter = 0;

            foreach (Country c in countries)
            {
                string name = countries[counter].name;
                int answer;

                do
                {
                    Console.WriteLine("please enter " + name + "'s vote:");
                    Console.WriteLine("Enter 1 for yes");
                    Console.WriteLine("Enter 2 for no");
                    Console.WriteLine("Enter 3 for abstain");
                }
                while (!int.TryParse(Console.ReadLine(), out answer) || answer > 3);

                if (answer == 1)
                {
                    countries[counter].vote = "true";
                    counter++;
                }
                else if (answer == 2)
                {
                    countries[counter].vote = "false";
                    counter++;
                }
                else if (answer == 3)
                {
                    countries[counter].vote = "abstain";
                    counter++;
                }
            }
            return "Error";

        }                 //Adds votes to the list of countries
        public void votes_to_countries()
        {
            int counter = 0;

            foreach (Country c in countries)
            {
                if (countries[counter].vote == "true")
                {
                    yes_votes.Add(countries[counter]);
                }
                else if (countries[counter].vote == "false")
                {
                    no_votes.Add(countries[counter]);
                }
                else
                {
                    abstain_votes.Add(countries[counter]);
                }
            }
        }           //Seperates the countries into seperate lists depending on how they voted
        public static double calculation()
        {
            int counter = 0;
            
            foreach (Country c in yes_votes)
            {
                total_pop += c.pop;
                total_states++;
                counter++;
            }

            return total_pop;
        }
    }

    class Country               // Stores the data used by countries                  
    {
        //Data
        public int num { get; set; }
        public string name { get; set; }
        public double pop { get; set; }
        public string vote { get; set; }
    }

    class Vote_type             // Contains the methods for determining if the vote passed or not, and calculates the minimum pop and states needed for the voting methods
    {
        //Data
        private static Voting_Calculator vc = new Voting_Calculator();
        private static List<Country> countries = vc.return_list();
        private static total_states = vc.
        private static double minimum_population = get_minimum_pop();
        private static double minimum_states = get_minimum_states();

        //Methods
        public static bool qualified_majority(double pop, double states)
        {
            if (pop >= minimum_population & states >= minimum_states)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private static double get_minimum_pop()
        {
            int counter = 0;  //Counter that keeps track of which country in the list needs to be read

            foreach (Country c in countries) //Goes through the list of countries, and add their pop to the total
            {
                total_pop += countries[counter].pop;
                counter++;
            }

            double minimum_pop = (total_pop * 65) * 0.01;

            Console.WriteLine(minimum_pop);
            return minimum_pop;
        }

        private static double get_minimum_states()
        {
            double total = 0;

            foreach (Country c in countries) //Goes through the list of countries, and add their pop to the total
            {
                total++;
            }

            double minimum = (total * 55) * 0.01;

            Console.WriteLine(minimum);
            return minimum;
        }
    }
}
