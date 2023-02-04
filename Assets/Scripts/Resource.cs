using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public static Action<Resource> OnPickUp;

    public enum ResourceType
    {
        Water = 0,
        Sunlight = 1
    }

    public ResourceType Type => type;
    [SerializeField] private ResourceType type;

    public void PickUp()
    {
        OnPickUp?.Invoke(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
