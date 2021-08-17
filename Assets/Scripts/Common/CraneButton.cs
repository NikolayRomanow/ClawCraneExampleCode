using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Common
{
    public class CraneButton : MonoBehaviour
    {
        [SerializeField] private Transform button;
        
        private Crane _crane;

        [Inject]
        private void Construct(Crane crane)
        {
            _crane = crane;
        }

        public void Press()
        {
            button
                .DOLocalMove(new Vector3(0, -0.065f, 0), 1f)
                .OnComplete(() =>
                {
                    button
                        .DOLocalMove(Vector3.zero, 1f);
                });
            
            _crane.TurnOnLadle();
        }
    }
}
