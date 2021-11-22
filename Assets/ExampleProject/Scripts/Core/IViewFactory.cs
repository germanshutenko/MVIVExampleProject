namespace ExampleProject
{
    public interface IViewFactory
    {
        IGameHUDView CreateGameHUD();
        IMainMenuView CreateMainMenu();
        ISettingsMenuView CreateSettingsMenu();
    }
}