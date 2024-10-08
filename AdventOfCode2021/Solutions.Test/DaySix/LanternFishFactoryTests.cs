using AutoFixture;
using DaySix.Factory;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DaySix;

public class LanternFishFactoryTests
{
    private readonly Fixture fixture = new();
    private readonly LanternFishFactory factory = new();

    [Fact]
    public void CreateNewLanternFish_ShouldReturnNewLanternFishWithCorrectTimer()
    {
        var result = factory.CreateNewLanternFish();

        result.DaysToReproduce.Should().Be(8);
    }

    [Fact]
    public void CreateExistingLanternFish_ShouldReturnNewLanternFishWithCorrectTimer()
    {
        var daysToReproduce = fixture.Create<int>();

        var result = factory.CreateExistingLanternFish(daysToReproduce);

        result.DaysToReproduce.Should().Be(daysToReproduce);
    }
}
