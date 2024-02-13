using System;
using UI.GameScene.HealthUi;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public event Action OnHealthZero;
       
        [SerializeField] private int _currentHealth;
        [SerializeField] private UiHeartView _heartHealth;
        
        public void TakeDamage(int damage)
        {
            if (_currentHealth <= 0) return;
            {
                _currentHealth -= damage;
            }
           
            _heartHealth.UpdateHealthView(_currentHealth);
            if (_currentHealth <= 0) OnHealthZero?.Invoke();
        }
        
    }
}