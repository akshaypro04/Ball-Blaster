using BallBlast.Comman.Game;
using UnityEngine;
using BallBlast.Comman.Destoy;

namespace BallBlast.Play.health
{
    public class PlayerHealth : Destruable
    {
        public override void die()
        {
            base.die();
            print("Player is die");
        }

        public void ResetLife()
        {
            Reset();
        }

        void OnTriggerEnter2D(Collider2D trigger)
        {
            if (trigger.gameObject.tag == "enemy")
            {
                GameManager.instances.Playsfx("playerdead");
                GameManager.instances.setplayerAlive(false);

            }
        }
    }
}
