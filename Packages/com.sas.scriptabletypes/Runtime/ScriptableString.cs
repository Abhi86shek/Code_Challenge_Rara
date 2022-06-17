using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/String")]
    public class ScriptableString : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private string m_InitialValue = default;
        [NonSerialized] public string runtimeValue;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            runtimeValue = m_InitialValue;
        }
    }
}
