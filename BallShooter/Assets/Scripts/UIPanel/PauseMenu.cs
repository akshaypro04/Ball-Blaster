using UnityEngine;
using UnityEngine.SceneManagement;
using BallBlast.Comman.Game;

namespace BallBlast.UI.Pause
{
    public class PauseMenu : MonoBehaviour
    {
        bool GameIsPause;
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameObject AudioControl;
        [SerializeField] GameObject EndingTrastion;

        public void resume()
        {
            if (GameIsPause == false)
                return;

            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPause = false;
            GameManager.instances.SetPause(false);
        }

        public void pause()
        {
            if (GameIsPause == true)
                return;

            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            GameIsPause = true;
            GameManager.instances.SetPause(true);
        }

        public void Menu()
        {
            EndingTrastion.SetActive(true);
            GameManager.instances.setplayerAlive(false);
            GameManager.instances.SetMainMenu(true);
            GameManager.instances.SetNumEnemies(0);
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);

            if (GameIsPause)
                GameManager.instances.SetHighScore(0);

        }

        public void Sound()
        {
            AudioControl.SetActive(true);
        }

        public void Quit()
        {
            GameManager.instances.SetHighScore(0);
            Application.Quit();
        }

        void OnApplicationPause()
        {
            pause();
        }

    }
}