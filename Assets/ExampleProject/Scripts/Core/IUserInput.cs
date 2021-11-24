using System;
using UnityEngine;

namespace ExampleProject
{
    public interface IUserInput
    {
        event Action<Vector2> DirectionChanged;
        event Action Escaped;

        bool IsLocked { get; set; }
    }
}