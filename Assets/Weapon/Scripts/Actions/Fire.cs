using SAS.StateMachineGraph;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara.WeaponSystem
{
	public class Fire : IStateAction
	{
		private IWeapon _weapon;
        public void OnInitialize(Actor actor, string tag, string key, State state)
        {
			actor.TryGetComponentInChildren(out _weapon, tag);
        }

        public void Execute(Actor actor)
        {
			_weapon.Trigger();
        }
	}
}
