namespace Combinatorics
{
    public static class PascalTriangle
    {
        // Example:
        // Console.WriteLine(PascalTriangle.GetBinom(4, 2));
        // Should equal 6
        public static int GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
        }
    }
}
