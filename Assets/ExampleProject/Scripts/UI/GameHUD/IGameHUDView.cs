namespace ExampleProject
{
    public interface IGameHUDView : IView
    {
        void SetHP(float value);
        void SetMana(float value);
        void SetTime(int value);
    }
}