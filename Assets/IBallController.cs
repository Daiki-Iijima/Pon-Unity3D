using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallController { 
    /// <summary>
    /// 動いているか
    /// </summary>
    bool IsMove { get; }
    /// <summary>
    /// スピードを設定する
    /// </summary>
    /// <param name="speed">設定するスピード</param>
    void SetSpeed(float speed);

    /// <summary>
    /// 動かすか
    /// </summary>
    /// <param name="flag"></param>
    void EnableMove(bool flag);

    void FixedTick(float deltaTime);
}
