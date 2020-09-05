using UnityEngine;
using BallBlast.Comman.Game;

namespace BallBlast.Comman.Destoy
{
    public class Destruable : MonoBehaviour
    {
        [HideInInspector]
        public float HitPoint;
        float DamageTaken;

        public float HealthReaming
        {
            get
            {
                return HitPoint - DamageTaken;
            }
        }

        public bool IsAlive
        {
            get
            {
                return HealthReaming > 0;
            }
        }

        public event System.Action OnDeath;
        public event System.Action<int> OnDamageRecevied;

        public virtual void DamageTake(int amount)
        {

            DamageTaken += amount;
            if (HealthReaming < 0)
            {
                amount = amount + (int)HealthReaming;
            }

            GameManager.instances.Playsfx("damage");

            if (OnDamageRecevied != null)
                OnDamageRecevied(amount);

            if (HealthReaming <= 0)
                die();
        }

        public virtual void die()
        {
            GameManager.instances.Playsfx("dead");
            if (OnDeath != null)
                OnDeath();
        }

        public void Reset()
        {
            DamageTaken = 0;
        }
    }
}
