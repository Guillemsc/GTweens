﻿using GTweens.Easings;

namespace GTweens.Interpolators
{
    public sealed class FloatInterpolator : IInterpolator<float>
    {
        public static readonly FloatInterpolator Instance = new();

        FloatInterpolator()
        {

        }

        public float Evaluate(
            float initialValue, 
            float finalValue, 
            float time, 
            EasingDelegate easingDelegate
            )
        {
            return easingDelegate(initialValue, finalValue, time);
        }

        public float Subtract(float initialValue, float finalValue)
        {
            return finalValue - initialValue;
        }

        public float Add(float initialValue, float finalValue)
        {
            return finalValue + initialValue;
        }
    }
}