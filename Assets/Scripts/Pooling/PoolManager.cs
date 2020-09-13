using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Pooling;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Pooling
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
