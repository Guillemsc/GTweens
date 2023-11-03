using System.Numerics;
using GTweens.Delegates;
using GTweens.Interpolators;

namespace GTweens.Tweeners
{
    public sealed class SystemQuaternionTweener : Tweener<Quaternion>
    {
        public SystemQuaternionTweener(
            Getter currValueGetter,
            Setter setter,
            Getter to,
            float duration,
            ValidationDelegates.Validation validation
            )
            : base(
                  currValueGetter,
                  setter,
                  to,
                  duration,
                  SystemQuaternionInterpolator.Instance,
                  validation
                  )
        {
        }
    }
}