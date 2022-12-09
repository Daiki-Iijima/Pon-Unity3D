using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectList {
    private List<IEffect> _list = new List<IEffect>();

    public List<IEffect> List { get { return _list; } }

    public bool IsAdaptAllEffect { get; private set; }

    public void AddEffect(IEffect effect) {
        _list.Add(effect);
    }

    public void AdaptAllEffect(bool flag) {

        IsAdaptAllEffect = flag;

        foreach(var effect in _list) {
            effect.AdaptEffect(IsAdaptAllEffect);
        }
    }

    public void DeleteEffect(IEffect effect) {
        _list.Remove(effect);
    }
    
    public void ClearEffect() {
        _list.Clear();
    }
}
