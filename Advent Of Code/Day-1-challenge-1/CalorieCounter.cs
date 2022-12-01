using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1_challenge_1
{
    internal class CalorieCounter
    {

        List<int> carrying = new List<int>();

        public void RunProgram()
        {
            // Put the input file into the bin folder
            string path = Directory.GetCurrentDirectory() + "\\input.txt";
            string[] fileLines = System.IO.File.ReadAllLines(path);

            int carryAmount = 0;

            for (int i = 0; i < fileLines.Length; i++)
            {
                if (fileLines[i] != "")
                {
                    carryAmount += int.Parse(fileLines[i]);
                }
                else if (fileLines[i] == "")
                {
                    carrying.Add(carryAmount);

                    carryAmount = 0;
                }
            }

            carrying.Sort();

            int total = carrying[carrying.Count - 1] + carrying[carrying.Count - 2] + carrying[carrying.Count - 3];

            Console.WriteLine("Highest Carry Amount Is: " + carrying[carrying.Count - 1]);
            Console.WriteLine("Total Of The Top 3 Carry Amounts Is: " + total);
        }
    }
}
