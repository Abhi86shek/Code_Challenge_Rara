using SAS.ScriptableTypes;
using SAS.StateMachineGraph;
using SAS.Utilities.TagSystem;
using UnityEngine;

namespace Rara.FSMCharacterController.AI
{
    public class IsInRange : IStateAction
    {
        [FieldRequiresSelf] Transform _aiPlayerTransform;
        private ScriptableReadOnlyFloat _range;
        private ScriptableReadOnlyString _paramKey;
        private ScriptableReadOnlyLayerMask _playerLayer;

        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.Initialize(this);
            actor.TryGet(out _range, key);
            actor.TryGet(out _paramKey, key);
            actor.TryGet(out _playerLayer, "Player");
        }

        void IStateAction.Execute(Actor actor)
        {
            actor.SetBool(_paramKey.value, Physics.CheckSphere(_aiPlayerTransform.position, _range.value, _playerLayer.value));
        }

    }
}
