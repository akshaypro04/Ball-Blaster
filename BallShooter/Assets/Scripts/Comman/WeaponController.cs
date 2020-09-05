using UnityEngine;
using BallBlast.BulletPrefab;
using BallBlast.Comman.Game;

namespace BallBlast.Comman.BulletControl
{

    public class WeaponController : MonoBehaviour
    {
        [SerializeField] Bullet bullet;
        [SerializeField] protected Transform Muzzle;

        protected bool canFire = true;
        float NextFireAllowed;


        public void Fire()
        {
            if (Time.time > NextFireAllowed && canFire)
            {
                GameManager.instances.Playsfx("Fire");
                NextFireAllowed = Time.time + (1 / GameManager.instances.GetBulletSpeed());
                Instantiate(bullet, Muzzle.position, Muzzle.rotation);
                Muzzle.GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
            else
            {
                Muzzle.GetComponentInChildren<SpriteRenderer>().enabled = false;
            }

        }
    }
}