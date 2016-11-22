using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace katas.ConnectFour
{
    /// <summary>
    /// https://www.codewars.com/kata/connect-four-1
    /// </summary>
    public class ConnectFour
    {
        private static Dictionary<char, int> xAxes = new Dictionary<char, int>
        {
            {'A', 0},
            {'B', 1},
            {'C', 2},
            {'D', 3},
            {'E', 4},
            {'F', 5},
            {'G', 6}
        };

        public static string WhoIsWinner(List<string> piecesPositionList)
        {
            var longestSeq = 0;
            string currColor;            

            var field = piecesPositionList
                .Select((x, i) => new
                {
                    Letter = x[0],
                    Position = xAxes[x[0]],
                    Player = i % 2,
                    Move = i,
                    Color = x.Substring(2, x.Length - 2)
                })
                .GroupBy(x => x.Position)
                .ToDictionary(x => x.Key,
                    y => y.OrderBy(a => a.Move).Select((p, i) => new
                    {
                        p.Letter,
                        xPosition = p.Position,
                        yPosition = i,
                        p.Player,
                        p.Color,
                        p.Move
                    })
                        .GroupBy(gr => gr.yPosition)
                        .ToDictionary(grx => grx.Key, gry => gry.FirstOrDefault()));

            // visualise grid:
            // field.OrderBy(x0 => x0.Key)
            //     .Select((x1, i1) => string.Join(" ",
            //         x1.Value.Select((x2, i2) => string.Join("",
            //             x2.Value.Letter, "[", x1.Key, ":", x2.Key, "] ", x2.Value.Color[0]))
            //             .ToList()));

            // left->right xMax = 7, yMax = 6
            for (int y = 0; y < 6; y++)
            {
                longestSeq = 0;
                currColor = string.Empty;
                for (int x = 0; x < 7; x++)
                    if (field.ContainsKey(x) && field[x].ContainsKey(y))
                    {
                        if (currColor != field[x][y].Color)
                        {
                            longestSeq = 0;
                            currColor = field[x][y].Color;
                        }

                        longestSeq++;
                        if (longestSeq >= 4)
                        {
                            return currColor;
                        }
                    }
                    else
                    {
                        longestSeq = 0;
                        currColor = string.Empty;
                    }
            }

            // bottom->top
            for (int x = 0; x < 7; x++)
            {
                longestSeq = 0;
                currColor = string.Empty;
                if (field.ContainsKey(x))
                {
                    for (int y = 0; y < 6; y++)
                        if (field[x].ContainsKey(y))
                        {
                            if (currColor != field[x][y].Color)
                            {
                                longestSeq = 0;
                                currColor = field[x][y].Color;
                            }

                            longestSeq++;
                            if (longestSeq >= 4) return currColor;
                        }
                        else
                        {
                            longestSeq = 0;
                            currColor = string.Empty;
                        }
                }
            }

            // left-top -> right-buttom
            longestSeq = 0;
            currColor = string.Empty;
            for (var sx = 0; sx <= 3; sx++)
                for (var sy = sx == 0 ? 3 : 5; sy <= 5; sy++)
                {
                    var x = sx;
                    //for (var x = sx; x <= 6; x++)
                    for (var y = sy; y >= 0 && x <= 6; x++, y--)
                    {
                        if (field.ContainsKey(x))
                        {
                            if (field[x].ContainsKey(y))
                            {
                                if (currColor != field[x][y].Color)
                                {
                                    longestSeq = 0;
                                    currColor = field[x][y].Color;
                                }

                                longestSeq++;
                                if (longestSeq >= 4) return currColor;
                            }
                            else
                            {
                                longestSeq = 0;
                                currColor = string.Empty;
                            }
                        }
                    }
                }

            // right-top->left-bottom
            longestSeq = 0;
            currColor = string.Empty;
            for (var sx = 6; sx >= 3; sx--)
                for (var sy = sx == 6 ? 3 : 5; sy <= 5; sy++)
                {
                    var x = sx;
                    for (var y = sy; y >= 0 && x >= 0; x--, y--)
                    {
                        if (field.ContainsKey(x))
                        {
                            if (field[x].ContainsKey(y))
                            {
                                if (currColor != field[x][y].Color)
                                {
                                    longestSeq = 0;
                                    currColor = field[x][y].Color;
                                }

                                longestSeq++;
                                if (longestSeq >= 4) return currColor;
                            }
                            else
                            {
                                longestSeq = 0;
                                currColor = string.Empty;
                            }
                        }
                    }
                }

            return string.Empty;
        }
    }
}