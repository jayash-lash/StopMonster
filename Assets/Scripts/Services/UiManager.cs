using Player;
using UI.GameScene.ScoreUI;
using UI.GameScene.ScreenOverGame.GetReadyScreen;
using UI.GameScene.ScreenOverGame.WellDoneScreen;
using UnityEngine;

namespace Services
{
    public class UiManager : MonoBehaviour
    {
        [Header("PLayer Settings")] 
        [SerializeField] private PlayerHealth _playerHealth;
        [Header("")] 
        [SerializeField] private GameObject _backGround;
        [Header("")]    
        [Header("Spawner Settings")]
        [SerializeField] private GameObject _objectSpawner;
        [Header("")]    
        [Header("UI Settings")]
        [Header("GetReadyScreenOverGame")] 
        [SerializeField] private GetReadyScreen _getReadyScreen;
        [Header("Game Screen")]
        [SerializeField] private GameObject _gameScreen;
        [SerializeField] private UIScoreView _scoreView;
        [Header("WellDoneScreenOverGame")] 
        [SerializeField] private WellDoneScreenOverGame _wellDoneScreen;
        [SerializeField] private WellDoneUiScoreText _finalScoreView;


        private void Start()
        {
        
            _getReadyScreen.OnCountdownCompleted += OnCountdownCompleted;
        
            _getReadyScreen.StartGetReadyTimer();
        }

        private void OnCountdownCompleted()
        {
            _getReadyScreen.SetInactive();

            _backGround.gameObject.SetActive(true);
            _gameScreen.gameObject.SetActive(true);
            _objectSpawner.SetActive(true);
            _playerHealth.OnHealthZero += PlayerDie;
        }

        private void PlayerDie()
        {
            _gameScreen.gameObject.SetActive(false);
            _objectSpawner.gameObject.SetActive(false);
        
            _wellDoneScreen.ScreenOn();
            _finalScoreView.SetupScoreInfo(_scoreView.Score);
        }

        private void OnDestroy()
        {
            _playerHealth.OnHealthZero -= PlayerDie;
        }
    }
}
