using System;

namespace ExampleProject
{
    public interface IGameOverView : IView
    {
        event Action NextClicked;
    }
}