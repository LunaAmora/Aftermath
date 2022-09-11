using UnityEngine.SceneManagement;
using UnityEngine;

namespace Aftermath
{
    public class CutsceneManager : MonoBehaviour
    {
        [SerializeField] private InputReader _input;
        [SerializeField] MenuButton _skip;

        private bool _hovered = false;

        void Start()
        {
            _skip.OnHighlighted += () => _hovered = true;
            _skip.OnExit += () => _hovered = false;
            _input.OnMouseClick += MouseClick;

            SoundPlayer.Instance.SetMusic(SoundPlayer.MusicEnum.Cutsene);
            SoundPlayer.Instance.OnMusicEnd += ChangeScene;
        }

        void OnDestroy()
        {
            _input.OnMouseClick -= MouseClick;
        }

        void MouseClick()
        {
            if (_hovered) ChangeScene();
        }

        void ChangeScene()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
