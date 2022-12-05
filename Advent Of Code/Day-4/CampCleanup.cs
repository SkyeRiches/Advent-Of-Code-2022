using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    internal class CampCleanup
    {
        string path = Directory.GetCurrentDirectory() + "\\input.txt";
        int totalOverlaps = 0;

        public void RunProgram()
        {
            // Put the input file into the bin folder
            string[] fileLines = System.IO.File.ReadAllLines(path);

            for (int i = 0; i < fileLines.Length; i++)
            {
                CalculateOverlap(fileLines[i]);
            }

            Console.WriteLine("Total overlaps: " + totalOverlaps);
        }

        private void CalculateOverlap(string line)
        {
            bool overlapped = false;

            string[] split = line.Split(',');
            string[] valuesA = split[0].Split('-');
            string[] valuesB = split[1].Split('-');

            int lowA = int.Parse(valuesA[0]);
            int lowB = int.Parse(valuesB[0]);
            int hiA = int.Parse(valuesA[1]);
            int hiB = int.Parse(valuesB[1]);

            if ((lowA <= lowB && lowB <= hiA))
            {
                overlapped = true;
            }
            else if ((lowB <= lowA && lowA <= hiB))
            {
                overlapped = true;
            }

            if (overlapped)
            {
                totalOverlaps++;
            }
        }
    }
}
