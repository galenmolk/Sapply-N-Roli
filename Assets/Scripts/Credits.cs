using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

public class Credits : MonoBehaviour
{
    public VideoPlayer vp;
    public CanvasGroup cg;
    public AudioSource music;

    private void Update() {
        if (vp.time > 21)
        {
            cg.DOFade(1f, 2f);
            music.DOFade(0f, 2f);
        }
    }
}
