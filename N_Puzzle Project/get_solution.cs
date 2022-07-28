using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle_Project
{
    internal class get_solution
    {
        static void print(List<int> v)
        {
            int x = 0;
            for (int i = 0; i < Program.N; i++)
            {
                for (int j = 0; j < Program.N; j++)
                {
                    Console.Write(v[x++] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void get_solution1(List<int> cur, List<int> term_node, Dictionary<List<int>, List<int>> parent, int dis)
        {

            Console.WriteLine("solution is found");
            Console.WriteLine("************************");
            Console.WriteLine("number of moves = " + dis);
            if (Program.N == 3)
            {
                List<int> cc = cur;
                List<List<int>> ans = new List<List<int>>();
                int sz = 0;
                while (cc != term_node)
                {
                    ans.Add(cc);
                    sz++;
                    cc = parent[cc];
                }
                ans.Reverse();
                foreach (var vec in ans)
                {
                    print(vec);
                    Console.WriteLine("==============================");
                }

            }
        }
    }
}
