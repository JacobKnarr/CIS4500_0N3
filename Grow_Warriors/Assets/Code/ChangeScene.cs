using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    Scene currentScene;
    public void NextScene()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "App")
        {
            SceneManager.LoadScene("Minigame", LoadSceneMode.Single);
            //SceneManager.UnloadSceneAsync("App");
        }
        else
        {
            SceneManager.LoadScene("App", LoadSceneMode.Single);
        }
    }
}
