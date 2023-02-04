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

        private Direction currentXDir;
        private Direction currentYDir;

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
                    currentYDir = Direction.Up;
                    currentDirection.y = 1f;
                    break;
                case Direction.Down:
                    currentYDir = Direction.Down;
                    currentDirection.y = -1f;
                    break;
                case Direction.Left:
                    currentXDir = Direction.Left;
                    currentDirection.x = -1f;
                    break;
                case Direction.Right:
                    currentXDir = Direction.Right;
                    currentDirection.x = 1f;
                    break;
            }
        }

        private void StopInDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (currentYDir == Direction.Up)
                    {
                        currentDirection.y = 0f;
                    }
                    break;
                case Direction.Down:
                    if (currentYDir == Direction.Down)
                    {
                        currentDirection.y = 0f;
                    }
                    break;
                case Direction.Left:
                    if (currentXDir == Direction.Left)
                    {
                        currentDirection.x = 0f;
                    }
                    break;
                case Direction.Right:
                    if (currentXDir == Direction.Right)
                    {
                        currentDirection.x = 0f;
                    }
                    break;
            }
        }
    }
}
