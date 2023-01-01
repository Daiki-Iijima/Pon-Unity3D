using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionProvider : MonoBehaviour
{
    public Action<Collision> CollisionEnterAction;

    private void OnCollisionEnter(Collision collision) {
        CollisionEnterAction?.Invoke(collision);
    }
}
