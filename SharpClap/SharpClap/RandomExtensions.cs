using System;

namespace SharpClap
{
    public static class RandomExtensions
    {
        public static Double NextDouble(this Random random, double minValue, double maxValue)
        { // http://stackoverflow.com/a/1064907/3649573
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
