using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2020
{
    class Day3
    {
        internal static void PartA()
        {
            var map = File.ReadAllText(@"C:\Users\md7\Code\aoc-2020\Aoc2020\Aoc2020\Input3.txt")
                .Split('\n')
                .Select(r => r.Trim().Select(i => i == '#').ToList()) //Space at the end of the ro
                .ToList();

            // across 1 down 3
            var y = 0;
            var mod = map.First().Count;

            var ans = map.Count(row => row[(y++ * 3) % mod]);

            Log.Information("Day3 partA answer: {0}", ans);
        }

        internal static void PartB()
        {
            var mod = 31;
            var ans = File.ReadAllText(@"C:\Users\md7\Code\aoc-2020\Aoc2020\Aoc2020\Input3.txt")
                .Split('\n')
                .Select((r, i) => new { Index = i, Row = r.Trim().Select(t => t == '#').ToList() }) //Space at the end of the row
                .Aggregate(new List<int>() { 0, 0, 0, 0, 0 },
                (treeCount, r) => new List<int>
                {
                    treeCount[0] + (r.Row[(r.Index * 1) % mod] ? 1 : 0),
                    treeCount[1] + (r.Row[(r.Index * 3) % mod] ? 1 : 0),
                    treeCount[2] + (r.Row[(r.Index * 5) % mod] ? 1 : 0),
                    treeCount[3] + (r.Row[(r.Index * 7) % mod] ? 1 : 0),
                    treeCount[4] + ((r.Index % 2 == 0 && r.Row[(r.Index / 2) % mod]) ? 1 : 0)
                })
                .Aggregate(1, (a, b) => a * b);

            Log.Information("Day3 partB answer: {0}", ans);
        }
    }
}
