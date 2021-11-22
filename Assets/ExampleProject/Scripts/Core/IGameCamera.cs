using UnityEngine;

namespace ExampleProject
{
    public interface IGameCamera
    {
        void SetTarget(IMovable target);
    }
}