using GTweens.Easings;

namespace GTweens.Interpolators
{
    public interface IInterpolator<T>
    {
        T Evaluate(T initialValue, T finalValue, float time, EasingDelegate easingFunction);
        T Subtract(T initialValue, T finalValue);
        T Add(T initialValue, T finalValue);
    }
}