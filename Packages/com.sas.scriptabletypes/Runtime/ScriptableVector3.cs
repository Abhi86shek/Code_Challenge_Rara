using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/Vector3")]
    public class ScriptableVector3 : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private Vector3 m_InitialValue = default;
        [NonSerialized] public Vector3 runtimeValue;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            runtimeValue = m_InitialValue;
        }
    }
}
