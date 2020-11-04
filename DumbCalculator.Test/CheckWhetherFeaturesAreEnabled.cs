using FluentAssertions;
using Xunit;

namespace DumbCalculator.Test
{
    public class CheckWhetherFeaturesAreEnabled
    {
        [Fact]
        public void FeaturesStartWithCorrectInitialValues()
        {
            Feature.InitiallyDisabledFeature.IsActive().Should().BeFalse();
            Feature.InitiallyEnabledFeature.IsActive().Should().BeTrue();
        }
    }
}
