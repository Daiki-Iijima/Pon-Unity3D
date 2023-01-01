using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ReflectEffect : BaseCollisionEffect {

    private ITransformUpdatable _trans;

    public ReflectEffect(CollisionProvider provider,ITransformUpdatable trans) : base(provider) {
        _trans = trans;
    }


    protected override void CollisionEffect(Collision collision) {
        if (_IsAdapt) {
            float y = GetReflectAngleY(_trans.GetForward(), collision);
            _trans.AddYRotate(y);
        }
    }


    /// <summary>
    /// ���˃x�N�g�����v�Z
    /// </summary>
    /// <param name="incidenceVector">���˃x�N�g��</param>
    /// <param name="targetCollision">������Ώۂ̃I�u�W�F�N�g</param>
    /// <returns></returns>
    private float GetReflectAngleY(Vector3 incidenceVector, Collision targetCollision) {
        //  ���������ǂ̃x�N�g��
        Vector3 targetNomal = targetCollision.contacts[0].normal;

        float angle = BallUtil.RefrectAngle(incidenceVector,targetNomal);

        return angle;
    }
}
