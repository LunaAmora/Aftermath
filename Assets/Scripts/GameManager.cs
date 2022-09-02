using UnityEngine;

namespace Aftermath
{
    public class GameManager : MonoBehaviour
    {
        public bool isPaused = false;

        public static GameManager Instance;

        void Start()
        {
            Instance = this;
        }

        void Update()
        {

        }
    }
}
