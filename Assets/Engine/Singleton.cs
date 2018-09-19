using UnityEngine;

namespace Engine
{
    public class Singleton<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    var go = new GameObject(nameof(T));
                    instance = go.AddComponent<T>();

                    DontDestroyOnLoad(instance);
                    return instance;
                }

                return instance;
            }
        }
    }
}