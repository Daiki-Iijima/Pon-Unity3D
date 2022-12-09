using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDriver))]
public class WaitEffect : BaseCollisionEffect {
    private IDriver driver;

    [SerializeField] private float _waitTime;

    private void Awake() {
        driver = GetComponent<IDriver>();
    }

    protected override void CollisionEffect(Collision collision) {
        driver.EnableDrive(false);

        StartCoroutine(SetEnable(_waitTime));
    }

    private IEnumerator SetEnable(float waitSec) {
        yield return new WaitForSeconds(waitSec);

        driver.EnableDrive(true);
    }
}
