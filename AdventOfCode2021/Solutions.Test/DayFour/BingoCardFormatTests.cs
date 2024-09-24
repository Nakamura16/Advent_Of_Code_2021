using DayFour;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayFour
{
    public class BingoCardFormatTests
    {
        private readonly BingoFormatter bingoFormatter = new ();
        private readonly new List<string> testData = new()
        {
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
        public void Format_ShouldReturnNumbersAndBingoCards()
        {
            var result = bingoFormatter.FormatBingoCards(testData);

            var expectedResult = new List<BingoCard>()
            {
                new(new (){
                    new(){22, 13, 17, 11, 0 },
                    new(){8, 2, 23, 4, 24 },
                    new(){21, 9, 14, 16, 7 },
                    new(){6, 10, 3, 18, 5 },
                    new(){1, 12, 20, 15, 19 } 
                }),

                new(new (){
                    new(){3, 15, 0, 2, 22},
                    new(){9, 18, 13, 17, 5},
                    new(){19, 8, 7, 25, 23},
                    new(){20, 11, 10, 24, 4},
                    new(){14, 21, 16, 12, 6},
                }),
            };

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
