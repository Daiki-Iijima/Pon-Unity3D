using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallList {

    private List<IBall> _balls = new List<IBall>();

    public readonly int MaxCount;

    public List<IBall> Balls {
        get {
            return _balls;
        }
    }

    public BallList(int maxCount) {
        MaxCount = maxCount;
    }

    /// <summary>
    /// ボールを追加する
    /// </summary>
    /// <param name="ball"></param>
    /// <returns></returns>
    public bool Add(IBall ball) {
        if(CanAddBall()) {
            return false;
        }

        _balls.Add(ball);

        return true;
    }

    public void Remove(IBall ball) {
        _balls.Remove(ball);
    }

    public void Clear() {
        _balls.Clear();
    }

    private bool CanAddBall() {
        //  Max未満であれば追加できる
        bool countResult = _balls.Count < MaxCount;
        return countResult;
    }
}
