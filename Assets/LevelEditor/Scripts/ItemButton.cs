using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SAS.Utilities.TagSystem;
using System;

namespace Rara.LevelEditor
{
    public class ItemButton : MonoBase
    {
        [FieldRequiresChild] private TMP_Text _displayText;
        private Item _item;
        Action<Item> _onButtonClicked;

        public void Set(Item item, Action<Item> onItemClicked)
        {
            _item = item;
            _displayText.text = _item.DisplayName;
            _onButtonClicked = onItemClicked;
        }

        public void ClickButton()
        {
            _onButtonClicked?.Invoke(_item);
        }
    }
}
