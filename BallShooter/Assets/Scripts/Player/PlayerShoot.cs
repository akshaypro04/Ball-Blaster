using UnityEngine;
using BallBlast.Comman.BulletControl;
using BallBlast.Comman.Game;

namespace BallBlast.Play.Shoot
{
    public class PlayerShoot : WeaponController
    {
        bool normalTime;
        Transform body;
        float amplifie = 0.1f / 3;
        float pos;

        void Start()
        {
            body = transform.Find("Mesh/Body").GetComponent<Transform>();
        }

        void Update()
        {

            if (!GameManager.instances.getplayerAlive())
                return;

            if (GameManager.instances.playerController.Fire1)
            {
                Fire();
                ShakePlayer(35);
                TimingNormal(1f);
            }
            else
            {
                if (GameManager.instances.GetPause() == true)
                    return;

                ShakePlayer(10);
                TimingSlow(0.8f);
            }

        }

        void TimingNormal(float t)
        {
            if (normalTime)
                return;
            Time.timeScale = t;
            normalTime = true;

        }

        void TimingSlow(float t)
        {
            if (!normalTime)
                return;

            Time.timeScale = t;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            normalTime = false;
        }

        void ShakePlayer(float frequency)
        {
            pos = 0.2f + transform.position.y + Mathf.Sin(Time.time * frequency) * amplifie;
            body.transform.position = new Vector3(transform.position.x, pos, transform.position.z);
        }

    }
}