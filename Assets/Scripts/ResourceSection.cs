using TMPro;
using UnityEngine;

public class ResourceSection : MonoBehaviour
{
    public int Max => max;
    public Resource.ResourceType Type => type;

    public int Count { get; private set; }

    [SerializeField] private TMP_Text countText;
    [SerializeField] private TMP_Text maxText;

    [SerializeField] private Resource.ResourceType type;
    [SerializeField] private int startingMax = 1;

    private int max;

    public void TryAdd(Resource resource)
    {
        if (Count < Max)
        {
            switch (resource.Type)
            {
                case Resource.ResourceType.Water:
                    SoundEffects.Instance.WaterPickedUp();
                    break;
                case Resource.ResourceType.Sunlight:
                    SoundEffects.Instance.SunPickedUp();
                    break;
            }

            SetCount(Count + 1);
            resource.Destroy();
        }
    }

    public bool TryConsume(int request)
    {
        if (request <= Count)
        {
            SetCount(Count - request);
            return true;
        }

        return false;
    }

    public void SetMax(int newMax)
    {
        max = newMax;
        maxText.text = max.ToString();
    }

    private void SetCount(int newCount)
    {
        Count = newCount;
        countText.text = Count.ToString();
    }

    private void Start()
    {
        SetMax(startingMax);
    }
}
