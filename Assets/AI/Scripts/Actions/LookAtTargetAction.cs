using SAS.ScriptableTypes;
using SAS.StateMachineGraph;
using SAS.Utilities.TagSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara.FSMCharacterController.AI
{
    public class LookAtTargetAction : IStateAction
    {
        [FieldRequiresChild("Head")] private Transform _transform;
        [FieldRequiresSelf] private AIPlayer _aiPlayer;
        private ScriptableReadOnlyFloat _turnSmoothSpeed;

        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.Initialize(this);
            actor.TryGet(out _turnSmoothSpeed, key);
        }

        void IStateAction.Execute(Actor actor)
        {
            if (!_aiPlayer.Target.IsActive())
                return;

            var targetRotation = Quaternion.LookRotation(_aiPlayer.Target.Transform.position - _transform.position);
            _transform.rotation = Quaternion.Lerp(_transform.rotation, targetRotation, Time.deltaTime * _turnSmoothSpeed.value);
        }
    }
}
