using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectFactory {
    public static WaitEffect CreateWait(GameObject targetGameObject, IBallController ballController, float waitTime) {
        //  必須コンポーネントがついているかチェック
        CoroutineProvider coroutineProvider = targetGameObject.GetComponent<CoroutineProvider>();
        //  必須コンポーネントがない場合は、つける
        if (coroutineProvider == null) {
            coroutineProvider = targetGameObject.AddComponent<CoroutineProvider>();
        }

        //  必須コンポーネントがついているかチェック
        CollisionProvider collisionProvider = targetGameObject.GetComponent<CollisionProvider>();
        //  必須コンポーネントがない場合は、つける
        if (collisionProvider == null) {
            collisionProvider = targetGameObject.AddComponent<CollisionProvider>();
        }

        return new WaitEffect(ballController, coroutineProvider, waitTime, collisionProvider);
    }

    public static ReflectEffect CreateReflect(GameObject targetGameObject, ITransformUpdatable transformUpdatable) {

        //  必須コンポーネントがついているかチェック
        CollisionProvider collisionProvider = targetGameObject.GetComponent<CollisionProvider>();
        //  必須コンポーネントがない場合は、つける
        if (collisionProvider == null) {
            collisionProvider = targetGameObject.AddComponent<CollisionProvider>();
        }

        return new ReflectEffect(collisionProvider, transformUpdatable);
    }
}
