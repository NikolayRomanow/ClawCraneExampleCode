using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace General
{
    public class InputDetector : MonoBehaviour
    {
        private Model _model;

        [Inject]
        private void Construct(Model model)
        {
            _model = model;
        }
        
        private void Start()
        {
            StartUpArrowPressDetect();
            StartDownArrowPressDetect();
            StartLeftArrowPressDetect();
            StartRightArrowPressDetect();
            
            StartAnyArrowReleaseDetect();
            StartSpaceButtonPressDetect();
        }
        
        private void StartUpArrowPressDetect()
        {
            Observable
                .EveryUpdate()
                .Where(x => Input.GetKey(KeyCode.UpArrow))
                .Subscribe(x => { _model.UpArrowPressed(); })
                .AddTo(this);
        }

        private void StartDownArrowPressDetect()
        {
            Observable
                .EveryUpdate()
                .Where(x => Input.GetKey(KeyCode.DownArrow))
                .Subscribe(x => { _model.DownArrowPressed(); })
                .AddTo(this);
        }

        private void StartLeftArrowPressDetect()
        {
            Observable
                .EveryUpdate()
                .Where(x => Input.GetKey(KeyCode.LeftArrow))
                .Subscribe(x => { _model.LeftArrowPressed(); })
                .AddTo(this);
        }

        private void StartRightArrowPressDetect()
        {
            Observable
                .EveryUpdate()
                .Where(x => Input.GetKey(KeyCode.RightArrow))
                .Subscribe(x => { _model.RightArrowPressed(); })
                .AddTo(this);
        }

        private void StartAnyArrowReleaseDetect()
        {
            Observable
                .EveryUpdate()
                .Where(x => Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
                            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                .Subscribe(x => { _model.ReleaseAnyArrow(); })
                .AddTo(this);
        }

        private void StartSpaceButtonPressDetect()
        {
            Observable
                .EveryUpdate()
                .Where(x => Input.GetKeyDown(KeyCode.Space))
                .Subscribe(x => { _model.SpacePressed(); })
                .AddTo(this);
        }
    }
}
