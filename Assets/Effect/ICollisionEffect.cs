using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionEffect : IEffect {
    /// <summary>
    /// 当たり判定の対象にするオブジェクトのタグの番号を設定
    /// </summary>
    /// <param name="no"></param>
    void SetHitTargetTag(List<string> noList);
}
