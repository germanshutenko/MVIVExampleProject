using UnityEngine;

namespace ExampleProject
{
    public class GameScene : MonoBehaviour
    {
        private IPlayer Player;
        private IUserInput UserInput;
        private IGameCamera GameCamera;
        private IConfiguration Configuration;

        private void Awake()
        {
            Player = CompositionRoot.GetPlayer();
            UserInput = CompositionRoot.GetUserInput();
            GameCamera = CompositionRoot.GetGameCamera();
            Configuration = CompositionRoot.GetConfiguration();

            GameCamera.SetTarget(Player);

            UserInput.DirectionChanged += OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector2 direction)
        {
            var properties = Configuration.GetPlayerProperties();
            var playerForce = properties.MovingForce;
            var worldDirection = new Vector3(direction.x, 0f, direction.y);
            var force = worldDirection * playerForce;

            Player.Move(force);
        }
    }
}