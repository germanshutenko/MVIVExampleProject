namespace ExampleProject
{
    public interface IGameHUD : IScreen
    {
        void SetHP(float value);
        void SetMana(float value);
        void SetTime(int value);
    }
}