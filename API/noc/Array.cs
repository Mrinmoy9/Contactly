using System;
namespace noc
{

    public class Array
    {
        public static void Main(string[] args)
        {
            int[] ar = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int x = 2;

            Queue<int> queue = new Queue<int>(ar);

            for (int i = 0; i < x; i++)
            {
                int last = queue.Dequeue();
                queue.Enqueue(last);
            }

            Console.WriteLine(string.Join(",", queue));

        }
    }
}
