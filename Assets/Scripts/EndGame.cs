using BramblyMead;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using DG;
using System.Collections;
using UnityEngine.SceneManagement;

namespace GGJ
{
    public class EndGame : Singleton<EndGame>
    {
        public GameObject saplyFinal;
        public CinemachineVirtualCamera cam;
        public Transform MainCam;
        public CanvasGroup uiCanvasGroup;
        public CanvasGroup whiteOverlayGroup;
        public float uiFadeDuration;
        public int camSize;
        public float camTweenDuration;
        public float fadeToWhiteDelay;
        public float whiteFadeDuration;
        public Transform camTarget;
        public AudioSource music;

        [ContextMenu("End the GAME")]
        public void EndTheGame()
        {
            InputManager.Instance.DisableInput();

            uiCanvasGroup.DOFade(0f, uiFadeDuration);
            Destroy(cam);
            MainCam.transform.DOMove(new Vector3(camTarget.position.x, camTarget.position.y, MainCam.transform.position.z), camTweenDuration).
            OnComplete(() => {
                saplyFinal.SetActive(true);
                StartCoroutine(FadeToWhite());
            });
        }

        private IEnumerator FadeToWhite()
        {
            yield return new WaitForSeconds(fadeToWhiteDelay);
            music.DOFade(0f, whiteFadeDuration);
            whiteOverlayGroup.DOFade(1f, whiteFadeDuration).OnComplete(() => {
                SceneManager.LoadScene("Credits");
            });
        }
    }
}
