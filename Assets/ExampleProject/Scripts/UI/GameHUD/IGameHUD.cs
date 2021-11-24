namespace ExampleProject
{
    public interface IGameHUD : IScreen
    {
        void SetHealth(float value);
        void SetMana(float value);
        void SetTime(int value);
    }
}