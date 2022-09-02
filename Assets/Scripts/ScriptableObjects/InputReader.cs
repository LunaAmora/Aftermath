using UnityEngine.InputSystem;
using UnityEngine;
using System;

namespace Aftermath
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Aftermath/Input Reader")]
    public class InputReader : ScriptableObject,
        GameInput.IBattleActions
    {
        public event Action<Vector2> OnMoveDirection;
        public event Action<Vector2> OnMouseMove;
        public event Action OnMouseClick;

        private GameInput _gameInput;

        public void Initialize()
        {
            if (_gameInput == null)
            {
                _gameInput = new GameInput();
                _gameInput.Battle.SetCallbacks(this);
            }
            _gameInput.Enable();
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.isPaused)
            {
                OnMouseClick?.Invoke();
            }
        }

        public void OnMousePos(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.isPaused)
            {
                OnMouseMove?.Invoke(context.ReadValue<Vector2>());
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.isPaused)
            {
                OnMoveDirection?.Invoke(context.ReadValue<Vector2>());
            }
        }
    }
}
