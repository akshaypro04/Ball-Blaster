using UnityEngine;
using BallBlast.Comman.Game;

namespace BallBlast.Comman.Bounderies
{

    public class BoundariesManagement : MonoBehaviour
    {

        Vector3 boundaries;
        [SerializeField] Transform leftWall;
        [SerializeField] Transform rightWall;
        [SerializeField] Transform limit;
        [SerializeField] Transform ground;
        [SerializeField] Transform player;
        [SerializeField] Transform s1;
        [SerializeField] Transform s2;
        [SerializeField] Transform dropBox;
        [SerializeField] Transform firework1;
        [SerializeField] Transform firework2;

        float countDown = 0;
        float timeLimit = 3;
        float speed = 0.1f;
        bool up;
        bool down;

        float upperitemY;
        bool playerset;

        void Awake()
        {
            Application.targetFrameRate = 60;
            down = true;
            fixedPositions();

        }

        void fixedPositions()
        {
            boundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));

            leftWall.localScale = new Vector3(1, boundaries.y * 5, 1);
            leftWall.position = new Vector3(-boundaries.x - leftWall.localScale.x / 2, boundaries.y / 2, transform.position.z);

            rightWall.localScale = new Vector3(1, boundaries.y * 5, 1);
            rightWall.position = new Vector3(boundaries.x + leftWall.localScale.x / 2, boundaries.y / 2, transform.position.z);

            ground.localScale = new Vector3(boundaries.x * 2, 1, 1);
            ground.position = new Vector3(0, -boundaries.y + ground.localScale.y / 0.8f, transform.position.z);

            limit.localScale = new Vector3(boundaries.x * 2, 1, 1);
            limit.position = new Vector3(0, boundaries.y * 1.5f, transform.position.z);

            dropBox.localScale = new Vector3(boundaries.x / 2f, 2f, 1);

            upperitemY = boundaries.y - dropBox.localScale.y * 1.3f;

            dropBox.position = new Vector3(0, upperitemY, transform.position.z);

            s1.position = new Vector3(-boundaries.x, upperitemY, transform.position.z);

            s2.position = new Vector3(boundaries.x, upperitemY, transform.position.z);

            firework1.position = new Vector3(-boundaries.x, -boundaries.y, 0);
            firework2.position = new Vector3(boundaries.x, -boundaries.y, 0);

        }


        void playerPos()
        {
            player.localScale = new Vector3(1, 1, 1);
            player.position = new Vector3(0, -boundaries.y + player.localScale.y * 2.2f, 0);
        }

        void Update()
        {

            if (!GameManager.instances.getplayerAlive())
                return;

            if (!playerset)
                playerPos();
            playerset = true;


            // this is set for boss level
            //if (((GameManager.instances.getPlayerLevel() / 5) == 0))
            //    return;

            //MoveUp();
            //MoveDown();

        }


        void MoveDown()
        {
            if (!down)
                return;

            if (countDown < timeLimit)
            {
                s1.position = new Vector3(s1.localPosition.x, s1.localPosition.y - speed, s1.localPosition.z);
                s2.position = new Vector3(s2.localPosition.x, s2.localPosition.y - speed, s2.localPosition.z);
                countDown += 0.1f;
            }
            else
            {
                down = false;
                up = true;
                countDown = 0;
            }

        }


        void MoveUp()
        {
            if (!up)
                return;

            if (countDown < timeLimit)
            {
                s1.position = new Vector3(s1.localPosition.x, s1.localPosition.y + speed, s1.localPosition.z);
                s2.position = new Vector3(s2.localPosition.x, s2.localPosition.y + speed, s2.localPosition.z);
                countDown += 0.1f;
            }
            else
            {
                down = true;
                up = false;
                countDown = 0;
            }

        }
    }
}