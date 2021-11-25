using UnityEngine;

namespace ExampleProject
{
    public class GameCamera : MonoBehaviour, IGameCamera
    {
        private const float MinFOV = 45f;
        private const float MaxFOV = 120f;
        private const float MaxSpeed = 10f;

        private const float CameraLerpFOV = 0.02f;
        private const float CameraLerpSpeed = 0.2f;
        private readonly Vector3 LookAtOffset = Vector3.up * 1f;

        public Transform CameraObject;
        public Camera CameraComponent;

        private IMovable Target;
        private Vector3 PreviousTargetPosition;

        public void SetTarget(IMovable target)
        {
            Target = target;
            PreviousTargetPosition = Target.Position;

            Target.Moved += OnTargetMoved;
        }

        private void OnTargetMoved(Vector3 position)
        {
            var cameraPosition = transform.position;
            var targetPosition = position;
            var newCameraPosition = Vector3.Lerp(cameraPosition, targetPosition, CameraLerpSpeed);

            CameraObject.LookAt(position + LookAtOffset);

            transform.position = newCameraPosition;

            var speed = Vector3.Magnitude(Target.Position - PreviousTargetPosition) / Time.fixedDeltaTime;
            var normalizedSpeed = speed / MaxSpeed;
            
            var targetFOV = Mathf.Lerp(MinFOV, MaxFOV, normalizedSpeed);

            CameraComponent.fieldOfView = Mathf.Lerp(CameraComponent.fieldOfView, targetFOV, CameraLerpFOV);

            PreviousTargetPosition = Target.Position;
        }
    }
}