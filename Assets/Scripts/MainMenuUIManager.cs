using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public void LoadRhythmGame()
    {
        SceneManager.LoadSceneAsync("Background_Test_Scene");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
