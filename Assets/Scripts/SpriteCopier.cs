using UnityEngine;

public class SpriteCopier : MonoBehaviour
{
    public SpriteRenderer fromRenderer;
    public SpriteRenderer toRenderer;

    private void Start() {
        toRenderer.sprite = fromRenderer.sprite;
    }
}
