using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aftermath
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public bool isPaused = false;
        
        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
