using UnityEngine.Events;
using UnityEngine;

namespace SAS.ScriptableTypes
{
	public abstract class ScriptableEvent<T> : ScriptableObject
	{
		private event UnityAction<T> m_OnEventRaised;

		public void Register(UnityAction<T> action)
		{
			m_OnEventRaised += action;
		}

		public void Unregister(UnityAction<T> action)
		{
			m_OnEventRaised -= action;
		}

		public void RaiseEvent(T value)
		{
			m_OnEventRaised?.Invoke(value);
		}
	}
}
