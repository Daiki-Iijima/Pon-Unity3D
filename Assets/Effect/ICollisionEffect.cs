using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionEffect : IEffect {
    /// <summary>
    /// �����蔻��̑Ώۂɂ���I�u�W�F�N�g�̃^�O�̔ԍ���ݒ�
    /// </summary>
    /// <param name="no"></param>
    void SetHitTargetTag(List<string> noList);
}
