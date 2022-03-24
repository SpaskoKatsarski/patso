using System;
using System.Linq;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums =  { 1, 2, 3, 4, 5};

            int[] onlyOdds = nums.Where((num, position) => position % 2 == 0).ToArray();

            Console.WriteLine(string.Join(", ", onlyOdds));
        }
    }
}
