using System;

namespace ExampleProject
{
    public interface IGameOver : IScreen
    {
        event Action NextClicked;
    }
}