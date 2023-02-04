using UnityEngine;
using UnityEngine.Events;

public class TriggerBehaviour : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger;

    [SerializeField] private LayerMask collidableLayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        if (collidableLayers == (collidableLayers | (1 << layer)))
        {
            Debug.Log($"{gameObject} collider triggered.");
            onTrigger?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;
        if (collidableLayers == (collidableLayers | (1 << layer)))
        {
            Debug.Log($"{gameObject} collider triggered.");
            onTrigger?.Invoke();
        }
    }
}
