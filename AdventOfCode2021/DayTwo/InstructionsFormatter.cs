using FileReader.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo;

public class InstructionsFormatter
{
    public List<(string direction, int steps)> GetInstructions(IReadOnlyList<string> instructions)
    {
        return instructions.Select(instruction =>
        {
            var instructionWords = instruction.Split(" ");
            var direction = instructionWords[0];
            var steps = int.Parse(instructionWords[1]);
            return (direction, steps);
        }).ToList();
    }
}
