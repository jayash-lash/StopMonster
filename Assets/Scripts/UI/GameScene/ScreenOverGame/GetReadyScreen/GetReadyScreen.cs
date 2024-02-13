using System;
using DG.Tweening;
using UnityEngine;

namespace UI.GameScene.ScreenOverGame.GetReadyScreen
{
    public class GetReadyScreen : MonoBehaviour
    {
        public event Action OnCountdownCompleted;
        
        [SerializeField] private GetReadyUiTimer _uiTimer;
        [SerializeField] private RectTransform _package;
        [SerializeField] private int _timeToCount = 3;

        public void SetInactive()
        {
            gameObject.SetActive(false);
        }

        public void StartGetReadyTimer()
        {
            var packageRotation = new Vector3(0f, 0f, 360f);
            
            Sequence sequence = DOTween.Sequence();
            
            sequence.AppendCallback(() => _uiTimer.StartGetReadyTimer(_timeToCount));
            sequence.Append(_package.DORotate(packageRotation, 4f, RotateMode.FastBeyond360));
            sequence.Join(_package.DOMoveY(-900f, 4f).OnComplete(() => OnCountdownCompleted?.Invoke()));

            sequence.Play(); 
        }
    }
}