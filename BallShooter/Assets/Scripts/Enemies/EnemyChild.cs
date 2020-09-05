using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using BallBlast.Comman.Game;
using BallBlast.Enemies.HealthChild;
using BallBlast.SpawnManager.child;
using BallBlast.SpawnManager.parent;
using BallBlast.UI.Sprites;
using BallBlast.level.levelValue;

namespace BallBlast.Enemies.ControllerChild
{
    public class EnemyChild : MonoBehaviour
    {
        [SerializeField] enemy enemyType;
        [HideInInspector] public SpriteRenderer renderer;
        Rigidbody2D rd;
        [SerializeField] GameObject ballBlastEffectPE;
        [SerializeField] GameObject roundEffectPE;
        [SerializeField] GameObject Dust;

        [HideInInspector] public int EnemyLifeNum;

        int enemiesSpritesLength;
        bool directionCheckedfirst;
        bool EnemyIsDead;

        int EnemyTypeNum;
        float Swap;
        int PlayerLevel;
        int r;

        Text enemyLifeText;

        public Vector2 groundForce;
        public Vector2 leftAndRight;

        EnemiesSprites enemiesSprites;
        LevelDifficulty m_levelDifficulty;
        LevelDifficulty levelDifficulty
        {
            get
            {
                if (m_levelDifficulty == null)
                    m_levelDifficulty = GameManager.instances.LevelDifficulty;
                return m_levelDifficulty;
            }
        }


        ChildEnemyHealth m_enemyHealth;
        ChildEnemyHealth enemyHealth
        {
            get
            {
                if (m_enemyHealth == null)
                    m_enemyHealth = GetComponent<ChildEnemyHealth>();
                return m_enemyHealth;
            }
        }

        [System.Obsolete]
        private void Start()
        {
            GameManager.instances.SetNumEnemies(GameManager.instances.getNumEnemies() + 1);

            enemiesSprites = GameObject.Find("gameObjects/EnemySprites").GetComponent<EnemiesSprites>();
            enemiesSpritesLength = enemiesSprites.enemies.Length;
            enemiesSpritesLength = UnityEngine.Random.Range(0, enemiesSpritesLength);

            rd = GetComponent<Rigidbody2D>();
            renderer = GetComponent<SpriteRenderer>();

            rd.gravityScale = GameManager.instances.getGravity();

            if (enemyType == enemy.enemyMediam)
            {
                r = Random.Range(21, 40);
            }
            if (enemyType == enemy.enemySmall)
            {
                r = Random.Range(2, 20);
            }

            renderer.sprite = enemiesSprites.enemies[enemiesSpritesLength];
            renderer.sortingOrder = r;

            Canvas myCanvas = GetComponentInChildren<Canvas>();
            myCanvas.sortingOrder = r;

            EnemyPoints();

            directionCheckedfirst = true;
            EnemyTypeNum = (int)enemyType;

            enemyHealth.HitPoint = EnemyLifeNum;

            this.enemyHealth.OnDamageRecevied += EnemyHealth_OnDamageRecevied;
            this.enemyHealth.OnDeath += EnemyHealth_OnDeath;
        }

        [System.Obsolete]
        void Update()
        {
            if (GameManager.instances.GetLevelUp())
                StartCoroutine(DestoryEnemyCoroutine());
        }

        [System.Obsolete]
        IEnumerator DestoryEnemyCoroutine()
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
            DestoryEnemy();
        }

        [System.Obsolete]
        public void EnemyHealth_OnDeath()
        {

            if (EnemyIsDead)
                return;

            GameManager.instances.SetNumEnemies(GameManager.instances.getNumEnemies() - 1);
            SpawnChild();
            EnemyIsDead = true;
            DestoryEnemy();
        }

        [System.Obsolete]
        void DestoryEnemy()
        {
            roundEffectPE.GetComponent<ParticleSystem>().startColor = GetColor();
            ballBlastEffectPE.GetComponent<ParticleSystem>().startColor = GetColor();

            Instantiate(roundEffectPE, transform.position, transform.rotation);
            Instantiate(ballBlastEffectPE, transform.position, transform.rotation);
            Destroy(gameObject);
        }


        public void EnemyHealth_OnDamageRecevied(int amount)
        {
            EnemyLifeNum -= amount;
            if (EnemyLifeNum < 0)
                return;

            GameManager.instances.SetScore(GameManager.instances.GetScore() + amount);
            GameManager.instances.SetHighScore(GameManager.instances.GetHighScore() + amount);
            enemyLifeText.text = EnemyLifeNum.ToString();
        }

        #region balls_Collision_System

        [System.Obsolete]
        public virtual void OnCollisionEnter2D(Collision2D collision)
        {

            var distdown = (this.transform.position - GameObject.Find("Ground").transform.position).normalized;
            var distleft = Mathf.Sign((this.transform.position.y - GameObject.Find("left").transform.position.y));       // here we get negative if height limit
            var distright = Mathf.Sign((this.transform.position.y - GameObject.Find("right").transform.position.y));      // ,,

            if (directionCheckedfirst == true)
            {
                Swap = checkdirection(distdown.x);
                directionCheckedfirst = false;
            }

            if (collision.gameObject.tag == "right")
            {
                rd.AddForce(new Vector2(-leftAndRight.x, -distright * leftAndRight.y));
                Swap = -1;
            }

            if (collision.gameObject.tag == "left")
            {
                rd.AddForce(new Vector2(leftAndRight.x, distleft * leftAndRight.y));                 // right way to center y
                Swap = 1;
            }
            if (collision.gameObject.tag == "ground")
            {
                Instantiate(Dust, transform.position - new Vector3(0, transform.localScale.y, 0), transform.rotation);
                rd.AddForce(new Vector2(Swap * groundForce.x, groundForce.y));                       // X move his side forword
                GameManager.instances.Playsfx("hitground");
            }

            if (collision.gameObject.tag == "limit")
            {
                rd.AddForce(new Vector2(Swap * groundForce.x, 0));                                   // X move his side forword 
            }

        }

        private float checkdirection(float dir)
        {
            if (dir >= 0)
            {
                Swap = 1;
            }
            else
            {
                Swap = -1;
            }
            return Swap;
        }

        #endregion
        public int GenerateRandomNum(int level)
        {
            int NumLimit = levelDifficulty.count[level - 1].levels.Length - 1;
            int[] numbers = new int[NumLimit];
            for (int i = 0; i < NumLimit; i++)
            {
                numbers = levelDifficulty.count[level - 1].levels;
            }
            int randomindex = Random.Range(0, NumLimit);
            return numbers[randomindex];
        }

        void SpawnChild()                                                            // smaall ball cant spawn children
        {
            if (EnemyTypeNum == 1)
            {
                GameObject.Find("SpawnManager").GetComponent<SpawnChildManager>().SpawnCoin(transform);

                if (GameManager.instances.getNumEnemies() <= 2)                                       // to fix bug
                {
                    GameObject.Find("SpawnManager").GetComponent<SpawnerManager>().EnemySpawnner();
                }
            }
            else
            {
                GameObject.Find("SpawnManager").GetComponent<SpawnerManager>().EnemySpawnner();
                GameObject.Find("SpawnManager").GetComponent<SpawnChildManager>().SpawnChildren(EnemyTypeNum, transform);
            }
        }

        void EnemyPoints()
        {
            PlayerLevel = GameManager.instances.getPlayerLevel();
            EnemyLifeNum = GenerateRandomNum(PlayerLevel);
            GameManager.instances.SetTotalEnemiesValues(EnemyLifeNum);
            enemyLifeText = GetComponentInChildren<Text>();
            enemyLifeText.text = EnemyLifeNum.ToString();
        }

        public Color GetColor()
        {
            return new Color(enemiesSprites.enemiesColor[enemiesSpritesLength].r, enemiesSprites.enemiesColor[enemiesSpritesLength].g, enemiesSprites.enemiesColor[enemiesSpritesLength].b);
        }
    }
}

