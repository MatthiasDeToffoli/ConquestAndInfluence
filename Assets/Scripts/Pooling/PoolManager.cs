using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Pooling;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.Pooling
{
    public class PoolManager : APoolManager<PoolInitializerContainer>
    {
        /// <summary>
        /// init the manager
        /// </summary>
        /// <remarks>this function is called by the app manager</remarks>
        public override void Init()
        {
            base.Init();
            mContainer.Init();
        }
    }
}
