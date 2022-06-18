using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara.LevelEditor
{
    [System.Serializable]
    public class Item
    {
        [SerializeField] private string m_Name;
        [SerializeField] private string m_DisplayName;
        [SerializeField] private GameObject m_GameObject;
        [SerializeField] private int m_MaxCount;

        [System.NonSerialized] private int _usedCount = 0;

        public bool TryInstantiate(out GameObject gameObject)
        {
            gameObject = null;
            if (_usedCount != m_MaxCount)
            {
                gameObject = Object.Instantiate(m_GameObject);
                _usedCount++;
                return true;
            }
            return false;
        }

        public string DisplayName => m_DisplayName;
    }

    [CreateAssetMenu(fileName = "LevelItemsConfig", menuName = "Rara/Level/ItemsConfig")]
    public class LevelItemsConfig : ScriptableObject
    {

        public Item[] items;
    }
}
