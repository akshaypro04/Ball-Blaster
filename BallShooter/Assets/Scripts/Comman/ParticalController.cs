using UnityEngine;


namespace BallBlast.Comman.partical
{
    public class ParticalController : MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject, 3f);
        }

        void Update()
        {
            if (Time.timeScale < 0.01f)
            {
                if (GetComponent<ParticleSystem>() == null)
                    return;

                GetComponent<ParticleSystem>().Simulate(0.5f, true, false);
            }
        }
    }
}

