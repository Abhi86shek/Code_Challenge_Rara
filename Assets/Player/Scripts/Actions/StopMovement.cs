using SAS.StateMachineGraph;
using UnityEngine;

namespace Rara.FSMCharacterController
{
	public class StopMovement : IStateAction
	{
		private Player _player;
        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
			actor.TryGetComponent(out _player);
        }

        void IStateAction.Execute(Actor actor)
        {
			_player.movementVector = Vector3.zero;
		}
    }
}
