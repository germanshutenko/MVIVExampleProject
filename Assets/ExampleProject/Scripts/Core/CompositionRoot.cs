using UnityEngine;
using UnityEngine.EventSystems;

namespace ExampleProject
{
    public class CompositionRoot : MonoBehaviour
    {
        private static IUIRoot UIRoot;
        private static IPlayer Player;
        private static IUserInput UserInput;
        private static IGameCamera GameCamera;
        private static EventSystem EventSystem;
        private static IViewFactory ViewFactory;
        private static IGameSettings GameSettings;
        private static ISceneManager SceneManager;
        private static IAudioManager AudioManager;
        private static IConfiguration Configuration;
        private static IResourceManager ResourceManager;

        private static IGameHUD GameHUD;
        private static IGameOverScreen GameOverScreen;
        private static IMainMenu MainMenu;
        private static ISettingsMenu SettingsMenu;

        private void OnDestroy()
        {
            UIRoot = null;
            Player = null;
            UserInput = null;
            GameCamera = null;
            EventSystem = null;
            ViewFactory = null;
            AudioManager = null;

            GameHUD = null;
            GameOverScreen = null;
            MainMenu = null;
            SettingsMenu = null;
        }

        public static IResourceManager GetResourceManager()
        {
            if (ResourceManager == null)
            {
                ResourceManager = new ResourceManager();
            }

            return ResourceManager;
        }

        public static IConfiguration GetConfiguration()
        {
            if (Configuration == null)
            {
                Configuration = new Configuration();
            }

            return Configuration;
        }

        public static ISceneManager GetSceneManager()
        {
            if (SceneManager == null)
            {
                SceneManager = new SceneManager();
            }

            return SceneManager;
        }

        public static EventSystem GetEventSystem()
        {
            if (EventSystem == null)
            {
                var resourceManager = GetResourceManager();
                EventSystem = resourceManager.CreatePrefabInstance<EventSystem, EComponents>(EComponents.EventSystem);
            }

            return EventSystem;
        }

        public static IPlayer GetPlayer()
        {
            if (Player == null)
            {
                var resourceManager = GetResourceManager();

                Player = resourceManager.CreatePrefabInstance<IPlayer, EComponents>(EComponents.Player);
            }

            return Player;
        }

        public static IUserInput GetUserInput()
        {
            if (UserInput == null)
            {
                UserInput = MonoExtensions.CreateComponent<UserInput>();
            }

            return UserInput;
        }

        public static IGameCamera GetGameCamera()
        {
            if (GameCamera == null)
            {
                var resourceManager = GetResourceManager();

                GameCamera = resourceManager.CreatePrefabInstance<IGameCamera, EComponents>(EComponents.GameCamera);
            }

            return GameCamera;
        }

        public static IViewFactory GetViewFactory()
        {
            if (ViewFactory == null)
            {
                var uiRoot = GetUIRoot();
                var sceneManager = GetSceneManager();
                var resourceManager = GetResourceManager();

                ViewFactory = new ViewFactory(uiRoot, resourceManager, sceneManager);
            }

            return ViewFactory;
        }

        public static IGameSettings GetGameSettings()
        {
            if (GameSettings == null)
            {
                GameSettings = new GameSettings();
            }

            return GameSettings;
        }

        public static IAudioManager GetAudioManager()
        {
            if (AudioManager == null)
            {
                AudioManager = MonoExtensions.CreateComponent<AudioManager>();
            }

            return AudioManager;
        }

        public static IUIRoot GetUIRoot()
        {
            if (UIRoot == null)
            {
                var resourceManager = GetResourceManager();

                UIRoot = resourceManager.CreatePrefabInstance<IUIRoot, EComponents>(EComponents.UIRoot);
            }

            return UIRoot;
        }

        public static IMainMenu GetMainMenu()
        {
            if (MainMenu == null)
            {
                MainMenu = MonoExtensions.CreateComponent<MainMenu>();
            }

            return MainMenu;
        }

        public static ISettingsMenu GetSettingsMenu()
        {
            if (SettingsMenu == null)
            {
                SettingsMenu = MonoExtensions.CreateComponent<SettingsMenu>();
            }

            return SettingsMenu;
        }

        public static IGameHUD GetGameHUD()
        {
            if (GameHUD == null)
            {
                GameHUD = MonoExtensions.CreateComponent<GameHUD>();
            }

            return GameHUD;
        }

        public static IGameOverScreen GetGameOverScreen()
        {
            if (GameOverScreen == null)
            {
                GameOverScreen = MonoExtensions.CreateComponent<GameOverScreen>();
            }

            return GameOverScreen;
        }
    }
}