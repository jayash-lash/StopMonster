using Enemy;
using Services.Pool;

namespace Factories
{
    public class RedBombFactory : BaseObjectFactory<RedBomb>
    {
        protected override void SwitchOffObject(PoolObject poolObject)
        {
            PoolService.ReturnObjectToPool(poolObject);
        }
    }
}