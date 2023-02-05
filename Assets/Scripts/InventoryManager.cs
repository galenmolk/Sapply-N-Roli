using BramblyMead;
using UnityEngine;
using System.Collections;

namespace GGJ
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        public ResourceSection waterSection;
        public ResourceSection sunlightSection;
        public CanvasGroup cg;

        public float loseResourceAnimDelay;

        public void DestroyResources()
        {
            bool willLoseAny = waterSection.Count > 0 || sunlightSection.Count > 0;

            waterSection.SetCount(0);
            sunlightSection.SetCount(0);

            if (willLoseAny)
            {
                StartCoroutine(LoseResouceAnim());
            }
        }

        private IEnumerator LoseResouceAnim()
        {
            cg.alpha = 0f;

            yield return new WaitForSeconds(0.1f);

            cg.alpha = 1f;

            yield return new WaitForSeconds(0.1f);

            cg.alpha = 0f;

            yield return new WaitForSeconds(0.1f);

            cg.alpha = 1f;

            yield return new WaitForSeconds(0.1f);

            cg.alpha = 0f;

            yield return new WaitForSeconds(0.1f);

            cg.alpha = 1f;

            yield return new WaitForSeconds(0.1f);

            cg.alpha = 0f;

            yield return new WaitForSeconds(0.1f);

            cg.alpha = 1f;
        }

        public void HandleResourcePickedUp(Resource resource)
        {
            TryPickUp(resource);
        }

        public bool TryProcessRequest(ResourceRequest request)
        {
            bool waterSuccess = false;
            bool sunlightSuccess = false;

            if (request.Water == 0)
            {
                waterSuccess = true;
            }
            else
            {
                if (waterSection.TryConsume(request.Water, out int consumed))
                {
                    SoundEffects.Instance.PartialDelivery();
                    waterSuccess = request.GiveWater(consumed);
                }
            }

            if (request.Sunlight == 0)
            {
                sunlightSuccess = true;
            }
            else
            {
                if (sunlightSection.TryConsume(request.Sunlight,  out int consumed))
                {
                    SoundEffects.Instance.PartialDelivery();
                    sunlightSuccess = request.GiveSunlight(consumed);;
                }
            }

            return waterSuccess && sunlightSuccess;
        }

        private void TryPickUp(Resource resource)
        {
            switch (resource.Type)
            {
                case Resource.ResourceType.Water:
                    waterSection.TryAdd(resource);
                    break;
                case Resource.ResourceType.Sunlight:
                    sunlightSection.TryAdd(resource);
                    break;
            }
        }

        private void Awake()
        {
            Resource.OnPickUp += HandleResourcePickedUp;
        }

        private void OnDestroy()
        {
            Resource.OnPickUp -= HandleResourcePickedUp;
        }
    }
}
