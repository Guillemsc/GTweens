using System.Collections.Generic;
using System.Diagnostics;
using GTweens.Tweens;

namespace GTweens.Contexts
{
    public sealed class GTweensContext 
    {
        public float TimeScale { get; set; } = 1f;
        public float TickDurationMs { get; private set; } 
        
        readonly List<GTween> _aliveTweens = new();
        readonly List<GTween> _tweensToAdd = new();
        readonly List<GTween> _tweensToRemove = new();

        readonly Stopwatch _updateStopwatch = new();
        
        public void Play(GTween gTween)
        {
            if(gTween.IsNested)
            {
                return;
            }

            if(gTween.IsAlive)
            {
                TryStartTween(gTween);
                return;
            }

            gTween.IsAlive = true;

            _tweensToAdd.Add(gTween);

            TryStartTween(gTween);
        }
        
        public void Tick(float deltaTime)
        {
            float scaledDeltaTime = deltaTime * TimeScale;
            
            _updateStopwatch.Restart();

            foreach(GTween tween in _tweensToAdd)
            {
                _aliveTweens.Add(tween);
            }

            _tweensToAdd.Clear();

            foreach (GTween tween in _aliveTweens)
            {
                if(tween.IsPlaying)
                {
                    tween.Tick(scaledDeltaTime);
                }
                else
                {
                    _tweensToRemove.Add(tween);
                }
            }

            foreach(GTween tween in _tweensToRemove)
            {
                tween.IsAlive = false;

                _aliveTweens.Remove(tween);
                _tweensToAdd.Remove(tween);
            }

            _tweensToRemove.Clear();

            _updateStopwatch.Stop();

            TickDurationMs = _updateStopwatch.ElapsedMilliseconds;
        }
        
        public void Clear()
        {
            _aliveTweens.Clear();
            _tweensToAdd.Clear();
            _tweensToRemove.Clear();
        }

        void TryStartTween(GTween gTween)
        {
            if (!gTween.IsPlaying)
            {
                gTween.Start();
            }
        }
    }
}