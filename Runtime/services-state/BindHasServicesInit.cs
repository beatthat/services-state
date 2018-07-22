using BeatThat.TransformPathExt;
using BeatThat.Properties;
#pragma warning disable 618

using UnityEngine;

namespace BeatThat.Service.State
{
    /// <summary>
    /// Keeps a state prop HasServicesInit in sync with BeatThatServices
    /// </summary>
    public class BindHasServicesInit : PropertyBinding<HasServicesInit>
    {
        public bool m_debug;

        protected override void BindProperty()
        {
            UpdateProperty();
            Bind(Services.InitStatusUpdated, this.OnInitStatusUpdated);
        }

        private void OnInitStatusUpdated(Services s)
        {
            UpdateProperty();
        }

        private bool UpdateProperty()
        {
            var hasInit = Services.exists && Services.Get.hasInit;

#if UNITY_EDITOR || DEBUG_UNSTRIP
            if(m_debug)
            {
                Debug.Log("[" + Time.frameCount + "] [" + this.Path() + "] " + GetType() + " - setting hasInit to " + hasInit);
            }
#endif

            this.property.value = hasInit;
            return hasInit;
        }
			
    }
}

#pragma warning restore 618


