using UnityEngine;

public interface ITransform {
    Transform GetTransform();
    void SetRotate(Vector3 rot);
    void SetTransfrom(Vector3 pos);
}
