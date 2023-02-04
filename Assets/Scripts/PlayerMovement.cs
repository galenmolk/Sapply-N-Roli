using UnityEngine;

namespace GGJ
{
    public class PlayerMovement : MonoBehaviour
    {
        private RigidbodyController rbController;

        private void Start()
        {
            InputManager.OnUpStart += MoveUp;
            InputManager.OnDownStart += MoveDown;
            InputManager.OnLeftStart += MoveLeft;
            InputManager.OnRightStart += MoveRight;

            InputManager.OnUpStop += StopMoveUp;
            InputManager.OnDownStop += StopMoveDown;
            InputManager.OnLeftStop += StopMoveLeft;
            InputManager.OnRightStop += StopMoveRight;

            rbController = GetComponent<RigidbodyController>();
        }

        private void OnDestroy()
        {
            InputManager.OnUpStart -= MoveUp;
            InputManager.OnDownStart -= MoveDown;
            InputManager.OnLeftStart -= MoveLeft;
            InputManager.OnRightStart -= MoveRight;

            InputManager.OnUpStop -= StopMoveUp;
            InputManager.OnDownStop -= StopMoveDown;
            InputManager.OnLeftStop -= StopMoveLeft;
            InputManager.OnRightStop -= StopMoveRight;
        }

        private void MoveUp()
        {
            rbController.Move(Direction.Up);
        }

        private void MoveDown()
        {
            rbController.Move(Direction.Down);
        }

        private void MoveLeft()
        {
            rbController.Move(Direction.Left);
        }

        private void MoveRight()
        {
            rbController.Move(Direction.Right);
        }

        private void StopMoveUp()
        {
            rbController.Stop(Direction.Up);
        }

        private void StopMoveDown()
        {
            rbController.Stop(Direction.Down);
        }

        private void StopMoveLeft()
        {
            rbController.Stop(Direction.Left);
        }

        private void StopMoveRight()
        {
            rbController.Stop(Direction.Right);
        }
    }
}
