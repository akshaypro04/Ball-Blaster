using BallBlast.SpawnManager.parent;
using UnityEngine;
using UnityEngine.UI;
using BallBlast.Comman.Game;

namespace BallBlast.Comman.ButtonManage
{

    public class ButtonManager : MonoBehaviour
    {

        public Button StartButton;

        public void StartButtonPress()
        {
            GameManager.instances.SetTotalEnemiesValues(-GameManager.instances.GetTotalEnemiesValues());
            GameManager.instances.SetLevelUp(false);
            GameManager.instances.setplayerAlive(true);
            GameManager.instances.SetMainMenu(false);
            GameObject.Find("SpawnManager").GetComponent<SpawnerManager>().EnemySpawnner();
            GameManager.instances.Setgravity(0.3f);
            StartButton.gameObject.SetActive(false);
        }
    }
}