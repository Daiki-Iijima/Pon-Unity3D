using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallDriver : MonoBehaviour, IDriver,ITransform {

    private Rigidbody _rb;

    public bool IsDrive { get; private set; }

    [SerializeField]private float _speed = 10f;

    public void EnableDrive(bool flag) {
        IsDrive = flag;
    }

    public Transform GetTransform() {
        return this.transform;
    }

    public void SetRotate(Vector3 rot) {
        this.transform.eulerAngles = rot;
    }

    public void SetSpeed(float speed) {
        _speed = speed;
    }

    public void SetTransfrom(Vector3 pos) {
        this.transform.position = pos;
    }

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (IsDrive) {
            _rb.AddForce(this.transform.forward, ForceMode.Acceleration);
            _rb.velocity = this.transform.forward * _speed;
        } else {
            _rb.velocity = Vector3.zero;
        }
    }
}
