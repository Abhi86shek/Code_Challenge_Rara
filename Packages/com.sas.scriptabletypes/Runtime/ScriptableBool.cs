using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/Bool")]
    public class ScriptableBool : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private bool m_InitialValue = default;
        [NonSerialized] public bool runtimeValue;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            runtimeValue = m_InitialValue;
        }
    }
}
