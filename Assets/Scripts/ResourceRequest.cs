using System.Collections;
using UnityEngine;

public class ResourceRequest : MonoBehaviour
{
    public int Water;
    public int Sunlight;

    [SerializeField] private bool isEnabled;

    [SerializeField] private GameObject sunIcon;
    [SerializeField] private GameObject waterIcon;

    [SerializeField] private float requestDelay;

    [SerializeField] private GameObject bubbleCanvas;

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

        StartCoroutine(EnableBubbleAfterDelay());
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

    private IEnumerator EnableBubbleAfterDelay()
    {
        yield return new WaitForSeconds(requestDelay);
        bubbleCanvas.SetActive(true);
    }
}