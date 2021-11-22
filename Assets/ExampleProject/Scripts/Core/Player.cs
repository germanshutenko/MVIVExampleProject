using System;
using UnityEngine;

namespace ExampleProject
{
    public class Player : MonoBehaviour, IPlayer
    {
        private Rigidbody Rigidbody;

        public event Action<Vector3> Moved = position => {};

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
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
    }
}