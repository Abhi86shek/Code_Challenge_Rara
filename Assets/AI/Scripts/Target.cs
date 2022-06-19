using SAS.Utilities.TagSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara.FSMCharacterController.AI
{
    public class Target : MonoBase, ITarget
    {
        [FieldRequiresChild("Head")] private Transform _lookAtTransform;
        public Transform Transform => _lookAtTransform;

        public bool IsActive()
        {
            if (this == null)
                return false;

            return gameObject.activeInHierarchy;
        }
    }
}
