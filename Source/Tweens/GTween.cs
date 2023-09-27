using System;
using GTweens.Easings;
using GTweens.Enums;
using GTweens.TweenBehaviours;

namespace GTweens.Tweens
{
    public sealed class GTween 
    {
        public event Action? OnStartAction;
        public event Action? OnLoopAction;
        public event Action? OnResetAction;
        public event Action? OnCompleteAction;
        public event Action? OnKillAction;
        public event Action? OnCompleteOrKillAction;
        public event Action<float>? OnTimeScaleChangedAction;
        
        public ITweenBehaviour Behaviour { get; }
        public float TimeScale { get; private set; } = 1;

        public int Loops { get; private set; }
        public ResetMode LoopResetMode { get; private set; }

        public bool IsNested { get; set; }

        public bool IsPlaying { get; private set; }
        public bool IsCompleted { get; private set; }
        public bool IsKilled { get; private set; }
        public bool IsCompletedOrKilled => IsCompleted || IsKilled;

        public bool IsAlive { get; set; }
        
        int _loopsRemaining;

        public GTween(ITweenBehaviour behaviour)
        {
            Behaviour = behaviour;
        }

        public void Start(bool isCompletingInstantly = false)
        {
            if (IsPlaying)
            {
                Kill();
            }

            IsPlaying = true;
            IsCompleted = false;
            IsKilled = false;

            _loopsRemaining = Loops;

            Behaviour.Start(isCompletingInstantly);
   
            OnStartAction?.Invoke();
        }
        
        public void Tick(float deltaTime)
        {
            if (!IsPlaying)
            {
                return;
            }

            Behaviour.Tick(deltaTime);

            bool isFinished = Behaviour.GetFinished();

            if (!isFinished)
            {
                return;
            }
            
            bool needsToLoop = _loopsRemaining > 0 && Behaviour.GetLoopable();

            if(needsToLoop)
            {
                Loop(LoopResetMode);
            }
            else
            {
                MarkFinished();
            }
        }

        public void Complete()
        {
            if (!IsPlaying && !IsCompleted)
            {
                Start(true);
            }

            Behaviour.Complete();

            _loopsRemaining = 0;

            MarkFinished();
        }

        public void Kill()
        {
            if (!IsPlaying)
            {
                return;
            }

            IsPlaying = false;
            IsCompleted = false;
            IsKilled = true;

            Behaviour.Kill();

            OnKillAction?.Invoke();
            OnCompleteOrKillAction?.Invoke();
        }

        public void Reset(bool kill, ResetMode resetMode = ResetMode.InitialValues)
        {
            if (kill)
            {
                Kill();
                IsPlaying = false;
            }

            IsCompleted = false;
            IsKilled = false;

            Behaviour.Reset(kill, resetMode);

            OnResetAction?.Invoke();
        }

        public float GetDuration()
        {
            return Behaviour.GetDuration();
        }

        public float GetElapsed()
        {
            if(!IsPlaying && !IsCompleted)
            {
                return 0.0f;
            }

            if(!IsPlaying && IsCompleted)
            {
                return GetDuration();
            }

            return Behaviour.GetElapsed();
        }
        
        public GTween SetTimeScale(float timeScale)
        {
            TimeScale = timeScale;
            OnTimeScaleChangedAction?.Invoke(timeScale);
            return this;
        }

        public GTween SetEasing(EasingDelegate easingFunction)
        {
            Behaviour.SetEasing(easingFunction);
            return this;
        }

        public GTween SetEasing(Easing easing)
        {
            return SetEasing(PresetEasingDelegateFactory.GetEaseDelegate(easing));
        }

        public GTween SetLoops(int loops, ResetMode resetMode = ResetMode.InitialValues)
        {
            Loops = Math.Max(loops, 0);
            LoopResetMode = resetMode;
            return this;
        }
        
        public GTween SetInfiniteLoops(ResetMode resetMode = ResetMode.InitialValues)
        {
            return SetLoops(int.MaxValue, resetMode);
        }
        
        public GTween OnStart(Action action)
        {
            OnStartAction += action;
            return this;
        }
        
        public GTween OnLoop(Action action)
        {
            OnLoopAction += action;
            return this;
        }
        
        public GTween OnReset(Action action)
        {
            OnResetAction += action;
            return this;
        }
        
        public GTween OnComplete(Action action)
        {
            OnCompleteAction += action;
            return this;
        }
        
        public GTween OnKill(Action action)
        {
            OnKillAction += action;
            return this;
        }
        
        public GTween OnCompleteOrKill(Action action)
        {
            OnCompleteOrKillAction += action;
            return this;
        }
        
        public GTween OnTimeScaleChanged(Action<float> action)
        {
            OnTimeScaleChangedAction += action;
            return this;
        }
        
        void Loop(ResetMode loopResetMode)
        {
            bool needsToLoop = _loopsRemaining > 0;

            if(!needsToLoop || !Behaviour.GetLoopable())
            {
                return;
            }

            --_loopsRemaining;

            Reset(kill: false, loopResetMode);

            Start();

            OnLoopAction?.Invoke();
        }

        void MarkFinished()
        {
            if (!IsPlaying)
            {
                return;
            }
            
            IsPlaying = false;
            IsCompleted = true;
            IsKilled = false;

            Behaviour.Complete();

            OnCompleteAction?.Invoke();
            OnCompleteOrKillAction?.Invoke();
        }
    }
}
