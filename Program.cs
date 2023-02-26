namespace Blocks
{
    internal class Program
    {
        public static int[][] Combinations = new[]
        {
            new int[] { 1, 2, 3, 4 },
            new int[] { 1, 2, 4, 3 },
            new int[] { 1, 3, 2, 4 },
            new int[] { 1, 3, 4, 2 },
            new int[] { 1, 4, 2, 3 },
            new int[] { 1, 4, 3, 2 },
            new int[] { 2, 1, 3, 4 },
            new int[] { 2, 1, 4, 3 },
            new int[] { 2, 3, 1, 4 },
            new int[] { 2, 3, 4, 1 },
            new int[] { 2, 4, 1, 3 },
            new int[] { 2, 4, 3, 1 },
            new int[] { 3, 2, 1, 4 },
            new int[] { 3, 2, 4, 1 },
            new int[] { 3, 1, 2, 4 },
            new int[] { 3, 1, 4, 2 },
            new int[] { 3, 4, 2, 1 },
            new int[] { 3, 4, 1, 2 },
            new int[] { 4, 2, 3, 1 },
            new int[] { 4, 2, 1, 3 },
            new int[] { 4, 3, 2, 1 },
            new int[] { 4, 3, 1, 2 },
            new int[] { 4, 1, 2, 3 },
            new int[] { 4, 1, 3, 2 },
        };
        static void Main(string[] args)
        {
            int[] input = args.Select(int.Parse).ToArray();
            bool found = false;
            foreach (var legalBlock in GetAllLegalBlocks())
            {
                var view = GetView(legalBlock);
                if (IsEqualView(view, input))
                {
                    PrintBlock(legalBlock);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Error!");
            }
        }

        private static bool IsEqualView(int[] view1, int[] view2)
        {
            int i = 0;
            while (i < 16)
            {
                if (view1[i] != view2[i])
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        private static void PrintBlock(int[,] candidateBlock)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    Console.Write(candidateBlock[x, y]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public static IEnumerable<int[,]> GetAllLegalBlocks()
        {
            foreach (var row1 in Combinations)
            {
                foreach (var row2 in Combinations.Where(r => DoesNotCollide(row1, r)))
                {
                    foreach (var row3 in Combinations.Where(r => DoesNotCollide(row1, row2, r)))
                    {
                        foreach (var row4 in Combinations.Where(r => DoesNotCollide(row1, row2, row3, r)))
                        {
                            var result = new int[4, 4];
                            for (int x = 0; x < 4; x++)
                            {
                                result[0, x] = row1[x];
                                result[1, x] = row2[x];
                                result[2, x] = row3[x];
                                result[3, x] = row4[x];
                            }
                            yield return result;
                        }
                    }
                }
            }
        }

        private static bool DoesNotCollide(params int[][] rows)
        {
            for (int col = 0; col < 4; col++)
            {
                var distinctHeights = new int[4];
                int row = 0;
                while (row < rows.Length)
                {
                    if (distinctHeights[rows[row][col]-1] > 0)
                    {
                        return false;
                    }
                    distinctHeights[rows[row][col]-1]++;
                    row++;
                }
            }
            return true;
        }

        public static int[] GetView(int[,] block)
        {
            var result = new int[16];

            // top and bottom view
            int i = 0;
            int j = 0;
            while (i < 4)
            {
                int[] row = new int[4];
                int[] col = new int[4];
                j = 0;
                while (j < 4)
                {
                    row[j] = block[i, j];
                    col[j] = block[j, i];
                    j++;
                }
                result[i] = RowView(row);
                result[i + 4] = RowView(row.Reverse().ToArray());
                result[i + 8] = RowView(col);
                result[i + 12] = RowView(col.Reverse().ToArray());
                i++;
            }
            return result;
        }

        private static int RowView(int[] row)
        {
            int numView = 0;
            int maxView = 0;
            int index = 0;
            while (index < row.Length)
            {
                if (row[index] > maxView)
                {
                    numView++;
                    maxView = row[index];
                }
                index++;
            }
            return numView;
        }
    }
}