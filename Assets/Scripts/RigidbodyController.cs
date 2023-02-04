using UnityEngine;

namespace GGJ
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyController : MonoBehaviour
    {
        [SerializeField] private float velocityMultiplier;

        private Rigidbody2D rb;

        private Vector2 currentDirection;
        private Vector2 currentVelocity;

        public void Move(Direction direction)
        {
            MoveInDirection(direction);
        }

        public void Stop(Direction direction)
        {
            StopInDirection(direction);
        }

        private void Update()
        {
            currentVelocity = currentDirection.normalized * velocityMultiplier;
            rb.velocity = currentVelocity;
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void MoveInDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    currentDirection.y = 1f;
                    break;
                case Direction.Down:
                    currentDirection.y = -1f;
                    break;
                case Direction.Left:
                    currentDirection.x = -1f;
                    break;
                case Direction.Right:
                    currentDirection.x = 1f;
                    break;
            }
        }

        private void StopInDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    currentDirection.y = 0f;
                    break;
                case Direction.Down:
                    currentDirection.y = 0f;
                    break;
                case Direction.Left:
                    currentDirection.x = 0f;
                    break;
                case Direction.Right:
                    currentDirection.x = 0f;
                    break;
            }
        }
    }
}
