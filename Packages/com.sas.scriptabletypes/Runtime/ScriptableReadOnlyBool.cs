using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/ReadOnly/Bool")]
    public class ScriptableReadOnlyBool : ScriptableObject
    {
        [SerializeField] private bool m_InitialValue = default;
        public bool value => m_InitialValue;
    }
}
