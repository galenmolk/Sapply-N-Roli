using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class PauseMenu : MonoBehaviour
    {
        public void Resume()
        {
            PauseMenuController.Instance.Resume();
        }

        public void MainMenu()
        {
            PauseMenuController.Instance.MainMenu();
        }
    }
}
