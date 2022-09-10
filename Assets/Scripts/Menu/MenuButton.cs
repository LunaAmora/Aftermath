using System;
using UnityEngine;

namespace Aftermath
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private Material _unselected;
        [SerializeField] private Material _selected;

        private MeshRenderer _renderer;

        public Action OnHighlighted;
        public Action OnExit;

        void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        void OnMouseEnter()
        {
            _renderer.material = _selected;
            OnHighlighted?.Invoke();
        }

        void OnMouseExit()
        {
            _renderer.material = _unselected;
            OnExit?.Invoke();
        }
    }
}
