using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Common
{
    public class CustomCylinder : CustomMesh
    {
        public class Factory : PlaceholderFactory<Vector3, CustomCylinder> {}
    }
}
