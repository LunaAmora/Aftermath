using System;
using UnityEngine;

namespace Aftermath
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private MenuButton _playButton;
        [SerializeField] private MenuButton _exitButton;
        [SerializeField] private InputReader _input;

        public Action OnPlay;
        public Action OnExit;

        void Start()
        {
            _input.OnMouseClick += MouseClick;
            gameObject.SetActive(false);
        }

        void OnDestroy()
        {
            _input.OnMouseClick -= MouseClick;
        }

        void MouseClick()
        {
            if (!GameManager.Instance.isPaused) return;

            Ray ray = Camera.main.ScreenPointToRay(_input.MousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                var button = hit.collider.gameObject.GetComponent<MenuButton>();
                if (button is null) return;

                if (button.Equals(_playButton))
                {
                    OnPlay?.Invoke();
                }
                else if (button.Equals(_exitButton))
                {
                    OnExit?.Invoke();
                }
            }
        }
    }
}
