using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    internal class SupplyStacks
    {
        string path = Directory.GetCurrentDirectory() + "\\input.txt";

        #region ARRAYS
        char[] a1 = new char[] { 'T', 'D', 'W', 'Z', 'V', 'P' };
        char[] a2 = new char[] { 'L', 'S', 'W', 'V', 'F', 'J', 'D' };
        char[] a3 = new char[] { 'Z', 'M', 'L', 'S', 'V', 'T', 'B', 'H' };
        char[] a4 = new char[] { 'R', 'S', 'J' };
        char[] a5 = new char[] { 'C', 'Z', 'B', 'G', 'F', 'M', 'L', 'W' };
        char[] a6 = new char[] { 'Q', 'W', 'V', 'H', 'Z', 'R', 'G', 'B' };
        char[] a7 = new char[] { 'V', 'J', 'P', 'C', 'B', 'D', 'N' };
        char[] a8 = new char[] { 'P', 'T', 'B', 'Q' };
        char[] a9 = new char[] { 'H', 'G', 'Z', 'R', 'C' };
        #endregion

        #region STACKS
        Stack<char> s1;
        Stack<char> s2;
        Stack<char> s3;
        Stack<char> s4;
        Stack<char> s5;
        Stack<char> s6;
        Stack<char> s7;
        Stack<char> s8;
        Stack<char> s9;
        #endregion

        List<int> amount = new List<int>();
        List<int> start = new List<int>();
        List<int> end = new List<int>();
        List<Stack<char>> stacks = new List<Stack<char>>();

        public void RunProgram()
        {
            s1 = new Stack<char>(a1); stacks.Add(s1);
            s2 = new Stack<char>(a2); stacks.Add(s2);
            s3 = new Stack<char>(a3); stacks.Add(s3);
            s4 = new Stack<char>(a4); stacks.Add(s4);
            s5 = new Stack<char>(a5); stacks.Add(s5);
            s6 = new Stack<char>(a6); stacks.Add(s6);
            s7 = new Stack<char>(a7); stacks.Add(s7);
            s8 = new Stack<char>(a8); stacks.Add(s8);
            s9 = new Stack<char>(a9); stacks.Add(s9);

            // Put the input file into the bin folder
            string[] fileLines = System.IO.File.ReadAllLines(path);

            Console.WriteLine("Number of instructions: " + fileLines.Length);

            GetInstructions(fileLines);

            for (int i = 0; i < fileLines.Length; i++)
            {
                CrateMove(i);
            }

            GetTopRow();
        }

        private void GetInstructions(string[] fileLines)
        {
            // FORMAT PASSED IN: "Move 0 from 0 to 0"
            // loop through all the lines in the file and split the contents of each line based on gaps. 
            // then store the values into the 3 appropriate list, ignoring the parts that are words and not ints.
            for (int i = 0; i < fileLines.Length; i++)
            {
                string[] split = fileLines[i].Split(' ');
                amount.Add(int.Parse(split[1])); // first value in the data passed in
                start.Add(int.Parse(split[3])); // 2nd value in the data passed in
                end.Add(int.Parse(split[5])); // 3rd value in the data passed in
            }
        }

        private void CrateMove(int i)
        {
            char[] removed = new char[amount[i]];

            // loop for amount of times specified in the amount instruction
            for (int j = 0; j < amount[i]; j++)
            {
                removed[j] = stacks[start[i] - 1].Pop(); // remove from the starting stack and return
            }

            for (int j = 0; j < removed.Length; j++)
            {
                stacks[end[i] - 1].Push(removed[(removed.Length - 1) - j]); // add to the target stack
            }
        }

        private void GetTopRow()
        {
            char[] top = new char[9];

            for (int i = 0; i < top.Length; i++)
            {
                top[i] = stacks[i].Peek();
            }

            Console.WriteLine(top);
        }
    }
}
