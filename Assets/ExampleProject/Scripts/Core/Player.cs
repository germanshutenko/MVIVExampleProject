using System;
using UnityEngine;

namespace ExampleProject
{
    public class Player : MonoBehaviour, IPlayer
    {
        public event Action<Vector3> Moved = position => { };
        public event Action<float> HealthChanged = value => { };
        public event Action<float> MaxHealthChanged = value => { };
        public event Action Died = () => { };

        public float Health { get; private set; }
        public float MaxHealth { get; private set; }

        private Rigidbody Rigidbody;

        private IAudioManager AudioManager;
        private IConfiguration Configuration;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            AudioManager = CompositionRoot.GetAudioManager();
            Configuration = CompositionRoot.GetConfiguration();

            var properties = Configuration.GetPlayerProperties();

            Health = properties.StartHealth;
            MaxHealth = properties.StartHealth;
        }

        private void FixedUpdate()
        {
            Moved(transform.position);
        }

        public void Move(Vector3 force)
        {
            var torque = new Vector3(force.z, force.y, -force.x);

            Rigidbody.AddTorque(torque, ForceMode.Force);
        }

        public void SetPosition(Vector3 position)
        {
            Rigidbody.position = position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var properties = Configuration.GetPlayerProperties();
            var velocity = Rigidbody.velocity.magnitude;

            if (velocity > properties.CrashVelocity)
            {
                AudioManager.PlayEffect(EAudio.Crash);

                Health -= 10f;
                Health = Mathf.Clamp(Health, 0f, MaxHealth);

                HealthChanged(Health);

                return;
            }

            if (velocity > properties.DamageVelocity)
            {
                AudioManager.PlayEffect(EAudio.Damage);

                Health -= 5f;
                Health = Mathf.Clamp(Health, 0f, MaxHealth);

                HealthChanged(Health);

                return;
            }

            if (velocity > properties.BumpVelocity)
            {
                AudioManager.PlayEffect(EAudio.Bump);
                return;
            }
        }

        public void Heal(float value)
        {
            Health += value;
        }
    }
}