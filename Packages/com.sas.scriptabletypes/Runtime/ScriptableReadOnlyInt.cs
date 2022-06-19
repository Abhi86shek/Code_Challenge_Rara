using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/ReadOnly/Integer")]
    public class ScriptableReadOnlyInt : ScriptableObject
    {
        [SerializeField] private int m_InitialValue = default;
        public int value => m_InitialValue;
    }
}
