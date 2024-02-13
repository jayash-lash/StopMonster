using Enemy;
using Services.Pool;

namespace Factories
{
    public class BlackBombFactory : BaseObjectFactory<BlackBomb>
    {
        protected override void SwitchOffObject(PoolObject poolObject)
        {
            PoolService.ReturnObjectToPool(poolObject);
        }
    }
}