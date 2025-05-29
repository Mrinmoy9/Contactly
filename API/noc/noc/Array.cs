using System;
namespace noc
{

    public class Array
    {
        public static void Main(string[] args)
        {
            int[] ar = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int x = 2;

            RotateRight(ar, x);
            Console.WriteLine(string.Join(",", ar));
        }

        static void RotateRight(int[] arr, int x)
        {
            int n = arr.Length;
            x = x % n; // Handle cases where x > n

            // Step 1: Reverse the entire array
            Reverse(arr, 0, n - 1);
            // Step 2: Reverse the first x elements
            Reverse(arr, 0, x - 1);
            // Step 3: Reverse the remaining n-x elements
            Reverse(arr, x, n - 1);
        }

        static void Reverse(int[] arr, int start, int end)
        {
            while (start < end)
            {
                (arr[start], arr[end]) = (arr[end], arr[start]);
                start++;
                end--;
            }
        }
    }
}
