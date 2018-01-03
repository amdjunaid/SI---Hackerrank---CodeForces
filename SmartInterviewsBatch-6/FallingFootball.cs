using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class FallingFootball
    {
        static Func<int> ReadInt = () => int.Parse(Console.ReadLine().Trim());
        static Func<short> ReadShort = () => short.Parse(Console.ReadLine().Trim());
        static Func<byte> ReadByte = () => byte.Parse(Console.ReadLine().Trim());
        static Func<string> ReadString = () => Console.ReadLine().Trim();

        //to hold balls at different levels. hashset is used as we can dynamically add positions to it and can access its index at O(1)
        static List<HashSet<sbyte>> ballPositionsList = new List<HashSet<sbyte>> {
            new HashSet<sbyte>()
        };
        public static void Solve()
        {
            short t = ReadShort();
            StringBuilder output = new StringBuilder();
            for (short tc = 0; tc < t; tc++)
            {
                ballPositionsList = new List<HashSet<sbyte>> { new HashSet<sbyte>() };//reset for each test case
                byte n = ReadByte();
                sbyte[] ballPositions = ReadString().Split(' ').Select(x => sbyte.Parse(x)).ToArray();
                for (byte i = 0; i < ballPositions.Length; i++) {
                    CheckforPositionAvailability((byte)(ballPositionsList.Count-1), ballPositions[i]);
                }

                output.AppendLine("Case " + (tc + 1) + ":");

                sbyte minPositionIndex = sbyte.MaxValue;
                sbyte maxPositionIndex = sbyte.MinValue;

                //find min and max position index to limit the upper and lower bounds of output.
                var ballsPosn = ballPositionsList[0].ToList<sbyte>();
                for (sbyte i = 0; i < ballsPosn.Count(); i++) {
                    if (minPositionIndex > ballsPosn[i]) {
                        minPositionIndex = ballsPosn[i];
                    }
                    if (maxPositionIndex < ballsPosn[i]) {
                        maxPositionIndex = ballsPosn[i];
                    }
                }

                for (sbyte ithLevel = (sbyte)(ballPositionsList.Count-1);ithLevel>=0;ithLevel--)
                {
                    for (sbyte i = minPositionIndex; i <= maxPositionIndex; i++) {
                        if (ballPositionsList[ithLevel].Contains(i))
                        {
                            output.Append("O");
                        }
                        else {
                            output.Append(".");
                        }
                    }
                    output.AppendLine();
                }
            }
            Console.Write(output);
        }

        //check all the positions to consider for placement
        public static void CheckforPositionAvailability(byte i, sbyte positionToPlaceCurrentBallAt)
        {
            // if reached ground level.
            if (i == 0)
            {
                //if place is empty
                if (!ballPositionsList[i].Contains(positionToPlaceCurrentBallAt))
                {
                    PlaceBall(i, positionToPlaceCurrentBallAt);
                }//if place is occupied
                else {
                    //if left and right are occupied
                    if ((ballPositionsList[i].Contains((sbyte)(positionToPlaceCurrentBallAt - 1))) && (ballPositionsList[i].Contains((sbyte)(positionToPlaceCurrentBallAt + 1))))
                    {
                        PlaceBall(i, positionToPlaceCurrentBallAt);
                    }
                    //check if right is empty.
                    else if (!ballPositionsList[i].Contains((sbyte)(positionToPlaceCurrentBallAt + 1)))
                    {
                        PlaceBall(i, ++positionToPlaceCurrentBallAt);
                    }
                    //check if left is empty.
                    else if (!ballPositionsList[i].Contains((sbyte)(positionToPlaceCurrentBallAt - 1)))
                    {
                        PlaceBall(i, --positionToPlaceCurrentBallAt);
                    }
                }
            }
            else
            {//if level is not zero

                if (ballPositionsList[i].Contains(positionToPlaceCurrentBallAt))
                {
                    if ((ballPositionsList[i].Contains((sbyte)(positionToPlaceCurrentBallAt - 1))) && (ballPositionsList[i].Contains((sbyte)(positionToPlaceCurrentBallAt + 1))))
                    {
                        PlaceBall(i, positionToPlaceCurrentBallAt);
                    }
                    //check for availability on diagonal right at i-1th level.
                    else if (!ballPositionsList[i].Contains((sbyte)(positionToPlaceCurrentBallAt + 1)))
                    {
                        CheckforPositionAvailability(--i, ++positionToPlaceCurrentBallAt);
                    }
                    //if ballposition is unavailable at previous position,then check for diagonal left on i-1th level
                    else if (!ballPositionsList[i].Contains((sbyte)(positionToPlaceCurrentBallAt - 1)))
                    {
                        CheckforPositionAvailability(--i, --positionToPlaceCurrentBallAt);
                    }
                }
                else {
                    CheckforPositionAvailability(--i, positionToPlaceCurrentBallAt);
                }
            }
        }

        public static void PlaceBall(byte i, sbyte positionToPlaceBallAt)
        {
            if (!ballPositionsList[i].Contains(positionToPlaceBallAt))// if position is available to place ball, then place the ball.
            {
                ballPositionsList[i].Add(positionToPlaceBallAt);
            }
            else
            { // if position is occupied, then create a new level above it and place the ball at the given position
                if (ballPositionsList.Count == (++i))
                {
                    ballPositionsList.Add(new HashSet<sbyte>());
                }
                ballPositionsList[i].Add(positionToPlaceBallAt);
            }
        }
    }
}
