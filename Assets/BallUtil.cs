using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallUtil
{
    /// <summary>
    /// ���˃x�N�g���ւ̊p�x�����߂�
    /// </summary>
    /// <param name="inDir">���˃x�N�g��</param>
    /// <param name="targetNomal">���˂���Ώۂ̖@���x�N�g��</param>
    /// <returns></returns>
    public static float RefrectAngle(Vector3 inDir,Vector3 targetNomal) {
        Vector3 reflectVec = Vector3.Reflect(inDir, targetNomal);

        float angle = Vector3.SignedAngle(inDir, reflectVec, Vector3.up);

        return angle;
    }
}
