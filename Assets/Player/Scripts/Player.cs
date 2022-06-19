using Rara.Collectables;
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

        protected override void Start()
        {
            base.Start();
            ICollectable<Coin>.OnPicked += OnCoinCollected;
            ICollectable<Flag>.OnPicked += OnFlagCaptured;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            ICollectable<Coin>.OnPicked -= OnCoinCollected;
            ICollectable<Flag>.OnPicked -= OnFlagCaptured;
        }

        private void OnFlagCaptured(Flag obj)
        {
            Debug.Log("Captured Flag! You Won.....");
        }

        private void OnCoinCollected(Coin obj)
        {
            Debug.Log("Collected Coin");
        }

        private void OnEnterInExplodable(object explodable)
        {
            gameObject.SetActive(false);
        }
    }
}
