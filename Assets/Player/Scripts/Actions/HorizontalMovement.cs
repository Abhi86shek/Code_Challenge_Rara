using SAS.ScriptableTypes;
using SAS.StateMachineGraph;

namespace Rara.FSMCharacterController
{
	public class HorizontalMovement : IStateAction
	{
		private Player _player;
		private ScriptableReadOnlyFloat _speed = default;

		void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
		{
			actor.TryGetComponent(out _player);
			actor.TryGet(out _speed, key);
		}

        void IStateAction.Execute(Actor actor)
        {
			_player.movementVector.x = _speed.value * _player.movementInput.x;
			_player.movementVector.z = _speed.value * _player.movementInput.z;
		}
    }
}