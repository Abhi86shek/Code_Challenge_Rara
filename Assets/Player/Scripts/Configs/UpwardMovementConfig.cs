using UnityEngine;

namespace Rara.FSMCharacterController.Configs
{
    [CreateAssetMenu(menuName = "Rara/State Machine Character Controller/Upward Movement Config")]
    public class UpwardMovementConfig : ScriptableObject
    {
        public float jumpForce = 6;
        public float gravityMultiplier = 5;
        public float gravityComebackMultiplier =0.03f;
        public float gravityDivider = 0.6f;
    }
}
