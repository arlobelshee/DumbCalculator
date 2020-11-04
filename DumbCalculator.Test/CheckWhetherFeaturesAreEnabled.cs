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
        public void TestsCanOverrideInitiallyFalseFeatureValues()
        {
            using(Feature.InitiallyDisabledFeature.OverrideTo(true))
            {
                Feature.InitiallyDisabledFeature.IsActive().Should().BeTrue();
            }
            Feature.InitiallyDisabledFeature.IsActive().Should().BeFalse();
        }

        [Fact]
        public void TestsCanOverrideInitiallyTrueFeatureValues()
        {
            using (Feature.InitiallyEnabledFeature.OverrideTo(false))
            {
                using (Feature.InitiallyDisabledFeature.OverrideTo(true))
                {
                    Feature.InitiallyDisabledFeature.IsActive().Should().BeTrue();
                    Feature.InitiallyEnabledFeature.IsActive().Should().BeFalse();
                }
                Feature.InitiallyDisabledFeature.IsActive().Should().BeFalse();
                Feature.InitiallyEnabledFeature.IsActive().Should().BeFalse();
            }
            Feature.InitiallyEnabledFeature.IsActive().Should().BeTrue();
        }

        [Fact]
        public void TestsCanOverrideMultipleFeatureValuesIndependently()
        {
            using (Feature.InitiallyEnabledFeature.OverrideTo(false))
            {
                Feature.InitiallyEnabledFeature.IsActive().Should().BeFalse();
            }
            Feature.InitiallyEnabledFeature.IsActive().Should().BeTrue();
        }
    }
}
