using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessSimGame
{
    class Company
    {
        List<string> UsedNames = new List<string>();
        Random random = new Random();

        public string Name { get; set; }
        public int Risk { get; set; }
        public int SPrice { get; set; }
        public Company()
        {
            //Name = GetName();
            Risk = random.Next(1, 6);
            SPrice = Risk * random.Next(10, 31);
        }

        public int[] weeklyUpdate()
        {
            int[] values = new int[5];
            int dayTrend;
            int weekTrend = random.Next(0, 2);
            if (weekTrend == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    dayTrend = random.Next(-10, 11) + 2;
                    dayTrend = Risk * ((dayTrend / 6) ^ 5 + 1);
                    values[i] = dayTrend;
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    dayTrend = random.Next(-10, 11) - 2;
                    dayTrend = Risk * ((dayTrend / 6) ^ 5 + 1);
                    values[i] = dayTrend;
                }
            }

            return values;
        }

        public string GetName()
        {
            bool NameUsed;
            string NewName;

            do
            {
                string[] NameSet1 = { "Northern" , "Eastern" , "Southern" , "Western" , "Northeast" , "Southeast" , "Southwest" , "Northwest" ,
                                      "American" , "Canadian" , "Alabama" , "Alaska" , "Arizona" , "Arkansas" , "California" , "Colorado" ,
                                      "Connecticut" , "Delaware" , "Florida" , "Georgia" , "Hawaii" , "Idaho" , "Illinois" , "Indiana" , "Iowa" ,
                                      "Kansas" , "Kentucky" , "Louisiana" , "Maine" , "Maryland" , "Massachusetts" , "Michigan" , "Minnesota" ,
                                      "Mississippi" , "Missouri" , "Montana" , "Nebraska" , "Nevada" , "New Hampshire" , "New Jersey" ,
                                      "New Mexico" , "New York" , "North Carolina" , "North Dakota" , "Ohio" , "Oklahoma" , "Oregon" ,
                                      "Pennsylvania" , "Rhode Island" , "South Carolina" , "South Dakota" , "Tennessee" , "Texas" , "Utah" ,
                                      "Vermont" , "Virginia" , "Washington" , "West Virginia" , "Wisconsin" , "Wyoming" };

                string[] NameSet2 = { "Concrete" , "Conveyor Systems" , "Compisites" , "Thermal" , "Security and Protection" ,
                                      "Windows and Doors" , "Electrical" , "Safety and Protection" , "Heating and Ventilation" ,
                                      "Steel" , "Structures" , "Architecture" , "Engineering" , "Consulting" , "Software" , "Plastics" ,
                                      "Security Systems" , "Security Solutions" , "Telecommunications" , "Forestry" , "Agricultural" ,
                                      "Retailers" , "Oil and Gas" , "Solar" , "Geothermal" , "Nuclear" , "Wind" , "Electric" , "Automotive" ,
                                      "Financial" , "Food Processing" , "Natural Gas" , "Pharmaceuticals" , "Computers" , "Health Care" ,
                                      "Insurance" };

                string[] NameSet3 = { "Ltd.", "Inc.", "Corp.", "Conglomerate" };

                string Name1 = NameSet1[random.Next(0, NameSet1.Length)];
                string Name2 = NameSet1[random.Next(0, NameSet2.Length)];
                string Name3 = NameSet1[random.Next(0, NameSet3.Length)];

                NewName = Name1 + Name2 + Name3;

                NameUsed = false;
                for (int i = 0; i < UsedNames.Count - 1; i++)
                {
                    if (NewName == UsedNames[i]) { NameUsed = true; }
                }
            } while (NameUsed);

            return NewName;
        }
    }
}
