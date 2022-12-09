using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDriver {
    bool IsDrive { get; }
    /// <summary>
    /// スピードを設定する
    /// </summary>
    /// <param name="speed">設定するスピード</param>
    void SetSpeed(float speed);

    /// <summary>
    /// 動かすか
    /// </summary>
    /// <param name="flag"></param>
    void EnableDrive(bool flag);
}
