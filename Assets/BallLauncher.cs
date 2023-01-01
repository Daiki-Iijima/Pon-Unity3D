using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private BallBase _ballPrefab;

    public BallBase LaunchBall() {
        int angleY = Random.Range(0, 360);

        BallBase ball = Instantiate(_ballPrefab,transform.position,Quaternion.Euler(new Vector3(0,angleY,0)));

        ball.gameObject.name = "ball";

        return ball;
    }
}
