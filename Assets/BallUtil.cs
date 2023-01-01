using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallUtil
{
    /// <summary>
    /// 反射ベクトルへの角度を求める
    /// </summary>
    /// <param name="inDir">入射ベクトル</param>
    /// <param name="targetNomal">反射する対象の法線ベクトル</param>
    /// <returns></returns>
    public static float RefrectAngle(Vector3 inDir,Vector3 targetNomal) {
        Vector3 reflectVec = Vector3.Reflect(inDir, targetNomal);

        float angle = Vector3.SignedAngle(inDir, reflectVec, Vector3.up);

        return angle;
    }
}
