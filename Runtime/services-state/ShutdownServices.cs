using BeatThat.StateControllers;
#pragma warning disable 618

namespace BeatThat.Service.State
{
    /// <summary>
    /// Shutsdown all services, which is a way to simulate that the app has been quit (at least from Services perspective).
    /// This can be useful for test scenarios. 
    /// </summary>
    public class ShutdownServices : AnimatorControllerBehaviour
    {
        protected override void DidEnter()
        {
            Services.ShutdownAll();
        }
        
    }

}
#pragma warning restore 618


