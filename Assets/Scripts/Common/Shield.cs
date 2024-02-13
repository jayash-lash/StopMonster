using System.Collections;
using UnityEngine;

namespace Common
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private float _duration = 5f;
        public bool IsActive { get; private set; }

        public void ActivateShield()
        {
            if (!IsActive)
            {
                IsActive = true;
                gameObject.SetActive(true);
                StartCoroutine(DeactivateAfterDuration());
            }
        }

        private IEnumerator DeactivateAfterDuration()
        {
            yield return new WaitForSeconds(_duration);
            gameObject.SetActive(false);
            IsActive = false;
        }
    }
}