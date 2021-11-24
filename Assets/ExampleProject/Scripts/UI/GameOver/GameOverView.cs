using System;
using UnityEngine.UI;

namespace ExampleProject
{
    public class GameOverView : BaseView, IGameOverView
    {
        public event Action NextClicked = () => { };

        public Button NextButton;

        private void Awake()
        {
            NextButton.onClick.AddListener(OnNextClicked);
        }

        private void OnNextClicked()
        {
            NextClicked();
        }
    }
}