using SAS.StateMachineGraph.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace Rara
{
    public class NavMeshAgentActivatable : MonoBehaviour, IActivatable
    {
        void IActivatable.Activate()
        {
            var agent = GetComponentInChildren<NavMeshAgent>();
            agent.enabled = true;
        }

        void IActivatable.Deactivate()
        {
            var agent = GetComponentInChildren<NavMeshAgent>();
            agent.enabled = false;
        }
    }
}
