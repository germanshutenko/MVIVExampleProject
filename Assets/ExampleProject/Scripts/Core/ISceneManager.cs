namespace ExampleProject
{
    public interface ISceneManager
    {
        EScenes CurrentScene { get; }

        void LoadScene(EScenes scene);
    }
}