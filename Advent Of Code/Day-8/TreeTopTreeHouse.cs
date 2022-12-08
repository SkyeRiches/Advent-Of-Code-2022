using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    internal class TreeTopTreeHouse
    {
        string path = Directory.GetCurrentDirectory() + "\\input.txt";
        string[] fileLines;

        int[,] treeGrid;
        int rowLength;

        List<int> visibleTrees = new List<int>();
        List<int> scenicScores = new List<int>();

        public void RunProgram()
        {
            fileLines = System.IO.File.ReadAllLines(path);

            rowLength = fileLines[0].Length;

            treeGrid = new int[fileLines.Length, rowLength];

            for (int i = 0; i < fileLines.Length; i++)
            {
                char[] line = fileLines[i].ToCharArray();

                for (int j = 0; j < rowLength; j++)
                {
                    treeGrid[i, j] = int.Parse(line[j].ToString());
                }
            }

            for (int i = 0; i < fileLines.Length; i++)
            {
                if (i == 0 || i == fileLines.Length - 1) continue; // ignore first and last row cos its the edge

                for (int j = 0; j < rowLength; j++)
                {
                    if (j == 0 || j == rowLength - 1) continue; // ignore first and last column cos its the edge

                    //bool visible = CheckVisibility(i, j);
                    //if (visible)
                    //{
                    //    visibleTrees.Add(treeGrid[i, j]);
                    //}

                    scenicScores.Add(CalculateScore(i, j));
                }
            }

            //Console.WriteLine(visibleTrees.Count + (2 * rowLength) + (2 * (fileLines.Length - 2)));
            int[] scores = scenicScores.ToArray();
            Array.Sort(scores);

            Console.WriteLine("Max Scene Score = " + scores[scores.Length - 1]);
        }

        private bool CheckVisibility(int row, int column)
        {
            bool left = true;
            bool right = true;
            bool top = true;
            bool down = true;

            for (int i = 0; i < column; i++)
            {
                if (treeGrid[row, i] >= treeGrid[row, column])
                {
                    left = false;
                }
            }

            for (int i = column + 1; i < rowLength; i++)
            {
                if (treeGrid[row, i] >= treeGrid[row, column])
                {
                    right = false;
                }
            }

            for (int i = 0; i < row; i++)
            {
                if (treeGrid[i, column] >= treeGrid[row, column])
                {
                    top = false;
                }
            }

            for (int i = row + 1; i < fileLines.Length; i++)
            {
                if (treeGrid[i, column] >= treeGrid[row, column])
                {
                    down = false;
                }
            }

            if (left || right || top || down)
            {
                return true;
            }
            return false;
        }

        private int CalculateScore(int row, int column)
        {
            int left = 0;
            int right = 0;
            int top = 0;
            int down = 0;

            for (int i = column - 1; i >= 0; i--)
            {
                left++;

                if (treeGrid[row, i] >= treeGrid[row, column])
                {
                    break;
                }
            }

            for (int i = column + 1; i < rowLength; i++)
            {
                right++;

                if (treeGrid[row, i] >= treeGrid[row, column])
                {
                    break;
                }
            }

            for (int i = row - 1; i >= 0; i--)
            {
                top++;

                if (treeGrid[i, column] >= treeGrid[row, column])
                {
                    break;
                }
            }

            for (int i = row + 1; i < fileLines.Length; i++)
            {
                down++;

                if (treeGrid[i, column] >= treeGrid[row, column])
                {
                    break;
                }
            }

            return right * left * top * down;
        }
    }
}
