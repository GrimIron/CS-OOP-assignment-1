using System;
using System.Collections.Generic;
using System.Text;

namespace Vote_Calc
{

    class Population
    {

        

    }



    class VotingType
    {

        int totalPop = 500000000;
        int numCountries = 27;
        double newPop;
        double numOfAddedCountries;

        list<Country>countries;
            {
            countries[0].pop
            }


            public void Percentage()
            {

            int Per = ((totalPop / 100) * countryPop); 

            }

            private static void Qualified_Majority()
            {

                double minMemberStates = 55;
                double minPopulation = 65;
                
                // Member states == Minimum “Yes” required for adoption: (55%)
                // Population == Minimum “Yes” required for adoption: 65%

                if(numOfAddedCountries >= minMemberStates)
                {
                    Console.WriteLine("The 55% requirement has been reached, for Qualified Majority");

                }
                    else if (numOfAddedCountries < minMemberStates)
                {
                    Console.WriteLine("The 55% requirement had not been reached, for Qualified Majority");
                }
                
                if (newPop >= minMemberStates)
                {
                    Console.WriteLine("The 65% requirement had not been reached, for Qualified Majority");
                }
                    else if (newPop < minMemberStates)
                    {
                        Console.WriteLine("The 65% requirement had not been reached, for Qualified Majority");
                    }

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
}
