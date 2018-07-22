using BeatThat.OptionalComponents;
using BeatThat.StateControllers;

namespace BeatThat.Service.State
{
    /// <summary>
    /// Bool animator state property that indicates whether BeatThat.Services has completed initialization.
    /// </summary>
	[OptionalComponent(typeof(BindHasServicesInit))]
	public class HasServicesInit : BoolStateProperty
    {
    }
}

