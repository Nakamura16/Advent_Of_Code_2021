//You're minding your own business on a ship at sea when the overboard alarm goes off!
//You rush to see if you can help. Apparently, one of the Elves tripped and accidentally
//sent the sleigh keys flying into the ocean!

//Before you know it, you're inside a submarine the Elves keep ready for situations like this.
//It's covered in Christmas lights (because of course it is), and it even has an experimental
//antenna that should be able to track the keys if you can boost its signal strength high enough;
//there's a little meter that indicates the antenna's signal strength by displaying 0-50 stars.

//Your instincts tell you that in order to save Christmas,
//you'll need to get all fifty stars by December 25th.

//As the submarine drops below the surface of the ocean, it automatically performs a sonar sweep of the nearby sea floor.
//On a small screen, the sonar sweep report (your puzzle input) appears: each line is a measurement of the sea
//floor depth as the sweep looks further and further away from the submarine.

//For example, suppose you had the following report:

//199
//200
//208
//210
//200
//207
//240
//269
//260
//263

//This report indicates that, scanning outward from the submarine,
//the sonar sweep found depths of 199, 200, 208, 210, and so on.

//The first order of business is to figure out how quickly the depth increases,
//just so you know what you're dealing with - you never know if the keys will get
//carried into deeper water by an ocean current or a fish or something.

//To do this, count the number of times a depth measurement
//increases from the previous measurement. (There is no measurement before the first measurement.)
//In the example above, the changes are as follows:

using DayOne;
using FileReader.Application;

internal class Program
{
    public static void Main(string[] args)
    {
        var fileReader = new FileReaderTool();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\DayOne\\Input.txt";

        var depthMeasurements = fileReader
            .ReadFile(filePath)
            .Select(m => int.Parse(m))
            .ToList();

        var solutionForDayOne = new PartOneSolution().Run(depthMeasurements);

        Console.WriteLine($"Solution for Part One: {solutionForDayOne}");
    }
}