public static class TwoCrystalBalls
{
    // Returns the integer of the floor the ball broke.
    public static int Run(bool[]? floors)
    {
        if (floors is null)
        {
            floors = new bool[]
            {
                false, false, false, false, false, true, true, true, true, true
            };
        }

        if (floors.Length == 0)
        {
            throw new InvalidOperationException("Floors length must be greater than 0.");
        }

        int jumpAmount = (int)Math.Floor(Math.Sqrt(floors.Length));

        int i = jumpAmount;
        for (; i < floors.Length; i += jumpAmount)
        {
            if (floors[i])
            {
                break;
            }
        }

        i -= jumpAmount;

        for (int j = 0; j < jumpAmount && i < floors.Length; ++j, ++i)
        {
            if (floors[i])
            {
                return i;
            }
        }

        return -1;
    }
}