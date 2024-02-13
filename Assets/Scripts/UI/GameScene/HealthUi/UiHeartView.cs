using UnityEngine;

namespace UI.GameScene.HealthUi
{
    public class UiHeartView : MonoBehaviour
    {
        [SerializeField] private HeartUiContent _heartUi;

        private int _heartCount;
        public void UpdateHealthView(int currentHealth)
        {
            _heartCount = currentHealth;
            _heartUi.UpdateLeftLives(_heartCount);
        }
    }
}