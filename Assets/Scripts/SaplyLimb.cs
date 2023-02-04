using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ 
{
    public class SaplyLimb : MonoBehaviour
    {
        [SerializeField] private ResourceRequest limbSectionPrefab;

        [SerializeField] private Direction direction;

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
    }
}
