using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle_Project
{
    internal class Print_Grid
    {
        static int N = 0;
        public static void print(List<int> v)
        {
            int x = 0;
            N = Program.N;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write( v[x++] +  " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
