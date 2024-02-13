using TMPro;
using UnityEngine;

namespace UI.GameScene.HealthUi
{
    public class HeartUiContent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void UpdateLeftLives(int livesLeft)
        {
            _scoreText.text = livesLeft.ToString();
        }
    }
}