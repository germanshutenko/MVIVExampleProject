using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExampleProject
{
    public class MainMenu : MonoBehaviour, IMainMenu
    {
        private IMainMenuView View;

        private ISettingsMenu SettingsMenu;

        private void Awake()
        {
            SettingsMenu = CompositionRoot.GetSettingsMenu();
            var viewFactory = CompositionRoot.GetViewFactory();

            View = viewFactory.CreateMainMenu();
            View.SettingsClicked += OnSettingsClicked;
            View.NewGameClicked += OnNewGameClicked;
            View.ExitClicked += OnExitClicked;

            SettingsMenu.BackClicked += OnSettingsMenuClosing;
        }

        public void Show()
        {
            View.Show();
        }

        public void Hide()
        {
            View.Hide();
        }

        private void OnSettingsClicked()
        {
            Hide();
            SettingsMenu.Show();
        }

        private void OnSettingsMenuClosing()
        {
            SettingsMenu.Hide();
            Show();
        }

        private void OnNewGameClicked()
        {
            SceneManager.LoadScene(EScenes.GameScene.ToString());
        }

        private void OnExitClicked()
        {
            Application.Quit();
        }
    }
}