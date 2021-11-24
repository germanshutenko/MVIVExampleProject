using System;
using UnityEngine;

namespace ExampleProject
{
    public class SettingsMenu : MonoBehaviour, ISettingsMenu
    {
        public event Action BackClicked;

        private ISettingsMenuView View;

        private IGameSettings GameSettings;

        private void Awake()
        {
            GameSettings = CompositionRoot.GetGameSettings();
            var viewFactory = CompositionRoot.GetViewFactory();

            View = viewFactory.CreateSettingsMenu();

            View.BackClicked += OnBackClicked;
            View.MusicClicked += OnMusicClicked;
            View.SoundEffectsClicked += OnSoundEffectsClicked;
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

        private void OnMusicClicked()
        {
            var isMusicOn = !GameSettings.IsMusicOn;

            GameSettings.IsMusicOn = isMusicOn;
            View.SetMusicParameter(isMusicOn);
        }

        private void OnSoundEffectsClicked()
        {
            var isSoundEffectsOn = !GameSettings.IsSoundEffectsOn;

            GameSettings.IsSoundEffectsOn = isSoundEffectsOn;
            View.SetSoundEffectsParameter(isSoundEffectsOn);
        }

        private void OnBackClicked()
        {
            BackClicked();
        }
    }
}