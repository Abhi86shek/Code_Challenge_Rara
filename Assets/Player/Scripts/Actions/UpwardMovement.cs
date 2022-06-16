using Rara.FSMCharacterController.Configs;
using SAS.StateMachineGraph;
using UnityEngine;

namespace Rara.FSMCharacterController
{
	public class UpwardMovement : IStateAction
	{
		private Player _player;
		private UpwardMovementConfig _upwardMovementConfig = default;

		private float _gravityContributionMultiplier;
		private float _verticalMovement;

		void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
		{
			actor.TryGet(out _upwardMovementConfig, key);
			actor.TryGetComponent(out _player);
			state.OnEnterEvent += () =>
			{
				_gravityContributionMultiplier = 0;
				_verticalMovement = _upwardMovementConfig.jumpForce;

			};
		}

		void IStateAction.Execute(Actor actor)
		{
			_gravityContributionMultiplier += _upwardMovementConfig.gravityComebackMultiplier;
			_gravityContributionMultiplier *= _upwardMovementConfig.gravityDivider; //Reduce the gravity effect
			_verticalMovement += Physics.gravity.y * _upwardMovementConfig.gravityMultiplier * Time.deltaTime * _gravityContributionMultiplier;
			
			_player.movementVector.y = _verticalMovement;
		}
	}
}
