using SAS.StateMachineGraph;
using SAS.Utilities.TagSystem;
using UnityEngine;
using UnityEngine.AI;

namespace Rara.FSMCharacterController.AI
{
    public class ChaseAction : IStateAction
    {
        [FieldRequiresSelf] private NavMeshAgent _agent;
        [FieldRequiresSelf] private AIPlayer _aiPlayer;

        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.Initialize(this);
        }

        void IStateAction.Execute(Actor actor)
        {
            if (!_aiPlayer.Target.IsActive())
                return;

            _agent.SetDestination(_aiPlayer.Target.Transform.position);
        }

    }
}
