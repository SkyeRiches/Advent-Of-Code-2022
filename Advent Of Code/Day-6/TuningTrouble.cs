using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    internal class TuningTrouble
    {
        string path = Directory.GetCurrentDirectory() + "\\input.txt";

        string content = "";

        public void RunProgram()
        {
            string[] fileLines = System.IO.File.ReadAllLines(path);

            foreach (string line in fileLines)
            {
                content += line;
            }

            char[] array = content.ToCharArray();

            Console.WriteLine("Length: " + array.Length);

            int marker = FindMarker(array) + 1; //add one because the array is starting at 0 but the marker number is starting at 1
            int message = 0;

            for (int i = 0; i < array.Length; i++)
            {
                message = FindMessage(array, i) + 1;
                if (message > 1) break;
            }

            Console.WriteLine("packet marker: " + marker);
            Console.WriteLine("Message marker: " + message);
        }

        private int FindMarker(char[] signal)
        {
            for (int i = 0; i < signal.Length; i++)
            {
                if (signal[i] != signal[i + 1] && signal[i] != signal[i + 2] && signal[i] != signal[i + 3])
                {
                    if (signal[i + 1] != signal[i + 2] && signal[i + 1] != signal[i + 3])
                    {
                        if (signal[i + 2] != signal[i + 3])
                        {
                            return i + 3;
                        }
                    }
                }
            }

            return 0;
        }

        private int FindMessage(char[] signal, int i)
        {
            if (i + 13 > signal.Length - 1) return 0; // the total num of characters isnt divisble by 14 so if i + 13 is more than the final index, there is no message

            char[] section = new char[14]; // create a sub array that is the 14 to loop through

            // fill the array
            for (int j = 0; j < section.Length; j++)
            {
                section[j] = signal[i + j];
            }

            bool foundDuplicate = false;

            // loop through array
            for (int k = 0; k < section.Length; k++)
            {
                // loop remaining elements in array after current index to see if it matches current index of first loop
                for (int l = 1; l < section.Length - k; l++)
                {
                    // if there is a match at any point, then a duplicate is found so it cant be a message
                    if (section[k] == section[k + l])
                    {
                        foundDuplicate = true;
                    }
                }
            }

            if (!foundDuplicate)
            {
                return i + 13;
            }

            return 0;
        }
    }
}
