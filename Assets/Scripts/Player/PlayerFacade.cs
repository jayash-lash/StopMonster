using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerFacade : MonoBehaviour
    {
        public int Id => _playerCollider.GetInstanceID();
        [FormerlySerializedAs("_playerHealth")] [SerializeField] private PlayerHealth _playerPlayerHealth; 
        [FormerlySerializedAs("_playerShield")] [SerializeField] private Shield _shield;
        [SerializeField] private Collider2D _playerCollider;
        

        public bool TryGetPlayerHealth(int id, out PlayerHealth playerPlayerHealth)
        {
            if (Id == id)
            {
                playerPlayerHealth = _playerPlayerHealth;
                return true;
            }

            playerPlayerHealth = null;
            return false;
        }
        
        public bool HasActiveShield()
        {
            return _shield.IsActive;
        }
        
        public void ActivateShield()
        {
            _shield.ActivateShield();
        }
    }
}