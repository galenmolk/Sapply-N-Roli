using UnityEngine;
using UnityEngine.Events;

public class OnStart : MonoBehaviour
{
    public UnityEvent onStart;

    private void Start() 
    {
        onStart?.Invoke();
    }
}
