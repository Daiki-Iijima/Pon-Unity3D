using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransformChangeable{
    /// <summary>
    /// Y²‰ñ“]•ÏX
    /// </summary>
    /// <param name="rot"></param>
    void SetYRotate(float yRot);
    /// <summary>
    /// ‰ñ“]•ÏX
    /// </summary>
    /// <param name="rot"></param>
    void SetRotate(Vector3 rot);

    /// <summary>
    /// Y²‰ñ“]‰ÁZ
    /// </summary>
    /// <param name="rot"></param>
    void AddYRotate(float addYRot);
    /// <summary>
    /// ˆÊ’u•ÏX
    /// </summary>
    /// <param name="pos"></param>
    void SetPosition(Vector3 pos);
}
