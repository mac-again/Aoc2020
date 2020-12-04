using System;
using Aoc2020;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo
    .Console()
    .CreateLogger();

Log.Information("Starting");

Day1.PartA();
Day1.PartB();

Day2.PartA();
Day2.PartB();

Day3.PartA();
Day3.PartB();
