using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle_Project
{
    internal class calc_Heuristic
    {
        static int N = Program.N;
        static int calc_hamming(List<int> grid)
        {
            int c = 1;
            int res = 0;
            for (int i = 0; i < N * N - 1; i++)
            {
                if (grid[i] != c)
                    res++;
                c++;

            }
            return res;
        }
        static int calc_Manhattan(List<int> grid)
        {
            int c = 1;
            int res = 0;
            int cx = 0, cy = 0;
            for (int i = 0; i < N * N; i++)
            {
                if (grid[i] != c && grid[i] != 0)
                {
                    int x = (grid[i] - 1) / (N);
                    int y = Math.Abs(grid[i] - (1 + (x * N)));
                    res += Math.Abs(cx - x);
                    res += Math.Abs(cy - y);
                }
                cy++;
                if (cy == N)
                {
                    cy = 0;
                    cx++;
                }
                c++;
            }
            return res;
        }
        public static int calc_Heuristic1(List<int> grid, int option)
        {
            N = Program.N;
            if (option == 1)
            {
                return calc_hamming(grid);
            }
            else
            {
                return calc_Manhattan(grid);
            }
        }
    }
}
