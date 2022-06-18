using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rara
{
    [CreateAssetMenu(fileName = "LevelItemsConfig", menuName = "Rara/Level/ItemsConfig")]
    public class LevelItemsConfig : ScriptableObject
    {
        public class Item
        {
            public string m_Name;
            public GameObject m_GameObject;
        }

        public Item[] items;
    }
}
