using Enemy;
using Services.Registry;
using Services.Pool;
using UnityEngine;
using Zenject;

namespace Factories
{
    public abstract class BaseObjectFactory : MonoBehaviour
    {
        public float SpawnChance => _spawnChance;
        protected GameObject Prefab => _prefab;
        
        [SerializeField] private GameObject _prefab; // should be in config file
        [SerializeField, Range(0f, 1f)] private float _spawnChance; // should be in config file

        public abstract void CreateObject(Vector3 position);
    }

    public abstract class BaseObjectFactory<T> : BaseObjectFactory where T : BaseCatchableGameObject
    {
        [SerializeField] private int _poolSize;
        [SerializeField] private bool _isDynamic;
        
        protected IPoolService PoolService;
        private ComponentsRegistry _componentsRegistry;

        [Inject]
        private void Construct(IPoolService poolService, ComponentsRegistry componentsRegistry)
        {
            PoolService = poolService;
            _componentsRegistry = componentsRegistry;
        }

        protected void Awake()
        {
            PoolService.CreatePool(Prefab, _poolSize, _isDynamic);
        }

        public override void CreateObject(Vector3 position)
        {
            var poolObject = PoolService.InstantiateFromPool(Prefab);
            var instance = poolObject.Instance.GetComponent<T>();

            var objectTransform = poolObject.Transform;
            objectTransform.position = position;
            objectTransform.rotation = Quaternion.identity;

            var coll = instance.GetComponent<Collider2D>();
            _componentsRegistry.Register(coll, instance);
            
            instance.VisibleStateProvider.OnVisibleStateChanged += isVisible =>
            {
                if (isVisible) return;
                ReturnObjectToPool(coll, instance, poolObject);
            };

            instance.OnCaught += () => ReturnObjectToPool(coll, instance, poolObject);
        }

        private void ReturnObjectToPool(Collider2D coll, T instance, PoolObject poolObject)
        {
            _componentsRegistry.Remove(coll);
            instance.ClearCallbacks();
            SwitchOffObject(poolObject);
        }

        protected abstract void SwitchOffObject(PoolObject poolObject);
    }
}