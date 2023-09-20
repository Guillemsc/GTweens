// using Juce.Tweening.Easings;
// using System;
//
// namespace Juce.Tweening
// {
//     public class ResetableCallbackTween : Tween
//     {
//         private readonly Action action;
//         private readonly Action resetAction;
//         private readonly bool callIfCompletingInstantly;
//
//         protected override bool Loopable => false;
//
//         public ResetableCallbackTween(Action action, Action resetAction, bool callIfCompletingInstantly)
//         {
//             this.action = action;
//             this.resetAction = resetAction;
//             this.callIfCompletingInstantly = callIfCompletingInstantly;
//         }
//
//
//         protected override void WhenTweenStarted(bool isCompletingInstantly)
//         {
//             bool canCall = !isCompletingInstantly || callIfCompletingInstantly;
//
//             if (canCall)
//             {
//                 action?.Invoke();
//             }
//
//             NewMarkCompleted();
//         }
//
//         protected override void WhenTweenTicked()
//         {
//
//         }
//
//         protected override void WhenTweenKilled()
//         {
//
//         }
//
//         protected override void WhenTweenCompleted()
//         {
//
//         }
//
//         protected override void WhenTweenReseted(bool kill, ResetMode resetMode)
//         {
//             resetAction?.Invoke();
//         }
//
//         protected override void WhenTweenLoopStarted(ResetMode loopResetMode)
//         {
//
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
//             return 0.0f;
//         }
//
//         public override float OnGetElapsed()
//         {
//             return 0.0f;
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
