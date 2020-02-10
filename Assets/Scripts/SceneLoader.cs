using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// This function loads the scene with the given name
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
