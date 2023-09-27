using GTweens.Extensions;
using GTweens.TweenBehaviours;
using GTweens.Tweens;
using NUnit.Framework;

namespace GTweens.Tests.TweenBehaviours;

public sealed class GroupTweenBehaviourTests
{
    [Test]
    public void CompletesWhenElapsedTimeBiggerThanDuration()
    {
        GroupTweenBehaviour groupTweenBehaviour = new();
        groupTweenBehaviour.Add(CreateTweenWithDuration(1));
        groupTweenBehaviour.Add(CreateTweenWithDuration(2));
        groupTweenBehaviour.Add(CreateTweenWithDuration(3));

        GTween tween = new(groupTweenBehaviour);
        
        tween.Start();
        tween.Tick(4);
        
        Assert.IsFalse(tween.IsPlaying);
        Assert.IsTrue(tween.IsCompleted);
    }
    
    [Test]
    public void NotCompletesWhenElapsedTimeSmallerThanDuration()
    {
        GroupTweenBehaviour groupTweenBehaviour = new();
        groupTweenBehaviour.Add(CreateTweenWithDuration(1));
        groupTweenBehaviour.Add(CreateTweenWithDuration(2));
        groupTweenBehaviour.Add(CreateTweenWithDuration(3));

        GTween tween = new(groupTweenBehaviour);
        
        tween.Start();
        tween.Tick(2);
        
        Assert.IsTrue(tween.IsPlaying);
        Assert.IsFalse(tween.IsCompleted);
    }
    
    GTween CreateTweenWithDuration(float duration)
    {
        return GTweenExtensions.Tween(0, 1, _ => { }, duration);
    }
}