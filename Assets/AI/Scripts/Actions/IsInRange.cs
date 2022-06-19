using SAS.ScriptableTypes;
using SAS.StateMachineGraph;
using SAS.Utilities.TagSystem;
using UnityEngine;

namespace Rara.FSMCharacterController.AI
{
    public class IsInRange : IStateAction
    {
        [FieldRequiresSelf] Transform _aiPlayerTransform;
        private ScriptableFloat _range;
        private ScriptableString _paramKey;
        private ScriptableLayerMask _playerLayer;

        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.Initialize(this);
            actor.TryGet(out _range, key);
            actor.TryGet(out _paramKey, key);
            actor.TryGet(out _playerLayer, "Player");
        }

        void IStateAction.Execute(Actor actor)
        {
            actor.SetBool(_paramKey.runtimeValue, Physics.CheckSphere(_aiPlayerTransform.position, _range.runtimeValue, _playerLayer.runtimeValue));
        }

    }
}
