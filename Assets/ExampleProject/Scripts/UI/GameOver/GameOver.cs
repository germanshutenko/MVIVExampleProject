using System;
using UnityEngine;

namespace ExampleProject
{
    public class GameOver : MonoBehaviour, IGameOver
    {
        public event Action NextClicked = () => { };

        private IGameOverView View;

        private void Awake()
        {
            var viewFactory = CompositionRoot.GetViewFactory();

            View = viewFactory.CreateGameOver();

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