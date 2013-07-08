using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AcademyTasks
{
    class Program
    {
        static List<int> tasks = new List<int>();
        static int veriety;

        static void Main(string[] args)
        {
            string[] tasksAsString = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var taskAsString in tasksAsString)
            {
                tasks.Add(int.Parse(taskAsString));
            }
            veriety = int.Parse(Console.ReadLine());

            bestSolution = tasks.Count;

            int currentMin = tasks[0];
            int currentMax = tasks[0];
            maxIndex = -1;

            for (int i = 0; i < tasks.Count; i++)
            {
                currentMin = Math.Min(currentMin, tasks[i]);
                currentMax = Math.Max(currentMax, tasks[i]);

                if (currentMax - currentMin >= veriety)
                {
                    maxIndex = i;
                    break;
                }
            }

            if (maxIndex == -1)
            {
                Console.WriteLine(tasks.Count);
                return;
            }

            Solve(0, 1, tasks[0], tasks[0]);

            Console.WriteLine(bestSolution);
        }

        static int maxIndex;
        static int bestSolution = tasks.Count;

        static void Solve(int index, int tasksSolved, int currentMin, int currentMax)
        {
            if (currentMax - currentMin >= veriety)
            {
                bestSolution = Math.Min(bestSolution, tasksSolved);
                return;
            }

            if (index >= maxIndex)
            {
                return;
            }

            for (int i = 2; i >= 1; i--)
            {
                if (index + i < tasks.Count)
                {
                    Solve(index + i, tasksSolved + 1, Math.Min(currentMin, tasks[index + i]), Math.Max(currentMax, tasks[index + i]));
                }

                if (bestSolution != tasks.Count)
                {
                    return;
                }
            }
        }
    }
}
