using Enemy;
using Services.Registry;
using UI.GameScene.ScoreUI;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Player : MonoBehaviour
    {
         private ComponentsRegistry _componentsRegistry;

        [Inject]
        private void Construct(ComponentsRegistry componentsRegistry)
        {
            _componentsRegistry = componentsRegistry;
        }
        
        [SerializeField] private UIScoreView _ui;
        
        private const int ScoreForEnemy = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_componentsRegistry.TryGetComponent<BaseCatchableGameObject>(other, out var enemy)) return;
            
            enemy.Caught();
            _ui.IncreaseScore(ScoreForEnemy);
        }
    }
}