using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleParent : BramblyMead.Singleton<BubbleParent>
{
    public BubbleBindings bubblePrefab;

    public RectTransform canvasRT;
    public  Camera cam;
    public BubbleBindings MakeBubble(Vector3 worldPos, Vector3 offset)
    {
        BubbleBindings bubble = Instantiate(bubblePrefab, worldPos + offset, Quaternion.identity, BubbleParent.Instance.transform);

        // Vector2 ViewportPosition = cam.WorldToViewportPoint(worldPos + offset);
        // Vector2 WorldObject_ScreenPosition = new Vector2(
        //     ((ViewportPosition.x * canvasRT.sizeDelta.x) - (canvasRT.sizeDelta.x * 0.5f)),
        //     ((ViewportPosition.y * canvasRT.sizeDelta.y) - (canvasRT.sizeDelta.y * 0.5f)));
 
        // bubble.rt.anchoredPosition = WorldObject_ScreenPosition;

        return bubble;
    }
}
