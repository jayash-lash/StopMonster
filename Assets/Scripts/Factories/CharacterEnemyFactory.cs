using Enemy;
using Services.Pool;

namespace Factories
{
    public class CharacterEnemyFactory : BaseObjectFactory<CharacterEnemy>
    {
        protected override void SwitchOffObject(PoolObject poolObject)
        {
            PoolService.ReturnObjectToPool(poolObject);
        }
    }
}