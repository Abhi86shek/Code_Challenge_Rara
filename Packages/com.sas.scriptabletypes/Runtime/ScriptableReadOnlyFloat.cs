using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/ReadOnly/Float")]
    public class ScriptableReadOnlyFloat : ScriptableObject
    {
        [SerializeField] private float m_InitialValue = default;
        public float value => m_InitialValue;
    }
}
