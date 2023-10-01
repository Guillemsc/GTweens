using System;
using GTweens.TweenBehaviours;
using GTweens.Tweens;

namespace GTweens.Builders;

public sealed class GTweenSequenceBuilder
{
    readonly SequenceTweenBehaviour _sequenceTweenBehaviour;
    readonly GTween _gTween;
    
    bool _creatingGroupTween;
    GroupTweenBehaviour? _groupTweenBehaviour;
    
    GTweenSequenceBuilder()
    {
        _sequenceTweenBehaviour = new SequenceTweenBehaviour();
        _gTween = new GTween(_sequenceTweenBehaviour);
    }
    
    public static GTweenSequenceBuilder New()
    {
        return new GTweenSequenceBuilder();
    }

    public GTweenSequenceBuilder Append(GTween gTween)
    {
        _creatingGroupTween = false;
        
        _sequenceTweenBehaviour.Add(gTween);

        return this;
    }
    
    public GTweenSequenceBuilder Join(GTween gTween)
    {
        if (_creatingGroupTween)
        {
            _groupTweenBehaviour!.Add(gTween);
            return this;
        }

        _creatingGroupTween = true;
        
        _groupTweenBehaviour = new GroupTweenBehaviour();

        if (_sequenceTweenBehaviour.Tweens.Count > 0)
        {
            GTween previousTween = _sequenceTweenBehaviour.Tweens[^1];
            _sequenceTweenBehaviour.Remove(previousTween);
            _groupTweenBehaviour.Add(previousTween);
        }
        
        _groupTweenBehaviour.Add(gTween);

        _sequenceTweenBehaviour.Add(new GTween(_groupTweenBehaviour));
        
        return this;
    }

    public GTweenSequenceBuilder AppendCallback(Action callback, bool callIfCompletingInstantly = true)
    {
        CallbackTweenBehaviour callbackTweenBehaviour = new(callback, callIfCompletingInstantly);
        Append(new GTween(callbackTweenBehaviour));
        
        return this;
    }
    
    public GTweenSequenceBuilder JoinCallback(Action callback, bool callIfCompletingInstantly = true)
    {
        CallbackTweenBehaviour callbackTweenBehaviour = new(callback, callIfCompletingInstantly);
        Join(new GTween(callbackTweenBehaviour));
        
        return this;
    }
    
    public GTweenSequenceBuilder AppendTime(float timeSeconds)
    {
        WaitTimeTweenBehaviour timeTweenBehaviour = new(timeSeconds);
        Append(new GTween(timeTweenBehaviour));
        
        return this;
    }
    
    public GTweenSequenceBuilder JoinTime(float timeSeconds)
    {
        WaitTimeTweenBehaviour timeTweenBehaviour = new(timeSeconds);
        Join(new GTween(timeTweenBehaviour));
        
        return this;
    }

    public GTweenSequenceBuilder AppendSequence(Action<GTweenSequenceBuilder> createSequence)
    {
        GTweenSequenceBuilder sequenceBuilder = New();
        createSequence.Invoke(sequenceBuilder);
        Append(sequenceBuilder.Build());
        
        return this;
    }
    
    public GTweenSequenceBuilder JoinSequence(Action<GTweenSequenceBuilder> createSequence)
    {
        GTweenSequenceBuilder sequenceBuilder = New();
        createSequence.Invoke(sequenceBuilder);
        Join(sequenceBuilder.Build());
        
        return this;
    }

    public GTween Build() => _gTween;
}