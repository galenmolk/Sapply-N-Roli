using BramblyMead;
using UnityEngine;

namespace GGJ
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [SerializeField] private ResourceSection waterSection;
        [SerializeField] private ResourceSection sunlightSection;

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
                    waterSuccess = true;
                    request.GiveWater(consumed);
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
                    sunlightSuccess = true;
                    request.GiveSunlight(consumed);
                }
            }

            if (waterSuccess != sunlightSuccess)
            {
                SoundEffects.Instance.PartialDelivery();
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
