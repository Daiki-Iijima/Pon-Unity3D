using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    [SerializeField] private float _paddleEndLine = 6.5f;
    [SerializeField] private Transform _rightWall;
    [SerializeField] private Transform _leftWall;

    private Vector3 _defaultPosition;

    private Vector2 rightEnd {
        get {
            Vector2 retValue = new Vector2(
                _rightWall.position.x - (_rightWall.localScale.x / 2),
                _paddleEndLine);

            return retValue;
        }
    }

    private Vector3 leftEnd {
        get {
            Vector2 retValue = new Vector2(
                _leftWall.position.x + (_leftWall.localScale.x / 2),
                _paddleEndLine);

            return retValue;
        }
    }

    private void Start() {
        _defaultPosition = this.transform.position;
    }

    public void ResetPosition() {
        this.transform.position = _defaultPosition;
    }

    void Update()
    {
        Vector3 oldPoint = this.transform.position;

        if (Input.GetKey(KeyCode.D)) {
            this.transform.position += Vector3.right * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A)) {
            this.transform.position += -Vector3.right * Time.deltaTime * _speed;
        }

        //  ???B?n?_???͈͊O?Ȃ̂ŁA?܂??ǂɔ??˂???
        Vector3 latestPos = this.transform.position;
        if (latestPos.x + (this.transform.localScale.x / 2) > (rightEnd.x) ||
            latestPos.x - (this.transform.localScale.x / 2) < (leftEnd.x)) {
            this.transform.position = oldPoint;
        }
    }
}
