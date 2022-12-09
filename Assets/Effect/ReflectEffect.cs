using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ITransform))]
[RequireComponent(typeof(Collider))]
public class ReflectEffect : BaseCollisionEffect {

    private ITransform _trans;

    private void Awake() {
        _trans = GetComponent<ITransform>();
    }

    protected override void CollisionEffect(Collision collision) {
        if (_IsAdapt) {
            Transform transform = _trans.GetTransform();
            float y = GetReflectAngleY(transform, collision);
            Vector3 rot = transform.eulerAngles;
            rot.y = y;
            _trans.SetRotate(rot);
        }
    }


    /// <summary>
    /// 反射ベクトルを計算
    /// </summary>
    /// <param name="selfTrans">動いているオブジェクト</param>
    /// <param name="targetCollision">当たる対象のオブジェクト</param>
    /// <returns></returns>
    private float GetReflectAngleY(Transform selfTrans, Collision targetCollision) {
        //  入射ベクトル
        Vector3 inDir = selfTrans.forward;
        //  当たった壁のベクトル
        Vector3 targetNomal = targetCollision.contacts[0].normal;

        Vector3 reflectVec = Vector3.Reflect(inDir, targetNomal);

        float angle = Vector3.SignedAngle(inDir, reflectVec, Vector3.up);
        angle = selfTrans.eulerAngles.y + angle;

        return angle;
    }
}
