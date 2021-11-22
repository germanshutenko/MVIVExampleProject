using UnityEngine;

namespace ExampleProject
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        public Transform MainCanvasContent;
        public Transform OverlayCanvasContent;

        public Transform MainCanvas
        {
            get
            {
                return MainCanvasContent;
            }
        }

        public Transform OverlayCanvas
        {
            get
            {
                return OverlayCanvasContent;
            }
        }
    }
}