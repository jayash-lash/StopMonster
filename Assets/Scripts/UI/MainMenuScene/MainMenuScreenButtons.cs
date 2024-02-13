using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.MainMenuScene
{
    public class MainMenuScreenButtons : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
    
        private void Awake()
        {
            _startButton.onClick.AddListener(StartGame);
        }
    
        public void StartGame()
        {
            SceneManager.LoadScene("LoadingScene");
        }
    }
}