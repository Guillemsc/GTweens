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
        
        Assert.That(!tween.IsPlaying);
        Assert.That(tween.IsCompleted);
    }
    
    [Test]
    public void CompletesWhenManuallyCompletedAndNotStarted()
    {
        int value = 0;
        int finalValue = 5;
        
        GTween tween = GTweenExtensions.Tween(0, finalValue, newValue => value = newValue, 1);
        
        tween.Complete();
        
        Assert.That(value, Is.EqualTo(finalValue));
    }
    
    [Test]
    public void StopsWhenManuallyKilled()
    {
        GTween tween = GTweenExtensions.Tween(0, 5, _ => { }, 1);
        
        tween.Start();
        tween.Kill();
        
        Assert.That(!tween.IsPlaying);
        Assert.That(!tween.IsCompleted);
        Assert.That(tween.IsKilled);
    }
}

#endif