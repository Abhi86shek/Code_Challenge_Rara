using UnityEngine;
using System;
using SAS.Utilities;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/FloatRange")]
    public class ScriptableFloatRange : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private floatRange m_InitialValue = default;
        [NonSerialized] public floatRange value;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            value = m_InitialValue;
        }
    }
}
