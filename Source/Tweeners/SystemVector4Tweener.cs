using System.Numerics;
using GTweens.Delegates;
using GTweens.Interpolators;

namespace GTweens.Tweeners
{
    public sealed class SystemVector4Tweener : Tweener<Vector4>
    {
        public SystemVector4Tweener(
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
                SystemVector4Interpolator.Instance,
                validation
            )
        {
        }
    }
}