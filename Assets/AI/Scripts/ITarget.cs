using UnityEngine;

namespace Rara.FSMCharacterController.AI
{
    public interface ITarget
    {
        Transform Transform { get; }
        bool IsActive();
    }
}
