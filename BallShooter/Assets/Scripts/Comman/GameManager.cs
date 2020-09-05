using BallBlast.Comman.AudioManage;
using UnityEngine;
using BallBlast.level.levelValue;
using BallBlast.level.levelManage;
using BallBlast.Play.input;
using BallBlast.Play.Controller;


namespace BallBlast.Comman.Game
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instances { get; private set; }

        int PlayerLevel;

        int score = 0;

        bool IsGameReady;

        bool LevelUp;

        int HighScore;

        int enemyNum;

        bool isPlayerAlive;

        float gravity;

        int totalValue;

        int winAmount;

        int enemyLimit;

        int Coin;

        bool pause;


        void Awake()
        {
            if (instances == null)
            {
                instances = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private Player m_LocalPlayer;
        public Player LocalPlayer
        {
            get
            {
                return m_LocalPlayer;
            }
            set
            {
                m_LocalPlayer = value;
            }
        }


        PlayerController m_playerController;
        public PlayerController playerController
        {
            get
            {
                if (m_playerController == null)
                    m_playerController = gameObject.GetComponent<PlayerController>();
                return m_playerController;
            }
        }

        LevelDifficulty m_LevelDifficulty;
        public LevelDifficulty LevelDifficulty
        {
            get
            {
                if (m_LevelDifficulty == null)
                    m_LevelDifficulty = gameObject.GetComponent<LevelDifficulty>();
                return m_LevelDifficulty;
            }
        }


        AudioManager m_audioManager;
        public AudioManager audioManager
        {
            get
            {
                if (m_audioManager == null)
                    m_audioManager = gameObject.GetComponent<AudioManager>();
                return m_audioManager;
            }
        }


        LevelManager m_levelManager;
        public LevelManager levelManager
        {
            get
            {
                if (m_levelManager == null)
                    m_levelManager = gameObject.GetComponent<LevelManager>();
                return m_levelManager;
            }
        }


        public void setPlayerLevel(int level)
        {
            this.PlayerLevel = level;
        }

        public int getPlayerLevel()
        {
            return this.PlayerLevel;
        }

        public void SetLevelUp(bool status)
        {
            LevelUp = status;
        }

        public bool GetLevelUp()
        {
            return LevelUp;
        }

        public void SetScore(int score)
        {
            this.score = score;
        }

        public int GetScore()
        {
            return this.score;
        }

        public void SetHighScore(int HighScore)
        {
            this.HighScore = HighScore;
        }

        public int GetHighScore()
        {
            return this.HighScore;
        }

        public void setplayerAlive(bool alive)
        {
            this.isPlayerAlive = alive;
        }

        public bool getplayerAlive()
        {
            return this.isPlayerAlive;
        }

        public void SetMainMenu(bool game)
        {
            this.IsGameReady = game;
        }

        public bool getMainMenu()
        {
            return this.IsGameReady;
        }

        public void SetNumEnemies(int enemy)
        {
            this.enemyNum = enemy;
        }

        public int getNumEnemies()
        {
            return this.enemyNum;
        }

        public void Setgravity(float g)
        {
            this.gravity = g;
        }

        public float getGravity()
        {
            return this.gravity;
        }

        public void SetEnemyLimt(int e)
        {
            this.enemyLimit = e;
        }

        public int getEnemyLimit()
        {
            return this.enemyLimit;
        }

        public void SetTotalEnemiesValues(int amount)
        {
            this.totalValue = GetTotalEnemiesValues() + amount;
        }

        public int GetTotalEnemiesValues()
        {
            return this.totalValue;
        }

        public void SetValueToWin(int win)
        {
            print(win);
            this.winAmount = win;
        }

        public int GetValueToWin()
        {
            return this.winAmount;
        }

        public void SetCoins(int coin)
        {
            this.Coin = coin;
        }

        public int GetCoins()
        {
            return this.Coin;
        }

        public void SetBulletSpeed(float Bullet)
        {
            PlayerPrefs.SetFloat("BPS", Bullet);
        }

        public float GetBulletSpeed()
        {

            return PlayerPrefs.GetFloat("BPS", 1);
        }


        public void SetDamageAmt(float Damage)
        {
            PlayerPrefs.SetFloat("DP", Damage);
        }

        public float GetDamageAmt()
        {

            return PlayerPrefs.GetFloat("DP", 1);
        }

        public void SetPause(bool game)
        {
            this.pause = game;
        }
        public bool GetPause()
        {
            return pause;
        }


        ///////////////////////////////////  M  U  S  I  C    //////////////////////////////////


        public void Playsfx(string audio)
        {
            audioManager.sfx(audio);
        }

        public void SetSfx(int i)
        {
            PlayerPrefs.SetInt("sfx", i);
        }
        public int GetSfx()
        {
            return PlayerPrefs.GetInt("sfx", 1);
        }


        public void PlayMusic(string audio)
        {
            audioManager.MusicPlay(audio);
        }

        public void StopMusic(string audio)
        {
            audioManager.MusicStop(audio);
        }

        public void SetMusic(int i)
        {
            PlayerPrefs.SetInt("music", i);
        }
        public int GetMusic()
        {
            return PlayerPrefs.GetInt("music", 1);
        }
    }
}

