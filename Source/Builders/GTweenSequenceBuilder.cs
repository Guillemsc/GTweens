using GTweens.TweenBehaviours;
using GTweens.Tweens;
using GUtils.Extensions;

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

    public GTween Build() => _gTween;
}