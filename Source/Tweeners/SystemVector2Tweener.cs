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
            Vector2 to, 
            float duration, 
            ValidationDelegates.Validation validation
            )
            : base(
                  currValueGetter, 
                  setter, 
                  to, 
                  duration,
                  SystemVector2Interpolator.Instance, 
                  validation
                  )
        {
        }
    }
}