using System;
using UnityEngine;

namespace SAS.ScriptableTypes
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/Transform")]
    public class ScriptableTransform : ScriptableObject, IProperty
    {
        [HideInInspector] public Transform value { get; set; }

        public void Set(Transform transform) 
        {
            value = transform;
        }

        public void Clear()
        {
            value = null;
        }
    }
}