using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private ImageColorChanger _imageColorChanger;

    private void Start()
    {
        ImageColorChanger.OnFinishFading += LoadRhythmGame;
    }

    private void OnDestroy()
    {
        ImageColorChanger.OnFinishFading -= LoadRhythmGame;
    }

    public void BeginFading()
    {
        _imageColorChanger.Play();
    }

    private void LoadRhythmGame()
    {
        SceneManager.LoadSceneAsync("Background_Test_Scene");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
