using GTweens.Delegates;
using GTweens.Interpolators;

namespace GTweens.Tweeners
{
    public sealed class IntTweener : Tweener<int>
    {
        internal IntTweener(
            Getter currValueGetter, 
            Setter setter, 
            int to, 
            float duration, 
            ValidationDelegates.Validation validation
            )
            : base(
                  currValueGetter, 
                  setter, 
                  to, 
                  duration,
                  IntInterpolator.Instance, 
                  validation
                  )
        {
        }
    }
}