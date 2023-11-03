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
            Getter to, 
            float duration, 
            ValidationDelegates.Validation validation
            )
            : base(currValueGetter, 
                  setter, 
                  to, 
                  duration,
                  SystemColorInterpolator.Instance, 
                  validation
                  )
        {
        }
    }
}