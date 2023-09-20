using System.Drawing;
using GTweens.Delegates;
using GTweens.Interpolators;

namespace GTweens.Tweeners
{
    public sealed class SystemColorTweener : Tweener<Color>
    {
        public SystemColorTweener(
            Getter currValueGetter, 
            Setter setter, 
            Getter finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
            : base(currValueGetter, 
                  setter, 
                  finalValueGetter, 
                  duration,
                  SystemColorInterpolator.Instance, 
                  validation
                  )
        {
        }
    }
}