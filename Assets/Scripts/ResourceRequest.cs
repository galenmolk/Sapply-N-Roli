using System.Collections;
using UnityEngine;
using System;

namespace GGJ
{
    public class ResourceRequest : MonoBehaviour
    {
        public Action<ResourceRequest> OnRequestSatisfied;

        public int Water;
        public int Sunlight;

        [SerializeField] private bool isEnabled;

        [SerializeField] private GameObject sunIcon;
        [SerializeField] private GameObject waterIcon;
        [SerializeField] private float requestDelay;
        [SerializeField] private GameObject bubbleCanvas;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private bool autoEnableRequest;
        [SerializeField] private Collider2D coll;

        private void Start()
        {
            if (autoEnableRequest)
            {
                StartCoroutine(EnableRequestAfterDelay());
            }
        }

        public void TryConsume()
        {
            if (!isEnabled)
            {
                return;
            }

            if (InventoryManager.Instance.TryProcessRequest(this))
            {
                OnRequestSatisfied?.Invoke(this);
                Saply.Instance.Progress();
                isEnabled = false;
                bubbleCanvas.SetActive(false);
            }
        }

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        public void ActivateRequest(RequestData request)
        {
            Water = request.Water;
            Sunlight = request.Sunlight;
            StartCoroutine(EnableRequestAfterDelay());
        }

        public void SatisfyWater()
        {
            Water = 0;
            waterIcon.SetActive(false);
        }

        public void SatisfySunlight()
        {
            Sunlight = 0;
            sunIcon.SetActive(false);
        }

        private IEnumerator EnableRequestAfterDelay()
        {
            yield return new WaitForSeconds(requestDelay);

            if (Water > 0)
            {
                waterIcon.SetActive(true);
            }

            if (Sunlight > 0)
            {
                sunIcon.SetActive(true);
            }

            bubbleCanvas.SetActive(true);
            isEnabled = true;
            SoundEffects.Instance.NewRequest();
        }
    }
}
