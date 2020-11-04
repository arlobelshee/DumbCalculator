using System;
using System.Collections.Generic;

namespace DumbCalculator
{
    public enum Feature
    {
        InitiallyDisabledFeature,
        InitiallyEnabledFeature,
        NewVariables,
        CompileToByteCodes
    }

    public static class FeatureExtensions
    {
        public static bool IsActive(this Feature which)
        {
            return FeatureConfigDb.temporaryOverrides.GetValueOrDefault(which) ??
                FeatureConfigDb.hardCodedValues.GetValueOrDefault(which) ??
                false;
        }

        public static IDisposable OverrideTo(this Feature which, bool newValue)
        {
            FeatureConfigDb.temporaryOverrides[which] = newValue;
            return new Undo(()=> FeatureConfigDb.temporaryOverrides.Remove(which));
        }
    }

    internal static class FeatureConfigDb
    {
        internal static Dictionary<Feature, bool?> hardCodedValues = new Dictionary<Feature, bool?>()
        {
            { Feature.InitiallyEnabledFeature, true }
        };

        internal static Dictionary<Feature, bool?> temporaryOverrides = new Dictionary<Feature, bool?>();
    }
}
