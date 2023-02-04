using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ
{
    public class PauseMenu : MonoBehaviour
    {
        private const string MENU_SCENE_NAME = "Menu";

        [SerializeField] private GameObject pauseMenu;

        private bool isPaused;

        private void Awake() 
        {
            InputManager.OnPauseMenuToggled += HandlePauseMenuToggled;
        }

        private void OnDestroy()
        {
            InputManager.OnPauseMenuToggled += HandlePauseMenuToggled;
        }

        private void HandlePauseMenuToggled()
        {
            if (isPaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }

        private void Pause()
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }

        public void Resume()
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }

        public void MainMenu()
        {
            isPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(MENU_SCENE_NAME);
        }
    }
}
