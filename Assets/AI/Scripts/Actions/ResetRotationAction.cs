using SAS.ScriptableTypes;
using SAS.StateMachineGraph;
using SAS.Utilities.TagSystem;
using UnityEngine;

namespace Rara.FSMCharacterController.AI
{
    public class ResetRotationAction : IStateAction
    {
        [FieldRequiresChild("Head")] private Transform _transform;
        private ScriptableFloat _turnSmoothSpeed;

        private Quaternion _initialRotation;

        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.Initialize(this);
            actor.TryGet(out _turnSmoothSpeed, key);
            _initialRotation = _transform.rotation;
        }

        void IStateAction.Execute(Actor actor)
        {
            _transform.rotation = Quaternion.Lerp(_transform.rotation, _initialRotation, Time.deltaTime * _turnSmoothSpeed.runtimeValue);
        }
    }
}
