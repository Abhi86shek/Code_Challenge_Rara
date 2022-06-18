using SAS.StateMachineGraph;
using SAS.Utilities.TagSystem;
using UnityEngine;
using UnityEngine.AI;

namespace Rara.FSMCharacterController.AI
{
    public class ChaseAction : IStateAction
    {
        [FieldRequiresSelf] private NavMeshAgent _agent;

        private Transform _player;

        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.Initialize(this);
        }

        void IStateAction.Execute(Actor actor)
        {
            if (_player == null)
            {
                _player = Object.FindObjectOfType<Player>()?.transform;
                return;
            }
            _agent.SetDestination(_player.position);
        }

    }
}
