using Rara.FSMCharacterController.Configs;
using SAS.StateMachineGraph;
using UnityEngine;

namespace Rara.FSMCharacterController
{
    public class HeadHitDetector : IStateAction
    {
        private Player _player;
        private CustomRaycast _raycast;
        private Collider _bodyCollider;

        void IStateAction.OnInitialize(Actor actor, string tag, string key, State state)
        {
            actor.TryGetComponent(out _player);
            actor.TryGetComponentInChildren(out _bodyCollider, tag);
            actor.TryGet(out _raycast, key);
        }

        void IStateAction.Execute(Actor actor)
        {
            if (_raycast.Raycast(_bodyCollider.bounds.center, _bodyCollider.bounds.extents.y))
            {
                actor.SetTrigger("HasHitHead");
            }
        }
    }
}
