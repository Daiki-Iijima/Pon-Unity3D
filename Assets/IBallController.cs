using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallController { 
    /// <summary>
    /// �����Ă��邩
    /// </summary>
    bool IsMove { get; }
    /// <summary>
    /// �X�s�[�h��ݒ肷��
    /// </summary>
    /// <param name="speed">�ݒ肷��X�s�[�h</param>
    void SetSpeed(float speed);

    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="flag"></param>
    void EnableMove(bool flag);

    void FixedTick(float deltaTime);
}
