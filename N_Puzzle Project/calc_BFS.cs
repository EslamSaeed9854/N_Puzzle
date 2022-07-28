using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle_Project
{
    internal class calc_BFS
    {
        static int N = 0;
        public static void calc_BFS1(List<int> grid)
        {
            N = Program.N;
            Queue<node> q = new Queue<node>();
            node n = new node(0,0, 0, 0, grid);
            q.Enqueue(n);
            Dictionary<List<int>, bool> vis= new Dictionary<List<int>, bool>();
            vis[grid] = true;
            Dictionary<List<int>, List<int>> parent=new Dictionary<List<int>, List<int>>();
            List<int> term= new List<int>();
            term.Add(-1);
            parent[grid] = term;
            if (calc_Heuristic.calc_Heuristic1(grid, 1) == 0)
            {
                float after = int.Parse(Program.before.ElapsedMilliseconds.ToString());
                Console.WriteLine("Time taken: " + after / 1000.0 + " Second");
                get_solution.get_solution1(grid, term, parent, 0);
                return;
            }
            while (q.Count>0)
            {
                var cur = q.Dequeue();
                int dist = cur.distance;
                int index_zero = cur.index_of_zero;
                int last_move = cur.last_move;
                dist++;
                if (calc_Heuristic.calc_Heuristic1(cur.grid,1)==0)
                {
                    float after = int.Parse(Program.before.ElapsedMilliseconds.ToString());
                    Console.WriteLine("Time taken: " + after / 1000.0 + " Second");
                    get_solution.get_solution1(cur.grid, term, parent, dist);
                    return;
                }
                List<int> v = new List<int>();
                if (index_zero + N < N * N)
                    v.Add(N);
                if (index_zero % N != 0)
                    v.Add(-1);
                if ((index_zero + 1) % N != 0)
                    v.Add(1);
                if (index_zero - N >= 0)
                    v.Add(-1 * N);
                foreach (var  i in v)
                {
                    if (i == last_move * -1 )
                        continue;
                    int from = index_zero;
                    int to = from + i;
                    List<int> next = new List<int>();
                    next.AddRange(cur.grid);
                    int tmp = next[from];
                    next[from] = next[to];
                    next[to] = tmp;
                    if (vis.ContainsKey(next))
                        continue;
                    vis[next] = true;
                    if (N == 3)
                        parent[next] = cur.grid;
                    node nw = new node(0,i,dist,i+index_zero,next);
                    q.Enqueue(nw);
                }
            }
        }
    }
}
