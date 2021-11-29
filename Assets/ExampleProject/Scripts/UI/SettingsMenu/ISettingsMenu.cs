using System;

namespace ExampleProject
{
    public interface ISettingsMenu : IScreen
    {
        event Action Closing;
    }
}