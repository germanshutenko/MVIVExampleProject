using System;
using UnityEngine;

namespace ExampleProject
{
    public interface IUserInput
    {
        event Action<Vector2> DirectionChanged;

        bool IsLocked { get; set; }

    }
}