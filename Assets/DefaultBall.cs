using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBall : BallBase {
    private IDriver _driver;

    private EffectList _effectList = new EffectList();

    protected override void Awake() {
        base.Awake();

        _driver = GetComponent<BallDriver>();
        if (_driver == null) {
            _driver = this.gameObject.AddComponent<BallDriver>();
        }

        //  �G�t�F�N�g�ݒ�
        //  ���˃G�t�F�N�g
        ICollisionEffect reflectEffect = GetComponent<ReflectEffect>();
        if (reflectEffect == null) {
            reflectEffect = gameObject.AddComponent<ReflectEffect>();
        }
        reflectEffect.SetHitTargetTag(new List<string>() { "Wall", "Paddle" });
        _effectList.AddEffect(reflectEffect);

        //  �q�b�g���ҋ@�G�t�F�N�g
        ICollisionEffect waitEffect = GetComponent<WaitEffect>();
        if (waitEffect == null) {
            waitEffect = gameObject.AddComponent<WaitEffect>();
        }
        waitEffect.SetHitTargetTag(new List<string>() { "Wall", "Paddle" });
        _effectList.AddEffect(waitEffect);
    }

    protected override void Start() {
        base.Start();

        //  �G�t�F�N�g�̗L����
        _effectList.AdaptAllEffect(true);

        //  �ړ��J�n
        _driver.EnableDrive(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _driver.EnableDrive(!_driver.IsDrive);
        }
    }

}
