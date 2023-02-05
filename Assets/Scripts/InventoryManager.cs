using BramblyMead;
using UnityEngine;

namespace GGJ
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        public ResourceSection waterSection;
        public ResourceSection sunlightSection;

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
