using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Common
{
    public class CustomCube : CustomMesh
    {
        public class Factory : PlaceholderFactory<Vector3, CustomCube> {}
    }
}
