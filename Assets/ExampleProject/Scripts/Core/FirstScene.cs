using UnityEngine;

namespace ExampleProject
{
    public class FirstScene : MonoBehaviour
    {
        private IMainMenu MainMenu;

        private void Awake()
        {
            MainMenu = CompositionRoot.GetMainMenu();
        }

        private void Start()
        {
            MainMenu.Show();
        }
    }
}