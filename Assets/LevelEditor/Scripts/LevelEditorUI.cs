using SAS.ScriptableTypes;
using SAS.StateMachineGraph.Utilities;
using SAS.Utilities.TagSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

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
        [SerializeField] private ScriptableVoidEvent m_OnFlagCoinCollectedEvent;
        [SerializeField] ScriptableVoidEvent m_OnPlayerCollidedWithExplodableEvent;
        [FieldRequiresChild("Content")] private Transform _content;
        [FieldRequiresChild("Result", includeInactive = true)] Transform _resultScreen;
        [FieldRequiresChild("Result", includeInactive = true)] TMP_Text _result;
        [FieldRequiresChild("Play")] private Button _playButton;
        [FieldRequiresChild("LevelEdit")] private Button _levelEditButton;

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

            m_OnFlagCoinCollectedEvent?.Register(OnFlagCaptured);
            m_OnPlayerCollidedWithExplodableEvent?.Register(GameOver);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            m_OnFlagCoinCollectedEvent?.Unregister(OnFlagCaptured);
            m_OnPlayerCollidedWithExplodableEvent?.Unregister(GameOver);
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
            _levelEditButton.interactable = true;
            _playButton.interactable = false;
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
            _content.gameObject.SetActive(true);
            _levelEditButton.interactable = false;
            _playButton.interactable = true;
            CloseResultScreen();
            m_levelEditingEventTrigger.triggers.Add(_entry);
            _testMode = false;
            _selectedItem = null;
            foreach (var levelObject in _levelObjects)
            {
                if (levelObject.gameObject != null)
                {
                    var activatables = levelObject.gameObject.GetComponentsInChildren<IActivatable>(true);
                    foreach (var activatable in activatables)
                    {
                        if (activatable != null)
                            activatable.Deactivate();
                    }
                    levelObject.gameObject.transform.position = levelObject.initialPosition;
                    levelObject.gameObject.SetActive(true);
                }
            }
        }

        public void ReplayButtonAction()
        {
            CloseResultScreen();
            PlaceButtonAction();
            TestButtonAction();
        }

        private void OnFlagCaptured()
        {
            Debug.Log("Captured Flag! You Won.....");
            _result.text = "Captured Flag! You Won !";
            _resultScreen.gameObject.SetActive(true);
            Time.timeScale = 0; //Should handle the Game Pause in a better way.
        }

        private void GameOver()
        {
            _result.text = "Player Died!  Lost The Game !";
            _resultScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        private void CloseResultScreen()
        {
            Time.timeScale = 1;
            _resultScreen.gameObject.SetActive(false);
        }
    }
}
