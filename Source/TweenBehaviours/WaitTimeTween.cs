// using Juce.Tweening.Easings;
//
// namespace Juce.Tweening
// {
//     public class WaitTimeTween : Tween
//     {
//         private readonly float duration;
//         private float elapsed;
//
//         protected override bool Loopable => true;
//
//         public WaitTimeTween(float duration)
//         {
//             this.duration = duration;
//         }
//
//         protected override void WhenTweenStarted(bool isCompletingInstantly)
//         {
//             elapsed = 0.0f;
//         }
//
//         protected override void WhenTweenTicked()
//         {
//             // float dt = Time.unscaledDeltaTime * JuceTween.TimeScale * TimeScale;
//             //
//             // elapsed += dt;
//             //
//             // if (elapsed >= duration)
//             // {
//             //     NewMarkCompleted();
//             // }
//         }
//
//         protected override void WhenTweenKilled()
//         {
//
//         }
//
//         protected override void WhenTweenCompleted()
//         {
//             elapsed = duration;
//
//             NewMarkCompleted();
//         }
//
//         protected override void WhenTweenReseted(bool kill, ResetMode resetMode)
//         {
//             elapsed = 0.0f;
//         }
//
//         protected override void WhenTweenLoopStarted(ResetMode loopResetMode)
//         {
//             elapsed = 0.0f;
//         }
//
//         public override void WhenTimeScaleChanged(float timeScale)
//         {
//
//         }
//
//         public override void WhenEaseDelegateChanged(EasingDelegate easingFunction)
//         {
//
//         }
//
//         public override float OnGetDuration()
//         {
//             return duration;
//         }
//
//         public override float OnGetElapsed()
//         {
//             return elapsed;
//         }
//
//         public override int OnGetTweensCount()
//         {
//             return 1;
//         }
//
//         public override int OnGetPlayingTweensCount()
//         {
//             return IsPlaying ? 1 : 0;
//         }
//     }
// }
