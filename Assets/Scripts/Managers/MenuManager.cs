using UnityEngine.SceneManagement;
using UnityEngine;

namespace Aftermath
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private MenuButton _playButton;
        [SerializeField] private MenuButton _exitButton;
        [SerializeField] private InputReader _input;

        void Start()
        {
            _input.OnMouseClick += MouseClick;
            _input.Initialize();
            SoundPlayer.Instance.SetMusic(SoundPlayer.MusicEnum.Abertura, true);
        }

        void OnDestroy()
        {
            _input.OnMouseClick -= MouseClick;
        }

        void MouseClick()
        {
            Ray ray = Camera.main.ScreenPointToRay(_input.MousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                var button = hit.collider.gameObject.GetComponent<MenuButton>();
                if (button is null) return;

                if (button.Equals(_playButton))
                {
                    OnPlay();
                }
                else if (button.Equals(_exitButton))
                {
                    OnExit();
                }
            }
        }

        void OnPlay()
        {
            SceneManager.LoadScene("CutScene");
        }

        void OnExit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
