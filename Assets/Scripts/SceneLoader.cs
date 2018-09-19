using Engine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}