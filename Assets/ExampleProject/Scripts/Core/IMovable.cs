using System;
using UnityEngine;

namespace ExampleProject
{
    public interface IMovable
    {
        event Action<Vector3> Moved;

        Vector3 Position { get; }

        void Move(Vector3 direction);
        void SetPosition(Vector3 position);
    }
}