using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    internal class RockPaperScissors
    {
        int totalScore1 = 0;
        int totalScore2 = 0;
        public void RunProgram()
        {
            // Put the input file into the bin folder
            string path = Directory.GetCurrentDirectory() + "\\input.txt";
            string[] fileLines = System.IO.File.ReadAllLines(path);

            for (int i = 0; i < fileLines.Length; i++)
            {
                // layout = 'A X'
                // need to split string
                char opponent = char.Parse(fileLines[i].Substring(0, 1));
                char play = char.Parse(fileLines[i].Substring(2, 1));

                CalculatePart1(opponent, play);

                CalculatePart2(opponent, play);
            }

            Console.WriteLine("Total Score For Part 1 Is: " + totalScore1);
            Console.WriteLine("Total Score For Part 2 Is: " + totalScore2);
        }

        private void CalculatePart1(char opponent, char play)
        {
            //------------------ score for playing ------------------\\
            if (play == 'X')
            {
                totalScore1 += 1;
            }
            else if (play == 'Y')
            {
                totalScore1 += 2;
            }
            else if (play == 'Z')
            {
                totalScore1 += 3;
            }

            //------------------ Result Score ------------------\\

            if (opponent == 'A')
            {
                if (play == 'X')
                {
                    totalScore1 += 3;
                }
                else if (play == 'Y')
                {
                    totalScore1 += 6;
                }
            }
            else if (opponent == 'B')
            {
                if (play == 'Y')
                {
                    totalScore1 += 3;
                }
                else if (play == 'Z')
                {
                    totalScore1 += 6;
                }
            }
            else if (opponent == 'C')
            {
                if (play == 'Z')
                {
                    totalScore1 += 3;
                }
                else if (play == 'X')
                {
                    totalScore1 += 6;

                }
            }
        }

        private void CalculatePart2(char opponent, char outcome)
        {
            char play = ' ';

            if (outcome == 'X')
            {
                // lose
                if (opponent == 'A')
                {
                    play = 'C';
                }
                else if (opponent == 'B')
                {
                    play = 'A';
                }
                else if (opponent == 'C')
                {
                    play = 'B';
                }
            }
            else if (outcome == 'Y')
            {
                // draw
                totalScore2 += 3;

                play = opponent;
            }
            else if (outcome == 'Z')
            {
                // win
                totalScore2 += 6;

                if (opponent == 'A')
                {
                    play = 'B';
                }
                else if (opponent == 'B')
                {
                    play = 'C';
                }
                else if (opponent == 'C')
                {
                    play = 'A';
                }
            }


            if (play == 'A')
            {
                totalScore2 += 1;
            }
            else if (play == 'B')
            {
                totalScore2 += 2;
            }
            else if (play == 'C')
            {
                totalScore2 += 3;
            }
            
        }
    }
}
