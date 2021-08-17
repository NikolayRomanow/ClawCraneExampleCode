using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Common
{
    public class CustomSphere : CustomMesh
    {
        public class Factory : PlaceholderFactory<Vector3, CustomSphere> {}
    }
}
