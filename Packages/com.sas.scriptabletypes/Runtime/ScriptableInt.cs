using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/Integer")]
    public class ScriptableInt : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private int m_InitialValue = default;
        [NonSerialized] public int value;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {

        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            value = m_InitialValue;
        }
    }
}
