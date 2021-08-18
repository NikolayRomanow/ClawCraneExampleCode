using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Common
{
    public abstract class CustomMesh : MonoBehaviour
    {
        [Inject]
        private void Construct(Vector3 position, Transform emptyParentOnScene)
        {
            transform.position = position;
            transform.SetParent(emptyParentOnScene);
        }
        
        public class Factory<T> : PlaceholderFactory<Vector3, Transform, T> where  T : CustomMesh  {}
    }
}
