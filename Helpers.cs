namespace Blocks
{
    public static class Helpers
    {
        public static bool IsValidConfiguration(int[,] configuration)
        {
            int i = 0;
            while (i < 4)
            {
                int sum1 = 0;
                int sum2 = 0;
                int j = 0;
                while (j < 4)
                {
                    sum1 += configuration[i, j];
                    sum2 += configuration[j, i];
                    j++;
                }
                if (sum1 != 10 || sum2 != 10)
                    return false;
                i++;
            }
            return true;
        }
    }
}
