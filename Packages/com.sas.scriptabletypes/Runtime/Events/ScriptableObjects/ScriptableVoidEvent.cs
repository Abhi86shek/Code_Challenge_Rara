using UnityEngine;
using UnityEngine.Events;

namespace SAS.ScriptableTypes
{
	[CreateAssetMenu(menuName = "SAS/ScriptableTypes/Events/Void")]
	public class ScriptableVoidEvent : ScriptableEvent<Void>
	{
		[SerializeField] private event UnityAction m_OnEventRaised;

		public void Register(UnityAction action)
		{
			m_OnEventRaised += action;
		}

		public void Unregister(UnityAction action)
		{
			m_OnEventRaised -= action;
		}
		public void RaiseEvent()
		{
			m_OnEventRaised?.Invoke();
		}

	}
}


