using UnityEngine;
using System;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/ReadOnly/String")]
    public class ScriptableReadOnlyString : ScriptableObject
    {
        [SerializeField] private string m_InitialValue = default;
        public string value => m_InitialValue;
      
    }
}
