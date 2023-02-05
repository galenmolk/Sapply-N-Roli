using System.Collections;
using UnityEngine;
using System;
using TMPro;

namespace GGJ
{
    public class ResourceRequest : MonoBehaviour
    {
        public Action<ResourceRequest> OnRequestSatisfied;

        public int Water;
        public int Sunlight;

        public TMP_Text waterText;
        public TMP_Text sunText;

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

        public bool GiveWater(int amount)
        {
            Water -= amount;
            SetText();
            ToggleIcons();
            return Water == 0;
        }

        public bool GiveSunlight(int amount)
        {
            Sunlight -= amount;
            SetText();
            ToggleIcons();
            return Sunlight == 0;
        }

        private IEnumerator EnableRequestAfterDelay()
        {
            yield return new WaitForSeconds(requestDelay);

            SetText();
            ToggleIcons();
            bubbleCanvas.SetActive(true);
            isEnabled = true;
            SoundEffects.Instance.NewRequest();
        }

        private void SetText()
        {
            waterText.text = Water.ToString();
            sunText.text = Sunlight.ToString();
        }

        private void ToggleIcons()
        {
            sunIcon.SetActive(Sunlight > 0);
            waterIcon.SetActive(Water > 0);
        }
    }
}
