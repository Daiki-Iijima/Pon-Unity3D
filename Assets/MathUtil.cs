using UnityEngine;

public static class MathUtil {
    /// <summary>
    /// 2ŸŒ³‹óŠÔ‚Ìü•ª‚ÌŒğ“_‚ğ‹‚ß‚é
    /// </summary>
    /// <param name="origin1"></param>
    /// <param name="direction1"></param>
    /// <param name="origin2"></param>
    /// <param name="direction2"></param>
    /// <returns></returns>
    public static Vector2 LineIntersect(Vector2 origin1, Vector2 direction1, Vector2 origin2, Vector2 direction2) {
        Vector2 intersect = Vector2.zero;

        Vector2 slopeV1 = origin1 - direction1;
        float slopeF1 = slopeV1.y / slopeV1.x;

        Vector2 slopeV2 = origin2 - direction2;
        float slopeF2 = slopeV2.y / slopeV2.x;

        intersect.x = (slopeF1 * origin1.x - slopeF2 * origin2.x + origin2.y - origin1.y) / (slopeF1 - slopeF2);
        intersect.y = slopeF1 * (intersect.x - origin1.x) + origin1.y;

        return intersect;
    }
}
