#if GTWEENS_TESTS

using GTweens.Builders;
using GTweens.Extensions;
using GTweens.TweenBehaviours;
using GTweens.Tweens;
using NUnit.Framework;

namespace GTweens.Tests.Builders;

public sealed class GTweenSequenceBuilderTests
{
    [Test]
    public void JoiningAndAppendingWorks()
    {
        GTween tween = GTweenSequenceBuilder.New()
            .Append(CreateTweenWithDuration(1))
            .Append(CreateTweenWithDuration(1))
            .Join(CreateTweenWithDuration(1))
            .Append(CreateTweenWithDuration(1))
            .Build();
        
        Assert.That(tween.Behaviour is SequenceTweenBehaviour);

        if (tween.Behaviour is not SequenceTweenBehaviour baseSequenceTweenBehaviour)
        {
            return;
        }
        
        Assert.That(baseSequenceTweenBehaviour.Tweens.Count == 3);
        Assert.That(baseSequenceTweenBehaviour.Tweens[0].Behaviour is not GroupTweenBehaviour);
        Assert.That(baseSequenceTweenBehaviour.Tweens[1].Behaviour is GroupTweenBehaviour);
        Assert.That(baseSequenceTweenBehaviour.Tweens[2].Behaviour is not GroupTweenBehaviour);
        
        if (baseSequenceTweenBehaviour.Tweens[1].Behaviour is not GroupTweenBehaviour groupTweenBehaviour)
        {
            return;
        }
        
        Assert.That(groupTweenBehaviour.Tweens.Count == 2);
    }
    
    GTween CreateTweenWithDuration(float duration)
    {
        return GTweenExtensions.Tween(0, 1, _ => { }, duration);
    }
}

#endif