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
        
        Assert.IsFalse(tweener.IsPlaying);
        Assert.IsTrue(tweener.IsCompleted);
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
        
        Assert.AreEqual(value, finalValue);
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
        
        Assert.AreEqual(finalValue, value);
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
        
        Assert.IsFalse(tweener.IsPlaying);
        Assert.IsFalse(tweener.IsCompleted);
        Assert.IsTrue(tweener.IsKilled);
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
        
        Assert.AreEqual(0, value);
    }
}

#endif