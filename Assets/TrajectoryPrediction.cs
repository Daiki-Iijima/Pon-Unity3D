using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 軌道を予測する
/// </summary>
public class TrajectoryPrediction:MonoBehaviour{

    [SerializeField] private GameObject prefab;
    private int _hitCount = 0;

    private List<GameObject> pointList = new List<GameObject>();
    public Dictionary<Vector3, Vector3> NextPosDirPairs = new Dictionary<Vector3, Vector3>();

    public  int _maxCount = 5;

    private void Start() {
        //  前進方向に進むと仮定して、前進方向で予測する
        Vector3 fDir = this.transform.forward;
        Vector3 pos = this.transform.position;
        float angle = this.transform.eulerAngles.y;

        //  3手先までよむ

        for (int i = 0; i < 1; i++) {
            (Vector3 rPos, Vector3 rDir,float rAngle) result = GetNextHitPosAndDir(pos, fDir,angle);
            pos = result.rPos;
            fDir = result.rDir;
            angle = result.rAngle;
            pointList.Add(Instantiate(prefab, pos, Quaternion.identity));

        }
    }

    private (Vector3 resultPos,Vector3 resultDir,float angle) GetNextHitPosAndDir(Vector3 pos,Vector3 dir,float angle,Collision collision = null) {

        if(collision != null) {
            float refAngle = BallUtil.RefrectAngle(dir, collision.contacts[0].normal);
            float sumAngle = angle + refAngle;
            GameObject o = new GameObject();
            o.transform.eulerAngles = new Vector3(0, sumAngle, 0);
            dir = o.transform.forward;
            Destroy(o);
        }

        //  壁にあたるまでレイを飛ばす
        RaycastHit hit;
        if (Physics.SphereCast(pos, 0.5f, dir, out hit, 100.0f)) {
            float refAngle = BallUtil.RefrectAngle(dir, hit.normal);
            float sumAngle = angle + refAngle;
            GameObject o = new GameObject();
            o.transform.eulerAngles = new Vector3(0, sumAngle, 0);
            Vector3 nextDir = o.transform.forward;
            Destroy(o);
            return (hit.point, nextDir,sumAngle);
        }
        return (Vector3.zero, Vector3.zero,0);
    }

    /// <summary>
    /// 反射した後の方向ベクトルと角度を求める
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="nomal"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    private (Vector3 reflectDir,float sumAngle) CalcRefrectDir(Vector3 dir,Vector3 nomal,float angle){
        //  反射ベクトルを求める
        float refAngle = BallUtil.RefrectAngle(dir, nomal);
        float sumAngle = angle + refAngle;

        GameObject o = new GameObject();
        o.transform.eulerAngles = new Vector3(0, sumAngle, 0);
        Vector3 refDir = o.transform.forward;
        Destroy(o);

        return (refDir, sumAngle);
    }

    private (Vector3 resultPos,Vector3 resultDir,Vector3 hitNomal,float sumAngle) CalcHitNextPoint(Vector3 latestPos,Vector3 dir,Vector3 hitNomal,float angle) {

        (Vector3 reflectDir, float sumAngle) result = CalcRefrectDir(dir, hitNomal, angle);

        RaycastHit hit;
        if (Physics.SphereCast(latestPos, 0.5f, result.reflectDir, out hit, 100.0f)) {
            Vector3 hitPoint = hit.point;
            Vector3 refDir = result.reflectDir;
            Vector3 nomal = hit.normal;
            float sumAngle = result.sumAngle;

            return (hitPoint, refDir, nomal, sumAngle);
        }

        return (Vector3.zero, Vector3.zero, Vector3.zero, result.sumAngle);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Paddle") {
            foreach (var obj in pointList) {
                Destroy(obj);
            }

            NextPosDirPairs.Clear();

            pointList.Clear();

            //  前進方向に進むと仮定して、前進方向で予測する
            Vector3 fDir = this.transform.forward;
            Vector3 pos = this.transform.position;
            Vector3 hitNomal = collision.contacts[0].normal;
            float angle = this.transform.eulerAngles.y;

            //  3手先までよむ

            for (int i = 0; i < _maxCount; i++) {
                (Vector3 rPos, Vector3 rDir, Vector3 nomal, float rAngle) result = CalcHitNextPoint(pos, fDir, hitNomal, angle);
                pos = result.rPos;
                fDir = result.rDir; //  posに向かうベクトル
                angle = result.rAngle;
                hitNomal = result.nomal;
                //pointList.Add(Instantiate(prefab, pos, Quaternion.identity));
                NextPosDirPairs.Add(pos, fDir);
            }
        }
    }
}
