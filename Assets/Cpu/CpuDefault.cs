using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuDefault : MonoBehaviour {
    private Transform _ballTransform;
    
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _height = 0f;
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

    public void SetBallTransform(Transform ball) {
        _ballTransform = ball;
    }

    void Update() {
        if(_ballTransform == null) {
            return;
        }

        //  2次元平面に変換
        Vector2 ballStart = new Vector2(_ballTransform.position.x, _ballTransform.position.z);
        Vector2 ballEnd = ballStart + (new Vector2(_ballTransform.forward.x, _ballTransform.forward.z) * 50);

        //  パドル上の直線との交点を求める
        Vector2 intersectPoint = MathUtil.LineIntersect(rightEnd, leftEnd, ballStart, ballEnd);

        //  計算エラー
        if (float.IsNaN(intersectPoint.x) ||
            float.IsInfinity(intersectPoint.x) ||
            float.IsNaN(intersectPoint.y) ||
            float.IsInfinity(intersectPoint.y)) {
            return;
        }

        //  3次元に拡張
        Vector3 targetPoint = new Vector3(intersectPoint.x, _height, intersectPoint.y);

        Vector3 oldPoint = this.transform.position;

        //  移動
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPoint, _speed * Time.deltaTime);

        //  到達地点が範囲外なので、また壁に反射する
        Vector3 latestPos = this.transform.position;
        if (latestPos.x + (this.transform.localScale.x / 2) > (rightEnd.x) ||
            latestPos.x - (this.transform.localScale.x / 2) < (leftEnd.x)) {
            this.transform.position = oldPoint;
        }

    }

}
