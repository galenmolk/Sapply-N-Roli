using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const string GAME_SCENE_NAME = "Saply";
    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }
}
