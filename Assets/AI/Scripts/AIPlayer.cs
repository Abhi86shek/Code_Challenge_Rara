using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara.FSMCharacterController.AI
{
    public class AIPlayer : MonoBehaviour, ITargetSpawnedListener
    {
        internal ITarget Target { get; private set; }

        void Start()
        {
            var target = FindObjectOfType<Target>();
            if (target != null)
                Target = (ITarget)(object)target;
        }

        public void OnDespawn(ITarget target)
        {
            Target = null;
        }

        public void OnSpawn(ITarget target)
        {
            Target = target;
        }
    }
}
