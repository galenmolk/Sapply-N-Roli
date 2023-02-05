using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleUp : MonoBehaviour
{
    public float scaleDuration;

    public void ScaleUpTo()
    {
        transform.DOScale(Vector3.one, scaleDuration);
    }

    public void ScaleDownTo()
    {
        transform.DOScale(Vector3.zero, scaleDuration);
    }
}
