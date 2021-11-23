using System;
using UnityEngine;

namespace ExampleProject
{
    public class Player : MonoBehaviour, IPlayer
    {
        private Rigidbody Rigidbody;
        private IAudioManager AudioManager;
        private IConfiguration Configuration;

        public event Action<Vector3> Moved = position => {};

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            AudioManager = CompositionRoot.GetAudioManager();
            Configuration = CompositionRoot.GetConfiguration();
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
                return;
            }

            if (velocity > properties.DamageVelocity)
            {
                AudioManager.PlayEffect(EAudio.Damage);
                return;
            }

            if (velocity > properties.BumpVelocity)
            {
                AudioManager.PlayEffect(EAudio.Bump);
                return;
            }
        }
    }
}