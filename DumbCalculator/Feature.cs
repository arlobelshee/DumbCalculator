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
            return false;
        }
    }

    internal static class FeatureConfigDb
    {
    }
}
