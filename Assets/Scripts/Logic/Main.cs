using System.Collections;
using UnityEngine;

namespace LockstepFramework {
    public static class Main {
        class Behaviour : MonoBehaviour {
            void Update() {
                FrameManager.Instance.Update();
            }
        }

        public static GameObject gameObject { get; internal set; }
        private static Behaviour behaviour { get; set; }

        [RuntimeInitializeOnLoadMethod]
        static void Initialized() {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0)
                return;

            gameObject = new GameObject("Main");
            behaviour = gameObject.AddComponent<Behaviour>();
            Object.DontDestroyOnLoad(gameObject);
        }

        public static Coroutine StartCoroutine(IEnumerator routine) {
            return behaviour.StartCoroutine(routine);
        }
    }
}