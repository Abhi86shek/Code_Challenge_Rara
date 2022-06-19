using UnityEngine;
using System;
using SAS.Utilities;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/ReadOnly/FloatRange")]
    public class ScriptableReadOnlyFloatRange : ScriptableObject
    {
        [SerializeField] private floatRange m_InitialValue = default;
        public floatRange value => m_InitialValue;
    }
}
