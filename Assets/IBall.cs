using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBall {
    int GetBoundCount();
    void SetEnable(bool flag);
    void Delete();
}
