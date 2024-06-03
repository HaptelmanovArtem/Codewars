using System.Text.Json.Serialization;

namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/valid-sudoku/
    /// </summary>
    public class ValidaSudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            var rows = new HashSet<char>();
            var columns = new HashSet<char>();
            Dictionary<(int, int), HashSet<char>> subBoard = new()
            {
                { (0, 0), new HashSet<char>() },
                { (0, 1), new HashSet<char>() },
                { (0, 2), new HashSet<char>() },
                { (1, 0), new HashSet<char>() },
                { (1, 1), new HashSet<char>() },
                { (1, 2), new HashSet<char>() },
                { (2, 0), new HashSet<char>() },
                { (2, 1), new HashSet<char>() },
                { (2, 2), new HashSet<char>() },
            };

            for (int i = 0; i < board.Length; i++)
            {
                columns.Clear();
                rows.Clear();

                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] != '.' && !subBoard[(i / 3, j / 3)].Add(board[i][j]))
                    {
                        return false;
                    }

                    if (board[i][j] != '.' && !rows.Add(board[i][j]))
                        return false;

                    if (board[j][i] != '.' && !columns.Add(board[j][i]))
                        return false;
                }
            }


            return true;
        }
    }
}