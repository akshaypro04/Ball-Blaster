using UnityEngine;
using DG.Tweening;
using BallBlast.Comman.Game;

namespace BallBlast.Comman.AudioControl
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] RectTransform MusicPivot;
        [SerializeField] RectTransform SfxPivot;
        [SerializeField] Transform PauseMenu;

        bool music;
        bool sfx;
        void Start()
        {
            if (GameManager.instances.GetMusic() == 1)
            {
                music = true;
                MusicPivot.pivot = new Vector2(1, 0.5f);
            }
            else
            {
                MusicPivot.pivot = new Vector2(0, 0.5f);
            }
            if (GameManager.instances.GetSfx() == 1)
            {
                sfx = true;
                SfxPivot.pivot = new Vector2(1, 0.5f);
            }
            else
            {
                SfxPivot.pivot = new Vector2(0, 0.5f);
            }

        }

        void OnEnable()
        {
            transform.localPosition = new Vector3(Screen.width, 0, 0);
            PauseMenu.DOMoveX(-Screen.width, 0.5f).SetUpdate(true);
            transform.DOMoveX(Screen.width / 2, 1f).SetUpdate(true);
        }



        public void setMusic()
        {
            if (music == false)
            {
                GameManager.instances.SetMusic(1);
                GameManager.instances.PlayMusic("theme");
                MusicPivot.pivot = new Vector2(1, 0.5f);
                music = true;
            }
            else
            {
                GameManager.instances.StopMusic("theme");
                GameManager.instances.SetMusic(0);
                MusicPivot.pivot = new Vector2(0, 0.5f);
                music = false;
            }

        }

        public void setSfx()
        {
            if (sfx == false)
            {
                GameManager.instances.SetSfx(1);
                SfxPivot.pivot = new Vector2(1, 0.5f);
                sfx = true;
            }
            else
            {
                GameManager.instances.SetSfx(0);
                SfxPivot.pivot = new Vector2(0, 0.5f);
                sfx = false;
            }

        }
    }
}