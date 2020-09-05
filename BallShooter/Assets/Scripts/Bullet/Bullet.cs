using UnityEngine;
using DG.Tweening;
using BallBlast.Comman.Game;
using BallBlast.Comman.Destoy;
using BallBlast.Enemies.ControllerChild;
using BallBlast.Enemies.ControllerParent;

namespace BallBlast.BulletPrefab
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] float timeToLive;
        [SerializeField] float Speed;
        [SerializeField] GameObject BulletHitEffect;

        void Start()
        {
            Destroy(gameObject, timeToLive);
        }

        void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }

        [System.Obsolete]
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "enemy")
            {
                var destoryer = collision.transform.GetComponent<Destruable>();

                if (destoryer == null)
                    return;

                collision.transform.DOPunchScale(new Vector3(-0.05f, -0.05f, 1), 0.1f);

                if (collision.GetComponent<EnemyChild>() == null)
                {
                    BulletHitEffect.GetComponent<ParticleSystem>().startColor = collision.GetComponent<Enemy>().GetColor();
                }
                else
                {
                    BulletHitEffect.GetComponent<ParticleSystem>().startColor = collision.GetComponent<EnemyChild>().GetColor();

                }

                Instantiate(BulletHitEffect, collision.transform.position - new Vector3(0, collision.transform.localScale.y, 0), collision.transform.rotation.normalized);
                destoryer.DamageTake((int)GameManager.instances.GetDamageAmt());
                Destroy(gameObject);
            }
        }
    }
}