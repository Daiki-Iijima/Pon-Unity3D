using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCollisionEffect : IEffect,ICollisionEffect
{
    protected bool _IsAdapt = false;

    protected List<string> _hitTargetTagNames = new List<string>();

    public BaseCollisionEffect(CollisionProvider provider) {
        provider.CollisionEnterAction += OnEnter;
    }

    public void AdaptEffect(bool flag) {
        _IsAdapt = flag;
    }

    private void OnEnter(Collision collision) {

        //  �^�O���ݒ肳��Ă��Ȃ��ꍇ�́A�S�Ăɓ�����
        bool canHit = _hitTargetTagNames.Count == 0;

        foreach(var tag in _hitTargetTagNames) {
            if (collision.gameObject.CompareTag(tag)) {
                canHit = true;
                break;
            }
        }

        if (!canHit) {
            return;
        }

        if (_IsAdapt) {
            CollisionEffect(collision);
        }
    }

    protected abstract void CollisionEffect(Collision collision);

    public void SetHitTargetTag(List<string> noList) {
        _hitTargetTagNames = noList;       
    }
}
