using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara.WeaponSystem
{
    public interface IProjectile
    {
        void Trigger();
        void OnCollision(Collision other);
    }
}
