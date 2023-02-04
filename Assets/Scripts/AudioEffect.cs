using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void Play()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        audioSource.Play();
    }
}
