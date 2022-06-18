using SAS.Pool;
using SAS.Utilities.TagSystem;
using UnityEngine;

namespace Rara.WeaponSystem
{
	public class TimedSelfDespawner : MonoBase
	{
		[SerializeField] private float m_Lifetime = 30.0f;
		private float lifeTimer = 0.0f;
		[FieldRequiresSelf] private Poolable _spawnable;

        private void Update()
		{
			lifeTimer += Time.deltaTime;

			if (lifeTimer >= m_Lifetime)
			{
				lifeTimer = 0;
				if (_spawnable != null)
					_spawnable.Destroy();
				else
					Destroy(gameObject);
			}
		}
	}
}
