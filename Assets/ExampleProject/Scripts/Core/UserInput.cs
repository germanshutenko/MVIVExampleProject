using System;
using UnityEngine;

namespace ExampleProject
{
    public class UserInput : MonoBehaviour, IUserInput
    {
        public event Action<Vector2> DirectionChanged = direction => { };
        public event Action Escaped = () => { };

        public bool IsLocked { get; set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Escaped();
            }
        }

        private void FixedUpdate()
        {
            if (IsLocked == true)
            {
                return;
            }

            var direction = Vector2.zero;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction += Vector2.left;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction += Vector2.right;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction += Vector2.up;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                direction += Vector2.down;
            }

            var normalizedDirection = direction.normalized;

            DirectionChanged(normalizedDirection);
        }
    }
}