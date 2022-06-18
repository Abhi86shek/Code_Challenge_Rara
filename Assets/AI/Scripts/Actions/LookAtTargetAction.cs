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
        private ScriptableFloat _turnSmoothSpeed;
        private Transform _player;

        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.Initialize(this);
            actor.TryGet(out _turnSmoothSpeed, key);
        }

        void IStateAction.Execute(Actor actor)
        {
            if (_player == null)
                _player = GameObject.FindObjectOfType<Player>().LookAtTransform;

            var targetRotation = Quaternion.LookRotation(_player.position - _transform.position);
            _transform.rotation = Quaternion.Lerp(_transform.rotation, targetRotation, Time.deltaTime * _turnSmoothSpeed.runtimeValue);
        }
    }
}
