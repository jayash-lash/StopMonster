using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class CharacterEnemy : BaseCatchableGameObject
    {
        [SerializeField] private float _speedWhenCaught = 1.5f;
        
        public override void Caught()
        {
            SetIncreasedSpeed(Speed * _speedWhenCaught);
            
            var sequence = DOTween.Sequence();
            
            sequence.Append(transform.DOScale(Vector3.zero, 0.5f));
           
            sequence.Append(transform.DOScale(Vector3.one, 0f));
            sequence.AppendCallback(ClearIncreasedSpeed);

            sequence.OnComplete(() => base.Caught());
        }
    }
}