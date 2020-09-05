using UnityEngine;
using BallBlast.Comman.Game;
using BallBlast.Play.Controller;

namespace BallBlast.Play.Anim
{
    public class PlayerAnim : MonoBehaviour
    {
        float countdown;
        float timeLimit = 6f;
        float speed = 0.035f;
        bool left;
        bool right;
        Vector3 boundires;

        Transform m_player;
        Transform player
        {
            get
            {
                if (m_player == null)
                    m_player = GetComponent<Player>().transform;
                return m_player;
            }
        }

        void Awake()
        {
            boundires = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
            player.transform.position = new Vector3(-boundires.x + player.localScale.x * 1.7f, -boundires.y + player.localScale.y * 3f, player.position.z);
            right = true;
        }

        void Update()
        {
            if (GameManager.instances.getplayerAlive())
                return;

            if (!GameManager.instances.getMainMenu())
                return;


            GameManager.instances.LocalPlayer.MovementDirection();
            animRight();                             
            animLeft();
        }

        void animRight()
        {
            if (!right)
                return;

            if (countdown < timeLimit)
            {
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                countdown += 0.1f;
            }
            else
            {
                left = true;
                right = false;
                countdown = 0;
            }
        }

        void animLeft()
        {
            if (!left)
                return;

            if (countdown < timeLimit)
            {
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
                countdown += 0.1f;
            }
            else
            {
                left = false;
                right = true;
                countdown = 0;
            }
        }

    }
}