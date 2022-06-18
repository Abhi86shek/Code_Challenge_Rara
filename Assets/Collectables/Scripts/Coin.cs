using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAS.Utilities.TagSystem;
using System;

namespace Rara.Collectables
{
    public class Coin : MonoBase, ICollectable<Coin>
    {
        [FieldRequiresSelf] Transform _transform;

        public void Collect()
        {
            ICollectable<Coin>.OnPicked?.Invoke(this);
            _transform.gameObject.SetActive(false);
        }
    }
}
