using TMPro;
using UnityEngine;
using BallBlast.Comman.Game;

namespace BallBlast.score.Collection
{

    public class CollectionBoard : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI CoinsBoard;

        int coins;
        int coinLength;
        void Start()
        {
            transform.Find("CoinCollected").GetComponent<RectTransform>().sizeDelta = new Vector2(200, 100);
        }

        void Update()
        {
            if (coins == GameManager.instances.GetCoins())     // set up coins and ui  on change
                return;

            coins = GameManager.instances.GetCoins();
            CoinsBoard.text = coins.ToString();
            coinLength = coins.ToString().Length;
            transform.Find("CoinCollected").GetComponent<RectTransform>().sizeDelta = new Vector2(200 + (coinLength - 1) * 20, 100);
        }
    }
}
