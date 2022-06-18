using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAS.Utilities.TagSystem;
using System;

namespace Rara.Collectables
{
    public class Flag : MonoBase, ICollectable<Flag>
    {
        [FieldRequiresSelf] Transform _transform;
        public void Collect()
        {
            ICollectable<Flag>.OnPicked?.Invoke(this);
        }
    }
}
