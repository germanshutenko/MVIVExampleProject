using System;

namespace ExampleProject
{
    public interface IHealth
    {
        event Action<float> HealthChanged;
        event Action<float> MaxHealthChanged;
        event Action Died;

        float Health { get; }
        float MaxHealth { get; }

        void Heal(float value);
    }
}