using Common;
using General;
using UnityEngine;
using Zenject;


namespace DIInstallers
{
    public class CommonInstaller : MonoInstaller
    {
        [SerializeField] private InputDetector inputDetector;
        [SerializeField] private Model model;
        [SerializeField] private Joystick joystick;
        [SerializeField] private Crane crane;
        [SerializeField] private CraneButton craneButton;
        [SerializeField] private CustomCube customCube;
        [SerializeField] private CustomSphere customSphere;
        [SerializeField] private CustomMushroom customMushroom;
        [SerializeField] private CustomCylinder customCylinder;
        [SerializeField] private CustomMeshesSpawner customMeshesSpawner;
        
        public override void InstallBindings()
        {
            BindCustomMeshesFactories();
            BindCustomMeshSpawner();
            BindCrane();
            BindCraneButton();
            BindJoystick();
            BindModel();
            BindInputDetector();
        }

        private void BindCustomMeshSpawner()
        {
            CustomMeshesSpawner customMeshesSpawnerOnScene =
                Container
                    .InstantiatePrefabForComponent<CustomMeshesSpawner>(customMeshesSpawner);

            Container
                .Bind<CustomMeshesSpawner>()
                .FromInstance(customMeshesSpawnerOnScene)
                .AsSingle();
        }
        
        private void BindCustomMeshesFactories()
        {
            Container
                .BindFactory<Vector3, CustomCube, CustomCube.Factory>()
                .FromComponentInNewPrefab(customCube)
                .AsTransient();
            
            Container
                .BindFactory<Vector3, CustomSphere, CustomSphere.Factory>()
                .FromComponentInNewPrefab(customSphere)
                .AsTransient();
            
            Container
                .BindFactory<Vector3, CustomCylinder, CustomCylinder.Factory>()
                .FromComponentInNewPrefab(customCylinder)
                .AsTransient();
            
            Container
                .BindFactory<Vector3, CustomMushroom, CustomMushroom.Factory>()
                .FromComponentInNewPrefab(customMushroom)
                .AsTransient();
        }
        
        private void BindCraneButton()
        {
            CraneButton craneButtonOnScene =
                Container
                    .InstantiatePrefabForComponent<CraneButton>(craneButton);

            Container
                .Bind<CraneButton>()
                .FromInstance(craneButtonOnScene)
                .AsSingle();
        }
        
        private void BindCrane()
        {
            Crane craneOnScene =
                Container
                    .InstantiatePrefabForComponent<Crane>(crane);

            Container
                .Bind<Crane>()
                .FromInstance(craneOnScene)
                .AsSingle();
        }
        
        private void BindJoystick()
        {
            Joystick joystickOnScene =
                Container
                    .InstantiatePrefabForComponent<Joystick>(joystick);

            Container
                .Bind<Joystick>()
                .FromInstance(joystickOnScene)
                .AsSingle();
        }
        
        private void BindModel()
        {
            Model modelOnScene =
                Container
                    .InstantiatePrefabForComponent<Model>(model);

            Container
                .Bind<Model>()
                .FromInstance(modelOnScene)
                .AsSingle();
        }
        
        private void BindInputDetector()
        {
            InputDetector inputDetectorOnScene = 
                Container
                    .InstantiatePrefabForComponent<InputDetector>(inputDetector);

            Container
                .Bind<InputDetector>()
                .FromInstance(inputDetectorOnScene)
                .AsSingle();
        }
        
    }
}