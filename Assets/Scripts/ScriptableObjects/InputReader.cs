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
        public event Action OnMouseRelease;
        public event Action OnCameraChange;

        public Vector2 MousePos {get; private set;}

        private static GameInput _gameInput;

        private bool InputActive()
        {
            var gm = GameManager.Instance;
            return (gm is null || !gm.isPaused);
        }

        public void Initialize()
        {
            if (_gameInput == null)
            {
                _gameInput = new GameInput();
                _gameInput.Battle.SetCallbacks(this);
                _gameInput.Enable();
            }
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (context.started) OnMouseClick?.Invoke();
            else if (context.canceled) OnMouseRelease?.Invoke();
        }

        public void OnLeftClick(InputAction.CallbackContext context)
        {
            if (InputActive())
            {
                OnCameraChange?.Invoke();
            }
        }

        public void OnMousePos(InputAction.CallbackContext context)
        {
            if (InputActive())
            {
                MousePos = context.ReadValue<Vector2>();
                OnMouseMove?.Invoke(MousePos);
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (InputActive())
            {
                OnMoveDirection?.Invoke(context.ReadValue<Vector2>());
            }
        }
    }
}
