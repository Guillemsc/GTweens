using System.Numerics;
using GTweens.Delegates;
using GTweens.Interpolators;

namespace GTweens.Tweeners
{
    public sealed class SystemVector2Tweener : Tweener<Vector2>
    {
        public SystemVector2Tweener(
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
                  SystemVector2Interpolator.Instance, 
                  validation
                  )
        {
        }
    }
}