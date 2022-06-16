using Rara.FSMCharacterController.Configs;
using SAS.StateMachineGraph;
using UnityEngine;

namespace Rara.FSMCharacterController
{
	public class DownwardMovement : IStateAction
	{
		private Player _player;
		private DownwardMovementConfig _downwardMovementConfig = default;
		private float _verticalMovement;

		void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
		{
			actor.TryGet(out _downwardMovementConfig, key);
			actor.TryGetComponent(out _player);
			state.OnEnterEvent += () =>
			{
				_verticalMovement = _player.movementVector.y;
			};
		}

		void IStateAction.Execute(Actor actor)
		{
			_verticalMovement += Physics.gravity.y * _downwardMovementConfig.gravityMultiplier * Time.deltaTime;
			_verticalMovement = Mathf.Clamp(_verticalMovement, _downwardMovementConfig.fallSpeedRange.min, _downwardMovementConfig.fallSpeedRange.max);

			_player.movementVector.y = _verticalMovement;
		}
	}
}
