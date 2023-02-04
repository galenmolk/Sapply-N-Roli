using BramblyMead;
using UnityEngine;
using UnityEngine.Events;

public class Saply : Singleton<Saply>
{
    [SerializeField] private UnityEvent[] sequence;

    private int sequenceIndex;

    public void Progress()
    {
        if (sequenceIndex >= sequence.Length)
        {
            return;
        }

        Debug.Log("Progress!");
        UnityEvent e = sequence[sequenceIndex];
        e?.Invoke();
        sequenceIndex++;
    }
}
