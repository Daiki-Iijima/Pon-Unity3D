using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDriver {
    bool IsDrive { get; }
    /// <summary>
    /// �X�s�[�h��ݒ肷��
    /// </summary>
    /// <param name="speed">�ݒ肷��X�s�[�h</param>
    void SetSpeed(float speed);

    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="flag"></param>
    void EnableDrive(bool flag);
}
