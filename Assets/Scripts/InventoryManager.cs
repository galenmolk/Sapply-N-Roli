using BramblyMead;
using UnityEngine;

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
        return waterSection.TryConsume(request.Water) &&
               sunlightSection.TryConsume(request.Sunlight);
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
