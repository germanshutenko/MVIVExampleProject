namespace ExampleProject
{
    public class Configuration : IConfiguration
    {
        private readonly PlayerProperties PlayerProperties;

        public Configuration()
        {
            PlayerProperties = new PlayerProperties()
            {
                MovingForce = 6f
            };
        }

        public PlayerProperties GetPlayerProperties()
        {
            return PlayerProperties;
        }
    }
}