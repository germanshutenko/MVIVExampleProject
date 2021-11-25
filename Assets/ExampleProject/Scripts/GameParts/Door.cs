using UnityEngine;

namespace ExampleProject.GameParts
{
    public class Door : MonoBehaviour
    {
        public float Offset = 0.75f;
        public float Speed = 1f;

        public Transform LeftDoor;
        public Transform RightDoor;

        private bool IsPlayerStaying;
        private Vector3 LeftDoorStartPosition;
        private Vector3 RightDoorStartPosition;

        private void Awake()
        {
            LeftDoorStartPosition = LeftDoor.localPosition;
            RightDoorStartPosition = RightDoor.localPosition;
        }

        private void Update()
        {
            var distance = Time.fixedDeltaTime * Offset;
            var leftPosition = LeftDoor.localPosition;
            var leftOffset = -Vector3.right * Offset;
            var rightPosition = RightDoor.localPosition;
            var rightOffset = Vector3.right * Offset;

            if (IsPlayerStaying == true)
            {
                LeftDoor.localPosition = Vector3.MoveTowards(leftPosition, LeftDoorStartPosition + leftOffset, distance);
                RightDoor.localPosition = Vector3.MoveTowards(rightPosition, RightDoorStartPosition + rightOffset, distance);
            }

            if (IsPlayerStaying == false)
            {
                LeftDoor.localPosition = Vector3.MoveTowards(leftPosition, LeftDoorStartPosition, distance);
                RightDoor.localPosition = Vector3.MoveTowards(rightPosition, RightDoorStartPosition, distance);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IPlayer>() != null)
            {
                IsPlayerStaying = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<IPlayer>() != null)
            {
                IsPlayerStaying = false;
            }
        }
    }
}