using System.Collections.Generic;
using Cinemachine;
using UnityEditor;
using UnityEngine;

namespace Aftermath
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Transform _world;
        [SerializeField] private CinemachineVirtualCamera _focusCam;
        [SerializeField] private InputReader _input;
        [SerializeField] private MenuButton _pauseButton;
        [SerializeField] private Player _player;

        [Space(10)]
        [EnumNamedList(typeof(LevelEnum))]
        [SerializeField] private List<Level> _levels;

        [SerializeField] private LevelEnum _currentLevel;
        [ReadOnly] [SerializeField] private Level _levelObject = null;

        [HideInInspector] public bool isPaused = false;
        private bool _focusMode = false;

        public static GameManager Instance;

        private bool _isPauseHovered = false;

        void Start()
        {
            Instance = this;
            if (_levelObject == null)
            {
                LoadCurrent();
            }

            _pauseButton.OnHighlighted += () => _isPauseHovered = true;
            _pauseButton.OnExit += () => _isPauseHovered = false;

            _input.OnCameraChange += CameraChange;
            _input.OnMouseClick += CheckPause;

            _player.Initialize();
            _input.Initialize();
        }

        void OnDestroy()
        {
            _input.OnCameraChange -= CameraChange;
            _input.OnMouseClick -= CheckPause;
        }

        [ContextMenu("Load Scene")]
        void LoadCurrent()
        {
            LoadLevel(_currentLevel);
        }

        void LoadLevel(LevelEnum level)
        {
            if (_levelObject != null)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    DestroyImmediate(_levelObject.gameObject);
                }
                else
#endif
                {
                    Destroy(_levelObject.gameObject);
                }
            }

            if((int)level < _levels.Count)
            {
                var lvl = _levels[(int)level];

#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    _levelObject = (Level) PrefabUtility.InstantiatePrefab(lvl, _world);
                    EditorUtility.SetDirty(_levelObject);
                }
                else
#endif
                {
                    _levelObject = Instantiate<Level>(lvl, _world);
                }
            }
            else
            {
                Debug.Log("Tryed to load a level not defined on the Level List");
            }
        }

        void NextLevel()
        {
            if (((LevelEnum)((int)_currentLevel + 1)) is LevelEnum lvl)
            {
                LoadLevel(lvl);
            }
            else
            {
                Debug.Log("Tryed to load a level out of the LevelEnum definition");
            }
        }

        void CameraChange()
        {
            _focusMode = !_focusMode;

            var priority = _focusMode ? 10 : 0;
            _focusCam.Priority = priority;
        }

        void CheckPause()
        {
            if (_isPauseHovered)
            {
                Pause();
            }
        }

        void Pause(bool value = true)
        {
            isPaused = value;
            Time.timeScale = value ? 0 : 1;
            _pauseButton.gameObject.SetActive(!value);
        }
    }

    public enum LevelEnum
    {
        Bhaskara,
    }
}
