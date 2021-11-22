using UnityEngine;

namespace ExampleProject
{
    public class GameCamera : MonoBehaviour, IGameCamera
    {
        private const float CameraLerpSpeed = 0.05f;
        private readonly Vector3 LookAtOffset = Vector3.up * 1f;

        public Transform CameraObject;
        public Camera CameraComponent;

        private IMovable Target;

        public void SetTarget(IMovable target)
        {
            Target = target;

            Target.Moved += OnTargetMoved;
        }

        private void OnTargetMoved(Vector3 position)
        {
            var cameraPosition = transform.position;
            var targetPosition = position;
            var newCameraPosition = Vector3.Lerp(cameraPosition, targetPosition, CameraLerpSpeed);

            CameraObject.LookAt(position + LookAtOffset);

            transform.position = newCameraPosition;
        }
    }
}