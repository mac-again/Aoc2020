using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2020
{
    class Day1
    {
        internal static void PartA()
        {
            var nums = File.ReadAllText(@"C:\Users\md7\Code\aoc-2020\Aoc2020\Aoc2020\Input1.txt")
                .Split("\n")
                .Select(x => int.Parse(x))
                .ToList();

            var ans = nums.Join(
                nums,
                n => n,
                m => 2020 - m,
                (n, m) => m * n)
                .First(); // We end up getting the number twice!

            Log.Information("Day1A answer: {answer}", ans);
        }

        internal static void PartB()
        {
            var nums = File.ReadAllText(@"C:\Users\md7\Code\aoc-2020\Aoc2020\Aoc2020\Input1.txt")
                .Split("\n")
                .Select(x => int.Parse(x))
                .ToList();

            var ans = nums.Join(
                nums,
                n => true,
                m => true,
                (n, m) => new { Product = n * m, Sum = n + m })
                .Join(nums,
                p => p.Sum,
                q => 2020 - q,
                (p, q) => p.Product * q)
                .First();

            Log.Information("Day1B answer: {answer}", ans);
        }
    }
}
