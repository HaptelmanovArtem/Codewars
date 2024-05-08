namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/rectangle-area/description/
    /// </summary>
    public class RectangleArea
    {
        public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            var coveredArea = ((ax2 - ax1) * (ay2 - ay1)) +
                              ((bx2 - bx1) * (by2 - by1)); // can use Math.Abs but make sure that Math.Abs working slover than just compering.

            if (ax1 >= bx2 || ay1 >= by2 || bx1 >= ax2 || by1 >= ay2)
                return coveredArea;

            return coveredArea - ((Math.Min(ay2, by2) - Math.Max(ay1, by1)) * (Math.Min(ax2, bx2) - Math.Max(ax1, bx1)));
        }
    }
}