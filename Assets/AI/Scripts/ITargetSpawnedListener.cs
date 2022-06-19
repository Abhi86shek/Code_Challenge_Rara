using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara.FSMCharacterController.AI
{
	public interface ITargetSpawnedListener
	{
		void OnSpawn(ITarget target);
		void OnDespawn(ITarget target);
	}
}