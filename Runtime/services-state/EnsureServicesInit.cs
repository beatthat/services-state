using BeatThat.CollectionsExt;
using BeatThat.GetComponentsExt;
using BeatThat.StateControllers;
#pragma warning disable 618

namespace BeatThat.Service.State
{
    /// <summary>
    /// Inits BeatThat.Services.
    /// Does nothing if Services have already been init or init is in progress.
    /// 
    /// Does not set any properties or triggers. 
    /// Instead usually used in conjunction with property IsServicesInit, which binds to services by default.
    /// </summary>
    public class EnsureServicesInit : AnimatorControllerBehaviour
    {
        /// <summary>
        /// By default, ensures that the associated GameObject has an IsServicesInit property.
        /// That property will presumably be used as a state-transition param.
        /// </summary>
        public bool m_ensureHasServicesInitProperty = true;

        protected override void DidEnter()
        {
            if(m_ensureHasServicesInitProperty)
            {
                this.controller.AddIfMissing<HasServicesInit>();
            }

            if(Services.exists && (Services.Get.hasInit || Services.Get.isInitInProgress))
            {
                return;
            }

            Services.Init(() => { });
        }
        
    }

}
#pragma warning restore 618




