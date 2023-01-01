using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ball/Settings",fileName ="BallData")]
public class BallSetting : ScriptableObject {
    [SerializeField] private float _speed;
    [SerializeField] private float _waitTime;

    public float Speed { get { return _speed; } }
    public float WaitTime { get { return _waitTime; } }
}
