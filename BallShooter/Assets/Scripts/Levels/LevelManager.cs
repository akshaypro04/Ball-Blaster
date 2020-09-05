using UnityEngine;
using BallBlast.Comman.Game;

namespace BallBlast.level.levelManage
{
    public class LevelManager : MonoBehaviour
    {

        levels level;
        float SaveScore;
        public int[] scoredata = new int[]
        {
        30,50,200,300,500,
        1000,1250,1500,2000,2500,
        3000,3250,3500,3750,4000,
        4200,4500,4800,5000,5250,
        5500,5555,5750,6000,6200,
        6400,6600,6800,7000,8000,
        100000
        };                                    // please update scoredata from Inspector;


        void Start()
        {
            CheckUserLevel();
        }

        public void CheckUserLevel()
        {
            SaveScore = PlayerPrefs.GetInt("Score", 0);

            if (SaveScore < scoredata[0])
            {
                level = levels.level1;
            }
            else if (SaveScore >= scoredata[0] && SaveScore < scoredata[1])
            {
                level = levels.level2;
            }
            else if (SaveScore >= scoredata[1] && SaveScore < scoredata[2])
            {
                level = levels.level3;
            }
            else if (SaveScore >= scoredata[2] && SaveScore < scoredata[3])
            {
                level = levels.level4;
            }
            else if (SaveScore >= scoredata[3] && SaveScore < scoredata[4])
            {
                level = levels.level5;
            }
            else if (SaveScore >= scoredata[4] && SaveScore < scoredata[5])
            {
                level = levels.level6;
            }
            else if (SaveScore >= scoredata[5] && SaveScore < scoredata[6])
            {
                level = levels.level7;
            }
            else if (SaveScore >= scoredata[6] && SaveScore < scoredata[7])
            {
                level = levels.level8;
            }
            else if (SaveScore >= scoredata[7] && SaveScore < scoredata[8])
            {
                level = levels.level9;
            }
            else if (SaveScore >= scoredata[8] && SaveScore < scoredata[9])
            {
                level = levels.level10;
            }
            else if (SaveScore >= scoredata[9] && SaveScore < scoredata[10])
            {
                level = levels.level11;
            }
            else if (SaveScore >= scoredata[10] && SaveScore < scoredata[11])
            {
                level = levels.level12;
            }
            else if (SaveScore >= scoredata[11] && SaveScore < scoredata[12])
            {
                level = levels.level13;
            }
            else if (SaveScore >= scoredata[12] && SaveScore < scoredata[13])
            {
                level = levels.level14;
            }
            else if (SaveScore >= scoredata[13] && SaveScore < scoredata[14])
            {
                level = levels.level15;
            }
            else if (SaveScore >= scoredata[14] && SaveScore < scoredata[15])
            {
                level = levels.level16;
            }
            else if (SaveScore >= scoredata[15] && SaveScore < scoredata[16])
            {
                level = levels.level17;
            }
            else if (SaveScore >= scoredata[16] && SaveScore < scoredata[17])
            {
                level = levels.level18;
            }
            else if (SaveScore >= scoredata[17] && SaveScore < scoredata[18])
            {
                level = levels.level19;
            }
            else if (SaveScore >= scoredata[18] && SaveScore < scoredata[19])
            {
                level = levels.level20;
            }
            else if (SaveScore >= scoredata[19] && SaveScore < scoredata[20])
            {
                level = levels.level21;
            }
            else if (SaveScore >= scoredata[20] && SaveScore < scoredata[21])
            {
                level = levels.level22;
            }
            else if (SaveScore >= scoredata[21] && SaveScore < scoredata[22])
            {
                level = levels.level23;
            }
            else if (SaveScore >= scoredata[22] && SaveScore < scoredata[23])
            {
                level = levels.level24;
            }
            else if (SaveScore >= scoredata[23] && SaveScore < scoredata[24])
            {
                level = levels.level25;
            }
            else if (SaveScore >= scoredata[24] && SaveScore < scoredata[25])
            {
                level = levels.level26;
            }
            else if (SaveScore >= scoredata[25] && SaveScore < scoredata[26])
            {
                level = levels.level27;
            }
            else if (SaveScore >= scoredata[26] && SaveScore < scoredata[27])
            {
                level = levels.level28;
            }
            else if (SaveScore >= scoredata[27] && SaveScore < scoredata[28])
            {
                level = levels.level29;
            }
            else if (SaveScore >= scoredata[28] && SaveScore < scoredata[29])
            {
                level = levels.level30;
            }
            else if (SaveScore >= scoredata[29] && SaveScore < scoredata[30])
            {
                level = levels.level31;
            }
            else if (SaveScore >= scoredata[30])
            {
                level = levels.level32;
            }

            SelectLevel();
        }

        void SelectLevel()
        {
            print((int)level);
            GameManager.instances.setPlayerLevel((int)level);
        }
    }
}
