namespace ExampleProject
{
    public class Configuration : IConfiguration
    {
        private readonly PlayerProperties PlayerProperties;

        public Configuration()
        {
            PlayerProperties = new PlayerProperties()
            {
                MovingForce = 6f,
                BumpVelocity = 0.2f,
                DamageVelocity = 2f,
                CrashVelocity = 4f
            };
        }

        public PlayerProperties GetPlayerProperties()
        {
            return PlayerProperties;
        }
    }
}