using System;
using BeatThat.StateControllers;

namespace BeatThat.Service.State
{
    /// <summary>
    /// Use to override autowired ([RegisterService] attribute driven) service registrations. 
    /// Common use would be to use a local/fake impl of an API interface for a test scenario.
    /// If used in conjunction with InitServices, make sure this component is *above* InitServices for execution order.
    /// </summary>
    /// <typeparam name="RegistrationInterface"></typeparam>
    /// <typeparam name="ConcreteType"></typeparam>
    public class OverrideServiceRegistration<RegistrationInterface, ConcreteType> : AnimatorControllerBehaviour
        where RegistrationInterface : class
        where ConcreteType : class, RegistrationInterface, new()
    {
        /// <summary>
        /// If true, will detach itself from ServiceLoader on exit state. 
        /// Service initialization has to happen in the same state where this component is attached, e.g. InitServices is a sibling.
        /// Default is true.
        /// </summary>
        public bool m_removeOnExit = true;

        protected override void DidEnter()
        {
            ServiceLoader.onAfterSetServiceRegistratonsStatic += this.action;
        }

        protected override void WillExit()
        {
            if(m_removeOnExit)
            {
                ServiceLoader.onAfterSetServiceRegistratonsStatic -= this.action;
            }
        }

        private Action<ServiceLoader> action { get { return (m_action != null) ? m_action : (m_action = this.OnAfterSetServiceRegistrations); } }
        private Action<ServiceLoader> m_action;

        private void OnAfterSetServiceRegistrations(ServiceLoader serviceLoader)
        {
            serviceLoader.Register<RegistrationInterface, ConcreteType>();
        }
    }

}


