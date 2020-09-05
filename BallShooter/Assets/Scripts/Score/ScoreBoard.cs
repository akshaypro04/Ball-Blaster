using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using BallBlast.Comman.Game;

namespace BallBlast.score.SController
{

    public class ScoreBoard : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI HighScorePlayer;
        [SerializeField] TextMeshProUGUI HighScore;
        [SerializeField] GameObject HighScorePanel;
        [SerializeField] GameObject levelUpNewScorePanel;
        [SerializeField] GameObject levelUpScorePanel;
        [SerializeField] TextMeshProUGUI Level;
        [SerializeField] Button PauseBtn;
        [SerializeField] GameObject DeadScreen;
        [SerializeField] TextMeshProUGUI DeadScreenScore;
        [SerializeField] TextMeshProUGUI DeadScreenNewRecord;
        [SerializeField] GameObject DeadScreenScorePanel;
        [SerializeField] GameObject DeadScreenNewRecordPanel;
        [SerializeField] GameObject DeadScreenEffect;
        [SerializeField] GameObject title;
        [SerializeField] GameObject LevelUpScreen;
        [SerializeField] GameObject LevelUpTitle;
        [SerializeField] TextMeshProUGUI ClearLevel;
        [SerializeField] TextMeshProUGUI PerviousLevel;
        [SerializeField] TextMeshProUGUI NextLevel;
        [SerializeField] TextMeshProUGUI ClearedLevel;
        [SerializeField] Slider slider;
        [SerializeField] TextMeshProUGUI currentLevelgame;
        [SerializeField] TextMeshProUGUI PerviousLevelgame;
        [SerializeField] TextMeshProUGUI LevelSocre;
        [SerializeField] TextMeshProUGUI NewRecordLevelSocre;
        [SerializeField] GameObject MusicScreen;
        [SerializeField] GameObject MusicBtn;
        [SerializeField] GameObject EntryScreen;
        [SerializeField] GameObject fireworkparticle;
        [SerializeField] Transform land;
        [SerializeField] Transform pauseMenu;
        [SerializeField] GameObject bar;
        [SerializeField] GameObject infinite;


        int HighScoreLive;
        int scoreLive;
        int HighScoreNum;
        int levelNo;
        bool isplayerDEAD;
        bool isPlayClick;
        bool IsLevelUp;
        float LandY;
        Transform pos1;
        Transform pos2;
        Vector2 ScreenBounds;
        int SavedHighScore;

        void Start()
        {
            ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
            GameManager.instances.SetSfx(GameManager.instances.GetSfx());
            GameManager.instances.SetMusic(GameManager.instances.GetMusic());
            GameManager.instances.SetEnemyLimt(3);
            GameManager.instances.SetMainMenu(true);
            GameManager.instances.levelManager.CheckUserLevel();             // to update the player level
            GameManager.instances.SetScore(0);
            GameManager.instances.SetNumEnemies(0);

            LandY = -ScreenBounds.y / 1.38f;
            land.DOMoveY(LandY, 0.2f);
            slider.gameObject.SetActive(false);
            HighScorePlayer.gameObject.SetActive(false);
            PauseBtn.gameObject.SetActive(false);
            MusicBtn.SetActive(true);

            LevelUpScreen.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, Screen.height * 3), 0);        // level up screen

            GameManager.instances.SetCoins(PlayerPrefs.GetInt("Coins", 0));                                       //coins load

            levelNo = GameManager.instances.getPlayerLevel();                                                     // level load
            GameManager.instances.SetValueToWin(GameManager.instances.levelManager.scoredata[levelNo - 1]);
            currentLevelgame.text = levelNo.ToString();
            PerviousLevelgame.text = (levelNo + 1).ToString();

            Level.text = " " + levelNo.ToString();                                                                       // level name in title
            HighScoreNum = PlayerPrefs.GetInt("HighScore", 0);
            SetLevelValue();
            SetTitleText();
            HighScoreMenu();
        }

        void Update()
        {
            if (GameManager.instances.getMainMenu())
                return;

            if (isPlayClick == false)                                       // to remove the UIs
            {
                HighScorePlayer.gameObject.SetActive(true);
                PauseBtn.gameObject.SetActive(true);
                title.SetActive(false);
                LevelUpTitle.SetActive(false);
                LevelUpScreen.SetActive(false);
                slider.gameObject.SetActive(true);
                if (levelNo == 32)
                {
                    infinite.SetActive(true);
                }
                else
                {
                    bar.SetActive(true);
                }
                MusicBtn.SetActive(false);
                StartCoroutine(LevelName());
                isPlayClick = true;
                land.DOMoveY(-ScreenBounds.y * 0.87f, 0.25f);
            }

            if (isplayerDEAD)
                return;


            HighScoreLive = GameManager.instances.GetHighScore();             // set player high score
            scoreLive = GameManager.instances.GetScore();                     // set stage player score
            HighScorePlayer.text = HighScoreLive.ToString();

            if (HighScoreLive > PlayerPrefs.GetInt("HighScore", 0))      // player score save every shot
            {
                PlayerPrefs.SetInt("HighScore", HighScoreLive);
            }

            UpdateLevelProgressbar();


            if (GameManager.instances.GetValueToWin() <= scoreLive)
            {
                if (IsLevelUp)
                    return;
                firework();

                SavedHighScore = PlayerPrefs.GetInt("HighScore");

                if (HighScoreLive >= SavedHighScore)
                {
                    NewRecordLevelSocre.text = "You Scored New Record " + SavedHighScore.ToString();
                    levelUpNewScorePanel.SetActive(true);
                }
                else
                {
                    LevelSocre.text = "You Score " + scoreLive.ToString();      // win the level
                    levelUpScorePanel.SetActive(true);
                }

                GameManager.instances.Playsfx("levelup");
                GameManager.instances.SetLevelUp(true);
                PlayerPrefs.SetInt("Score", scoreLive);
                GameManager.instances.setplayerAlive(false);
                LevelUpScreen.SetActive(true);
                LevelUpScreen.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 1f);
                ClearLevel.text = "You Cleared Level " + levelNo.ToString();
                IsLevelUp = true;
            }


            if (GameManager.instances.getplayerAlive())
                return;

            if (GameManager.instances.GetLevelUp())
                return;

            if (!isplayerDEAD)
                deadScreen();

        }

        void HighScoreMenu()
        {
            if (HighScoreNum > 0)
            {
                HighScore.gameObject.SetActive(true);
                HighScore.text = " " + HighScoreNum.ToString();                                 // HIGH SCORE TITLE
            }
            else
            {
                HighScorePanel.gameObject.SetActive(false);
            }
        }


        void deadScreen()
        {
            DeadScreen.SetActive(true);
            DeadScreenEffect.SetActive(true);

            SavedHighScore = PlayerPrefs.GetInt("HighScore");

            if (HighScoreLive >= SavedHighScore)
            {
                DeadScreenNewRecord.text = "You Scored New Record " + SavedHighScore.ToString();
                DeadScreenNewRecordPanel.SetActive(true);
            }
            else
            {
                DeadScreenScore.text = "You Score " + scoreLive.ToString();                  // win the level
                DeadScreenScorePanel.SetActive(true);
            }

            isplayerDEAD = true;
            Time.timeScale = 0f;
            GameManager.instances.SetHighScore(0);
        }

        void SetTitleText()                                                                    // after restarting game
        {
            if (GameManager.instances.GetLevelUp())
            {
                LevelUpScreen.SetActive(false);
                LevelUpTitle.SetActive(true);
                PerviousLevel.text = (levelNo - 1).ToString();
                NextLevel.text = (levelNo).ToString();
                ClearedLevel.text = "Level " + (levelNo - 1) + " COMPLETED !!";
            }
            else
            {
                title.gameObject.SetActive(true);
            }
        }


        void SetLevelValue()
        {
            slider.maxValue = (GameManager.instances.levelManager.scoredata[levelNo - 1]);
            slider.value = 0;
        }

        void UpdateLevelProgressbar()
        {
            slider.value = scoreLive;
        }

        public void MusicOnScreen()
        {
            MusicScreen.SetActive(true);
        }

        public void MusicOffScreen()
        {
            pauseMenu.DOMoveX(Screen.width / 2, 0.5f).SetUpdate(true);
            MusicScreen.transform.DOMoveX(Screen.width * 2, 1f).OnComplete(() => MusicScreen.SetActive(false)).SetUpdate(true);

        }

        IEnumerator LevelName()
        {
            EntryScreen.SetActive(true);

            if (levelNo == 32)
            {
                EntryScreen.GetComponentInChildren<TextMeshProUGUI>().text = "NFINITY LEVEL ";
            }
            else
            {
                EntryScreen.GetComponentInChildren<TextMeshProUGUI>().text = "level " + levelNo.ToString();
            }
            yield return new WaitForSeconds(3f);
            EntryScreen.SetActive(false);
        }

        void firework()
        {
            pos1 = GameObject.Find("gameObjects/firework1").GetComponent<Transform>();
            pos2 = GameObject.Find("gameObjects/firework2").GetComponent<Transform>();

            Instantiate(fireworkparticle, pos1.transform.position, pos1.transform.rotation);
            Instantiate(fireworkparticle, pos2.transform.position, pos2.transform.rotation);
        }


        [ContextMenu("Rest_Player_Data")]
        void Reset()
        {
            PlayerPrefs.DeleteKey("Coins");
            PlayerPrefs.DeleteKey("HighScore");
            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("BPS");
            PlayerPrefs.DeleteKey("DP");
        }
    }
}