using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle_Project
{
    internal class A_star_algorithm
    {
        static int N = Program.N;
         public static void A_star_algorithm1(List<int> grid, int option)
         {
            int ix = -1;
            N = Program.N;
            PriorityQueue<node, int> not_vis = new PriorityQueue<node, int>();
            //priorityqueue pq=new priorityqueue();
            for (int i = 0; i < Program.N * Program.N; i++)
            {
                if (grid[i] == 0)
                {
                    ix = i;
                    break;
                }
            }
            int c = calc_Heuristic.calc_Heuristic1(grid, option);
            Dictionary<List<int>, int> vis = new Dictionary<List<int>, int>();
            node n = new node(c,0, 0, ix, grid);
            not_vis.Enqueue(n, 0);
           // pq.enqueue(n);
            Dictionary<List<int>, List<int>> parent = new Dictionary<List<int>, List<int>>();
            List<int> term = new List<int>();
            term.Add(-1);
            parent[grid] = term;
            if (c == 0)
            {
                Console.WriteLine("Time taken: " + Program.before.ElapsedMilliseconds + "ms");
                get_solution.get_solution1(grid, term, parent, 0);
                return;
            }
            while (true)
            {
                var ccc = not_vis.Dequeue();
               // var ccc = pq.dequeue();
                List<int> cur = ccc.grid;
                int idx_of_zero = ccc.index_of_zero;
                int vs = ccc.last_move; // move
                int d = ccc.distance;// distence
                List<int> v = new List<int>();
                if (idx_of_zero + N < N * N)
                    v.Add(N);
                if (idx_of_zero % N != 0)
                    v.Add(-1);
                if ((idx_of_zero + 1) % N != 0)
                    v.Add(1);
                if (idx_of_zero - N >= 0)
                    v.Add(-1 * N);
                foreach (var j in v)
                {
                    if (j == vs * -1)
                    {
                        continue;
                    }
                    int from = idx_of_zero;
                    int to = from + j;
                    List<int> next = new List<int>();
                    next.AddRange(cur);
                    int tmp = next[from];
                    next[from] = next[to];
                    next[to] = tmp;
                    int cost = calc_Heuristic.calc_Heuristic1(next, option);//O(N*N)
                    if (N == 3)
                        parent[next] = cur;
                    if (cost == 0)
                    {
                        float after = int.Parse(Program.before.ElapsedMilliseconds.ToString());
                        Console.WriteLine("Time taken: " + after / 1000.0 + " Second");
                        get_solution.get_solution1(next, term, parent, d + 1);
                        return;
                    }
                    node nn = new node(cost + d+1 , j, d + 1, j + idx_of_zero, next);
                    not_vis.Enqueue(nn, cost + d + 1);
                  // pq.enqueue(nn);
                }
            }


         }
    }
}
