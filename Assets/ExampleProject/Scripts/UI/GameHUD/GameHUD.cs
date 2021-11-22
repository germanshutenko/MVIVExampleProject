using UnityEngine;

namespace ExampleProject
{
    public class GameHUD : MonoBehaviour, IScreen
    {
        private IGameHUDView View;

        private void Awake()
        {
            var viewFactory = CompositionRoot.GetViewFactory();
            View = viewFactory.CreateGameHUD();
        }

        public void Show()
        {
            View.Show();
        }

        public void Hide()
        {
            View.Hide();
        }
    }
}