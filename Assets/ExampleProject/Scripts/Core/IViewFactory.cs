namespace ExampleProject
{
    public interface IViewFactory
    {
        IGameHUDView CreateGameHUD();
        IGameOverView CreateGameOver();
        IMainMenuView CreateMainMenu();
        ISettingsMenuView CreateSettingsMenu();
    }
}