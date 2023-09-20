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
        
        Assert.IsTrue(tween.Behaviour is SequenceTweenBehaviour);

        if (tween.Behaviour is not SequenceTweenBehaviour baseSequenceTweenBehaviour)
        {
            return;
        }
        
        Assert.IsTrue(baseSequenceTweenBehaviour.Tweens.Count == 3);
        Assert.IsTrue(baseSequenceTweenBehaviour.Tweens[0].Behaviour is not GroupTweenBehaviour);
        Assert.IsTrue(baseSequenceTweenBehaviour.Tweens[1].Behaviour is GroupTweenBehaviour);
        Assert.IsTrue(baseSequenceTweenBehaviour.Tweens[2].Behaviour is not GroupTweenBehaviour);
    }
    
    GTween CreateTweenWithDuration(float duration)
    {
        return GTweenExtensions.To(0, 1, _ => { }, duration);
    }
}