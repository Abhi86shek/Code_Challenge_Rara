using SAS.ScriptableTypes;
using SAS.StateMachineGraph;
using UnityEngine;

namespace Rara.FSMCharacterController
{ 
    public class ApplyRotation : IStateAction
    {
        private Player _player;
        private Transform _transform;
        private ScriptableFloat _turnSmoothTime;

        private float _turnSmoothSpeed;

        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.TryGetComponent(out _player);
            actor.TryGetComponent(out _transform);
            actor.TryGet(out _turnSmoothTime, key);
        }

        void IStateAction.Execute(Actor actor)
        {
            Vector3 horizontalMovement = _player.movementVector;
            horizontalMovement.y = 0f;

            if (horizontalMovement.sqrMagnitude >= 0.02f)
            {
                float targetRotation = Mathf.Atan2(_player.movementVector.x, _player.movementVector.z) * Mathf.Rad2Deg;
                _transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetRotation, ref _turnSmoothSpeed, _turnSmoothTime.runtimeValue);
            }
        }
    }
}
