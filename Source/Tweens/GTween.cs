using System;
using System.Threading;
using System.Threading.Tasks;
using GTweens.Easings;
using GTweens.Enums;
using GTweens.TweenBehaviours;

namespace GTweens.Tweens
{
    public sealed class GTween 
    {
        public event Action<float>? OnTimeScaleChanged;
        public event Action? OnStart;
        public event Action? OnLoop;
        public event Action? OnReset;
        public event Action? OnComplete;
        public event Action? OnKill;
        public event Action? OnCompleteOrKill;
        
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
   
            OnStart?.Invoke();
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

            OnKill?.Invoke();
            OnCompleteOrKill?.Invoke();
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

            OnReset?.Invoke();
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
            if(TimeScale == timeScale)
            {
                return this;
            }

            TimeScale = timeScale;
            
            OnTimeScaleChanged?.Invoke(timeScale);

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

            OnLoop?.Invoke();
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

            OnComplete?.Invoke();
            OnCompleteOrKill?.Invoke();
        }
    }
}
