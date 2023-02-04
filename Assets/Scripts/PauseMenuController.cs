using UnityEngine;
using UnityEngine.SceneManagement;
using BramblyMead;

namespace GGJ
{
    public class PauseMenuController : Singleton<PauseMenuController>
    {
        private const string MENU_SCENE_NAME = "Menu";

        [SerializeField] private GameObject pauseMenuPrefab;
        private GameObject pauseMenuInstance;

        private bool isPaused;

        private void Awake() 
        {
            InputManager.OnPauseMenuToggled += HandlePauseMenuToggled;
        }

        private void OnDisable()
        {
            InputManager.OnPauseMenuToggled -= HandlePauseMenuToggled;
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
            pauseMenuInstance = Instantiate(pauseMenuPrefab, transform);
        }

        public void Resume()
        {
            isPaused = false;
            Time.timeScale = 1f;
            Destroy(pauseMenuInstance);
        }

        public void MainMenu()
        {
            isPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(MENU_SCENE_NAME);
        }
    }
}
