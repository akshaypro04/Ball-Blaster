using UnityEngine;

namespace BallBlast.UI.BG
{
    public class background : MonoBehaviour
    {

        public Sprite[] image;
        int bg;

        void Start()
        {
            bg = Random.Range(0, image.Length);
            this.GetComponent<SpriteRenderer>().sprite = image[bg];
        }

        void Update()
        {

        }
    }
}