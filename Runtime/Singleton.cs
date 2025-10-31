using UnityEngine;

namespace Utils.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        protected static T instance;

        public static bool HasInstance => instance != null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindAnyObjectByType<T>();
                    if (instance == null)
                    {
                        var go = new GameObject(typeof(T).Name + " Auto-Generated");
                        instance = go.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            InitializeSingleton();
        }

        public static T TryGetInstance()
        {
            return HasInstance ? instance : null;
        }

        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying) return;

            instance = this as T;
        }
    }
}
