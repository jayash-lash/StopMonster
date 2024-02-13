using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.LoadScene
{
    public class GameSceneLoader : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _loadingTime = 3.0f;

        private void Start()
        {
            StartCoroutine(LoadLevel());
        }

        private IEnumerator LoadLevel()
        {
            var startTime = Time.time;
            var elapsedTime = 0.0f;

            while (elapsedTime < _loadingTime)
            {
                elapsedTime = Time.time - startTime;
                _slider.value = elapsedTime / _loadingTime;

                yield return null;
            }

            var asyncLoad = SceneManager.LoadSceneAsync("GameScene");

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}