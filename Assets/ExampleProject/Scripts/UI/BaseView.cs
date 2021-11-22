using UnityEngine;

namespace ExampleProject
{
    public abstract class BaseView : MonoBehaviour, IView
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }
    }
}