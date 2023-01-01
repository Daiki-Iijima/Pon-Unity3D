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
    /// 反射ベクトルを計算
    /// </summary>
    /// <param name="incidenceVector">入射ベクトル</param>
    /// <param name="targetCollision">当たる対象のオブジェクト</param>
    /// <returns></returns>
    private float GetReflectAngleY(Vector3 incidenceVector, Collision targetCollision) {
        //  当たった壁のベクトル
        Vector3 targetNomal = targetCollision.contacts[0].normal;

        float angle = BallUtil.RefrectAngle(incidenceVector,targetNomal);

        return angle;
    }
}
