using System;

namespace ExampleProject
{
    public interface IGameOverScreen : IScreen
    {
        event Action NextClicked;
    }
}