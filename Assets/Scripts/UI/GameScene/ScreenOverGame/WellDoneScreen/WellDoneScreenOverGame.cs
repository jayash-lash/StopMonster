using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.GameScene.ScreenOverGame.WellDoneScreen
{
    public class WellDoneScreenOverGame : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _exitButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _mainMenuButton.onClick.AddListener(OpenMainMenu);
            _exitButton.onClick.AddListener(ExitGame);
        }

        public void ScreenOn() => gameObject.SetActive(true);

        public void RestartGame() => SceneManager.LoadScene("GameScene");

        public void OpenMainMenu() => SceneManager.LoadScene("MainMenuScene");

        public void ExitGame() => Application.Quit();
    }
}