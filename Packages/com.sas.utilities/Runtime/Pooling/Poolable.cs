using SAS.Utilities.TagSystem;
using UnityEngine;

namespace SAS.Pool
{
    public abstract class Poolable : MonoBase
    {
        internal SpawnablePoolSO ObjectPool { get; set; }
        [FieldRequiresChild] protected ISpawnable[] _spawnables;

        public void Destroy()
        {
            if (ObjectPool != null)
                ObjectPool.Despawn(this);
        }

        internal void OnSpawn()
        {
            foreach (var spawnable in _spawnables)
                spawnable.OnSpawn();
        }

        internal void OnDespawn()
        {
            foreach (var spawnable in _spawnables)
                spawnable.OnDespawn();
        }
    }
}
