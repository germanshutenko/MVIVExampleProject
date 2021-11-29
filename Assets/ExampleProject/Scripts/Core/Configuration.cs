namespace ExampleProject
{
    public class Configuration : IConfiguration
    {
        private readonly PlayerProperties PlayerProperties;

        public Configuration()
        {
            PlayerProperties = new PlayerProperties()
            {
                MovingForce = 5f,
                BumpForce = 100f,
                DamageForce = 200f,
                CrashForce = 400f,
                StartHealth = 100f
            };


        }

        public PlayerProperties GetPlayerProperties()
        {
            return PlayerProperties;
        }
    }
}