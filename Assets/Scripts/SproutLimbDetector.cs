using UnityEngine;

namespace GGJ{
    public class SproutLimbDetector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.CompareTag("Win"))
            {
                EndGame.Instance.EndTheGame();
            }
        }
    }
}
