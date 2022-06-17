using SAS.StateMachineGraph;
using SAS.ScriptableTypes;
using UnityEngine;
using UnityEngine.AI;
using SAS.Utilities.TagSystem;

namespace Rara.FSMCharacterController.AI
{
    public class PatrolAction : IStateAction
    {
        [FieldRequiresSelf] private Transform _transform;
        [FieldRequiresSelf] private NavMeshAgent _agent;

        private bool _walkPointSet;
        private ScriptableFloatRange _range;
        private ScriptableLayerMask _ground;
        private Vector3 _walkPoint;
        
        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.Initialize(this);
            actor.TryGet(out _range, key);
            actor.TryGet(out _ground, "Ground");
        }

        void IStateAction.Execute(Actor actor)
        {
            if (!_walkPointSet)
                SearchWalkPoint();
            if (_walkPointSet)
                _agent.SetDestination(_walkPoint);

            var distance = _transform.position - _walkPoint;
            if (distance.sqrMagnitude < 1)
                _walkPointSet = false;
        }

        private void SearchWalkPoint()
        {
            float randomX = Random.Range(_range.runtimeValue.min, _range.runtimeValue.max);
            float randomZ = Random.Range(_range.runtimeValue.min, _range.runtimeValue.max);
            _walkPoint.Set(randomX, _transform.position.y, randomZ);
            if (Physics.Raycast(_walkPoint, -_transform.up, _ground.runtimeValue))
                _walkPointSet = true;
        }
    }
}
