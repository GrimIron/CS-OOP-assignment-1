using System;
using System.Collections.Generic;

namespace Vot_calculator_v2

{   // Face of the program that calls together the other classes 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Voting Calculator!");
            Console.WriteLine();
            Console.WriteLine("please press any key to begin the voting...");
            Console.WriteLine();

            Console.ReadKey();

            Voting_Calculator vc = new Voting_Calculator();         //initialises the Class Voting_Calculator
            List<Country> countries = vc.list_countries();          //Generates a list of countries
            

            Vote vote = new Vote();                                 //initialises the Class Vote
            vote.get_votes(countries);
            vote.votes_to_countries(countries);                     //Separates the Countries into different list depending on the votes
            List<Country> yes = vote.return_yes_list();
            List<Country> no = vote.return_no_list();
            List<Country> abstain = vote.return_abstain_list();


            Vote_type vt = new Vote_type();
            vt.get_minimum_pop_qm(countries);
            vt.get_minimum_states_qm(countries);

            vc.calculate_total_pop_and_states(yes);

            bool pass = vt.qualified_majority(vc.total_pop, vc.total_states);

            Console.WriteLine(pass);
            Console.ReadLine();
        }
    }

    // Contains the list of countries and functions that have effects on them  
    class Voting_Calculator
    {
        private List<Country> countries = new List<Country>();
        public double total_pop = 0;
        public double total_states = 0;

        //Generates the list of countries
        public List<Country> list_countries()
        {
            List<Country> countries = new List<Country>();

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
        }

        //add the number of states in the yes vote list and returns, and calculates their total pop
        public void calculate_total_pop_and_states(List<Country> yes_votes)
        {
            int counter = 0;

            foreach (Country c in yes_votes)
            {
                total_pop += c.pop;
                total_states++;
                //Console.WriteLine(total_pop);
                //Console.WriteLine(total_states);

                counter++;
            }
        }

    }

    class Vote
    {
        private static List<Country> yes_votes = new List<Country>();
        private static List<Country> no_votes = new List<Country>();
        private static List<Country> abstain_votes = new List<Country>();

        //Asks the user for the votes and sets them to the country list
        public string get_votes(List<Country> countries)
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
                    countries[counter].vote = 1;
                    //Console.WriteLine("ans 1");
                    counter++;
                }
                else if (answer == 2)
                {
                    countries[counter].vote = 2;
                    //Console.WriteLine("ans 2");
                    counter++;
                }
                else if (answer == 3)
                {
                    countries[counter].vote = 3;
                    //Console.WriteLine("ans 3");
                    counter++;
                }
            }
            return "Error";

        }

        //Seperates the countries into seperate lists depending on how they voted
        public void votes_to_countries(List<Country> countries)
        {
            int counter = 0;

            foreach (Country c in countries)
            {
                //Console.WriteLine(countries[counter].name);
                //Console.WriteLine(countries[counter].vote);
                if (countries[counter].vote == 1)
                {
                    yes_votes.Add(countries[counter]);
                    counter++;
                }
                else if (countries[counter].vote == 2)
                {
                    no_votes.Add(countries[counter]);
                    counter++;
                }
                else
                {
                    abstain_votes.Add(countries[counter]);
                    counter++;
                }
            }
        }

        public List<Country> return_yes_list()
        {
            return yes_votes;
        }

        public List<Country> return_no_list()
        {
            return no_votes;
        }

        public List<Country> return_abstain_list()
        {
            return abstain_votes;
        }
    }

    // Stores the data used by countries  
    class Country
    {
        //Data
        public int num { get; set; }
        public string name { get; set; }
        public double pop { get; set; }
        public int vote { get; set; }
    }

    // Contains the methods for determining if the vote passed or not, and calculates the minimum pop and states needed for the voting methods
    class Vote_type
    {
        //Data
        private static double minimum_population_qm {get; set;}     //Qualified Majority required pop
        private static double minimum_population_rm { get; set; }   //Qualified Majority required pop
        private static double minimum_population_sm { get; set; }   //Qualified Majority required pop
        private static double minimum_states_qm { get; set; }
        private static double minimum_states_qrm { get; set; }

        //Methods
        public bool qualified_majority(double pop, double states)
        {
            //Console.WriteLine(pop);
            //Console.WriteLine(states);
            Console.WriteLine(minimum_population_qm);
            Console.WriteLine(minimum_states_qm);
            if (pop >= minimum_population_qm && states >= minimum_states_qm)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void get_minimum_pop_qm(List<Country> countries)
        {
            int counter = 0;  //Counter that keeps track of which country in the list needs to be read
            double total_pop = 0;

            Console.WriteLine("here");

            foreach (Country c in countries) //Goes through the list of countries, and add their pop to the total
            {
                Console.WriteLine(countries[counter].name);
                total_pop += countries[counter].pop;
                Console.WriteLine(total_pop);
                counter++;
            }

            //Get percentage
            minimum_population_qm = (total_pop * 65) * 0.01;

            Console.WriteLine(minimum_population_qm);
        }

        public void get_minimum_pop_qrm(List<Country> countries)
        {
            int counter = 0;  //Counter that keeps track of which country in the list needs to be read
            double total_pop = 0;

            Console.WriteLine("here");

            foreach (Country c in countries) //Goes through the list of countries, and add their pop to the total
            {
                Console.WriteLine(countries[counter].name);
                total_pop += countries[counter].pop;
                Console.WriteLine(total_pop);
                counter++;
            }

            //Get percentage
            minimum_population_qm = (total_pop * 65) * 0.01;

            Console.WriteLine(minimum_population_qm);
        }

        public void get_minimum_pop_sm(List<Country> countries)
        {
            int counter = 0;  //Counter that keeps track of which country in the list needs to be read
            double total_pop = 0;

            Console.WriteLine("here");

            foreach (Country c in countries) //Goes through the list of countries, and add their pop to the total
            {
                Console.WriteLine(countries[counter].name);
                total_pop += countries[counter].pop;
                Console.WriteLine(total_pop);
                counter++;
            }

            //Get percentage
            minimum_population_qm = (total_pop * 65) * 0.01;

            Console.WriteLine(minimum_population_qm);
        }

        public void get_minimum_pop_u(List<Country> countries)
        {
            int counter = 0;  //Counter that keeps track of which country in the list needs to be read
            double total_pop = 0;

            Console.WriteLine("here");

            foreach (Country c in countries) //Goes through the list of countries, and add their pop to the total
            {
                Console.WriteLine(countries[counter].name);
                total_pop += countries[counter].pop;
                Console.WriteLine(total_pop);
                counter++;
            }

            //Get percentage
            minimum_population_qm = (total_pop * 65) * 0.01;

            Console.WriteLine(minimum_population_qm);
        }

        public void get_minimum_states_qm(List<Country> countries)
        {
            double total = 0;

            foreach (Country c in countries) //Goes through the list of countries, and add their pop to the total
            {
                total++;
            }

            //Get percentage
            minimum_states_qm = (total * 55) * 0.01;

            Console.WriteLine(minimum_states_qm);
            
        }
    }
}
