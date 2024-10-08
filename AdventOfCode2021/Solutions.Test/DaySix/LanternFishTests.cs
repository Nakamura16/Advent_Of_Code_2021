using AutoFixture;
using DaySix.Model;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DaySix;

public class LanternFishTests
{
    private readonly Fixture fixture = new();

    [Fact]
    public void Reset_ShouldResetTheCorrectValue()
    {
        var fish = new LanternFish(fixture.Create<int>());

        fish.ResetTimer();

        fish.DaysToReproduce.Should().Be(6);
    }
}
