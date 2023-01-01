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

        //  ���˃G�t�F�N�g
        ICollisionEffect reflectEffect = EffectFactory.CreateReflect(this.gameObject, _controller);
        reflectEffect.SetHitTargetTag(new List<string>() { "Wall", "Paddle" });
        _effectList.AddEffect(reflectEffect);

        //  �q�b�g���ҋ@�G�t�F�N�g
        ICollisionEffect waitEffect = EffectFactory.CreateWait(this.gameObject, _controller, _setting.WaitTime);
        waitEffect.SetHitTargetTag(new List<string>() { "Wall", "Paddle" });
        _effectList.AddEffect(waitEffect);
    }

    protected override void Start() {
        base.Start();

        //  �G�t�F�N�g�̗L����
        _effectList.AdaptAllEffect(true);

        //  �ړ��J�n
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
