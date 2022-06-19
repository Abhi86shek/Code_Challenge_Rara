using UnityEngine;
using System;
using SAS.Utilities;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/IntRange")]
    public class ScriptableReadOnlyIntRange : ScriptableObject
    {
        [SerializeField] private intRange m_InitialValue = default;
        public intRange value => m_InitialValue;
    }
}
