using Enemy;
using Services.Pool;

namespace Factories
{
    public class ShieldPillFactory : BaseObjectFactory<ShieldPill>
    {
        protected override void SwitchOffObject(PoolObject poolObject)
        {
            PoolService.ReturnObjectToPool(poolObject);
        }
    }
}