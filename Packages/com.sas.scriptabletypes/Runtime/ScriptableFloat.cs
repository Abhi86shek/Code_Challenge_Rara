using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/Float")]
    public class ScriptableFloat : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private float m_InitialValue = default;
        [NonSerialized] public float runtimeValue;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            runtimeValue = m_InitialValue;
        }
    }
}
