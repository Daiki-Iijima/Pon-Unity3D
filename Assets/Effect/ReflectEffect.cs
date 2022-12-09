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
    /// ���˃x�N�g�����v�Z
    /// </summary>
    /// <param name="selfTrans">�����Ă���I�u�W�F�N�g</param>
    /// <param name="targetCollision">������Ώۂ̃I�u�W�F�N�g</param>
    /// <returns></returns>
    private float GetReflectAngleY(Transform selfTrans, Collision targetCollision) {
        //  ���˃x�N�g��
        Vector3 inDir = selfTrans.forward;
        //  ���������ǂ̃x�N�g��
        Vector3 targetNomal = targetCollision.contacts[0].normal;

        Vector3 reflectVec = Vector3.Reflect(inDir, targetNomal);

        float angle = Vector3.SignedAngle(inDir, reflectVec, Vector3.up);
        angle = selfTrans.eulerAngles.y + angle;

        return angle;
    }
}
