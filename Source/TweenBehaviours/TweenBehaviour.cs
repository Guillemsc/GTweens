using GTweens.Easings;
using GTweens.Enums;

namespace GTweens.TweenBehaviours;

public abstract class TweenBehaviour : ITweenBehaviour
{
    bool _finished;
    
    public abstract float GetDuration();
    public abstract float GetElapsed();
    public virtual bool GetLoopable() => true;
    
    public virtual void Start(bool isCompletingInstantly) { }
    public virtual void Tick(float deltaTime) { }
    public virtual void Kill() { }
    public virtual void Complete() { }
    public virtual void Reset(bool kill, ResetMode loopResetMode) { }
    public virtual void Loop(ResetMode loopResetMode) { }
    public virtual void SetEasing(EasingDelegate easingFunction) { }

    public bool GetFinished() => _finished;

    protected void MarkFinished() => _finished = true;
    protected void MarkUnfinished() => _finished = false;
}