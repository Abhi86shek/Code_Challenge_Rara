using UnityEngine;

namespace Rara.FSMCharacterController.Configs
{
	[CreateAssetMenu(fileName = "AerialMovement", menuName = "Rara/State Machine Character Controller/Aerial Movement")]
	public class AerialMovementConfig : ScriptableObject
	{
		public float speed = 7;
		public float acceleration = 30;
		public float airResistance = 5f;
	}
}