using UnityEngine;

namespace Enemy
{
    public class ShieldPill : BaseCatchableGameObject
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var instanceId = other.GetInstanceID();

            if (instanceId == PlayerFacade.Id)
            {
                PlayerFacade.ActivateShield();
                Caught();
            }
        }
    }
}