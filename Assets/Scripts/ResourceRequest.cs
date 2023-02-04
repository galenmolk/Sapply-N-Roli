using UnityEngine;

public class ResourceRequest : MonoBehaviour
{
    public int Water;
    public int Sunlight;

    [SerializeField] private bool isEnabled;

    [SerializeField] private GameObject sunIcon;
    [SerializeField] private GameObject waterIcon;

    private void Start()
    {
        if (Water > 0)
        {
            waterIcon.SetActive(true);
        }

        if (Sunlight > 0)
        {
            sunIcon.SetActive(true);
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
            Saply.Instance.Progress();
            gameObject.SetActive(false);
        }
    }
}
