using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    public CanvasGroup cg;
    public AudioSource music;

    public float fadeLength;
    public float audioFadeLength;
    public VideoPlayer videoPlayer;
    public GameObject secondPanel;

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    public void FadeOutAudio()
    {
        music.DOFade(0f, audioFadeLength);
    }

    public void BeginVid()
    {
        music.DOFade(0f, audioFadeLength);

        cg.DOFade(1f, 1f).OnComplete(() => {
            secondPanel.SetActive(false);
            videoPlayer.Play();
            StartCoroutine(Timer());
            cg.DOFade(0f, 1f);
        });
    }

    private IEnumerator Timer() {
        yield return new WaitForSeconds(14);
        cg.DOFade(1f, fadeLength).OnComplete(() => {
            SceneManager.LoadScene("Saply");   
        });
    }
}
