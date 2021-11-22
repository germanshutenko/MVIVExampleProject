using UnityEngine;

namespace ExampleProject
{
    public class MainMenu : MonoBehaviour, IMainMenu
    {
        private IMainMenuView View;

        private void Awake()
        {
            var viewFactory = CompositionRoot.GetViewFactory();
            View = viewFactory.CreateMainMenu();
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