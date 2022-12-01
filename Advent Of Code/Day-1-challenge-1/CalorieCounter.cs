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
            string path = "D:\\Advent Code\\Advent Of Code\\Day-1-challenge-1\\input.txt";
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

            Console.WriteLine(total);
        }
    }
}
