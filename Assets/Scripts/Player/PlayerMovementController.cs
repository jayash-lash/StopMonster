using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Inject] private Camera _camera;
        [SerializeField] private PlayerBounds _playerBounds;
        
        [SerializeField, Range(0f, 1f)] private float _lerpParameter = 0.5f;
        private Vector2 _originalPosition;
        private Vector2 _mouseOffset;
        private Transform _transform;

        private float _leftBound;
        private float _rightBound;

        private void Awake()
        {
            _transform = transform;
            _originalPosition = _transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mouseOffset = _transform.position - _camera.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                Vector3 targetPosition = new Vector2(mousePosition.x + _mouseOffset.x, _originalPosition.y);
                
               var clampedPosition = _playerBounds.ClampPosition(targetPosition);

                transform.position = Vector3.Lerp(transform.position, clampedPosition, _lerpParameter);
            }
        }
    }
}
