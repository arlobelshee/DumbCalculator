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

        [Fact]
        public void TestsCanOverrideFeatureValues()
        {
            using(Feature.InitiallyDisabledFeature.OverrideTo(true))
            {
                Feature.InitiallyDisabledFeature.IsActive().Should().BeTrue();
            }
            Feature.InitiallyDisabledFeature.IsActive().Should().BeFalse();
        }
    }
}
