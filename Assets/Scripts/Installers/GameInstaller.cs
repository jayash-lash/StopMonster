using Factories;
using Player;
using UnityEngine;
using Zenject;
using Services.Pool;
using Services.Registry;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Player Facade")]
        [SerializeField] private PlayerFacade _playerFacade;

        [Header("Factories")]
        [SerializeField] private CharacterEnemyFactory _enemyFactory;
        [SerializeField] private RedBombFactory _redBombFactory;
        [SerializeField] private BlackBombFactory _blackBombFactory;
        [SerializeField] private ShieldPillFactory _shieldPillFactory;

        public override void InstallBindings()
        {
            // registries binds
            Container.Bind<ComponentsRegistry>().AsCached();

            //pool bind
            PoolInstaller.Install(Container);
            
            // scene objects binds 
            Container.Bind<PlayerFacade>().FromInstance(_playerFacade).AsCached().NonLazy();
            Container.Bind<Camera>().FromComponentInHierarchy().AsCached().NonLazy();

            // factories binds
            BindFactory(_enemyFactory);
            BindFactory(_redBombFactory);
            BindFactory(_blackBombFactory);
            BindFactory(_shieldPillFactory);
        }

        private void BindFactory<T>(T factoryInstance) where T : BaseObjectFactory
        {
            Container.Bind<T>().FromInstance(factoryInstance).AsCached().NonLazy(); 
        }
    }
}