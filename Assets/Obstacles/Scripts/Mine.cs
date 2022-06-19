using UnityEngine;
using SAS.ScriptableTypes;

namespace Rara.Obstacles
{
    public class Mine : MonoBehaviour, IExplodable
    {
        [SerializeField] ScriptableReadOnlyLayerMask m_Player;
        [SerializeField] ScriptableVoidEvent m_OnCollisionEvent;
        public void Explode()
        {
            Debug.Log("Explode...");
        }

        private void OnTriggerEnter(Collider other)
        {
            if ((1 << other.gameObject.layer) == m_Player.value.value)
            {
                other.transform.root.gameObject.SendMessage("OnEnterInExplodable", this, SendMessageOptions.DontRequireReceiver);
                m_OnCollisionEvent?.RaiseEvent();
                Explode();
            }
        }
    }
}
