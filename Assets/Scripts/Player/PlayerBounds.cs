using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerBounds : MonoBehaviour
    {
        [Inject] private Camera _camera;
        
        [SerializeField] private GameObject _player;
        
        private float _leftBound;
        private float _rightBound;
        private float _playerHalfWidth;
        
        private void Awake()
        {
            _playerHalfWidth = GetComponent<Renderer>().bounds.extents.x;
            var position = _player.transform.position;
            _leftBound = position.x + _camera.ViewportToWorldPoint(new Vector2(0, 0)).x + _playerHalfWidth;
            _rightBound = position.x + _camera.ViewportToWorldPoint(new Vector2(1, 0)).x - _playerHalfWidth;
        }
        
        public Vector2 ClampPosition(Vector2 targetPos)
        {
            targetPos.x = Mathf.Clamp(targetPos.x, _leftBound, _rightBound);

            return targetPos;
        }

#if UNITY_EDITOR
        private void DrawBoundsLines()
        {
            Gizmos.color = Color.red;
            var transformPos = transform.position;
            Gizmos.DrawLine(new Vector3(_leftBound, transformPos.y, transformPos.z), new Vector3(_leftBound, transformPos.y + 1, transformPos.z));

            Gizmos.color = Color.green;
            Gizmos.DrawLine(new Vector3(_rightBound, transformPos.y, transformPos.z), new Vector3(_rightBound, transformPos.y + 1, transformPos.z));
        }
#endif
    }
}