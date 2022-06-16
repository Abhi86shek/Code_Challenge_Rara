using SAS.StateMachineGraph;
using UnityEngine;

namespace Rara.FSMCharacterController
{
    public class ApplyMovementVector : IStateAction
    {
        private Player _player;
        private CharacterController _characterController;
        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.TryGetComponent(out _player);
            actor.TryGetComponent(out _characterController);
        }

        void IStateAction.Execute(Actor actor)
        {
            _characterController.Move(_player.movementVector * Time.deltaTime);
            _player.movementVector = _characterController.velocity;
        }
    }
}
