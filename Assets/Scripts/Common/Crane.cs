using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Common
{
    public class Crane : MonoBehaviour
    {
        [SerializeField] private List<Transform> handles;

        private Vector3 _scope = new Vector3(3, 0, 3);
        private bool _canMovable = true;
        private bool _ladleClosed = false;
        
        public void MoveOn(Vector3 vector)
        {
            if (!_canMovable)
                return;
            
            var direction = new Vector3(vector.z * -1, 0, vector.x);
            var estimatedCranePosition = transform.position + (direction * Time.deltaTime);
            
            if (Mathf.Abs(estimatedCranePosition.x) >= _scope.x ||
                Mathf.Abs(estimatedCranePosition.z) >= _scope.z)
                return;
            
            transform.position += direction * Time.deltaTime * 2f;
        }

        public void TurnOnLadle()
        {
            switch (_ladleClosed)
            {
                case true:
                    ReleaseLadle();
                    break;
                case false:
                    TryTake();
                    break;
            } 
        }
        
        private void ReleaseLadle()
        {
            for (int i = 0; i < handles.Count - 1; i++)
            {
                var variableHandle = handles[i];
                variableHandle.DORotate(new Vector3(0, variableHandle.rotation.eulerAngles.y, 0), 1f);
            }

            var lastHandle = handles[handles.Count - 1];

            lastHandle
                .DORotate(new Vector3(0, lastHandle.rotation.eulerAngles.y, 0), 1f)
                .OnComplete(() => { _ladleClosed = false; });
        }
        
        private void TryTake()
        {
            _canMovable = false;

            var currentVectorPosition = transform.position;

            transform
                .DOMove(new Vector3(currentVectorPosition.x, 1.6f, currentVectorPosition.z), 1f)
                .OnComplete(() =>
                {
                    for (int i = 0; i < handles.Count - 1; i++)
                    {
                        var variableHandle = handles[i];
                        variableHandle.DORotate(new Vector3(0, variableHandle.rotation.eulerAngles.y, -50), 1f);
                    }

                    var lastHandle = handles[handles.Count - 1];

                    lastHandle
                        .DORotate(new Vector3(0, lastHandle.rotation.eulerAngles.y, -50), 1f)
                        .OnComplete(() =>
                        {
                            transform
                                .DOMove(new Vector3(currentVectorPosition.x, 3f, currentVectorPosition.z), 1f)
                                .OnComplete(() => { _canMovable = true; });

                            _ladleClosed = true;
                        });
                });
        }
    }
}
