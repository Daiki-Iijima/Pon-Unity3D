using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DefaultBall : BallBase {
    public BallController _controller { get; private set; }

    private EffectList _effectList = new EffectList();

    [SerializeField] private BallSetting _setting;

    protected override void Awake() {
        base.Awake();

        _controller = new BallController(this.transform, GetComponent<Rigidbody>(),_setting.Speed);

        //  反射エフェクト
        ICollisionEffect reflectEffect = EffectFactory.CreateReflect(this.gameObject, _controller);
        reflectEffect.SetHitTargetTag(new List<string>() { "Wall", "Paddle" });
        _effectList.AddEffect(reflectEffect);

        //  ヒット時待機エフェクト
        ICollisionEffect waitEffect = EffectFactory.CreateWait(this.gameObject, _controller, _setting.WaitTime);
        waitEffect.SetHitTargetTag(new List<string>() { "Wall", "Paddle" });
        _effectList.AddEffect(waitEffect);
    }

    protected override void Start() {
        base.Start();

        //  エフェクトの有効化
        _effectList.AdaptAllEffect(true);

        //  移動開始
        _controller.EnableMove(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _controller.EnableMove(!_controller.IsMove);
        }
    }

    private void FixedUpdate() {
        _controller.FixedTick(Time.deltaTime);
    }

}
