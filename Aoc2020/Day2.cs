using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Serilog;

namespace Aoc2020
{
    class Day2
    {
        internal static void PartA()
        {
            var regex = new Regex(@"(\d+)-(\d+) ([a-z]): ([a-z]+)");
            var ans = File.ReadAllText(@"C:\Users\md7\Code\aoc-2020\Aoc2020\Aoc2020\Input2.txt")
                .Split('\n')
                .Select(x =>
                {
                    var match = regex.Match(x);
                    return new
                    {
                        Min = int.Parse(match.Groups[1].Value), // 0th group is everything
                        Max = int.Parse(match.Groups[2].Value),
                        Letter = match.Groups[3].Value.Single(),
                        Text = match.Groups[4].Value
                    };
                })
                .Count(m =>
                {
                    var count = m.Text.Count(n => n == m.Letter);
                    return count >= m.Min && count <= m.Max;
                });
            Log.Information("Day2 part A answer: {answer}", ans);
        }

        internal static void PartB()
        {
            var regex = new Regex(@"(\d+)-(\d+) ([a-z]): ([a-z]+)");
            var ans = File.ReadAllText(@"C:\Users\md7\Code\aoc-2020\Aoc2020\Aoc2020\Input2.txt")
                .Split('\n')
                .Select(x =>
                {
                    var match = regex.Match(x);
                    return new
                    {
                        Index1 = int.Parse(match.Groups[1].Value)-1, // 0th group is everything
                        Index2 = int.Parse(match.Groups[2].Value)-1,
                        Letter = match.Groups[3].Value.Single(),
                        Text = match.Groups[4].Value
                    };
                })
                .Count(m =>
                {
                    var m1 = m.Text.ElementAtOrDefault(m.Index1) == m.Letter;
                    var m2 = m.Text.ElementAtOrDefault(m.Index2) == m.Letter;
                    return (m1 || m2) && !(m1 && m2);
                });
            Log.Information("Day2 part B answer: {answer}", ans);
        }
    }
}
