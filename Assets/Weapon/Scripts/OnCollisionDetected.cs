using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAS.Utilities.TagSystem;

namespace Rara.WeaponSystem
{
    public class OnCollisionDetected : MonoBase
    {
        [FieldRequiresParent] private IProjectile _projectile;

        private void OnCollisionEnter(Collision collision)
        {
            _projectile.OnCollision(collision);
        }
    }
}
