using System;
using UnityEngine;
using BallBlast.Comman.Game;
using BallBlast.Play.input;

namespace BallBlast.Play.Controller
{

    [RequireComponent(typeof(BoxCollider2D))]
    public class Player : MonoBehaviour
    {
        PlayerController playerController;
        Rigidbody2D rd;

        public float speed = 0.1f;
        public float slerp = 1f;
        private float objectWidth;

        Vector3 TouchPosition;
        Vector3 position;
        Vector2 ScreenBounds;

        Transform[] wheels;
        void Start()
        {
            GameManager.instances.LocalPlayer = this;
            playerController = GameManager.instances.playerController;
            rd = GetComponent<Rigidbody2D>();
            wheels = transform.Find("Mesh/Wheels").GetComponentsInChildren<Transform>();
            objectWidth = transform.Find("Mesh/Body").GetComponent<SpriteRenderer>().bounds.size.x / 2;
            ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        }

        void Update()
        {

            if (!GameManager.instances.getplayerAlive())
                return;

            if (!playerController.Fire1)
                return;

            PlayerMovement();
        }



        void PlayerMovement()
        {
            TouchPosition = playerController.MouseVector;
            TouchPosition = Camera.main.ScreenToWorldPoint(TouchPosition);
            position = Vector3.Lerp(transform.position, TouchPosition, speed);
        }

        void LateUpdate()
        {
            if (!GameManager.instances.getplayerAlive())
                return;

            decimal pp = Decimal.Round((decimal)transform.position.x, 2);
            decimal cp = Decimal.Round((decimal)position.x, 2);

            if (pp != cp)
            {
                position.x = Mathf.Clamp(position.x, -ScreenBounds.x + objectWidth, ScreenBounds.x - objectWidth);
                rd.MovePosition(position);
                MovementDirection();
            }
        }


        public void MovementDirection()
        {
            if (transform.position.x > position.x)
            {
                WheelsMovement(1f);
            }
            else if (transform.position.x < position.x)
            {
                WheelsMovement(-1f);
            }
        }

        void WheelsMovement(float direction)
        {
            for (int i = 1; i < wheels.Length; i++)
            {
                wheels[i].transform.rotation = Quaternion.Slerp(wheels[i].transform.rotation, wheels[i].transform.rotation * Quaternion.Euler(0, 0, direction * 6), slerp);
            }
        }
    }
}