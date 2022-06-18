using SAS.Pool;
using UnityEngine;

namespace Rara.WeaponSystem
{
	public class ProjectileWeapon : MonoBehaviour, IWeapon
	{
		[SerializeField] private SpawnablePoolSO m_ProjectilePool;
		[SerializeField] private Transform m_ProjectileSpawnSpot;

		void Awake()
        {
			m_ProjectilePool.Initialize(10);
			if (m_ProjectileSpawnSpot == null)
				m_ProjectileSpawnSpot = transform;
        }
		public void Trigger()
		{
			var projectile = m_ProjectilePool.Spawn();
			projectile.transform.position = m_ProjectileSpawnSpot.position;
			projectile.transform.rotation = m_ProjectileSpawnSpot.rotation;
			(projectile as IProjectile).Trigger();
		}
	}
}
