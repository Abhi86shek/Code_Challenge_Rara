using SAS.StateMachineGraph;
using SAS.Utilities.TagSystem;
using System;
using UnityEngine;

namespace Rara.FSMCharacterController
{
    [RequireComponent(typeof(Actor)), DisallowMultipleComponent]
    public class Player : MonoBase
    {
        [NonSerialized] public Vector3 movementVector;
        [NonSerialized] public Vector3 movementInput;

        [FieldRequiresChild("Head")] private Transform _lookAtTransform;
        public float NormalizedMoveInput => movementInput.magnitude;
        
        private Actor _actor;

        public Actor Actor 
        {
            get
            {
                if (_actor == null)
                    _actor = GetComponent<Actor>();
                return _actor;
            }
        }

        private bool _isGrounded = true;
        public bool IsGrounded
        {
            get { return _isGrounded; }
            internal set
            {
                _isGrounded = value;
                Actor.SetBool("IsGrounded", _isGrounded);
            }
        }

        public Transform LookAtTransform => _lookAtTransform;

        public void OnMove(float normalizedMoveInput)
        {
            Actor.SetFloat("NormalizedMoveInput", (float)Math.Round(normalizedMoveInput, 2));
        }

        public void OnJumpInitiated()
        {
            Actor.SetBool("Jump", true);
        }

        public void OnJumpCanceled()
        {
            Actor.SetBool("Jump", false);
        }
    }
}
