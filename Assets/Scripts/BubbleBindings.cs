using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class BubbleBindings : MonoBehaviour
{
    public GameObject water;
    public GameObject sunlight;
    public TMPro.TMP_Text waterText;
    public TMPro.TMP_Text sunlightText;
    public RectTransform rt;

    public UnityEvent TryConsume;

    public ScaleUp scale;

    public void Kill()
    {
        transform.DOScale(0f, scale.scaleDuration).OnComplete(() => {
            transform.DOKill();
            Destroy(gameObject);
        });
    }

    public void Consume()
    {
        TryConsume?.Invoke();
    }
}
