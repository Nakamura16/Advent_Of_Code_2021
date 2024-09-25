using DayFour;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayFour
{
    public class BingoCardFormatTests
    {
        private readonly BingoFormatter bingoFormatter = new ();
        private readonly List<string> testData = new()
        {
            "85,84,30,15,46,71,64,45,13,90,63,89,62,25,87,68,73,47,65,78,2,27,67,95,88,99",
            "",
            "22 13 17 11  0",
            " 8  2 23  4 24",
            "21  9 14 16  7",
            " 6 10  3 18  5",
            " 1 12 20 15 19",
            "",
            " 3 15  0  2 22",
            " 9 18 13 17  5",
            "19  8  7 25 23",
            "20 11 10 24  4",
            "14 21 16 12  6",
        };

        [Fact]
        public void FormatBingoCards_ShouldReturnCorrectBingoCards()
        {
            var result = bingoFormatter.FormatBingoCards(testData);

            var expectedResult = new List<BingoCard>()
            {
                new(new (){
                    new(){ new (22),new(13), new(17), new(11), new(0) },
                    new(){ new (8),new(2), new(23), new(4), new(24) },
                    new(){ new (21),new(9), new(14), new(16), new(7) },
                    new(){ new (6),new(10), new(3), new(18), new(5) },
                    new(){ new (1),new(12), new(20), new(15), new(19) }
                }),

                new(new (){
                    new(){ new (3), new(15), new(0), new(2), new(22) },
                    new(){ new (9), new(18), new(13), new(17), new(5) },
                    new(){ new (19), new(8), new(7), new(25), new(23) },
                    new(){ new (20), new(11), new(10), new(24), new(4) },
                    new(){ new (14), new(21), new(16), new(12), new(6) },
                }),
            };

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
