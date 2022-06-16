using UnityEngine;
using System;
using SAS.Utilities;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/FloatRange")]
    public class ScriptableFloatRange : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private floatRange m_InitialValue = default;
        [NonSerialized] public floatRange runtimeValue;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            runtimeValue = m_InitialValue;
        }
    }
}
