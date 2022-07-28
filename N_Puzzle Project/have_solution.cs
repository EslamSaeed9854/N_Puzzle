using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle_Project
{
    internal class have_solution
    {
        static int N = Program.N;
        static int M = Program.M;
        static int getInvCount(int[,] ar)
        {
            int inv_count = 0;
            List<int> arr = new List<int>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    arr.Add(ar[i, j]);
                }
            }
            for (int i = 0; i < N * N - 1; i++)
            {
                for (int j = i + 1; j < N * N; j++)
                {

                    if (arr[j] != 0 && arr[i] != 0 && arr[i] > arr[j])
                        inv_count++;
                }
            }
            return inv_count;
        }
        static int findXPosition(int[,] puzzle)
        {

            for (int i = N - 1; i >= 0; i--)
                for (int j = N - 1; j >= 0; j--)
                    if (puzzle[i, j] == 0)
                        return N - i;
            return 0;
        }
        static bool isSolvable(int[,] puzzle)
        {

            int invCount = getInvCount(puzzle);


            if (N % 2 != 0)
                return !(invCount % 2 != 0);

            else
            {
                int pos = findXPosition(puzzle);
                if (pos % 2 != 0)
                    return !(invCount % 2 != 0);
                else
                    return invCount % 2 != 0;
            }
        }

        public static bool have_solution1(List<int> grid)
        {
            N = Program.N;
            int[,] g = new int[M, M];

            int x = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {

                    g[i, j] = grid[x++];
                }
            }

            return (isSolvable(g));
        }
    }
}
