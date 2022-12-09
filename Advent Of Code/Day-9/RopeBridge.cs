using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Day_9
{
    internal class RopeBridge
    {
        string path = Directory.GetCurrentDirectory() + "\\input.txt";
        string[] fileLines;

        List<Vector2> positions = new List<Vector2>();
        Vector2 headPos = new Vector2(0, 0);
        Vector2 tailPos = new Vector2(0, 0);
        Vector2[] ropePos = new Vector2[9];

        public void RunProgram()
        {
            fileLines = File.ReadAllLines(path);

            for (int i = 0; i < fileLines.Length; i++)
            {
                string[] splitStr = fileLines[i].Split(' ');
                TrackPositionsPart2(splitStr[0], int.Parse(splitStr[1]));
            }

            Console.WriteLine("Number of positions visited = " + positions.Count);
        }

        private void TrackPositions(string dir, int movement)
        {
            switch (dir)
            {
                case "U":
                    for (int i = 0; i < movement; i++)
                    {
                        headPos = new Vector2(headPos.X, headPos.Y + 1);

                        if ((tailPos.X == headPos.X) && (headPos.Y > tailPos.Y + 1))
                        {
                            tailPos = new Vector2(tailPos.X, tailPos.Y + 1);
                        }
                        else if ((headPos.Y > tailPos.Y + 1) && (tailPos.X != headPos.X))
                        {
                            tailPos = new Vector2(headPos.X, tailPos.Y + 1);
                        }
                        else
                        {
                            Console.WriteLine("Hit else");
                        }

                        bool inList = false;

                        for (int j = 0; j < positions.Count; j++)
                        {
                            if (positions[j] == tailPos)
                            {
                                inList = true;
                                break;
                            }
                        }

                        if (!inList)
                        {
                            positions.Add(tailPos);
                        }
                    }
                    break;

                case "D":
                    for (int i = 0; i < movement; i++)
                    {
                        headPos = new Vector2(headPos.X, headPos.Y - 1);

                        if ((tailPos.X == headPos.X) && (headPos.Y < tailPos.Y - 1))
                        {
                            tailPos = new Vector2(tailPos.X, tailPos.Y - 1);
                        }
                        else if ((headPos.Y < tailPos.Y - 1) && (tailPos.X != headPos.X))
                        {
                            tailPos = new Vector2(headPos.X, tailPos.Y - 1);
                        }
                        else
                        {
                            Console.WriteLine("Hit else");
                        }

                        bool inList = false;

                        for (int j = 0; j < positions.Count; j++)
                        {
                            if (positions[j] == tailPos)
                            {
                                inList = true;
                                break;
                            }
                        }

                        if (!inList)
                        {
                            positions.Add(tailPos);
                        }
                    }
                    break;

                case "L":
                    for (int i = 0; i < movement; i++)
                    {
                        headPos = new Vector2(headPos.X - 1, headPos.Y);

                        if ((tailPos.Y == headPos.Y) && (headPos.X < tailPos.X - 1))
                        {
                            tailPos = new Vector2(tailPos.X - 1, tailPos.Y);
                        }
                        else if ((tailPos.Y != headPos.Y) && (headPos.X < tailPos.X - 1))
                        {
                            tailPos = new Vector2(tailPos.X - 1, headPos.Y);
                        }
                        else
                        {
                            Console.WriteLine("Hit else");
                        }

                        bool inList = false;

                        for (int j = 0; j < positions.Count; j++)
                        {
                            if (positions[j] == tailPos)
                            {
                                inList = true;
                                break;
                            }
                        }

                        if (!inList)
                        {
                            positions.Add(tailPos);
                        }
                    }
                    break;

                case "R":
                    for (int i = 0; i < movement; i++)
                    {
                        headPos = new Vector2(headPos.X + 1, headPos.Y);

                        if ((tailPos.Y == headPos.Y) && (headPos.X > tailPos.X + 1))
                        {
                            tailPos = new Vector2(tailPos.X + 1, tailPos.Y);
                        }
                        else if ((tailPos.Y != headPos.Y) && (headPos.X > tailPos.X + 1))
                        {
                            tailPos = new Vector2(tailPos.X + 1, headPos.Y);
                        }
                        else
                        {
                            Console.WriteLine("Hit else");
                        }

                        bool inList = false;

                        for (int j = 0; j < positions.Count; j++)
                        {
                            if (positions[j] == tailPos)
                            {
                                inList = true;
                                break;
                            }
                        }

                        if (!inList)
                        {
                            positions.Add(tailPos);
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void TrackPositionsPart2(string dir, int movement)
        {
            switch (dir)
            {
                case "U":
                    for (int i = 0; i < movement; i++)
                    {
                        headPos = new Vector2(headPos.X, headPos.Y + 1);

                        for (int j = 0; j < ropePos.Length; j++)
                        {
                            if (j == 0)
                            {
                                if ((ropePos[j].X == headPos.X) && (headPos.Y > ropePos[j].Y + 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X, ropePos[j].Y + 1);
                                }
                                else if ((headPos.Y > ropePos[j].Y + 1) && (ropePos[j].X != headPos.X))
                                {
                                    ropePos[j] = new Vector2(headPos.X, ropePos[j].Y + 1);
                                }
                            }
                            else
                            {
                                if ((ropePos[j].X == ropePos[j - 1].X) && (ropePos[j-1].Y > ropePos[j].Y + 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X, ropePos[j].Y + 1);
                                }
                                else if ((ropePos[j-1].Y > ropePos[j].Y + 1) && (ropePos[j].X != ropePos[j-1].X))
                                {
                                    ropePos[j] = new Vector2(ropePos[j-1].X, ropePos[j].Y + 1);
                                }
                            }
                        }

                        bool inList = false;

                        for (int j = 0; j < positions.Count; j++)
                        {
                            if (positions[j] == ropePos[8])
                            {
                                inList = true;
                                break;
                            }
                        }

                        if (!inList)
                        {
                            positions.Add(ropePos[8]);
                        }
                    }
                    break;

                case "D":
                    for (int i = 0; i < movement; i++)
                    {
                        headPos = new Vector2(headPos.X, headPos.Y - 1);

                        for (int j = 0; j < ropePos.Length; j++)
                        {
                            if (j == 0)
                            {
                                if ((ropePos[j].X == headPos.X) && (headPos.Y < ropePos[j].Y - 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X, ropePos[j].Y - 1);
                                }
                                else if ((headPos.Y < ropePos[j].Y - 1) && (ropePos[j].X != headPos.X))
                                {
                                    ropePos[j] = new Vector2(headPos.X, ropePos[j].Y - 1);
                                }
                            }
                            else
                            {
                                if ((ropePos[j].X == ropePos[j - 1].X) && (ropePos[j - 1].Y < ropePos[j].Y - 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X, ropePos[j].Y - 1);
                                }
                                else if ((ropePos[j - 1].Y < ropePos[j].Y - 1) && (ropePos[j].X != ropePos[j - 1].X))
                                {
                                    ropePos[j] = new Vector2(ropePos[j - 1].X, ropePos[j].Y - 1);
                                }
                            }
                        }

                            bool inList = false;

                        for (int j = 0; j < positions.Count; j++)
                        {
                            if (positions[j] == ropePos[8])
                            {
                                inList = true;
                                break;
                            }
                        }

                        if (!inList)
                        {
                            positions.Add(ropePos[8]);
                        }
                    }
                    break;

                case "L":
                    for (int i = 0; i < movement; i++)
                    {
                        headPos = new Vector2(headPos.X - 1, headPos.Y);

                        for (int j = 0; j < ropePos.Length; j++)
                        {
                            if (j == 0)
                            {
                                if ((ropePos[j].Y == headPos.Y) && (headPos.X < ropePos[j].X - 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X - 1, ropePos[j].Y);
                                }
                                else if ((ropePos[j].Y != headPos.Y) && (headPos.X < ropePos[j].X - 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X - 1, headPos.Y);
                                }
                            }
                            else
                            {
                                if ((ropePos[j].Y == ropePos[j-1].Y) && (ropePos[j-1].X < ropePos[j].X - 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X - 1, ropePos[j].Y);
                                }
                                else if ((ropePos[j].Y != ropePos[j-1].Y) && (ropePos[j-1].X < ropePos[j].X - 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X - 1, ropePos[j-1].Y);
                                }
                            }
                        }

                        bool inList = false;

                        for (int j = 0; j < positions.Count; j++)
                        {
                            if (positions[j] == ropePos[8])
                            {
                                inList = true;
                                break;
                            }
                        }

                        if (!inList)
                        {
                            positions.Add(ropePos[8]);
                        }
                    }
                    break;

                case "R":
                    for (int i = 0; i < movement; i++)
                    {
                        headPos = new Vector2(headPos.X + 1, headPos.Y);

                        for (int j = 0; j < ropePos.Length; j++)
                        {
                            if (j == 0)
                            {
                                if ((ropePos[j].Y == headPos.Y) && (headPos.X > ropePos[j].X + 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X + 1, ropePos[j].Y);
                                }
                                else if ((ropePos[j].Y != headPos.Y) && (headPos.X > ropePos[j].X + 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X + 1, headPos.Y);
                                }
                            }
                            else
                            {
                                if ((ropePos[j].Y == ropePos[j - 1].Y) && (ropePos[j - 1].X > ropePos[j].X + 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X + 1, ropePos[j].Y);
                                }
                                else if ((ropePos[j].Y != ropePos[j - 1].Y) && (ropePos[j - 1].X > ropePos[j].X + 1))
                                {
                                    ropePos[j] = new Vector2(ropePos[j].X + 1, ropePos[j - 1].Y);
                                }
                            }
                        }

                        bool inList = false;

                        for (int j = 0; j < positions.Count; j++)
                        {
                            if (positions[j] == ropePos[8])
                            {
                                inList = true;
                                break;
                            }
                        }

                        if (!inList)
                        {
                            positions.Add(ropePos[8]);
                        }
                    }
                    break;

                default:
                    break;
            }

            Console.WriteLine("Head: " + ropePos[4].ToString());
        }
    }
}
