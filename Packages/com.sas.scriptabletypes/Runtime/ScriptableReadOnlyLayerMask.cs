using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/ReadOnly/LayerMask")]
    public class ScriptableReadOnlyLayerMask : ScriptableObject
    {
        [SerializeField] private LayerMask m_InitialValue = default;
        public LayerMask value => m_InitialValue;
    }
}
