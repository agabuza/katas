using System.Collections.Generic;
using System.Linq;

namespace katas.Battleships
{
    /// <summary>
    /// https://www.codewars.com/kata/58d06bfbc43d20767e000074
    /// </summary>
    internal class Kata
    {
        public static Dictionary<string, double> damagedOrSunk(int[,] board, int[,] attacks)
        {
            var result = new List<(string, double)>();
            var originalBoard = (int[,])board.Clone();
            
            for (int i = 0; i < attacks.GetLength(0); i++)
            {
                var y = attacks[i, 0] - 1;
                var x = board.GetLength(0) - attacks[i, 1];
                board[x, y] = 9;
            }

            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] > 0 && originalBoard[i, j] != 0)
                    {
                        var assessment = InvestigateShip(board, i, j, originalBoard);
                        result.Add((assessment.Item1, assessment.Item2));
                    }
                }

            var res = result.GroupBy(x => x.Item1).ToDictionary(x => x.Key, x => (double)x.Count());
            
            if (!res.ContainsKey("sunk"))
                res.Add("sunk", 0);


            if (!res.ContainsKey("damaged"))
                res.Add("damaged", 0);

            if (!res.ContainsKey("notTouched"))
                res.Add("notTouched", 0);

            res.Add("points", result.Sum(x => x.Item2));

            return res;
        }

        public static (string, double) InvestigateShip(int[,] board, int x, int y, int[,] originalboard)
        {
            var stateChanged = false;
            var originalState = board[x, y];
            var originalShipId = originalboard[x, y];
            var queue = new Queue<(int, int, int)>();
            double points = 0;
            queue.Enqueue((x, y, board[x, y]));

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                var cellX = cell.Item1;
                var cellY = cell.Item2; 
                if (cellX + 1 < board.GetLength(0) && originalboard[cellX + 1, cellY] == originalShipId) queue.Enqueue((cellX + 1, cellY, board[cellX + 1, cellY]));
                if (cellY + 1 < board.GetLength(1) && originalboard[cellX, cellY + 1] == originalShipId) queue.Enqueue((cellX, cellY + 1, board[cellX, cellY + 1]));

                if (cell.Item3 != originalState)
                {
                    stateChanged = true;
                }

                board[cellX, cellY] = -1;
            }

            var state = originalState == 9 ? // entrypoint was damaged
                      (stateChanged ? "damaged" : "sunk") :
                      (stateChanged ? "damaged" : "notTouched");

            if (state == "sunk") points = 1;
            if (state == "notTouched") points = -1;
            if (state == "damaged") points = 0.5;

            return (state, points);
        }
    }
}
