using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle_Project
{
    internal class node
    {
        public int last_move;
        public int distance;
        public int index_of_zero;
        public int cost;
        public List<int> grid;
        public node() { }
        public node(int cost,int last_move, int distance, int index_of_zero, List<int> grid)
        {
            this.cost = cost;
            this.last_move = last_move;
            this.index_of_zero = index_of_zero;
            this.distance = distance;
            this.grid = grid;
        }
        public int getTotalDest()
        {
            return cost;
        }
    }
}
