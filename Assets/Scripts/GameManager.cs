using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Aftermath
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Transform _world;
        [EnumNamedList(typeof(LevelEnum))]
        [SerializeField] private List<Level> _levels;

        [SerializeField] private LevelEnum _currentLevel;
        [ReadOnly] public Level _levelObject = null;

        [HideInInspector] public bool isPaused = false;

        public static GameManager Instance;

        void Start()
        {
            Instance = this;
            if (_levelObject == null)
            {
                LoadCurrent();
            }
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
    }

    public enum LevelEnum
    {
        Bhaskara,
    }
}
