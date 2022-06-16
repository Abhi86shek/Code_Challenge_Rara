using UnityEngine;
using System;
using SAS.Utilities;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/IntRange")]
    public class ScriptableIntRange : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private intRange m_InitialValue = default;
        [NonSerialized] public intRange runtimeValue;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            runtimeValue = m_InitialValue;
        }
    }
}
