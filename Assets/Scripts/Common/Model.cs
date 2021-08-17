using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Common
{
    public class Model : MonoBehaviour
    {
        private Joystick _joystick;
        private CraneButton _craneButton;

        [Inject]
        private void Construct(Joystick joystick, CraneButton craneButton)
        {
            _joystick = joystick;
            _craneButton = craneButton;
        }
        
        public void UpArrowPressed()
        {
            _joystick.TiltTo(new Vector3(0.1f,0,0));
        }

        public void DownArrowPressed()
        {
            _joystick.TiltTo(new Vector3(-0.1f,0,0));
        }

        public void LeftArrowPressed()
        {
            _joystick.TiltTo(new Vector3(0,0,0.1f));
        }

        public void RightArrowPressed()
        {
            _joystick.TiltTo(new Vector3(0,0,-0.1f));
        }

        public void ReleaseAnyArrow()
        {
            _joystick.ResetToOriginPosition();
        }

        public void SpacePressed()
        {
            _craneButton.Press();
        }
    }
}
