using UnityEngine;
using SAS.ScriptableTypes;

namespace Rara.Obstacles
{
    public class Mine : MonoBehaviour, IExplodable
    {
        [SerializeField] ScriptableLayerMask m_Player;

        public void Explode()
        {
            Debug.Log("Explode...");
        }

        private void OnTriggerEnter(Collider other)
        {
            if ((1 << other.gameObject.layer) == m_Player.runtimeValue.value)
            {
                Destroy(other.transform.root.gameObject);
                Explode();
            }
        }
    }
}
