#if GTWEENS_TESTS

using GTweens.Extensions;
using GTweens.TweenBehaviours;
using GTweens.Tweens;
using NUnit.Framework;

namespace GTweens.Tests.TweenBehaviours;

public sealed class SequenceTweenBehaviourTests
{
    [Test]
    public void CompletesWhenElapsedTimeBiggerThanDuration()
    {
        SequenceTweenBehaviour sequenceTweenBehaviour = new();
        sequenceTweenBehaviour.Add(CreateTweenWithDuration(1));
        sequenceTweenBehaviour.Add(CreateTweenWithDuration(2));
        sequenceTweenBehaviour.Add(CreateTweenWithDuration(3));

        GTween tween = new(sequenceTweenBehaviour);
        
        tween.Start();
        tween.Tick(4);
        tween.Tick(4);
        tween.Tick(4);
        
        Assert.IsFalse(tween.IsPlaying);
        Assert.IsTrue(tween.IsCompleted);
    }
    
    [Test]
    public void NotCompletesWhenElapsedTimeSmallerThanDuration()
    {
        SequenceTweenBehaviour sequenceTweenBehaviour = new();
        sequenceTweenBehaviour.Add(CreateTweenWithDuration(1));
        sequenceTweenBehaviour.Add(CreateTweenWithDuration(2));
        sequenceTweenBehaviour.Add(CreateTweenWithDuration(3));

        GTween tween = new(sequenceTweenBehaviour);
        
        tween.Start();
        tween.Tick(3);
        tween.Tick(3);
        
        Assert.IsTrue(tween.IsPlaying);
        Assert.IsFalse(tween.IsCompleted);
    }
    
    GTween CreateTweenWithDuration(float duration)
    {
        return GTweenExtensions.Tween(0, 1, _ => { }, duration);
    }
}

#endif