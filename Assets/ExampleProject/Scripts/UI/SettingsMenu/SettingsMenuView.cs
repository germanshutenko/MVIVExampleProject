using System;
using UnityEngine.UI;

namespace ExampleProject
{
    public class SettingsMenuView : BaseView, ISettingsMenuView
    {
        private const string OnText = "On";
        private const string OffText = "Off";
        private const string MusicParameterText = "Music";
        private const string SoundEffectsParameterText = "Sound Effects";

        public event Action MusicClicked = () => { };
        public event Action SoundEffectsClicked = () => { };
        public event Action BackClicked = () => { };

        public Button MusicButton;
        public Text MusicText;

        public Button SoundEffectsButton;
        public Text SoundEffectsText;

        public Button BackButton;

        private void Awake()
        {
            MusicButton.onClick.AddListener(OnMusicClicked);
            SoundEffectsButton.onClick.AddListener(OnSoundEffectsClicked);
            BackButton.onClick.AddListener(OnBackClicked);
        }

        private void OnMusicClicked()
        {
            MusicClicked();
        }

        private void OnSoundEffectsClicked()
        {
            SoundEffectsClicked();
        }

        private void OnBackClicked()
        {
            BackClicked();
        }

        public void SetMusicParameter(bool isOn)
        {
            var stateStr = isOn ? OnText : OffText;
            var text = string.Format("{0}: {1}", MusicParameterText, stateStr);

            MusicText.text = text;
        }

        public void SetSoundEffectsParameter(bool isOn)
        {
            var stateStr = isOn ? OnText : OffText;
            var text = string.Format("{0}: {1}", SoundEffectsParameterText, stateStr);

            SoundEffectsText.text = text;
        }
    }
}