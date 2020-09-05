using UnityEngine;

namespace BallBlast.Play.input
{
    public class PlayerController : MonoBehaviour
    {
        Animator anim;

        [HideInInspector] public Vector3 MouseVector;
        [HideInInspector] public bool Fire1;
        [HideInInspector] public bool FireUp;

        void Update()
        {
            MouseVector = Input.mousePosition;
            Fire1 = Input.GetMouseButton(0);
            FireUp = Input.GetMouseButtonUp(0);
        }
    }
}