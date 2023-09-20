using System.Drawing;
using System.Numerics;
using GTweens.Delegates;
using GTweens.TweenBehaviours;
using GTweens.Tweeners;
using GTweens.Tweens;

namespace GTweens.Extensions
{
    public static class GTweenExtensions
    {
        public static GTween To(
            Tweener<int>.Getter currValueGetter, 
            Tweener<int>.Setter setter,
            Tweener<int>.Getter finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new IntTweener(currValueGetter, setter, finalValueGetter, duration, validation));
            return new GTween(tweenBehaviour);
        }

        public static GTween To(
            Tweener<float>.Getter currValueGetter, 
            Tweener<float>.Setter setter,
            Tweener<float>.Getter finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new FloatTweener(currValueGetter, setter, finalValueGetter, duration, validation));
            return new GTween(tweenBehaviour);
        }

        public static GTween To(
            Tweener<Vector2>.Getter currValueGetter, 
            Tweener<Vector2>.Setter setter,
            Tweener<Vector2>.Getter finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new SystemVector2Tweener(currValueGetter, setter, finalValueGetter, duration, validation));
            return new GTween(tweenBehaviour);
        }

        public static GTween To(
            Tweener<Vector3>.Getter currValueGetter, 
            Tweener<Vector3>.Setter setter,
            Tweener<Vector3>.Getter finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new SystemVector3Tweener(currValueGetter, setter, finalValueGetter, duration, validation));
            return new GTween(tweenBehaviour);
        }

        // public static ITween To(
        //     Tweener<Vector3>.Getter currValueGetter,
        //     Tweener<Vector3>.Setter setter,
        //     Tweener<Vector3>.Getter finalValueGetter,
        //     RotationMode rotationMode,
        //     float duration,
        //     Tweener<Vector3>.Validation validation = null
        //     )
        // {
        //     InterpolationTween tween = new InterpolationTween();
        //     tween.Add(new Vector3RotationTweener(currValueGetter, setter, finalValueGetter, rotationMode, duration, validation));
        //     return tween;
        // }

        public static GTween To(
            Tweener<Vector4>.Getter currValueGetter, 
            Tweener<Vector4>.Setter setter,
            Tweener<Vector4>.Getter finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new SystemVector4Tweener(currValueGetter, setter, finalValueGetter, duration, validation));
            return new GTween(tweenBehaviour);
        }

        public static GTween To(
            Tweener<Color>.Getter currValueGetter, 
            Tweener<Color>.Setter setter,
            Tweener<Color>.Getter finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new SystemColorTweener(currValueGetter, setter, finalValueGetter, duration, validation));
            return new GTween(tweenBehaviour);
        }

        public static GTween To(
            Tweener<Quaternion>.Getter currValueGetter, 
            Tweener<Quaternion>.Setter setter,
            Tweener<Quaternion>.Getter finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new SystemQuaternionTweener(currValueGetter, setter, finalValueGetter, duration, validation));
            return new GTween(tweenBehaviour);
        }

        public static GTween To(
            Tweener<int>.Getter[] currValueGetter, 
            Tweener<int>.Setter[] setter,
            Tweener<int>.Getter[] finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tweenBehaviour.Add(new IntTweener(currValueGetter[i], setter[i], finalValueGetter[i], duration, validation));
                }
            }
            return new GTween(tweenBehaviour);
        }

        public static GTween To(
            Tweener<float>.Getter[] currValueGetter, 
            Tweener<float>.Setter[] setter,
            Tweener<float>.Getter[] finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tweenBehaviour.Add(new FloatTweener(currValueGetter[i], setter[i], finalValueGetter[i], duration, validation));
                }
            }
            return new GTween(tweenBehaviour);
        }

        public static GTween To(
            Tweener<Vector2>.Getter[] currValueGetter, 
            Tweener<Vector2>.Setter[] setter,
            Tweener<Vector2>.Getter[] finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tweenBehaviour.Add(new SystemVector2Tweener(currValueGetter[i], setter[i], finalValueGetter[i], duration, validation));
                }
            }
            return new GTween(tweenBehaviour);
        }

        public static GTween To(
            Tweener<Vector3>.Getter[] currValueGetter, 
            Tweener<Vector3>.Setter[] setter,
            Tweener<Vector3>.Getter[] finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tweenBehaviour.Add(new SystemVector3Tweener(currValueGetter[i], setter[i], finalValueGetter[i], duration, validation));
                }
            }
            return new GTween(tweenBehaviour);
        }

        public static GTween To(
            Tweener<Vector4>.Getter[] currValueGetter, 
            Tweener<Vector4>.Setter[] setter,
            Tweener<Vector4>.Getter[] finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tweenBehaviour.Add(new SystemVector4Tweener(currValueGetter[i], setter[i], finalValueGetter[i], duration, validation));
                }
            }
            return new GTween(tweenBehaviour);
        }
        
        public static GTween To(
            Tweener<Color>.Getter[] currValueGetter, 
            Tweener<Color>.Setter[] setter,
            Tweener<Color>.Getter[] finalValueGetter, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tweenBehaviour.Add(new SystemColorTweener(currValueGetter[i], setter[i], finalValueGetter[i], duration, validation));
                }
            }
            return new GTween(tweenBehaviour);
        }
        
        public static GTween To(
            int initialValue, 
            int finalValue, 
            Tweener<int>.Setter setter,
            float duration
        )
        {
            return To(
                () => initialValue,
                setter,
                () => finalValue,
                duration,
                () => true
            );
        }
        
        public static GTween To(
            float initialValue, 
            float finalValue, 
            Tweener<float>.Setter setter,
            float duration
        )
        {
            return To(
                () => initialValue,
                setter,
                () => finalValue,
                duration,
                () => true
            );
        }
        
        public static bool IsPlayingOrCompleted(this GTween gTween)
        {
            return gTween.IsPlaying || gTween.IsCompleted;
        }
        
        public static bool IsPlayingOrCompletedOrNested(this GTween gTween)
        {
            return gTween.IsPlaying || gTween.IsCompleted || gTween.IsNested;
        }
    }
}
