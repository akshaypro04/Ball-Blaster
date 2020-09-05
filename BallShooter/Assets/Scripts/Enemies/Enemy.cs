using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using BallBlast.Comman.Game;
using BallBlast.Enemies.HealthParent;
using BallBlast.SpawnManager.child;
using BallBlast.SpawnManager.parent;
using BallBlast.UI.Sprites;
using BallBlast.level.levelValue;

namespace BallBlast.Enemies.ControllerParent
{
    public class Enemy : MonoBehaviour
    {

        [SerializeField] enemy enemyType;
        [HideInInspector] public SpriteRenderer renderer;
        int enemiesSpritesLength;
        Rigidbody2D rd;
        [SerializeField] GameObject roundEffectPE;
        [SerializeField] GameObject ballBlastEffectPE;
        [SerializeField] GameObject Dust;

        float Moveingspeed = 1.2f;
        [HideInInspector] public int EnemyLifeNum;

        protected bool move;
        bool directionCheckedfirst;
        bool Triggered;
        bool EnemyIsDead;

        int EnemyTypeNum;
        float Swap;
        float ParentX;
        float ParentXLocalPos;

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


        EnemyHealth m_enemyHealth;
        EnemyHealth enemyHealth
        {
            get
            {
                if (m_enemyHealth == null)
                    m_enemyHealth = GetComponent<EnemyHealth>();
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

            if (enemyType == enemy.enemyBig)
            {
                r = UnityEngine.Random.Range(41, 60);
            }
            if (enemyType == enemy.enemyMediam)
            {
                r = UnityEngine.Random.Range(21, 40);
            }
            if (enemyType == enemy.enemySmall)
            {
                r = UnityEngine.Random.Range(2, 20);
            }

            renderer.sprite = enemiesSprites.enemies[enemiesSpritesLength];
            renderer.sortingOrder = r;

            Canvas myCanvas = GetComponentInChildren<Canvas>();
            myCanvas.sortingOrder = r;

            SpawnPosition();

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

            if (!GameManager.instances.getplayerAlive())
                return;

            if (!move)
                return;

            transform.Translate(new Vector2(ParentXLocalPos / ParentX, 0) * Moveingspeed * Time.deltaTime);
        }

        [System.Obsolete]
        IEnumerator DestoryEnemyCoroutine()
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 2.0f));
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

        [Obsolete]
        public virtual void OnCollisionEnter2D(Collision2D collision)
        {

            if (move)
                return;

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

        public virtual void OnTriggerEnter2D(Collider2D trigger)
        {
            if ((trigger.gameObject.tag == "dropping") || (trigger.gameObject.tag == "bullet"))
            {
                if (Triggered)
                    return;

                rd.gravityScale = GameManager.instances.getGravity();
                var xforce = new Vector2(ParentXLocalPos / ParentX * 70, 0);
                rd.AddRelativeForce(xforce);
                move = false;
                Triggered = true;
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
        int GenerateRandomNum(int level)
        {
            int NumLimit = levelDifficulty.count[level - 1].levels.Length - 1;
            int[] numbers = new int[NumLimit];
            for (int i = 0; i < NumLimit; i++)
            {
                numbers = levelDifficulty.count[level - 1].levels;
            }
            int randomindex = UnityEngine.Random.Range(0, NumLimit);
            return numbers[randomindex];
        }

        void SpawnChild()                                                             // just before destory
        {
            GameObject.Find("SpawnManager").GetComponent<SpawnerManager>().EnemySpawnner();

            if (EnemyTypeNum == 1)
            {
                GameObject.Find("SpawnManager").GetComponent<SpawnChildManager>().SpawnCoin(transform);
            }
            else
            {

                GameObject.Find("SpawnManager").GetComponent<SpawnChildManager>().SpawnChildren(EnemyTypeNum, transform);
            }

        }

        void SpawnPosition()
        {
            rd.gravityScale = 0;
            ParentX = Mathf.Abs(GameObject.Find("e1").transform.position.x);
            ParentXLocalPos = -GetComponentInParent<Transform>().position.x;

            PlayerLevel = GameManager.instances.getPlayerLevel();

            EnemyLifeNum = GenerateRandomNum(PlayerLevel);
            GameManager.instances.SetTotalEnemiesValues(EnemyLifeNum);
            enemyLifeText = GetComponentInChildren<Text>();
            enemyLifeText.text = EnemyLifeNum.ToString();

            directionCheckedfirst = true;
            move = true;
        }

        public Color GetColor()
        {
            return new Color(enemiesSprites.enemiesColor[enemiesSpritesLength].r, enemiesSprites.enemiesColor[enemiesSpritesLength].g, enemiesSprites.enemiesColor[enemiesSpritesLength].b);
        }

    }
}