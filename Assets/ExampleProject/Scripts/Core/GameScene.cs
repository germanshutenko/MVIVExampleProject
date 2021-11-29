using UnityEngine;

namespace ExampleProject
{
    public class GameScene : MonoBehaviour
    {
        private IPlayer Player;
        private IUserInput UserInput;
        private IGameCamera GameCamera;
        private IConfiguration Configuration;

        private IGameHUD GameHUD;
        private ISceneManager SceneManager;
        private ISettingsMenu SettingsMenu;
        private IGameOverScreen GameOverScreen;

        private void Awake()
        {
            Player = CompositionRoot.GetPlayer();
            UserInput = CompositionRoot.GetUserInput();
            GameCamera = CompositionRoot.GetGameCamera();
            SceneManager = CompositionRoot.GetSceneManager();
            Configuration = CompositionRoot.GetConfiguration();

            GameHUD = CompositionRoot.GetGameHUD();
            SettingsMenu = CompositionRoot.GetSettingsMenu();
            GameOverScreen = CompositionRoot.GetGameOverScreen();

            var eventSystem = CompositionRoot.GetEventSystem();
            var gameSettings = CompositionRoot.GetGameSettings();
            var audioManager = CompositionRoot.GetAudioManager();

            GameCamera.SetTarget(Player);

            GameHUD.Show();
            SettingsMenu.Hide();
            GameOverScreen.Hide();

            var isMusicOn = gameSettings.IsMusicOn;
            var isSoundEffectsOn = gameSettings.IsSoundEffectsOn;

            audioManager.SetMusicActive(isMusicOn);
            audioManager.SetEffectsActive(isSoundEffectsOn);

            audioManager.PlayMusic(EAudio.MainTheme);

            UserInput.DirectionChanged += OnDirectionChanged;
            UserInput.Escaped += OpenSettings;

            Player.Died += OnPlayerDied;
            Player.HealthChanged += OnlayerHealthChanged;
            Player.MaxHealthChanged += OnPlayerMaxHealthChanged;

            SettingsMenu.Closing += CloseSettings;
            GameOverScreen.NextClicked += ExitGame;
        }

        private void OpenSettings()
        {
            GameHUD.Hide();
            SettingsMenu.Show();
        }

        private void CloseSettings()
        {
            SettingsMenu.Hide();
            GameHUD.Show();
        }

        private void ExitGame()
        {
            GameOverScreen.Hide();
            SceneManager.LoadScene(EScenes.FirstScene);
        }

        private void OnPlayerDied()
        {
            GameHUD.Hide();
            GameOverScreen.Show();
        }

        private void OnPlayerMaxHealthChanged(float maxHealth)
        {
            var normalizedHealth = Player.Health / maxHealth;
            GameHUD.SetHealth(normalizedHealth);
        }

        private void OnlayerHealthChanged(float health)
        {
            var normalizedHealth = health / Player.MaxHealth;
            GameHUD.SetHealth(normalizedHealth);
        }

        private void OnDirectionChanged(Vector2 direction)
        {
            var properties = Configuration.GetPlayerProperties();
            var playerForce = properties.MovingForce;
            var worldDirection = new Vector3(direction.x, 0f, direction.y);
            var force = worldDirection * playerForce;

            Player.Move(force);
        }
    }
}