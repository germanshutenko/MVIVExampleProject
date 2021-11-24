using UnityEngine;

namespace ExampleProject
{
    public class GameHUD : MonoBehaviour, IGameHUD
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

        public void SetHP(float value)
        {
            View.SetHP(value);
        }

        public void SetMana(float value)
        {
            View.SetMana(value);
        }

        public void SetTime(int value)
        {
            View.SetTime(value);
        }
    }
}