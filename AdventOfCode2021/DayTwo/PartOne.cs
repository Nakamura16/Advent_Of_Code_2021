﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo;

internal class PartOne
{
    public int Calculate(IReadOnlyList<(string direction,int steps)> instructions)
    {
        var horizontalPosition = 0;
        var depthPosition = 0;
        foreach (var (direction, steps) in instructions)
        {
            switch (direction)
            {
                case "forward":
                    horizontalPosition += steps;
                    break;
                case "down":
                    depthPosition += steps;
                    break;
                case "up":
                    depthPosition -= steps;
                    break;
            }
        }
        return horizontalPosition * depthPosition;
    }
}
