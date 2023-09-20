using GTweens.Delegates;
using GTweens.Interpolators;

namespace GTweens.Tweeners
{
    public sealed class IntTweener : Tweener<int>
    {
        internal IntTweener(
            Getter currValueGetter, 
            Setter setter, 
            Getter finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
            : base(
                  currValueGetter, 
                  setter, 
                  finalValueGetter, 
                  duration,
                  IntInterpolator.Instance, 
                  validation
                  )
        {
        }
    }
}