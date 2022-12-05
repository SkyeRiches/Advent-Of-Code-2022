using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    internal class RucksackReorganise
    {
        public void RunProgram()
        {
            // Put the input file into the bin folder
            string path = Directory.GetCurrentDirectory() + "\\input.txt";
            string[] fileLines = System.IO.File.ReadAllLines(path);

            FindCommonItems(fileLines);

            FindElfGroups(fileLines);
        }

        private void FindCommonItems(string[] fileLines)
        {
            List<char> duplicates = new List<char>();

            for (int i = 0; i < fileLines.Length; i++)
            {
                char[] half1 = fileLines[i].Substring(0, fileLines[i].Length / 2).ToCharArray();
                char[] half2 = fileLines[i].Substring(fileLines[i].Length / 2, fileLines[i].Length / 2).ToCharArray();

                bool added = false;

                for (int j = 0; j < half1.Length; j++)
                {
                    for (int k = 0; k < half2.Length; k++)
                    {
                        if (half1[j] == half2[k] && !added)
                        {
                            duplicates.Add(half1[j]);
                            added = true;
                        }
                    }
                }
            }

            // A == 65
            // a == 97
            int totalPriority = 0;

            for (int i = 0; i < duplicates.Count; i++)
            {
                int value = (int)duplicates[i];
                if (char.IsUpper(duplicates[i]))
                {
                    value = value - 38;
                }
                else
                {
                    value = value - 96;
                }

                totalPriority += value;
            }

            Console.WriteLine("number of lines: " + fileLines.Length);
            Console.WriteLine("number of duplicates: " + duplicates.Count);
            Console.WriteLine("Total Priority: " + totalPriority);
        }

        private void FindElfGroups(string[] fileLines)
        {
            List<char> groupBadges = new List<char>();

            int pos = 0;

            int totalPriority = 0;

            for (int i = 0; i < fileLines.Length; i+=3)
            {
                char[] elf1 = fileLines[i].ToCharArray();
                char[] elf2 = fileLines[i + 1].ToCharArray();
                char[] elf3 = fileLines[i + 2].ToCharArray();

                bool added = false;

                for (int j = 0; j < elf1.Length; j++)
                {
                    for (int k = 0; k < elf2.Length; k++)
                    {
                        if (elf1[j] == elf2[k])
                        {
                            for (int l = 0; l < elf3.Length; l++)
                            {
                                if (elf3[l] == elf2[k] && !added)
                                {
                                    groupBadges.Add(elf3[l]);
                                    added = true;
                                }
                            }
                        }
                    }
                }

                pos += 3;
            }

            for (int i = 0; i < groupBadges.Count; i++)
            {
                int value = (int)groupBadges[i];
                if (char.IsUpper(groupBadges[i]))
                {
                    value = value - 38;
                }
                else
                {
                    value = value - 96;
                }

                totalPriority += value;
            }

            Console.WriteLine("number of lines: " + fileLines.Length);
            Console.WriteLine("number of duplicates: " + groupBadges.Count);
            Console.WriteLine("Total Priority: " + totalPriority);
        }
    }
}
