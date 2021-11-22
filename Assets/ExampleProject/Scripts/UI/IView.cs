using UnityEngine;

namespace ExampleProject
{
    public interface IView
    {
        void Show();
        void Hide();
        void SetParent(Transform parent);
    }
}