using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using UniRx;
using UnityEngine;
using Zenject;

namespace Common
{
    public class Joystick : MonoBehaviour
    {
        private Crane _crane;

        [Inject]
        private void Construct(Crane crane)
        {
            _crane = crane;
        }
        
        public void TiltTo(Vector3 direction)
        {
            transform.DOKill();
            
            var estimatedJoystickRotation = 
                transform.rotation * Quaternion.Euler(direction);
            
            _crane.MoveOn(direction * 10);
            
            if (Mathf.Abs(estimatedJoystickRotation.x) >= 0.3f || 
                Mathf.Abs(estimatedJoystickRotation.z) >= 0.3f)
                return;

            transform.rotation *= Quaternion.Euler(direction);
        }

        public void ResetToOriginPosition()
        {
            transform.DORotate(Vector3.zero, 0.5f);
        }
    }
}
