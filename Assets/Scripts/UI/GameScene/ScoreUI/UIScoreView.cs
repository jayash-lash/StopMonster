using UnityEngine;

namespace UI.GameScene.ScoreUI
{
    public class UIScoreView : MonoBehaviour
    {
        public int Score => _score;
        
        [SerializeField] private ScoreUiContent _scoreUI;
        
        private int _score;
        
        public void IncreaseScore(int points)
        {
            _score += points;
            _scoreUI.UpdateScore(_score);
        }
    }
}