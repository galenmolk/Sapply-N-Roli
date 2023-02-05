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

        public Vector2 bubbleOffset;


        [SerializeField] private bool isEnabled;

        [SerializeField] private float requestDelay;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private bool autoEnableRequest;
        [SerializeField] private Collider2D coll;

        public BubbleBindings bubble;

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
                bubble.TryConsume.RemoveListener(TryConsume);
                bubble.Kill();
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

            bubble = BubbleParent.Instance.MakeBubble(transform.position, bubbleOffset);
            bubble.TryConsume.AddListener(TryConsume);

            SetText();
            ToggleIcons();
            isEnabled = true;
            SoundEffects.Instance.NewRequest();
        }

        private void SetText()
        {
            bubble.waterText.text = Water.ToString();
            bubble.sunlightText.text = Sunlight.ToString();
        }

        private void ToggleIcons()
        {
            bubble.sunlight.SetActive(Sunlight > 0);
            bubble.water.SetActive(Water > 0);
        }
    }
}
