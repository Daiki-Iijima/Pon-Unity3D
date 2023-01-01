using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : IBallController,ITransformUpdatable { 

    private Rigidbody _rb;
    private Transform _targetTransform;

    private float _speed = 10f;

    #region IBallController
    public bool IsMove { get; private set; }

    public void SetSpeed(float speed) {
        _speed = speed;
    }

    public void EnableMove(bool flag) {
        IsMove = flag;
    }
    #endregion

    public BallController(Transform targetTransform,Rigidbody rb,float speed = 10f) {
        _targetTransform = targetTransform;
        _rb = rb;
        _speed = speed;
    }

    /// <summary>
    /// FixedUpdate‚ÅŒÄ‚Ô
    /// </summary>
    public void FixedTick(float deltaTime) {
        if (IsMove) {
            _rb.AddForce(_targetTransform.forward, ForceMode.Acceleration);
            _rb.velocity = _targetTransform.forward * _speed;
        } else {
            _rb.velocity = Vector3.zero;
        }
    }

    void ITransformChangeable.SetRotate(Vector3 rot) {
        _targetTransform.eulerAngles = rot;
    }
    void ITransformChangeable.AddYRotate(float addYRot) {
        Vector3 angle = _targetTransform.eulerAngles;
        angle.y += addYRot;
        _targetTransform.eulerAngles = angle;
    }

    void ITransformChangeable.SetPosition(Vector3 pos) {
        _targetTransform.position = pos;
    }

    void ITransformChangeable.SetYRotate(float yRot) {
        Vector3 latestAngle = _targetTransform.eulerAngles;
        latestAngle.y = yRot;
        _targetTransform.eulerAngles = latestAngle;
    }

    Vector3 ITransformAcquirable.GetForward() {
        return _targetTransform.forward;
    }

    Vector3 ITransformAcquirable.GetRotate() {
        return _targetTransform.eulerAngles;
    }

    Vector3 ITransformAcquirable.GetPosition() {
        return _targetTransform.position;
    }
}
