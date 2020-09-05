using TMPro;
using UnityEngine;
using BallBlast.Comman.Game;


namespace BallBlast.Comman.Coins
{
    public class coin : MonoBehaviour
    {

        [SerializeField] GameObject coinBoom;
        [SerializeField] GameObject floatingNumber;
        int coinVlaue;

        void Update()
        {
            if (GameManager.instances.GetLevelUp())
                coinDestoryanim();
        }

        void OnCollisionEnter2D(Collision2D trigger)
        {
            if (trigger.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                coinDestoryanim();
            }

            if (trigger.gameObject.tag == "ground")
            {
                Destroy(gameObject);
                coinDestoryanim();
            }

        }

        void coinDestoryanim()
        {

            if (!GameManager.instances.GetLevelUp())
            {
                coinVlaue = Random.Range(1, (int)Mathf.Abs((GameManager.instances.getPlayerLevel() * 1.5f)));

                GameManager.instances.SetCoins(GameManager.instances.GetCoins() + coinVlaue);
                PlayerPrefs.SetInt("Coins", GameManager.instances.GetCoins());

                floatingNumber.GetComponentInChildren<TextMeshPro>().text = "+" + coinVlaue.ToString();

                Instantiate(coinBoom, transform.position, Quaternion.identity);
                Instantiate(floatingNumber, transform.position, Quaternion.identity);
                Instantiate(coinBoom, transform.position, Quaternion.identity);

                GameManager.instances.Playsfx("coin");
            }

        }
    }
}
