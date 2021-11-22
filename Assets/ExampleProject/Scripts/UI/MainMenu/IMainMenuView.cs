using System;

namespace ExampleProject
{
    public interface IMainMenuView : IView
    {
        event Action NewGameClicked;
        event Action SettingsClicked;
        event Action ExitClicked;
    }
}