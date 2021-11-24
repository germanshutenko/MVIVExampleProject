using UnityEngine;

namespace ExampleProject
{
    public class FirstScene : MonoBehaviour
    {
        private IMainMenu MainMenu;

        private void Awake()
        {
            MainMenu = CompositionRoot.GetMainMenu();
            var eventSystem = CompositionRoot.GetEventSystem();
            var audioManager = CompositionRoot.GetAudioManager();
            var gameSettings = CompositionRoot.GetGameSettings();

            var isMusicOn = gameSettings.IsMusicOn;
            var isSoundEffectsOn = gameSettings.IsSoundEffectsOn;

            audioManager.SetMusicActive(isMusicOn);
            audioManager.SetEffectsActive(isSoundEffectsOn);
        }

        private void Start()
        {
            MainMenu.Show();
        }
    }
}