using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Common
{
    public class CustomMeshesSpawner : MonoBehaviour
    {
        private CustomMesh.Factory<CustomCube> _customCubeFactory;
        private CustomMesh.Factory<CustomSphere> _customSphereFactory;
        private CustomMesh.Factory<CustomCylinder> _customCylinderFactory;
        private CustomMesh.Factory<CustomMushroom> _customMushroomFactory;

        private Transform _emptyParentForCustomMeshes;
        
        [Inject]
        private void Construct(CustomMesh.Factory<CustomCube> customCubeFactory, CustomMesh.Factory<CustomSphere> customSphereFactory,
            CustomMesh.Factory<CustomCylinder> customCylinderFactory, CustomMesh.Factory<CustomMushroom> customMushroomFactory)
        {
            _customCubeFactory = customCubeFactory;
            _customSphereFactory = customSphereFactory;
            _customCylinderFactory = customCylinderFactory;
            _customMushroomFactory = customMushroomFactory;

            _emptyParentForCustomMeshes = new GameObject("EmptyParentForCustomMeshes").transform;
            
            SpawnMeshes(10,10,10,10);
        }

        public void SpawnMeshes(int cubesCount, int spheresCount, int cylindersCount, int mushroomsCount)
        {
            for (int i = 0; i < cubesCount; i++)
            {
                float x = Random.Range(-3f, 3f);
                float z = Random.Range(-3f, 3f);

                _customCubeFactory.Create(new Vector3(x, 0.1f, z), _emptyParentForCustomMeshes);
            }
            
            for (int i = 0; i < spheresCount; i++)
            {
                float x = Random.Range(-3f, 3f);
                float z = Random.Range(-3f, 3f);

                _customSphereFactory.Create(new Vector3(x, 0.1f, z), _emptyParentForCustomMeshes);
            }
            
            for (int i = 0; i < cylindersCount; i++)
            {
                float x = Random.Range(-3f, 3f);
                float z = Random.Range(-3f, 3f);

                _customCylinderFactory.Create(new Vector3(x, 0.1f, z), _emptyParentForCustomMeshes);
            }
            
            for (int i = 0; i < mushroomsCount; i++)
            {
                float x = Random.Range(-3f, 3f);
                float z = Random.Range(-3f, 3f);

                _customMushroomFactory.Create(new Vector3(x, 0.1f, z), _emptyParentForCustomMeshes);
            }
        }
    }
}
