using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BubbleBindings : MonoBehaviour
{
    public GameObject water;
    public GameObject sunlight;
    public TMPro.TMP_Text waterText;
    public TMPro.TMP_Text sunlightText;
    public RectTransform rt;

    public UnityEvent TryConsume;

    public void Consume()
    {
        TryConsume?.Invoke();
    }
}
