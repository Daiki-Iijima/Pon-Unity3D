using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class BallBase : MonoBehaviour, IBall {
    protected int _ballCount = 0;

    protected Rigidbody _rb;
    protected Collider _collider;

    protected virtual void Awake() {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    protected virtual void Start() {
        _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }

    public void Delete() {
        Destroy(this);        
    }

    public int GetBoundCount() {
        return _ballCount;
    }

    public void SetEnable(bool flag) {
        this.gameObject.SetActive(flag);
    }
}
