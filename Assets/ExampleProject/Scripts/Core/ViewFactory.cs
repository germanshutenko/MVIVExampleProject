namespace ExampleProject
{
    public class ViewFactory : IViewFactory
    {
        private IUIRoot UIRoot;
        private IResourceManager ResourceManager;

        public ViewFactory(IUIRoot uiRoot, IResourceManager resourceManager)
        {
            UIRoot = uiRoot;
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
            var view = ResourceManager.CreatePrefabInstance<ISettingsMenuView, EViews>(EViews.SettingsMenu);
            view.SetParent(UIRoot.OverlayCanvas);

            return view;
        }
    }
}