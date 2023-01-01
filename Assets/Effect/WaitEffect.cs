using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitEffect : BaseCollisionEffect {
    private IBallController _controller;
    private CoroutineProvider _coroutineProvider;

    private float _waitTime;

    public WaitEffect(IBallController ballController,CoroutineProvider coroutineProvider,float waitTime,CollisionProvider provider) : base(provider) {
        _controller = ballController;
        _coroutineProvider = coroutineProvider;
        _waitTime = waitTime;
    }

    protected override void CollisionEffect(Collision collision) {
        _controller.EnableMove(false);

        _coroutineProvider.CallStartCoroutine(SetEnable(_waitTime));
    }

    private IEnumerator SetEnable(float waitSec) {
        yield return new WaitForSeconds(waitSec);

        _controller.EnableMove(true);
    }
}
