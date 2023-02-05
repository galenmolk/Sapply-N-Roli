using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    public CanvasGroup cg;

    public float fadeLength;

    private IEnumerator Start() {
        yield return new WaitForSeconds(14);
        cg.DOFade(1f, fadeLength).OnComplete(() => {
        SceneManager.LoadScene("Saply");   
        });

    }
}
