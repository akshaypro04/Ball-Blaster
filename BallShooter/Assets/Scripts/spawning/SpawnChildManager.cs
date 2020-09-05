using UnityEngine;
using BallBlast.Comman.Game;

namespace BallBlast.SpawnManager.child
{
    public class SpawnChildManager : MonoBehaviour
    {

        [SerializeField] GameObject mediumEnemy;
        [SerializeField] GameObject smallEenmy;
        [SerializeField] GameObject coins;
        int enemynum;
        Transform enemyTransform;

        float xpower = 1.75f;
        float ypower = 4f;

        public void SpawnChildren(int enemyType, Transform enemy)
        {
            if (GameManager.instances.GetTotalEnemiesValues() >= GameManager.instances.GetValueToWin())
                return;

            if (GameManager.instances.getNumEnemies() >= GameManager.instances.getEnemyLimit())
                return;

            enemynum = enemyType;
            enemyTransform = enemy;
            switch (enemynum)
            {

                case 3:
                    GameObject mright = Instantiate(mediumEnemy, enemyTransform.transform.position, enemyTransform.transform.rotation);
                    mright.GetComponent<Rigidbody2D>().AddForce((Vector2.up) * ypower + (Vector2.right) * xpower, ForceMode2D.Impulse);
                    GameObject mleft = Instantiate(mediumEnemy, enemyTransform.transform.position, enemyTransform.transform.rotation);
                    mleft.GetComponent<Rigidbody2D>().AddForce((Vector2.up) * ypower - (Vector2.right) * xpower, ForceMode2D.Impulse);
                    break;

                case 2:
                    GameObject sright = Instantiate(smallEenmy, enemyTransform.transform.position, enemyTransform.transform.rotation);
                    sright.GetComponent<Rigidbody2D>().AddForce((Vector2.up) * ypower + (Vector2.right) * xpower, ForceMode2D.Impulse);
                    GameObject sleft = Instantiate(smallEenmy, enemyTransform.transform.position, enemyTransform.transform.rotation);
                    sleft.GetComponent<Rigidbody2D>().AddForce((Vector2.up) * ypower - (Vector2.right) * xpower, ForceMode2D.Impulse);
                    break;

                default:
                    print("out of range");
                    break;
            }
        }

        public void SpawnCoin(Transform enemy)
        {
            enemyTransform = enemy;

            GameObject coin = Instantiate(coins, enemyTransform.transform.position, enemyTransform.transform.rotation);
            coin.GetComponent<Rigidbody2D>().AddForce((Vector2.up) * ypower, ForceMode2D.Impulse);
        }
    }
}
