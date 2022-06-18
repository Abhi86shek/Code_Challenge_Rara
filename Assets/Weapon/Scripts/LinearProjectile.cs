using SAS.Pool;
using SAS.Utilities.TagSystem;
using UnityEngine;

namespace Rara.WeaponSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class LinearProjectile : Poolable, IProjectile, ISpawnable
    {
        [SerializeField] private float m_Speed = 10;
        [FieldRequiresSelf] private Rigidbody _rigidbody;

        public void Trigger()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = transform.forward * m_Speed;
        }

        private void FixedUpdate()
        {
            if (!_rigidbody.isKinematic)
                _rigidbody.velocity = transform.forward * m_Speed;
        }

        public void OnCollision(Collision other)
        {
            this.Destroy();
        }

        public void OnSpawn()
        {
        }

        public void OnDespawn()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
        }
    }
}
