﻿using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/LayerMask")]
    public class ScriptableLayerMask : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private LayerMask m_InitialValue = default;
        public LayerMask runtimeValue { get; private set; }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            runtimeValue = m_InitialValue;
        }
    }
}
