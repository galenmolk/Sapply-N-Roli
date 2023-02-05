using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    public CanvasGroup cg;
    public AudioSource music;

    public float fadeLength;
    public float audioFadeLength;

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    public void FadeOutAudio()
    {
        music.DOFade(0f, audioFadeLength);
    }

    private IEnumerator Timer() {
        yield return new WaitForSeconds(14);
            cg.DOFade(1f, fadeLength).OnComplete(() => {
            SceneManager.LoadScene("Saply");   
        });
    }
}
