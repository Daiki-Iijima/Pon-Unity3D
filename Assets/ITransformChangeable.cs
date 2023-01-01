using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransformChangeable{
    /// <summary>
    /// Y����]�ύX
    /// </summary>
    /// <param name="rot"></param>
    void SetYRotate(float yRot);
    /// <summary>
    /// ��]�ύX
    /// </summary>
    /// <param name="rot"></param>
    void SetRotate(Vector3 rot);

    /// <summary>
    /// Y����]���Z
    /// </summary>
    /// <param name="rot"></param>
    void AddYRotate(float addYRot);
    /// <summary>
    /// �ʒu�ύX
    /// </summary>
    /// <param name="pos"></param>
    void SetPosition(Vector3 pos);
}
