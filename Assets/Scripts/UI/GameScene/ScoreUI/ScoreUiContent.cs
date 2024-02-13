using TMPro;
using UnityEngine;

namespace UI.GameScene.ScoreUI
{
    public class ScoreUiContent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void UpdateScore(int playerScore)
        {
            _scoreText.text = "Score: " + playerScore;
        }
    }
}
