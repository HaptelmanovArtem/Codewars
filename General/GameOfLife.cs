namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/game-of-life/description/
    /// </summary>
    public class GameOfLife
    {
        private int xLength;
        private int yLength;

        public void GameOfLifeSolution(int[][] board)
        {
            xLength = board.Length;
            yLength = board[0].Length;

            var temp = new int[board.Length][];
            for (var i = 0; i < board.Length; i++)
            {
                temp[i] = new int[board[i].Length];
                Array.Copy(board[i], temp[i], yLength);
            }

            for (var i = 0; i < xLength; i++)
            {
                for (var j = 0; j < yLength; j++)
                {
                    var currentCell = temp[i][j];
                    var liveNeighbors = GetLiveNeighbors(i, j, temp);

                    if (currentCell == 1 && liveNeighbors < 2)
                    {
                        board[i][j] = 0;
                    }
                    else if (currentCell == 1 && (liveNeighbors == 2 || liveNeighbors == 3))
                    {
                        board[i][j] = 1;
                    }
                    else if (currentCell == 1 && liveNeighbors > 3)
                    {
                        board[i][j] = 0;
                    }
                    else if (currentCell == 0 && liveNeighbors == 3)
                    {
                        board[i][j] = 1;
                    }
                    else
                    {
                        board[i][j] = currentCell;
                    }
                }
            }
        }

        private int GetLiveNeighbors(int i, int j, int[][] board)
        {
            var liveNeighbors = 0;

            // diagonal
            var dRightTopX = i - 1;
            var dRightTopY = j + 1;
            if (IsLive(dRightTopX, dRightTopY, board))
                liveNeighbors++;

            var dRightBottomX = i + 1;
            var dRightBottomY = j + 1;
            if (IsLive(dRightBottomX, dRightBottomY, board))
                liveNeighbors++;

            var dLeftTopX = i - 1;
            var dLeftTopY = j - 1;
            if (IsLive(dLeftTopX, dLeftTopY, board))
                liveNeighbors++;

            var dLeftBottomX = i + 1;
            var dLeftBottomY = j - 1;
            if (IsLive(dLeftBottomX, dLeftBottomY, board))
                liveNeighbors++;

            // vertical
            var vLeftX = i;
            var vLeftY = j - 1;
            if (IsLive(vLeftX, vLeftY, board))
                liveNeighbors++;

            var vRightX = i;
            var vRightY = j + 1;
            if (IsLive(vRightX, vRightY, board))
                liveNeighbors++;

            // horizontal
            var hTopX = i - 1;
            var hTopY = j;
            if (IsLive(hTopX, hTopY, board))
                liveNeighbors++;

            var hBotoomX = i + 1;
            var hBottomY = j;
            if (IsLive(hBotoomX, hBottomY, board))
                liveNeighbors++;

            return liveNeighbors;

            bool IsLive(int x, int y, int[][] board)
            {
                if (x >= xLength || x < 0 || y >= yLength || y < 0)
                    return false;

                return board[x][y] == 1;
            }
        }

        // SIMPLE SOLUTION
/*        public void GameOfLifeSolution(int[][] board)
        {
            xLength = board.Length;
            yLength = board[0].Length;

            var result = new int[board.Length][];
            for (var i = 0; i < board.Length; i++)
            {
                result[i] = new int[board[i].Length];
                Array.Copy(board[i], result[i], yLength);

            }

            for (var i = 0; i < xLength; i++)
            {
                for (var j = 0; j < yLength; j++)
                {
                    var currentCell = result[i][j];
                    var neighbors = GetNeighbors(i, j);

                    var numberOfLive = neighbors.Count(dto => result[dto.x][dto.y] == 1);
                    if (currentCell == 1 && numberOfLive < 2)
                    {
                        board[i][j] = 0;
                    }
                    else if (currentCell == 1 && (numberOfLive == 2 || numberOfLive == 3))
                    {
                        board[i][j] = 1;
                    }
                    else if (currentCell == 1 && numberOfLive > 3)
                    {
                        board[i][j] = 0;
                    }
                    else if (currentCell == 0 && numberOfLive == 3)
                    {
                        board[i][j] = 1;
                    }
                    else
                    {
                        board[i][j] = currentCell;
                    }
                }
            }
        }

        private List<(int x, int y)> GetNeighbors(int i, int j)
        {
            var result = new List<(int, int)>();

            // diagonal
            var dRightTopX = i - 1;
            var dRightTopY = j + 1;
            PopulateNeighbors(dRightTopX, dRightTopY, result);

            var dRightBottomX = i + 1;
            var dRightBottomY = j + 1;
            PopulateNeighbors(dRightBottomX, dRightBottomY, result);

            var dLeftTopX = i - 1;
            var dLeftTopY = j - 1;
            PopulateNeighbors(dLeftTopX, dLeftTopY, result);

            var dLeftBottomX = i + 1;
            var dLeftBottonY = j - 1;
            PopulateNeighbors(dLeftBottomX, dLeftBottonY, result);

            // vertical
            var vLeftX = i;
            var vLeftY = j - 1;
            PopulateNeighbors(vLeftX, vLeftY, result);

            var vRightX = i;
            var vRightY = j + 1;
            PopulateNeighbors(vRightX, vRightY, result);

            // horizontal
            var hTopX = i - 1;
            var hTopY = j;
            PopulateNeighbors(hTopX, hTopY, result);

            var hBotoomX = i + 1;
            var hBottomY = j;
            PopulateNeighbors(hBotoomX, hBottomY, result);

            return result;

            void PopulateNeighbors(int x, int y, List<(int, int)> values)
            {
                if (x >= xLength || x < 0 || y >= yLength || y < 0)
                    return;

                values.Add((x, y));
            }
        }*/
    }
}