using SAS.ScriptableTypes;
using SAS.StateMachineGraph;

namespace Rara.FSMCharacterController
{
	public class VerticalPull : IStateAction
	{
		private  Player _player;
		private ScriptableReadOnlyFloat _verticalPull;

        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
			actor.TryGet(out _verticalPull, key);
			actor.TryGetComponent(out _player);
		}

        void IStateAction.Execute(Actor actor)
        {
			_player.movementVector.y = _verticalPull.value;
		}
    }
}
