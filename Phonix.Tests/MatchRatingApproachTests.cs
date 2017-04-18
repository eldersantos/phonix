using System;
using Xunit;

namespace Phonix.Tests
{
  public class MatchRatingApproachTests
  {
    private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfy", "Sputfi" };

    readonly MatchRatingApproach _generator = new MatchRatingApproach();


    [Fact]
    public void Should_Be_Similar()
    {
      Assert.True(_generator.IsSimilar(Words));
    }

    [Fact]
    public void Should_Match_Compute_6_Value()
    {
      var val = _generator.MatchRatingCompute("test", "TEST");
      Console.WriteLine(val.ToString());
      Assert.Equal(6, val);
    }

    [Fact]
    public void Should_Match_Compute_0_Value()
    {
      var val = _generator.MatchRatingCompute("left", "right");
      Console.WriteLine(val.ToString());
      Assert.Equal(0, val);
    }

  }
}
