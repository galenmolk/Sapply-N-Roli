using UnityEngine;

namespace GGJ 
{
    public class SaplyLimb : MonoBehaviour
    {
        [SerializeField] private ResourceRequest limbSectionPrefab;

        [SerializeField] private Direction direction;
        [SerializeField] private float sizeFactor;

        [SerializeField] private Sprite[] spriteOptions;

        private Transform currentLimbEnd;

        public bool hasRequest;

        public void Grow(RequestData request = null)
        {
            Vector2 position = GetNewPosition();
            ResourceRequest newSection = Instantiate(limbSectionPrefab, position, limbSectionPrefab.transform.rotation, transform);
            currentLimbEnd = newSection.transform;

            newSection.SetSprite(GetRandomSprite());

            if (request != null)
            {
                hasRequest = true;
                newSection.OnRequestSatisfied += HandleRequestSatisfied;
                newSection.ActivateRequest(request);
            }
        }

        private void HandleRequestSatisfied(ResourceRequest request)
        {
            hasRequest = false;
            request.OnRequestSatisfied -= HandleRequestSatisfied;
        }

        private Sprite GetRandomSprite()
        {
            return spriteOptions[Random.Range(0, spriteOptions.Length)];
        }

        private Vector2 GetNewPosition()
        {
            Vector2 end = currentLimbEnd.position;
            Vector2 direction = GetDirectionVector();
            return end + (direction * sizeFactor);
        }

        private Vector2 GetDirectionVector()
        {
            switch (direction)
            {
                case Direction.Up:
                    return Vector2.up;
                case Direction.Down:
                    return Vector2.down;
                case Direction.Left:
                    return Vector2.left;
                case Direction.Right:
                    return Vector2.right;
                default:
                    return Vector2.zero;
            }
        }

        private void Start() 
        {
            currentLimbEnd = transform;
        }
    }
}
