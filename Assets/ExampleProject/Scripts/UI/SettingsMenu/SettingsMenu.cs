using UnityEngine;

namespace ExampleProject
{
    public class SettingsMenu : MonoBehaviour, ISettingsMenu
    {
        private ISettingsMenuView View;
        private IGameSettings GameSettings;

        private void Awake()
        {
            GameSettings = CompositionRoot.GetGameSettings();
            var viewFactory = CompositionRoot.GetViewFactory();

            View = viewFactory.CreateSettingsMenu();
        }

        public void Show()
        {
            var isMusicOn = GameSettings.IsMusicOn;
            var isSoundEffectsOn = GameSettings.IsSoundEffectsOn;

            View.SetMusicParameter(isMusicOn);
            View.SetSoundEffectsParameter(isSoundEffectsOn);

            View.Show();
        }

        public void Hide()
        {
            View.Hide();
        }
    }
}