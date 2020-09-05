using System.Collections;
using UnityEngine;
using BallBlast.Comman.Game;

namespace BallBlast.SpawnManager.parent
{
    public class SpawnerManager : MonoBehaviour
    {

        [SerializeField] Transform Enemy1;
        [SerializeField] Transform Enemy2;
        [SerializeField] Transform Enemy3;
        [SerializeField] Transform position1;
        [SerializeField] Transform position2;

        public void EnemySpawnner()                                                      // it alsp callled from enemy destory
        {
            if (GameManager.instances.GetTotalEnemiesValues() >= GameManager.instances.GetValueToWin())
                return;


            if (GameManager.instances.getNumEnemies() >= GameManager.instances.getEnemyLimit())
                return;

            StartCoroutine(spawnEnemies());
        }

        IEnumerator spawnEnemies()
        {
            yield return new WaitForSeconds(3f);
            {
                Transform[] SPositions = { position1, position2 };
                int ramdomSpawnIndex = Random.Range(0, SPositions.Length);
                int ramdomSize = Random.Range(1, 4);
                switch (ramdomSize)
                {
                    case 1:
                        var smallEnemy = Instantiate(Enemy1, SPositions[ramdomSpawnIndex].position, SPositions[ramdomSpawnIndex].rotation);
                        smallEnemy.transform.SetParent(SPositions[ramdomSpawnIndex]);
                        break;

                    case 2:
                        var MediumEnemy = Instantiate(Enemy2, SPositions[ramdomSpawnIndex].position, SPositions[ramdomSpawnIndex].rotation);
                        MediumEnemy.transform.SetParent(SPositions[ramdomSpawnIndex]);
                        break;

                    case 3:
                        var bigEnemy = Instantiate(Enemy3, SPositions[ramdomSpawnIndex].position, SPositions[ramdomSpawnIndex].rotation);
                        bigEnemy.transform.SetParent(SPositions[ramdomSpawnIndex]);
                        break;

                    default:
                        print("out of range");
                        break;
                }
            }
        }
    }
}
