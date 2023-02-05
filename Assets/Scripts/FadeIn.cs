using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float duration;

    private void Awake() {
        canvasGroup.alpha = 1f;
    }

    private void Start() {
        canvasGroup.DOFade(0f, duration);
    }
}
