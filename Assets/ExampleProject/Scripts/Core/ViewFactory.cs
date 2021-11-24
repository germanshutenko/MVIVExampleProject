namespace ExampleProject
{
    public class ViewFactory : IViewFactory
    {
        private IUIRoot UIRoot;
        private ISceneManager SceneManager;
        private IResourceManager ResourceManager;

        public ViewFactory(IUIRoot uiRoot, IResourceManager resourceManager, ISceneManager sceneManager)
        {
            UIRoot = uiRoot;
            SceneManager = sceneManager;
            ResourceManager = resourceManager;
        }

        public IGameHUDView CreateGameHUD()
        {
            var view = ResourceManager.CreatePrefabInstance<IGameHUDView, EViews>(EViews.GameHUD);
            view.SetParent(UIRoot.MainCanvas);

            return view;
        }

        public IGameOverView CreateGameOver()
        {
            var view = ResourceManager.CreatePrefabInstance<IGameOverView, EViews>(EViews.GameOver);
            view.SetParent(UIRoot.OverlayCanvas);

            return view;
        }

        public IMainMenuView CreateMainMenu()
        {
            var view = ResourceManager.CreatePrefabInstance<IMainMenuView, EViews>(EViews.MainMenu);
            view.SetParent(UIRoot.OverlayCanvas);

            return view;
        }

        public ISettingsMenuView CreateSettingsMenu()
        {
            ISettingsMenuView view;

            if (SceneManager.CurrentScene == EScenes.GameScene)
            {
                view = ResourceManager.CreatePrefabInstance<ISettingsMenuView, EViews>(EViews.InGameSettingsMenu);
            }
            else
            {
                view = ResourceManager.CreatePrefabInstance<ISettingsMenuView, EViews>(EViews.SettingsMenu);
            }

            view.SetParent(UIRoot.OverlayCanvas);

            return view;
        }
    }
}