using System;
using UnityEngine;

namespace Common
{
    public class VisibleStateProvider : MonoBehaviour
    {
        public event Action<bool> OnVisibleStateChanged;

        private void OnBecameInvisible()
        {
            OnVisibleStateChanged?.Invoke(false);
        }

        private void OnBecameVisible()
        {
            OnVisibleStateChanged?.Invoke(true);
        }

        public void ClearCallbacks()
        {
            OnVisibleStateChanged = null;
        }
    }
}
