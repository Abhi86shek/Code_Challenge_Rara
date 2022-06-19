using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/Float")]
    public class ScriptableFloat : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private float m_InitialValue = default;
        [NonSerialized] public float value;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            value = m_InitialValue;
        }
    }
}
