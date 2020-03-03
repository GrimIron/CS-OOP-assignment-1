using System;
using System.Collections.Generic;

namespace Vot_calculator_v2

{   //Face of the program that calls together the other classes  
    class Program
    {
        static void Main(string[] args)
        {
            welcome();                      //the welcome message
            prog_qualified_majority();      //the calculator

            Console.ReadKey();
        }
        
        //Contains the Welcome messages
        private static void welcome()
        {
            Console.WriteLine("Welcome to the Voting Calculator!");
            Console.WriteLine();
            Console.WriteLine("please press any key to begin the voting...");
            Console.WriteLine();

            Console.ReadKey();
        }

        //Contains the Classes and functions for the qualified majority calculator 
        private static void prog_qualified_majority()
        {
            Voting_Calculator vc = new Voting_Calculator();                             //Initialises the Class Voting_Calculator
            Vote vote = new Vote();                                                     //Initialises the Class Vote

            List<Country> countries = vc.list_countries();                              //Generates a list of countries
            vote.get_votes(countries);                                                  //Asks the user for the vote for the countries and adds it the the list of countries
            bool pass = vc.qualified_majority(countries, vote.return_yes_list());       //Returns a true or false value based on the qualified majority rule set

            result(pass);                                                               //Runs the function result() the output wether the vote passed or not

            vote.how_voted();                                                           //Displays how many countries voted for each vote
        }

        //Takes in a bool from prog() and outputs wether the vote has passed or not
        private static void result(bool pass)
        {
            if (pass == true)
            {
                Console.WriteLine("The vote has Passed!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The vote has Failed!");
                Console.WriteLine();
            }
        }
    }

    //Gets the Votes for the countries and contains the lists that the countries are moved into after getting the votes
    class Vote
    {
        private static List<Country> yes_votes = new List<Country>();
        private static List<Country> no_votes = new List<Country>();
        private static List<Country> abstain_votes = new List<Country>();

        //Asks the user for the votes and sets them to the main country list and separates them into different lists
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
                    yes_votes.Add(countries[counter]);
                    //Console.WriteLine("ans 1");
                    counter++;
                }
                else if (answer == 2)
                {
                    countries[counter].vote = 2;
                    no_votes.Add(countries[counter]);
                    //Console.WriteLine("ans 2");
                    counter++;
                }
                else if (answer == 3)
                {
                    countries[counter].vote = 3;
                    abstain_votes.Add(countries[counter]);
                    //Console.WriteLine("ans 3");
                    counter++;
                }
            }
            return "Error";
        }

        //Returns the list yes_votes
        public List<Country> return_yes_list()
        {
            return yes_votes;
        }       

        //Displays how many countries votes for each vote e.g. yes: 20  no: 5  abstain: 2
        public void how_voted()
        {
            Console.WriteLine("votes for yes:     " + yes_list_total());
            Console.WriteLine("Votes for no:      " + no_list_total());
            Console.WriteLine("Votes for abstain: " + abstain_list_total());
        }

        //Counts how many countries voted yes
        private int yes_list_total()
        {
            int counter = 0;
            foreach (Country c in yes_votes)
            {
                counter++;
            }

            return counter;
        }

        //Counts how many countries voted no
        private int no_list_total()
        {
            int counter = 0;
            foreach (Country c in no_votes)
            {
                counter++;
            }

            return counter;
        }

        //Counts how many countries voted abstain
        private int abstain_list_total()
        {
            int counter = 0;
            foreach (Country c in abstain_votes)
            {
                counter++;
            }

            return counter;
        }

    }

    //Stores the data used by countries  
    class Country
    {
        //Data
        public int num { get; set; }
        public string name { get; set; }
        public double pop { get; set; }
        public int vote { get; set; }
    }

    //Contains the methods for determining if the vote passed or not, and calculates the minimum pop and states needed for the voting methods
    class Voting_Calculator
    {
        private static double minimum_population {get; set;}
        private static int minimum_states { get; set; }
        private double total_pop = 0;
        private double total_states = 0;

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

        //Add the number of states in the yes vote list and returns, and adds their total pop together
        private void calculate_total_pop_and_states(List<Country> yes_votes)
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
        
        //Contans the method for working out the result of the vote using a qualified majority
        public bool qualified_majority(List<Country> countries, List<Country> yes_votes)
        {
            calculate_total_pop_and_states(yes_votes);
            get_minimum_pop(countries, 65);     //total pop needs to be of 65% of minimum pop to pass
            get_minimum_states(countries, 55);  //total states needs to be of 55% of minimum states to pass

            if (total_pop >= minimum_population && total_states >= minimum_states)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Gets the minimum percentage of pop needed for the vote to pass. the percentage value can be changed via argument
        private static void get_minimum_pop(List<Country> countries, int percentage)
        {
            int counter = 0;        //Counter that keeps track of which country in the list needs to be read
            double total_pop = 0;
            
            //Goes through the list of countries, and add their pop to the total
            foreach (Country c in countries) 
            {
                total_pop += countries[counter].pop;
                counter++;
            }

            //Get percentage
            minimum_population = (total_pop * percentage) * 0.01;
        }

        //Gets the minimum percentage of states needed for the vote to pass. the percentage value can be changed via argument
        private static void get_minimum_states(List<Country> countries, int percentage)
        {
            int total = 0;

            //Goes through the list of countries, and add one to the total
            foreach (Country c in countries) 
            {
                total++;
            }

            //Get percentage
            minimum_states = (int)Math.Round((total * percentage) * 0.01);
            Console.WriteLine(minimum_states);
        }


    }
}
