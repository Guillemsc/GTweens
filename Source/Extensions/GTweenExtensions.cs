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
        public static GTween Tween(
            Tweener<int>.Getter getter, 
            Tweener<int>.Setter setter,
            int to, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new IntTweener(getter, setter, to, duration, validation));
            return new GTween(tweenBehaviour);
        }
        
        public static GTween Tween(
            Tweener<int>.Getter getter, 
            Tweener<int>.Setter setter,
            int to, 
            float duration
        ) => Tween(getter, setter, to, duration, ValidationExtensions.AlwaysValid);


        public static GTween Tween(
            Tweener<float>.Getter getter,
            Tweener<float>.Setter setter,
            float to,
            float duration,
            ValidationDelegates.Validation validation
        )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new FloatTweener(getter, setter, to, duration, validation));
            return new GTween(tweenBehaviour);
        }

        public static GTween Tween(
            Tweener<float>.Getter getter,
            Tweener<float>.Setter setter,
            float to,
            float duration
        ) => Tween(getter, setter, to, duration, ValidationExtensions.AlwaysValid);

        public static GTween Tween(
            Tweener<Vector2>.Getter getter,
            Tweener<Vector2>.Setter setter,
            Vector2 to,
            float duration,
            ValidationDelegates.Validation validation
        )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new SystemVector2Tweener(getter, setter, to, duration, validation));
            return new GTween(tweenBehaviour);
        }
        
        public static GTween Tween(
            Tweener<Vector2>.Getter getter,
            Tweener<Vector2>.Setter setter,
            Vector2 to,
            float duration
        ) => Tween(getter, setter, to, duration, ValidationExtensions.AlwaysValid);
        

        public static GTween Tween(
            Tweener<Vector3>.Getter getter, 
            Tweener<Vector3>.Setter setter,
            Vector3 to, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new SystemVector3Tweener(getter, setter, to, duration, validation));
            return new GTween(tweenBehaviour);
        }
        
        public static GTween Tween(
            Tweener<Vector3>.Getter getter, 
            Tweener<Vector3>.Setter setter,
            Vector3 to, 
            float duration
        ) => Tween(getter, setter, to, duration, ValidationExtensions.AlwaysValid);
        

        public static GTween Tween(
            Tweener<Vector4>.Getter getter, 
            Tweener<Vector4>.Setter setter,
            Vector4 to, 
            float duration, 
            ValidationDelegates.Validation validation
            )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new SystemVector4Tweener(getter, setter, to, duration, validation));
            return new GTween(tweenBehaviour);
        }
        
        public static GTween Tween(
            Tweener<Vector4>.Getter getter, 
            Tweener<Vector4>.Setter setter,
            Vector4 to, 
            float duration
        ) => Tween(getter, setter, to, duration, ValidationExtensions.AlwaysValid);


        public static GTween Tween(
            Tweener<Color>.Getter getter,
            Tweener<Color>.Setter setter,
            Color to,
            float duration,
            ValidationDelegates.Validation validation
        )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new SystemColorTweener(getter, setter, to, duration, validation));
            return new GTween(tweenBehaviour);
        }

        public static GTween Tween(
            Tweener<Color>.Getter getter, 
            Tweener<Color>.Setter setter,
            Color to, 
            float duration
        ) => Tween(getter, setter, to, duration, ValidationExtensions.AlwaysValid);

        public static GTween Tween(
            Tweener<Quaternion>.Getter getter,
            Tweener<Quaternion>.Setter setter,
            Quaternion to,
            float duration,
            ValidationDelegates.Validation validation
        )
        {
            InterpolationTweenBehaviour tweenBehaviour = new InterpolationTweenBehaviour();
            tweenBehaviour.Add(new SystemQuaternionTweener(getter, setter, to, duration, validation));
            return new GTween(tweenBehaviour);
        }
        
        public static GTween Tween(
            Tweener<Quaternion>.Getter getter,
            Tweener<Quaternion>.Setter setter,
            Quaternion to,
            float duration
        ) => Tween(getter, setter, to, duration, ValidationExtensions.AlwaysValid);
        
        
        public static GTween Tween(
            int from, 
            int to, 
            Tweener<int>.Setter setter,
            float duration
        )
        {
            return Tween(
                () => from,
                setter,
                to,
                duration,
                ValidationExtensions.AlwaysValid
            );
        }
        
        public static GTween Tween(
            float from, 
            float to, 
            Tweener<float>.Setter setter,
            float duration
        )
        {
            return Tween(
                () => from,
                setter,
                to,
                duration,
                ValidationExtensions.AlwaysValid
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
