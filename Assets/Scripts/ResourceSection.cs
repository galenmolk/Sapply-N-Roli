using TMPro;
using UnityEngine;
using DG.Tweening;

namespace GGJ
{
    public class ResourceSection : MonoBehaviour
    {
        public int Max => max;
        public Resource.ResourceType Type => type;

        public int Count { get; private set; }

        public float tweenDuration = 0.5f;

        [SerializeField] private TMP_Text countText;
        [SerializeField] private TMP_Text maxText;

        [SerializeField] private Resource.ResourceType type;
        [SerializeField] private int startingMax = 1;

        public Vector2 Pos 
        {
            get => Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
        }

        private int max;

        public void TryAdd(Resource resource)
        {
            if (Count < Max)
            {
                switch (resource.Type)
                {
                    case Resource.ResourceType.Water:
                        SoundEffects.Instance.WaterPickedUp();
                        if (!Player.Instance.isBeingHit)
                        {
                            SetCount(Count + 1);
                        }
                        else
                        {
                            resource.Destroy();
                            return;
                        }

                        resource.transform.DOScale(0f, tweenDuration);
                        resource.transform.DOMove(Pos, tweenDuration).OnComplete(() => {
                            resource.Destroy();
                        });
                        break;
                    case Resource.ResourceType.Sunlight:
                        SoundEffects.Instance.SunPickedUp();
                        if (!Player.Instance.isBeingHit)
                        {
                            SetCount(Count + 1);
                        }
                        else
                        {
                            resource.Destroy();
                            return;
                        }

                        resource.transform.DOScale(0f, tweenDuration);
                        resource.transform.DOMove(Pos, tweenDuration).OnComplete(() => {
                            resource.Destroy();                    
                        });
                        break;
                }
            }
        }

        public bool TryConsume(int request, out int consumed)
        {
            consumed = 0;

            if (Count == 0)
            {
                return false;
            }

            int subtract = Count - request;

            if (subtract < 0)
            {
                consumed = Count;
            }
            else
            {
                consumed = request;
            }

            SetCount(Count - consumed);
            return true;
        }

        public void SetMax(int newMax)
        {
            max = newMax;
            maxText.text = max.ToString();
        }

        public void SetCount(int newCount)
        {
            Count = newCount;
            countText.text = Count.ToString();
        }

        private void Start()
        {
            SetMax(startingMax);
        }
    }

}
