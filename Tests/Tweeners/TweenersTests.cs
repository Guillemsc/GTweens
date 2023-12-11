#if GTWEENS_TESTS

using GTweens.Enums;
using GTweens.Tweeners;
using NUnit.Framework;

namespace GTweens.Tests.Tweeners;

public sealed class TweenersTests
{
    [Test]
    public void CompletesWhenElapsedTimeBiggerThanDuration()
    {
        ITweener tweener = new IntTweener(
            () => 0,
            _ => { },
            () => 1,
            1f,
            () => true
        );
        
        tweener.Start();
        tweener.Tick(2f);
        
        Assert.That(!tweener.IsPlaying);
        Assert.That(tweener.IsCompleted);
    }
    
    [Test]
    public void SetsFinalValueWhenElapsedTimeBiggerThanDuration()
    {
        int value = 0;
        int finalValue = 5;
        
        ITweener tweener = new IntTweener(
            () => value,
            newValue => value = newValue,
            () => finalValue,
            1f,
            () => true
        );
        
        tweener.Start();
        tweener.Tick(2f);
        
        Assert.That(value, Is.EqualTo(finalValue));
    }
    
    [Test]
    public void SetsFinalValueWhenManuallyCompleted()
    {
        int value = 0;
        int finalValue = 5;
        
        ITweener tweener = new IntTweener(
            () => value,
            newValue => value = newValue,
            () => finalValue,
            1f,
            () => true
        );
        
        tweener.Complete();
        
        Assert.That(finalValue, Is.EqualTo(value));
    }
    
    [Test]
    public void StopsWhenManuallyKilled()
    {
        ITweener tweener = new IntTweener(
            () => 0,
            _ => { },
            () => 1,
            1f,
            () => true
        );
        
        tweener.Start();
        tweener.Kill();
        
        Assert.That(!tweener.IsPlaying);
        Assert.That(!tweener.IsCompleted);
        Assert.That(tweener.IsKilled);
    }
    
    [Test]
    public void ResetsInitialValuesWhenManuallyReset()
    {
        int value = 0;
        int finalValue = 5;
        
        ITweener tweener = new IntTweener(
            () => value,
            newValue => value = newValue,
            () => finalValue,
            1f,
            () => true
        );
        
        tweener.Start();
        tweener.Tick(2f);
        tweener.Reset(ResetMode.InitialValues);
        
        Assert.That(0, Is.EqualTo(value));
    }
}

#endif