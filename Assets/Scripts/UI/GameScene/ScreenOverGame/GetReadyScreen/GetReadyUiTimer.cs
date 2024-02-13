using TMPro;
using UnityEngine;

namespace UI.GameScene.ScreenOverGame.GetReadyScreen
{
    public class GetReadyUiTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numberOfTime;

        private float _countdownTime;
        private bool _isCountingDown = false;

        public void StartGetReadyTimer(int time)
        {
            _countdownTime = time;
            _isCountingDown = true;
            UpdateCountdownText();
        }

        private void Update()
        {
            if (_isCountingDown)
            {
                _countdownTime -= Time.deltaTime;

                if (_countdownTime <= 0f)
                {
                    _numberOfTime.text = "0";
                    _isCountingDown = false;
                }
                else
                {
                    UpdateCountdownText();
                }
            }
        }

        private void UpdateCountdownText()
        {
            int seconds = Mathf.CeilToInt(_countdownTime);
            _numberOfTime.text = seconds.ToString();
        }
    }
}