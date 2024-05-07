namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/find-the-largest-area-of-square-inside-two-rectangles/
    /// </summary>
    public class LargestSquareAreaProblem
    {
        public long LargestSquareArea(int[][] bottomLeft, int[][] topRight)
        {
            var maximumArea = 0;

            for (int i = 0; i < bottomLeft.Length - 1; i++)
            {
                for (int j = i + 1; j < topRight.Length; j++)
                {
                    var xLeft = Math.Max(bottomLeft[i][0], bottomLeft[j][0]);
                    var xRight = Math.Min(topRight[i][0], topRight[j][0]);

                    if (xLeft >= xRight)
                    {
                        maximumArea = Math.Max(maximumArea, 0);
                        continue;
                    }

                    var yBottom = Math.Max(bottomLeft[i][1], bottomLeft[j][1]);
                    var yTop = Math.Min(topRight[i][1], topRight[j][1]);

                    if (yBottom >= yTop)
                    {
                        maximumArea = Math.Max(maximumArea, 0);
                        continue;
                    }

                    var side = Math.Min(xRight - xLeft, yTop - yBottom);

                    maximumArea = Math.Max(maximumArea, side * side);
                }
            }

            return maximumArea;
        }
    }
}