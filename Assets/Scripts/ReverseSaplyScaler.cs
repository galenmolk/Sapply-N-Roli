using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ;

public class ReverseSaplyScaler : MonoBehaviour
{
    private void Start() {
        Vector3 saplyScale = Saply.Instance.transform.localScale;

        Vector3 bigFactor = saplyScale - Vector3.one;

        transform.localScale -= bigFactor;
    }
}
