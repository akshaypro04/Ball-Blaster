using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using BallBlast.Comman.Game;

namespace BallBlast.UI.Upgrade
{
    public class PlayerUpgrades : MonoBehaviour
    {

        Vector3 boundaries;

        public Button BPS_Button;
        public Button BP_Button;

        RectTransform PButton;
        RectTransform SButton;

        RectTransform PButton_control;
        RectTransform Sbutton_control;

        RectTransform PButton_down;
        RectTransform Sbutton_down;

        [SerializeField] TextMeshProUGUI SpeedAmount;
        [SerializeField] TextMeshProUGUI BulletPerSec;

        [SerializeField] TextMeshProUGUI DamageAmount;
        [SerializeField] TextMeshProUGUI BulletDamage;

        float Speed;
        float SetSpeedAmount;
        int BPSamount;

        float Damage;
        float SetBulletDamageAmt;
        int DPamount;

        bool IsSpeed;
        bool IsDamage = true;

        float UppesDowns = 12;

        void Start()
        {
            SetBulletPerSecBtn();
            SetBulletPerSecSpeed();

            setBulletDamageBtn();
            setBulletDamgeAmt();

            Config();
            SetSizeOfPanel();
            SetDefualtUI();
        }

        void Config()
        {
            Sbutton_control = transform.Find("bps/bps_bg").GetComponent<RectTransform>();
            Sbutton_down = transform.Find("bps/bps_bg/bps_down").GetComponent<RectTransform>();

            PButton_control = transform.Find("bPower/bPower_bg").GetComponent<RectTransform>();
            PButton_down = transform.Find("bPower/bPower_bg/bPower_down").GetComponent<RectTransform>();

            boundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));

            transform.Find("bps_btn").GetComponent<Button>().onClick.AddListener(speed);          // BULLET PER SECOND
            transform.Find("bPower_btn").GetComponent<Button>().onClick.AddListener(power);  // DAMAGE

            SButton = transform.Find("bps_btn").GetComponent<RectTransform>();                         // BULLET PER SECOND
            PButton = transform.Find("bPower_btn").GetComponent<RectTransform>();                     // DAMAGE PER BULLET
        }

        void SetDefualtUI()
        {
            PButton_control.DOMoveX(-Screen.width / 2, 0);
            Sbutton_control.DOMoveX(Screen.width / 2, 0);

            SButton.DOMoveY(Screen.height / 6.4f, 0);
            PButton.DOMoveY(Screen.height / 6.4f, 0);

            SButton.DOMoveX(Screen.width / 6f, 0);
            PButton.DOMoveX(Screen.width / 6f + Screen.width / 5.2f, 0);
        }

        public void speed()
        {
            if (IsSpeed == true)                                                // default one false reset are true
            {
                Sbutton_control.DOMoveX(-Screen.width / 2, 0);
                Sbutton_control.DOMoveX(Screen.width / 2, 0.8f);
                PButton_control.DOMoveX(Screen.width * 1.5f, 0.8f).OnComplete(() => PButton_control.DOMoveX(-Screen.width / 2, 0));
                IsSpeed = false;
                IsDamage = true;
                SButton.DOAnchorPosY(PButton.anchoredPosition.y + UppesDowns, 0.25f);
                PButton.DOAnchorPosY(PButton.anchoredPosition.y - UppesDowns, 0.25f);
            }

        }

        public void power()
        {
            if (IsDamage == true)
            {
                PButton_control.DOMoveX(-Screen.width / 2, 0);
                PButton_control.DOMoveX(Screen.width / 2, 0.8f);
                Sbutton_control.DOMoveX(Screen.width * 1.5f, 0.8f).OnComplete(() => Sbutton_control.DOMoveX(-Screen.width / 2, 0));
                IsDamage = false;
                IsSpeed = true;
                PButton.DOAnchorPosY(PButton.anchoredPosition.y + UppesDowns, 0.25f);
                SButton.DOAnchorPosY(PButton.anchoredPosition.y - UppesDowns, 0.25f);
            }

        }

        void SetSizeOfPanel()
        {
            var limit = (boundaries.x / 3) + (boundaries.x / 45);

            Sbutton_down.DOScaleX(limit, 0);

            PButton_down.DOScaleX(limit, 0);
        }


        public void BPS()
        {
            SetBulletPerSecBtn();

            if (BPSamount <= GameManager.instances.GetCoins())
            {
                GameManager.instances.SetCoins(GameManager.instances.GetCoins() - BPSamount);
                GameManager.instances.SetBulletSpeed(GameManager.instances.GetBulletSpeed() + 2f);
                SetBulletPerSecSpeed();
                SetBulletPerSecBtn();
            }
        }

        void SetBulletPerSecBtn()
        {
            Speed = GameManager.instances.GetBulletSpeed();

            for (float i = 1; i <= Speed; i++)
            {
                SetSpeedAmount = (Speed * 5f * i);
                SpeedAmount.text = SetSpeedAmount.ToString();                      // set Amount to next BPS speed 
            }
            BPSamount = (int)SetSpeedAmount;
            BPS_Button.GetComponent<RectTransform>().DOSizeDelta(new Vector2(170 + BPSamount.ToString().Length * 30, 145), 0);
        }

        void SetBulletPerSecSpeed()
        {
            BulletPerSec.text = (GameManager.instances.GetBulletSpeed()).ToString() + " BPS";
        }


        public void DP()
        {
            setBulletDamageBtn();

            if (DPamount <= GameManager.instances.GetCoins())
            {
                GameManager.instances.SetCoins(GameManager.instances.GetCoins() - DPamount);
                GameManager.instances.SetDamageAmt(GameManager.instances.GetDamageAmt() + 1f);
                setBulletDamgeAmt();
                setBulletDamageBtn();
            }
        }

        void setBulletDamageBtn()
        {
            Damage = GameManager.instances.GetDamageAmt();

            for (float i = 1; i <= Damage; i++)
            {
                SetBulletDamageAmt = (Damage * 8f * i);
                DamageAmount.text = SetBulletDamageAmt.ToString();                      // set Amount to next DAMAGE AMOUNT 
            }
            DPamount = (int)SetBulletDamageAmt;
            BP_Button.GetComponent<RectTransform>().DOSizeDelta(new Vector2(170 + DPamount.ToString().Length * 30, 145), 0);
        }

        void setBulletDamgeAmt()
        {
            BulletDamage.text = (GameManager.instances.GetDamageAmt()).ToString() + "00 %";
        }



        void Update()
        {
            if (GameManager.instances.GetCoins() == 0)
            {
                gameObject.SetActive(false);
                return;
            }

            if (!GameManager.instances.getplayerAlive())
                return;

            this.GetComponent<RectTransform>().DOAnchorPosY(-Screen.height / 2, 0.5f);
        }

    }
}