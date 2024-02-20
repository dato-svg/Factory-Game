using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components
{
    public class ExitSceneComponent : MonoBehaviour
    {
        [SerializeField] private string sceneName;


        public void OpenScene()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
