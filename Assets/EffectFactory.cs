using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectFactory {
    public static WaitEffect CreateWait(GameObject targetGameObject, IBallController ballController, float waitTime) {
        //  �K�{�R���|�[�l���g�����Ă��邩�`�F�b�N
        CoroutineProvider coroutineProvider = targetGameObject.GetComponent<CoroutineProvider>();
        //  �K�{�R���|�[�l���g���Ȃ��ꍇ�́A����
        if (coroutineProvider == null) {
            coroutineProvider = targetGameObject.AddComponent<CoroutineProvider>();
        }

        //  �K�{�R���|�[�l���g�����Ă��邩�`�F�b�N
        CollisionProvider collisionProvider = targetGameObject.GetComponent<CollisionProvider>();
        //  �K�{�R���|�[�l���g���Ȃ��ꍇ�́A����
        if (collisionProvider == null) {
            collisionProvider = targetGameObject.AddComponent<CollisionProvider>();
        }

        return new WaitEffect(ballController, coroutineProvider, waitTime, collisionProvider);
    }

    public static ReflectEffect CreateReflect(GameObject targetGameObject, ITransformUpdatable transformUpdatable) {

        //  �K�{�R���|�[�l���g�����Ă��邩�`�F�b�N
        CollisionProvider collisionProvider = targetGameObject.GetComponent<CollisionProvider>();
        //  �K�{�R���|�[�l���g���Ȃ��ꍇ�́A����
        if (collisionProvider == null) {
            collisionProvider = targetGameObject.AddComponent<CollisionProvider>();
        }

        return new ReflectEffect(collisionProvider, transformUpdatable);
    }
}
