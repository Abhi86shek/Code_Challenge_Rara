using SAS.ScriptableTypes;
using SAS.Utilities.TagSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara.Collectables
{
    public abstract class BaseCollectable<T> : MonoBase, ICollectable<BaseCollectable<T>>
    {
        [FieldRequiresSelf] protected Transform _transform;
        [SerializeField] ScriptableVoidEvent m_OnCollectedEvent;
        public virtual void Collect()
        {
            m_OnCollectedEvent?.RaiseEvent();
        }
    }
}
