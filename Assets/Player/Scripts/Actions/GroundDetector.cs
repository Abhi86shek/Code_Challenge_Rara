using SAS.StateMachineGraph;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara.FSMCharacterController
{
    public class GroundDetector : IStateAction
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
            _player.IsGrounded = _characterController.isGrounded;
        }
    }
}
