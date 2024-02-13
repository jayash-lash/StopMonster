using System;
using Common;
using Player;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public abstract class BaseCatchableGameObject : MonoBehaviour
    {
        public event Action OnCaught;
        
        protected PlayerFacade PlayerFacade;
        [Inject]
        protected void Construct(PlayerFacade playerFacade)
        {
            PlayerFacade = playerFacade;
        }
        
        public VisibleStateProvider VisibleStateProvider => _visibleStateProvider;

        [SerializeField] private VisibleStateProvider _visibleStateProvider;
        [SerializeField] protected float Speed;
        [SerializeField] protected Vector3 Direction;

        private Transform _transform;
        private float _increasedSpeed;

        private void Awake() => _transform = transform;

        private void Update() => Move();
        private void OnBecameInvisible() => gameObject.SetActive(false);

        public virtual void Caught() => OnCaught?.Invoke();
        protected void SetIncreasedSpeed(float speed) => _increasedSpeed = speed;
        public void ClearIncreasedSpeed() => _increasedSpeed = 0;

        private void Move()
        {
            var currentSpeed = _increasedSpeed > 0 ? _increasedSpeed : Speed;
            
            _transform.position += Direction * (currentSpeed * Time.deltaTime);
        }

        public void ClearCallbacks()
        {
            _visibleStateProvider.ClearCallbacks();
            OnCaught = null;
        }
    }
}