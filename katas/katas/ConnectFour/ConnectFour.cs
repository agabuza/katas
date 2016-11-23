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

            var winCollections = new List<List<Tuple<int, string>>>();

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
            var currColor = string.Empty;
            var currWinCollection = new Queue<Tuple<int, string>>();

            var verify = new Func<int, int, Queue<Tuple<int, string>>, List<Tuple<int, string>>>((x, y, collection) =>
            {
                if (field.ContainsKey(x) && field[x].ContainsKey(y))
                {
                    if (currColor != field[x][y].Color)
                    {
                        currColor = field[x][y].Color;
                        collection.Clear();
                    }

                    collection.Enqueue(new Tuple<int, string>(field[x][y].Move, field[x][y].Color));

                    if (collection.Count == 4)
                    {
                        winCollections.Add(collection.ToList());
                        collection.Dequeue();
                    }
                }
                else
                {
                    collection.Clear();
                    currColor = string.Empty;
                }

                return collection.ToList();
            });

            // visualise grid:
            // field.OrderBy(x0 => x0.Key)
            //     .Select((x1, i1) => string.Join(" ",
            //         x1.Value.Select((x2, i2) => string.Join("",
            //             x2.Value.Letter, "[", x1.Key, ":", x2.Key, "] ", x2.Value.Color[0]))
            //             .ToList()));

            // left->right
            for (int y = 0; y < 6; y++)
            {
                currColor = string.Empty;
                currWinCollection.Clear();
                for (int x = 0; x < 7; x++) verify(x, y, currWinCollection);
            }

            // bottom->top
            for (int x = 0; x < 7; x++)
            {
                currColor = string.Empty;
                currWinCollection.Clear();
                for (int y = 0; y < 6; y++) verify(x, y, currWinCollection);
            }

            // left-top -> right-buttom
            for (var sx = 0; sx <= 3; sx++)
                for (var sy = sx == 0 ? 3 : 5; sy <= 5; sy++)
                {
                    var x = sx;
                    currColor = string.Empty;
                    currWinCollection.Clear();
                    for (var y = sy; y >= 0 && x <= 6; x++, y--) verify(x, y, currWinCollection);
                }

            // right-top->left-bottom
            for (var sx = 6; sx >= 3; sx--)
                for (var sy = sx == 6 ? 3 : 5; sy <= 5; sy++)
                {
                    var x = sx;
                    currColor = string.Empty;
                    currWinCollection.Clear();
                    for (var y = sy; y >= 0 && x >= 0; x--, y--) verify(x, y, currWinCollection);
                }

            var result = winCollections.Select(x =>
                new
                {
                    MaxMove = x.Max(y => y.Item1),
                    Color = x.FirstOrDefault().Item2
                }).OrderBy(x => x.MaxMove);

            return result.Any() ? result.FirstOrDefault().Color : string.Empty;
        }
    }
}