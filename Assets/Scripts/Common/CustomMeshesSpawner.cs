using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Common
{
    public class CustomMeshesSpawner : MonoBehaviour
    {
        private CustomCube.Factory _customCubeFactory;
        private CustomSphere.Factory _customSphereFactory;
        private CustomCylinder.Factory _customCylinderFactory;
        private CustomMushroom.Factory _customMushroomFactory;

        [Inject]
        private void Construct(CustomCube.Factory customCubeFactory, CustomSphere.Factory customSphereFactory,
            CustomCylinder.Factory customCylinderFactory, CustomMushroom.Factory customMushroomFactory)
        {
            _customCubeFactory = customCubeFactory;
            _customSphereFactory = customSphereFactory;
            _customCylinderFactory = customCylinderFactory;
            _customMushroomFactory = customMushroomFactory;
            
            SpawnMeshes(10,10,10,10);
        }

        public void SpawnMeshes(int cubesCount, int spheresCount, int cylindersCount, int mushroomsCount)
        {
            for (int i = 0; i < cubesCount; i++)
            {
                float x = Random.Range(-3f, 3f);
                float z = Random.Range(-3f, 3f);

                _customCubeFactory.Create(new Vector3(x, 0.1f, z));
            }
            
            for (int i = 0; i < spheresCount; i++)
            {
                float x = Random.Range(-3f, 3f);
                float z = Random.Range(-3f, 3f);

                _customSphereFactory.Create(new Vector3(x, 0.1f, z));
            }
            
            for (int i = 0; i < cylindersCount; i++)
            {
                float x = Random.Range(-3f, 3f);
                float z = Random.Range(-3f, 3f);

                _customCylinderFactory.Create(new Vector3(x, 0.1f, z));
            }
            
            for (int i = 0; i < mushroomsCount; i++)
            {
                float x = Random.Range(-3f, 3f);
                float z = Random.Range(-3f, 3f);

                _customMushroomFactory.Create(new Vector3(x, 0.1f, z));
            }
        }
    }
}
