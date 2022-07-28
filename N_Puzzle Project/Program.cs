using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace N_Puzzle_Project
{
    public static class Program
    {
        public static Stopwatch before = Stopwatch.StartNew();
        public static List<int> grid, GD, goal;
        public static int N = 0, M = 111;
        static void Main(string[] args)
        {   
            while (true)
            {
                string name = @"C:\Users\EslamSaeed\source\repos\N_Puzzle Project\Tests\";
                Console.WriteLine("Unsolvable puzzles\n");
                Console.WriteLine("[1] 15 Puzzle 1 - Unsolvable");
                Console.WriteLine("[2] 99 Puzzle - Unsolvable Case 1");
                Console.WriteLine("[3] 99 Puzzle - Unsolvable Case 2");
                Console.WriteLine("[4] 9999 Puzzle Unsolvable");
                Console.WriteLine("\nSolvable puzzles\n");
                Console.WriteLine("\nManhattan & Hamming\n");
                Console.WriteLine("[5] 50 Puzzle");
                Console.WriteLine("[6] 99 Puzzle - 1");
                Console.WriteLine("[7] 99 Puzzle - 2");
                Console.WriteLine("[8] 9999 Puzzle");
                Console.WriteLine("\nManhattan Only\n");
                Console.WriteLine("[9] 15 Puzzle 1");
                Console.WriteLine("[10] 15 Puzzle 3");
                Console.WriteLine("[11] 15 Puzzle 4");
                Console.WriteLine("[12] 15 Puzzle 5");
                Console.WriteLine("\nV. Large test case\n");
                Console.WriteLine("[13] TEST");
                Console.WriteLine("[14] for new Grid\n");
                Console.WriteLine("any other number to Exit\n");
                int test = int.Parse(Console.ReadLine());
                if (test == 1)
                {
                    name += "15 Puzzle 1 - Unsolvable";
                }
                else if (test == 2)
                {
                    name += "99 Puzzle - Unsolvable Case 1";
                }
                else if (test == 3)
                {
                    name += "99 Puzzle - Unsolvable Case 2";
                }
                else if (test == 4)
                {
                    name += "9999 Puzzle Unsolvable";
                }
                else if (test == 5)
                {
                    name += "50 Puzzle";
                }
                else if (test == 6)
                {
                    name += "99 Puzzle - 1";
                }
                else if (test == 7)
                {
                    name += "99 Puzzle - 2";
                }
                else if (test == 8)
                {
                    name += "9999 Puzzle";
                }
                else if (test == 9)
                {
                    name += "15 Puzzle 1";
                }
                else if (test == 10)
                {
                    name += "15 Puzzle 3";
                }
                else if (test == 11)
                {
                    name += "15 Puzzle 4";
                }
                else if (test == 12)
                {
                    name += "15 Puzzle 5";
                }
                else if (test == 13)
                {
                    name += "TEST";
                }
                else if(test == 14)
                {
                    Console.WriteLine("Enter size of grid");
                    int n = int.Parse(Console.ReadLine());
                    N = n;
                    grid = new List<int>();
                    Console.WriteLine("GRID ? ");
                    for (int i = 0; i < n; i++)
                    {
                        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                        for (int j = 0; j < n; j++)
                            grid.Add(a[j]);

                    }
                    GD = grid;
                    if (have_solution.have_solution1(grid) == true)
                    {
                        Console.WriteLine("this grid have a solution");
                        Console.WriteLine("[1] use A_star_algorithm");
                        Console.WriteLine("[2] use BFS_algorithm");
                        int opt = int.Parse(Console.ReadLine());
                        if (opt == 1)
                        {
                            Console.WriteLine("[1] use hamming");
                            Console.WriteLine("[2] use Manhattan");

                            opt = int.Parse(Console.ReadLine());
                            Console.WriteLine("Running.....");
                            before = Stopwatch.StartNew();
                            A_star_algorithm.A_star_algorithm1(grid, opt);

                        }
                        else
                        {
                            Console.WriteLine("Running.....");
                            before = Stopwatch.StartNew();
                            calc_BFS.calc_BFS1(grid);
                        }
                    }
                    else
                        Console.WriteLine("there is no solution for this grid");
                }
                if (test > 14)
                    return;
                if (test == 14)
                    continue;
                name += ".txt";
                var file_read = File.ReadLines(name);
                grid = new List<int>();
                N = 0;
                foreach (var line in file_read)
                {
                    if (line.Length == 0)
                        continue;
                    if (N == 0)
                        N = int.Parse(line);
                    else
                    {
                        int[] a = Array.ConvertAll(line.Split(' '), int.Parse);
                        for (int j = 0; j < a.Length; j++)
                            grid.Add(int.Parse(a[j].ToString()));
                    }
                }
                GD = grid;
                if (have_solution.have_solution1(grid) == true)
                {
                    Console.WriteLine("this grid have a solution");
                    Console.WriteLine("[1] use A_star_algorithm");
                    Console.WriteLine("[2] use BFS_algorithm");
                    int opt = int.Parse(Console.ReadLine());
                    if (opt == 1)
                    {
                        Console.WriteLine("[1] use hamming");
                        Console.WriteLine("[2] use Manhattan");
                        opt = int.Parse(Console.ReadLine());
                        Console.WriteLine("Running.....");
                        before = Stopwatch.StartNew();
                        A_star_algorithm.A_star_algorithm1(grid, opt);
                    }
                    else
                    {
                        Console.WriteLine("Running.....");
                        before = Stopwatch.StartNew();
                        calc_BFS.calc_BFS1(grid);
                    }
                }
                else
                    Console.WriteLine("there is no solution for this grid");
            }
            before.Stop();
        }
    }
}