using System;
using UnityEngine;

namespace ExampleProject
{
    public class GameOverScreen : MonoBehaviour, IGameOverScreen
    {
        public event Action NextClicked = () => { };

        private IGameOverView View;

        private void Awake()
        {
            var viewFactory = CompositionRoot.GetViewFactory();
            View = viewFactory.CreateGameOver();

            View.NextClicked += OnNextClicked;
        }

        private void OnNextClicked()
        {
            NextClicked();
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