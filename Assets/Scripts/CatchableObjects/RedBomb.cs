using UnityEngine;

namespace Enemy
{
    public class RedBomb : BaseCatchableGameObject
    {
        [SerializeField] private int _damage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var instanceId = other.GetInstanceID();
            
            if (PlayerFacade.HasActiveShield()) // Implement a method in PlayerFacade to check for active shield
            {
                Caught();
            }
            else if (PlayerFacade.TryGetPlayerHealth(instanceId, out var playerHealth))
            {
                playerHealth.TakeDamage(_damage);
                Caught();
            }
        }
    }
}