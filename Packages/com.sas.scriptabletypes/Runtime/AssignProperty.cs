using UnityEngine;

namespace SAS.ScriptableTypes
{
    interface IProperty
    {
        void Set(Transform transform);
    }

    public class AssignProperty : MonoBehaviour
    {
        [SerializeField] private ScriptableObject m_Property = default;

        private void Awake()
        {
            (m_Property as IProperty).Set(transform);
            Destroy(this);
        }
    }
}
