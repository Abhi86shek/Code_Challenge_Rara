using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using Rara.FSMCharacterController;
using SAS.ScriptableTypes;

namespace Rara.FSMCharacterController.Input
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private InputConfig m_InputConfig;
        [SerializeField] private float m_targetSpeedReachMultplier = 5;
        [SerializeField] private ScriptableVoidEvent m_OnGameOver;

        private float _previousSpeed;
        private Vector2 _inputVector;
        private Player _player;
        private float _targetValue = 1;

        Action<CallbackContext> _jumpPerformed;
        Action<CallbackContext> _jumpCanceled;

        void Awake()
        {
            _player = GetComponent<Player>();
        }

        void OnEnable()
        {
            m_OnGameOver?.Register(ResetInput);
            var moveInputAction = m_InputConfig.GetInputAction("Move");
            moveInputAction.Enable();
            moveInputAction.started += OnMove;
            moveInputAction.performed += OnMove;
            moveInputAction.canceled += OnMove;

            var jumpInputAction = m_InputConfig.GetInputAction("Jump");
            jumpInputAction.Enable();

            _jumpPerformed = _ => _player.OnJumpInitiated();
            _jumpCanceled = _ => _player.OnJumpCanceled();

            jumpInputAction.performed += _jumpPerformed;
            jumpInputAction.canceled += _jumpCanceled;
        }


        private void OnDisable()
        {
            m_OnGameOver?.Unregister(ResetInput);
            var moveInputAction = m_InputConfig.GetInputAction("Move");
            moveInputAction.started -= OnMove;
            moveInputAction.performed -= OnMove;
            moveInputAction.canceled -= OnMove;

            var jumpInputAction = m_InputConfig.GetInputAction("Jump");
            jumpInputAction.performed -= _jumpPerformed;
            jumpInputAction.canceled -= _jumpCanceled;
            _inputVector = Vector2.zero;
            _previousSpeed = 0;
        }

        private void Update() => ProcessMovementInput();

        private void ProcessMovementInput()
        {
            Vector3 adjustedMovement = new Vector3(_inputVector.x, 0f, _inputVector.y);

            //Fix to avoid getting a Vector3.zero vector, which would result in the player turning to x:0, z:0
            if (_inputVector.sqrMagnitude == 0.0f)
                adjustedMovement = _player.transform.forward * (adjustedMovement.magnitude + .01f);

            //Accelerate/decelerate
            var targetSpeed = Mathf.Clamp01(_inputVector.magnitude);

            targetSpeed = Mathf.Lerp(_previousSpeed, targetSpeed, Time.deltaTime * m_targetSpeedReachMultplier);
            _player.movementInput = adjustedMovement.normalized * targetSpeed;
            _player.OnMove(targetSpeed);
            _previousSpeed = targetSpeed;
        }

        private void OnMove(InputAction.CallbackContext value)
        {
            _inputVector = value.ReadValue<Vector2>();
        }

        private void ResetInput()
        {
            _inputVector = Vector2.zero;
            _previousSpeed = 0;
        }
    }
}
