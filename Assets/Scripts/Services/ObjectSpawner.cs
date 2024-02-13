using System;
using Factories;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Services
{
    public class ObjectSpawner : MonoBehaviour
    {
        private Camera _camera;
        private BaseObjectFactory[] _objectFactories;

        [Inject]
        private void Construct(ShieldPillFactory shieldPillFactory,RedBombFactory redBombFactory,
            BlackBombFactory blackBombFactory, CharacterEnemyFactory enemyFactory, Camera cam)
        {
            // also we can bind all factories as array, and inject BaseObjectFactory[]
            // but leave like this for now
            _objectFactories = new BaseObjectFactory[]
            {
                shieldPillFactory,
                redBombFactory,
                blackBombFactory,
                enemyFactory
            };

            var sum = 0f;
            foreach (var factory in _objectFactories)
                sum += factory.SpawnChance;

            if (sum > 1f)
                throw new InvalidOperationException($"Sum of {nameof(BaseObjectFactory.SpawnChance)} of all factoies should be less than 1");

            _camera = cam;
        }
        
        [SerializeField] private float _distance;
        [SerializeField] private float _distanceRatio = 7f;
        [SerializeField] private float _timeBetweenSpawn;
        
        [SerializeField] private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
            
            if (_timer >= _timeBetweenSpawn)
            {
                SpawnObject();
                _timer = 0;
            }
        }

        private void SpawnObject()
        {
            // random spawn similar to lootbox logic
            var randomValue = Random.value;

            var sum = 0f;
            foreach (var factory in _objectFactories)
            {
                sum += factory.SpawnChance;
                if (randomValue > sum) continue;

                factory.CreateObject(CalculateRandomSpawnPoint());
                break;
            }
        }
        
        private Vector3 CalculateRandomSpawnPoint()
        {
            _distance = _camera.aspect * _distanceRatio;
        
            var randomPoints = Random.Range(-_distance, _distance);
            var spawnPoints = new Vector3(randomPoints, transform.position.y, 0);

            return spawnPoints;
        }
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            var position = transform.position;
            
            Gizmos.color = Color.green;
            Gizmos.DrawRay(position, Vector3.right * _distance);
            Gizmos.DrawRay(position, Vector3.left * _distance);
        }
#endif
    }
}