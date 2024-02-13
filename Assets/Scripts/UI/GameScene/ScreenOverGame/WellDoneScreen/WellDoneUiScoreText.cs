using TMPro;
using UnityEngine;

namespace UI.GameScene.ScreenOverGame.WellDoneScreen
{
    public class WellDoneUiScoreText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _upperScoreInfo;
        [SerializeField] private TextMeshProUGUI _mainScoreInfo;

        public void SetupScoreInfo(int playerScore)
        {
            _upperScoreInfo.text = "You save the planet from " + playerScore + " monsters";
            _mainScoreInfo.text = $"{playerScore}";
        }
    }
}