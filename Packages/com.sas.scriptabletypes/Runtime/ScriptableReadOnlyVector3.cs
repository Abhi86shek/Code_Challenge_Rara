using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/ReadOnly/Vector3")]
    public class ScriptableReadOnlyVector3 : ScriptableObject
    {
        [SerializeField] private Vector3 m_InitialValue = default;
        public Vector3 value => m_InitialValue;
    }
}
