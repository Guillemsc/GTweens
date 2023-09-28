#if GTWEENS_TESTS

using GTweens.Extensions;
using GTweens.Tweens;
using NUnit.Framework;

namespace GTweens.Tests.Tweens;

public sealed class TweenTests
{
    [Test]
    public void CompletesWhenElapsedTimeBiggerThanDuration()
    {
        GTween tween = GTweenExtensions.Tween(0, 5, _ => { }, 1);
        
        tween.Start();
        tween.Tick(2f);
        
        Assert.IsFalse(tween.IsPlaying);
        Assert.IsTrue(tween.IsCompleted);
    }
    
    [Test]
    public void CompletesWhenManuallyCompletedAndNotStarted()
    {
        int value = 0;
        int finalValue = 5;
        
        GTween tween = GTweenExtensions.Tween(0, finalValue, newValue => value = newValue, 1);
        
        tween.Complete();
        
        Assert.AreEqual(value, finalValue);
    }
    
    [Test]
    public void StopsWhenManuallyKilled()
    {
        GTween tween = GTweenExtensions.Tween(0, 5, _ => { }, 1);
        
        tween.Start();
        tween.Kill();
        
        Assert.IsFalse(tween.IsPlaying);
        Assert.IsFalse(tween.IsCompleted);
        Assert.IsTrue(tween.IsKilled);
    }
}

#endif