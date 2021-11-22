using UnityEngine;

namespace ExampleProject
{
    public interface IUIRoot
    {
        Transform MainCanvas { get; }
        Transform OverlayCanvas { get; }
    }
}