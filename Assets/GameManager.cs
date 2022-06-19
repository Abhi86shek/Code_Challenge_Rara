using SAS.ScriptableTypes;
using SAS.Utilities.TagSystem;
using UnityEngine;

namespace Rara
{
    public class GameManager : MonoBase
    {
        [SerializeField] private ScriptableVoidEvent m_OnCoinCollectedEvent;
        [SerializeField] private ScriptableVoidEvent m_OnFlagCoinCollectedEvent;
        [SerializeField] ScriptableVoidEvent m_OnPlayerCollidedWithExplodableEvent;

        protected override void Start()
        {
            base.Start();
            m_OnCoinCollectedEvent?.Register(OnCoinCollected);
            m_OnFlagCoinCollectedEvent?.Register(OnFlagCaptured);
            m_OnPlayerCollidedWithExplodableEvent?.Register(GameOver);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            m_OnCoinCollectedEvent?.Unregister(OnCoinCollected);
            m_OnFlagCoinCollectedEvent?.Unregister(OnFlagCaptured);
            m_OnPlayerCollidedWithExplodableEvent?.Unregister(GameOver);
        }

        private void OnFlagCaptured()
        {
            Debug.Log("Captured Flag! You Won.....");
        }

        private void OnCoinCollected()
        {
            Debug.Log("Collected Coin");
        }

        private void GameOver()
        {

        }
    }
}
