using System.Collections;
using UnityEngine;

public class CoroutineProvider : MonoBehaviour {
    public void CallStartCoroutine(IEnumerator iEnumerator) {
        StartCoroutine(iEnumerator);
    }
}
