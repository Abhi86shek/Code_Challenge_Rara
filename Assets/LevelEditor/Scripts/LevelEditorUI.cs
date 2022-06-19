using SAS.StateMachineGraph.Utilities;
using SAS.Utilities.TagSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Rara.LevelEditor
{
    public class LevelEditorUI : MonoBase
    {
        class LevelObject
        {
            internal Item Item;
            internal GameObject gameObject;
            internal Vector3 initialPosition;
        }

        [SerializeField] LevelItemsConfig m_ItemsConfig;
        [SerializeField] ItemButton m_ItemButtonTemplate;
        [SerializeField] EventTrigger m_levelEditingEventTrigger;
        [FieldRequiresChild("Content")] private Transform _content;

        private List<LevelObject> _levelObjects = new List<LevelObject>();
        private Item _selectedItem;
        private bool _testMode = false;
        EventTrigger.Entry _entry = new EventTrigger.Entry();

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            foreach (var item in m_ItemsConfig.items)
            {
                var itemButton = Instantiate<ItemButton>(m_ItemButtonTemplate, _content);
                itemButton.Set(item, SelectItem);
            }

            _entry.eventID = EventTriggerType.PointerDown;
            _entry.callback.AddListener((data) => { PointerDown((PointerEventData)data); });
            m_levelEditingEventTrigger.triggers.Add(_entry);
        }

        private void SelectItem(Item item)
        {
            _selectedItem = item;
        }

        private void PointerDown(BaseEventData eventData)
        {
            if (_testMode)
                return;

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out var hit, 1000f))
            {
                if (_selectedItem != null && _selectedItem.TryInstantiate(out var gameObject))
                {
                   var activatables = gameObject.GetComponents<IActivatable>();
                    foreach (var activatable in activatables)
                    {
                        if (activatable != null)
                            activatable.Deactivate();
                    }
                    _levelObjects.Add(new LevelObject() { Item = _selectedItem, gameObject = gameObject, initialPosition = hit.point });
                    gameObject.transform.position = hit.point;
                }
            }
        }

        public void TestButtonAction()
        {
            m_levelEditingEventTrigger.triggers.Remove(_entry);
            _testMode = true;
            _selectedItem = null;
            foreach (var levelObject in _levelObjects)
            {
                var activatables = levelObject.gameObject.GetComponentsInChildren<IActivatable>(true);
                foreach (var activatable in activatables)
                {
                    if (activatable != null)
                        activatable.Activate();
                }
            }
        }

        public void PlaceButtonAction()
        {
            m_levelEditingEventTrigger.triggers.Add(_entry);
            _testMode = false;
            _selectedItem = null;
            foreach (var levelObject in _levelObjects)
            {
                if (levelObject.gameObject != null)
                {
                    levelObject.gameObject.SetActive(true);
                    var activatables = levelObject.gameObject.GetComponentsInChildren<IActivatable>(true);
                    foreach (var activatable in activatables)
                    {
                        if (activatable != null)
                            activatable.Deactivate();
                    }
                    levelObject.gameObject.transform.position = levelObject.initialPosition;
                }
            }
        }
    }
}
